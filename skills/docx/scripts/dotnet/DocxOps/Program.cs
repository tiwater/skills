using System.Text.Json;
using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;

return await ProgramMain.RunAsync(args);

internal static class ProgramMain
{
    private sealed record HeadingInfo(string style, string text);

    public static async Task<int> RunAsync(string[] args)
    {
        if (args.Length == 0)
        {
            PrintUsage();
            return 1;
        }

        try
        {
            switch (args[0])
            {
                case "inspect":
                    return await RunInspectAsync(args[1..]);
                case "strip-direct-formatting":
                    return RunStripDirectFormatting(args[1..]);
                case "replace-style-ids":
                    return RunReplaceStyleIds(args[1..]);
                default:
                    Console.Error.WriteLine($"Unknown command: {args[0]}");
                    PrintUsage();
                    return 1;
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine(ex.Message);
            return 1;
        }
    }

    private static void PrintUsage()
    {
        Console.WriteLine("Usage:");
        Console.WriteLine("  inspect <input.docx> [--json]");
        Console.WriteLine("  strip-direct-formatting <input.docx> <output.docx>");
        Console.WriteLine("  replace-style-ids <input.docx> <output.docx> <style-map.json>");
    }

    private static Task<int> RunInspectAsync(string[] args)
    {
        if (args.Length < 1)
        {
            throw new InvalidOperationException("inspect requires <input.docx>");
        }

        var input = args[0];
        var json = args.Skip(1).Contains("--json");

        using var doc = WordprocessingDocument.Open(input, false);
        var body = doc.MainDocumentPart?.Document?.Body
            ?? throw new InvalidOperationException("Document body not found.");

        var paragraphs = body.Elements<Paragraph>().ToList();
        var tables = body.Descendants<Table>().Count();
        var sections = body.Descendants<SectionProperties>().Count();
        var headings = new List<HeadingInfo>();
        var paragraphStyles = new Dictionary<string, int>(StringComparer.Ordinal);
        var runStyles = new Dictionary<string, int>(StringComparer.Ordinal);

        foreach (var paragraph in paragraphs)
        {
            var text = paragraph.InnerText?.Trim() ?? string.Empty;
            var pStyle = paragraph.ParagraphProperties?.ParagraphStyleId?.Val?.Value;
            if (!string.IsNullOrWhiteSpace(pStyle))
            {
                paragraphStyles[pStyle] = paragraphStyles.GetValueOrDefault(pStyle) + 1;
                if (pStyle.StartsWith("Heading", StringComparison.OrdinalIgnoreCase) && !string.IsNullOrWhiteSpace(text))
                {
                    headings.Add(new HeadingInfo(pStyle, Clip(text, 120)));
                }
            }

            foreach (var runStyle in paragraph.Descendants<RunStyle>())
            {
                var value = runStyle.Val?.Value;
                if (!string.IsNullOrWhiteSpace(value))
                {
                    runStyles[value] = runStyles.GetValueOrDefault(value) + 1;
                }
            }
        }

        var placeholderMatches = paragraphs
            .Select(p => p.InnerText ?? string.Empty)
            .SelectMany(text => System.Text.RegularExpressions.Regex.Matches(text, @"\{\{[^{}]+\}\}|<<[^<>]+>>").Select(m => m.Value))
            .Distinct()
            .OrderBy(x => x)
            .ToList();

        var result = new
        {
            file = Path.GetFullPath(input),
            paragraphCount = paragraphs.Count,
            tableCount = tables,
            sectionCount = sections,
            commentCount = doc.MainDocumentPart?.WordprocessingCommentsPart?.Comments?.Elements<Comment>().Count() ?? 0,
            footnoteCount = doc.MainDocumentPart?.FootnotesPart?.Footnotes?.Elements<Footnote>().Count() ?? 0,
            endnoteCount = doc.MainDocumentPart?.EndnotesPart?.Endnotes?.Elements<Endnote>().Count() ?? 0,
            trackedChangeElements =
                body.Descendants<InsertedRun>().Count()
                + body.Descendants<DeletedRun>().Count()
                + body.Descendants<MoveFromRun>().Count()
                + body.Descendants<MoveToRun>().Count(),
            paragraphStylesInUse = paragraphStyles.OrderByDescending(kv => kv.Value).Take(20).Select(kv => new { style = kv.Key, count = kv.Value }),
            runStylesInUse = runStyles.OrderByDescending(kv => kv.Value).Take(20).Select(kv => new { style = kv.Key, count = kv.Value }),
            headings = headings.Take(25),
            placeholders = placeholderMatches.Take(50),
        };

        if (json)
        {
            Console.WriteLine(JsonSerializer.Serialize(result, new JsonSerializerOptions { WriteIndented = true }));
        }
        else
        {
            Console.WriteLine($"File: {Path.GetFullPath(input)}");
            Console.WriteLine($"Paragraphs: {result.paragraphCount}");
            Console.WriteLine($"Tables: {result.tableCount}");
            Console.WriteLine($"Sections: {result.sectionCount}");
            Console.WriteLine($"Comments: {result.commentCount}");
            Console.WriteLine($"Footnotes: {result.footnoteCount}");
            Console.WriteLine($"Endnotes: {result.endnoteCount}");
            Console.WriteLine($"Tracked change elements: {result.trackedChangeElements}");
            Console.WriteLine("Paragraph styles in use:");
            foreach (var item in result.paragraphStylesInUse)
            {
                Console.WriteLine($"  {item.style}: {item.count}");
            }

            Console.WriteLine("Headings:");
            foreach (var heading in result.headings)
            {
                Console.WriteLine($"  [{heading.style}] {heading.text}");
            }

            if (result.placeholders.Any())
            {
                Console.WriteLine("Placeholders:");
                foreach (var placeholder in result.placeholders)
                {
                    Console.WriteLine($"  {placeholder}");
                }
            }
        }

        return Task.FromResult(0);
    }

    private static int RunStripDirectFormatting(string[] args)
    {
        if (args.Length < 2)
        {
            throw new InvalidOperationException("strip-direct-formatting requires <input.docx> <output.docx>");
        }

        var input = Path.GetFullPath(args[0]);
        var output = Path.GetFullPath(args[1]);
        File.Copy(input, output, overwrite: true);

        using var doc = WordprocessingDocument.Open(output, true);
        var body = doc.MainDocumentPart?.Document?.Body
            ?? throw new InvalidOperationException("Document body not found.");

        foreach (var paragraph in body.Descendants<Paragraph>())
        {
            NormalizeParagraph(paragraph);
        }

        doc.MainDocumentPart!.Document.Save();
        Console.WriteLine(output);
        return 0;
    }

    private static int RunReplaceStyleIds(string[] args)
    {
        if (args.Length < 3)
        {
            throw new InvalidOperationException("replace-style-ids requires <input.docx> <output.docx> <style-map.json>");
        }

        var input = Path.GetFullPath(args[0]);
        var output = Path.GetFullPath(args[1]);
        var mapPath = Path.GetFullPath(args[2]);
        var styleMap = JsonSerializer.Deserialize<Dictionary<string, string>>(File.ReadAllText(mapPath))
            ?? throw new InvalidOperationException("Could not parse style map JSON.");

        File.Copy(input, output, overwrite: true);

        using var doc = WordprocessingDocument.Open(output, true);
        var body = doc.MainDocumentPart?.Document?.Body
            ?? throw new InvalidOperationException("Document body not found.");

        var changed = 0;
        foreach (var paragraph in body.Descendants<Paragraph>())
        {
            var pStyle = paragraph.ParagraphProperties?.ParagraphStyleId;
            if (pStyle?.Val?.Value is string currentParagraphStyle && styleMap.TryGetValue(currentParagraphStyle, out var newParagraphStyle))
            {
                pStyle.Val = newParagraphStyle;
                changed++;
            }

            foreach (var runStyle in paragraph.Descendants<RunStyle>())
            {
                if (runStyle.Val?.Value is string currentRunStyle && styleMap.TryGetValue(currentRunStyle, out var newRunStyle))
                {
                    runStyle.Val = newRunStyle;
                    changed++;
                }
            }
        }

        doc.MainDocumentPart!.Document.Save();
        Console.WriteLine($"Updated {changed} style references in {output}");
        return 0;
    }

    private static void NormalizeParagraph(Paragraph paragraph)
    {
        if (paragraph.ParagraphProperties is { } pPr)
        {
            var keep = new List<OpenXmlElement>();

            if (pPr.ParagraphStyleId is not null)
            {
                keep.Add((OpenXmlElement)pPr.ParagraphStyleId.CloneNode(true));
            }

            if (pPr.NumberingProperties is not null)
            {
                keep.Add((OpenXmlElement)pPr.NumberingProperties.CloneNode(true));
            }

            if (pPr.SectionProperties is not null)
            {
                keep.Add((OpenXmlElement)pPr.SectionProperties.CloneNode(true));
            }

            paragraph.ParagraphProperties = new ParagraphProperties();
            foreach (var item in keep)
            {
                paragraph.ParagraphProperties.Append(item);
            }
        }

        foreach (var run in paragraph.Descendants<Run>())
        {
            if (run.RunProperties is { } rPr)
            {
                var keep = new List<OpenXmlElement>();
                if (rPr.RunStyle is not null)
                {
                    keep.Add((OpenXmlElement)rPr.RunStyle.CloneNode(true));
                }

                run.RunProperties = keep.Count == 0 ? null : new RunProperties(keep);
            }
        }
    }

    private static string Clip(string text, int max)
        => text.Length <= max ? text : text[..max] + "...";
}
