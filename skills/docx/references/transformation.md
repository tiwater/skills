# Transformation

This skill focuses on format transformation more than document authoring.

## Safe defaults

- Preserve document text and block order.
- Avoid rebuilding sections or numbering unless required.
- Change style usage before changing raw XML geometry.
- Make one class of transformation at a time and inspect after each step.

## Common transformations

### Strip direct formatting

Use when the document visually ignores a template or style guide because paragraphs and runs carry inline overrides.

Expected result:

- paragraph style IDs remain
- numbering and section properties remain
- direct paragraph spacing/indentation/borders are reduced
- direct run formatting such as font/color/highlight is reduced

### Replace style IDs

Use when the source document uses nonstandard style names and you need to align them to a target style system.

Typical mappings:

- custom heading styles -> `Heading1`, `Heading2`, `Heading3`
- vendor body styles -> `Normal`
- ad hoc emphasis character styles -> approved character styles

## When to stop using built-in commands

Write a focused C# task in the bundled project when you need:

- header/footer migration
- section-level page layout changes
- numbering definition merges
- style definition import from another document
- template overlay with content preservation
