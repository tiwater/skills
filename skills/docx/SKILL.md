---
name: docx
description: >
  Inspect and transform DOCX documents with OpenXML SDK (.NET), with emphasis on
  document content inspection, structure analysis, and safe format transformation.
  Use when the user wants to examine a .docx file, extract headings/styles/placeholders,
  detect tracked changes or comments, normalize direct formatting, remap style IDs,
  or prepare an existing Word document for template-based reformatting.
---

# docx

Use this skill for existing `.docx` files when the main work is:

- inspecting document text, headings, styles, tables, sections, comments, or revisions
- understanding why a Word file formats incorrectly
- transforming formatting without rewriting content
- preparing a document for later template application

Prefer OpenXML SDK for structural edits. Use the shell and Python helpers for quick preview and lightweight XML inspection.

## Setup

Run the environment check first to verify `pandoc` and `dotnet` availability:

```bash
bash {baseDir}/scripts/env_check.sh
```

The `tiwater-docx` global tool is required for OpenXML operations. If it is not installed, install it:
```bash
dotnet tool install -g tiwater.docx.cli
```

## Routing

### 1. Inspect

Start here whenever the document is unfamiliar.

```bash
bash {baseDir}/scripts/docx_preview.sh file.docx
python3 {baseDir}/scripts/docx_inspect.py file.docx
tiwater-docx inspect file.docx
```

Use the Python inspector for fast package-level facts. Use the `tiwater-docx` tool when you need paragraph/style/revision-aware results from the WordprocessingML model.

Read [references/inspection.md](references/inspection.md) before doing deeper analysis.

### 2. Transform

Use the OpenXML SDK tool for safe format transformations that preserve content:

```bash
tiwater-docx strip-direct-formatting in.docx out.docx
tiwater-docx replace-style-ids in.docx out.docx style-map.json
```

Typical sequence:

1. Preview and inspect.
2. Strip direct formatting if the document contains font/color/spacing contamination.
3. Remap paragraph and run style IDs to the target style system.
4. Re-inspect the output to confirm structure and style usage changed as intended.

Read [references/transformation.md](references/transformation.md) and [references/openxml_rules.md](references/openxml_rules.md) before modifying structure.

## Preferred workflow

For most requests:

1. Preview document text with `docx_preview.sh`.
2. Run `docx_inspect.py` for package-level signals.
3. Run `tiwater-docx inspect` for OpenXML-aware counts and heading/style summaries.
4. Apply the smallest transformation that solves the formatting problem.
5. Inspect the output again before delivering it.

## Commands

### Plain-text preview

```bash
bash {baseDir}/scripts/docx_preview.sh file.docx
```

### XML/package inspection

```bash
python3 {baseDir}/scripts/docx_inspect.py file.docx
python3 {baseDir}/scripts/docx_inspect.py file.docx --json
```

### OpenXML-aware inspection

```bash
tiwater-docx inspect file.docx
tiwater-docx inspect file.docx --json
```

### Compare documents

Check for structural and style usage differences between two versions of a document.

```bash
tiwater-docx compare old.docx new.docx
tiwater-docx compare old.docx new.docx --json
```

### Validate Template Transform

Validate compatibility of placeholders between a source formatting template and a target template.

```bash
tiwater-docx validate-template-transform source-template.docx target-template.docx
tiwater-docx validate-template-transform source-template.docx target-template.docx --json
```

### Remove direct formatting

Preserves style references and numbering/section semantics while removing most inline paragraph and run formatting overrides.

```bash
tiwater-docx strip-direct-formatting in.docx out.docx
```

### Remap style IDs

Use a JSON file shaped like:

```json
{
  "OldHeading1": "Heading1",
  "BodyText": "Normal"
}
```

Then run:

```bash
tiwater-docx replace-style-ids in.docx out.docx style-map.json
```

## Rules

- Prefer editing a copy, not the original input.
- Inspect before and after every transformation.
- Treat direct formatting as contamination unless the user explicitly wants it preserved.
- Preserve semantic constructs when possible: style IDs, numbering, tables, section breaks, comments, tracked changes.
- For advanced operations such as header/footer transfer, section rebuilds, numbering reconstruction, or template overlay, write a focused C# script on top of the included project instead of editing XML blindly.

## References

- [references/inspection.md](references/inspection.md): what to inspect and how to interpret the results
- [references/transformation.md](references/transformation.md): safe transformation patterns
- [references/openxml_rules.md](references/openxml_rules.md): element-order and preservation rules
