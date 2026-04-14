---
name: docx
description: Inspect and transform DOCX documents. Use when working with .docx files, headings, styles, placeholders, tracked changes, or template-safe formatting changes.
license: MIT
compatibility: Requires access to the shared Office MCP server that exposes DOCX inspection and transformation tools.
metadata:
  mcp_servers:
    - office
---

# docx

Use this skill for existing `.docx` files when the task is to inspect document structure, compare versions, export structured content, or apply format-preserving transformations.

## Workflow

1. Inspect the document with Office MCP DOCX tools.
2. Compare versions or export structured JSON when needed.
3. Apply the smallest transformation that solves the formatting problem.
4. Re-inspect the output before delivering it.

## Capabilities

- inspect document structure, headings, styles, comments, and tracked changes
- compare document package and style differences
- export structured JSON for downstream mapping
- strip direct formatting and remap style IDs
- fill templates from structured JSON

## Notes

This skill depends on shared MCP capability. It should not install or carry its own DOCX executable implementation.
