---
name: pdf
description: Inspect PDFs and extract structured tables. Use when working with tabular PDF reports, multi-page tables, or malformed/scanned table extraction.
license: MIT
compatibility: Requires access to the shared PDF MCP server that exposes inspection and extraction tools.
metadata:
  mcp_servers:
    - pdf
---

# pdf

Use this skill to extract structured data from PDF files, especially tables.

## Workflow

1. Inspect the PDF to understand layout and page structure.
2. Extract all tables or find a named table.
3. Retry with more robust extraction only if the first pass is insufficient.

## Capabilities

- inspect page metadata and table layout
- extract all tables
- find a named table
- support multi-page table extraction

## Notes

This skill depends on shared MCP capability. It should not install or carry its own PDF executable implementation.
