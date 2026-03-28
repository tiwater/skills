---
name: pdf
description: >
  Inspect PDF files and extract structured tables using the tiwater-pdf CLI. Use when you need
  to extract numerical or textual data tables from PDFs, handle multi-page spanned tables, or perform
  vision-based LLM fallback extraction for garbled/scanned pdf tables.
---

# pdf

Use this skill to extract structured data from PDF files, prioritizing tabular data parsing over raw text extraction.

## Setup

The `tiwater-pdf` tool must be installed in your python environment or globally via pip:
```bash
pip install tiwater-pdf
```

## Commands

### 1. Inspect

Retrieve metadata and page sizes from the PDF to roughly understand document length and dimensions.

```bash
tiwater-pdf inspect file.pdf
tiwater-pdf inspect file.pdf --json
```

### 2. Extract Tables

Extract structured tabular data from the PDF. The tool uses PyMuPDF under the hood.

```bash
tiwater-pdf extract-tables file.pdf
```

**Options:**
- `--pages 1,2,3`: Restrict extraction to specific pages (1-indexed).
- `--auto-span`: Intelligently merge tables that span across consecutive pages if they have matching column headers.
- `--llm-fallback`: Send images of garbled or malformed tables to an LLM Vision model to recover table data geometrically. *(Requires `OPENROUTER_API_KEY` in the environment)*.
- `--json`: Output full raw JSON data representing the extracted table arrays.

### 3. Find Table

Find and extract a specific table by doing a fuzzy text match against its preceding title or its column headers.

```bash
tiwater-pdf find-table file.pdf "Income Statement"
```

Accepts the same flags (`--auto-span`, `--llm-fallback`, and `--json`) as `extract-tables`.

## Rules & Best Practices

1. Use `--auto-span` natively when dealing with PDFs that paginate single large tables.
2. If the user complains that the extracted table cells are merged incorrectly or garbled, inform them you can retry extraction with `--llm-fallback`, but be aware it incurs API costs and takes more time to process.
