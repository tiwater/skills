# OpenXML Rules

## Preserve semantics first

- Keep `w:pStyle` and `w:rStyle` when removing direct formatting.
- Preserve `w:numPr` and `w:sectPr` unless the user asked to rebuild lists or sections.
- Do not delete comments, footnotes, endnotes, bookmarks, or revision markup unless requested.

## Element-order reminders

- `w:p`: `w:pPr` must come before runs.
- `w:r`: `w:rPr` must come before text and breaks.
- `w:tc`: `w:tcPr` must come before paragraph content.
- `w:body`: `w:sectPr` is the final child.

## Units

- Font size uses half-points: 12pt => `24`.
- Many page and spacing measurements use DXA: 1 inch = 1440.

## Practical rule

If a change touches more than style IDs or direct formatting cleanup, inspect the relevant OpenXML part first and prefer a targeted C# change over search-and-replace in XML.
