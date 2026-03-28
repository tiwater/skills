# Inspection

Use inspection to answer three questions before any transformation:

1. What content structures exist?
2. Which formatting system is actually in use?
3. What risks are present?

## What to check

- paragraph count, table count, section count
- heading paragraphs and the style IDs they use
- style IDs in active use, not just styles defined in `styles.xml`
- comments, footnotes, endnotes, tracked changes, and placeholders
- obvious contamination signs: many one-off run properties, mixed fonts, inconsistent paragraph spacing, manual formatting instead of styles

## Recommended sequence

1. `docx_preview.sh` for readable text.
2. `docx_inspect.py` for package-level facts such as parts, headings, placeholders, and comments.
3. `DocxOps inspect` for OpenXML-aware style and revision data.

## Signals and interpretation

- Many headings with custom style IDs: plan a style-ID remap.
- Heavy run-level formatting with few style IDs: strip direct formatting first.
- Placeholder tokens like `{{name}}`: content fill may still be pending.
- Tracked changes present: avoid transformations that flatten revisions unless explicitly requested.
- Comments present: preserve review artifacts during transformation.
