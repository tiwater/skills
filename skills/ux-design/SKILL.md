---
name: ux-design
description: Use when designing, reviewing, or modifying existing product UI: dashboards, sidebars, chat/editor surfaces, settings, forms, tables, dense SaaS tools, responsive layouts, interaction states, accessibility, screenshots, visual regressions, or UX polish in workflow-heavy applications.
license: MIT
---

# ux-design

Use this skill for product interfaces people use repeatedly to get work done. Optimize for clarity, stability, speed, and trust before visual novelty.

This is not a landing-page or brand-art skill. For operational screens, the best UI usually preserves user context, makes status legible, keeps controls predictable, and avoids surprising behavior changes.

## Operating Contract

Before changing UI, identify which layer the user asked about:

- **Visual:** spacing, hierarchy, alignment, density, color, icon, typography.
- **Interaction:** hover, focus, active, disabled, keyboard, touch, drag, menu, dialog.
- **Content:** labels, empty-state copy, timestamps, badges, counters, summaries.
- **Behavior:** sorting, filtering, grouping, persistence, navigation, polling, mutation.
- **Data/API:** schema, request timing, cache, loading, errors, optimistic updates.

Do not cross layers without evidence. A visual request does not imply behavior, data, grouping, persistence, or navigation changes.

Preserve explicit and implicit invariants: information order, row height, keyboard path, loading behavior, existing routes, user data, and local design-system conventions. If changing an invariant is necessary, state that before editing.

## Product UX Principles

1. **Status is always visible.**
   Loading, saving, disconnected, stale, empty, error, disabled, and success states must be represented in the UI. Avoid blank, frozen, or misleading default states.

2. **Layout must be stable.**
   Hover controls, badges, async content, validation messages, and responsive wrapping should not cause avoidable row-height changes, metadata drift, or content overlap. Preserve spatial memory.

3. **Hierarchy beats decoration.**
   The primary object should be easiest to scan. Metadata should be secondary but consistently placed. Actions should be close to the object they affect. Decorative cards, gradients, blobs, oversized type, and marketing composition are usually wrong for dense tools.

4. **Progressive disclosure reduces noise.**
   Show primary actions persistently when they are central to the workflow. Reveal secondary or destructive actions by hover, menu, disclosure, or detail view. Do not hide essential status behind hover.

5. **Controls must be honest.**
   Icon buttons need accessible names and recognizable icons. Disabled controls should explain why when practical. A control that looks clickable must do something. A destructive action needs a real confirmation pattern consistent with the app.

6. **Responsiveness preserves the job, not the desktop layout.**
   On narrow screens, keep the most important content and actions in one coherent flow. Collapse secondary metadata, menus, and panes before creating two-row headers, clipped text, or overlapping controls.

7. **Accessibility is part of layout quality.**
   Verify keyboard focus, visible focus indicators, semantic names, sufficient contrast, non-color-only status, reduced motion where relevant, and pointer targets. WCAG 2.2 AA target size is at least 24 by 24 CSS pixels unless an allowed exception applies.

8. **Existing product language wins.**
   Reuse local tokens, components, icon families, radius, density, and state patterns. Introduce new patterns only when the existing system cannot express the needed behavior cleanly.

## Component Guidance

### Sidebars, Lists, and Rows

- Keep title, timestamp, badges, counters, and actions in predictable slots.
- Default rows should optimize scanning; hover rows may reveal actions without moving primary content.
- Do not reserve empty space for rare hover actions unless the surrounding pattern already does.
- Hover-revealed controls must also be revealed by keyboard focus, usually with `focus-within`, so tabbing never lands on invisible buttons.
- Selection, hover, focus, unread, running, pinned, and error states must be visually distinguishable without breaking row density.

### Tables and Data Grids

- Preserve column alignment and row height under loading, empty, error, filtered, and long-content states.
- Keep sorting/filtering affordances near the labels they affect.
- Use truncation, wrapping, tooltips, or detail panels intentionally; do not let long tokens stretch the grid.
- Bulk actions should become available only when selection exists.

### Forms and Settings

- Group fields by user task, not implementation structure.
- Inline validation should identify the field, the problem, and the recovery path.
- Save, revert, dirty, disabled, and pending states must be clear.
- Avoid exposing config-file internals when the user needs a product-level summary or control.

### Dashboards and Detail Pages

- Put identity and current status first: name, state, owner/location/version, last activity.
- Follow with the metrics or controls that determine the next user decision.
- Cards are for comparable objects or framed tools, not for every section.
- Do not include destructive management surfaces for entities that are not user-deletable.

### Chat, Editors, and Agent Surfaces

- Keep the composer stable around keyboard, mobile viewport, permissions, attachments, and send controls.
- Message blocks should use full available width unless intentionally constrained for readability.
- Summaries of changed files/artifacts should expose the useful names before requiring expansion.
- Streaming, reconnecting, retrying, cancelled, and failed states should be visible near the affected message or thread.

### Menus, Dialogs, and Overlays

- Menus should be anchored to the triggering control and contain actions for that object only.
- Dialogs should make consequence, target object, and escape path clear.
- Avoid overlays that obscure the title, current focus, or active work area.
- Do not use native browser alert/confirm/prompt in projects that have a dialog system.

## Implementation Workflow

1. Inspect the local implementation and at least one adjacent similar component.
2. Name the exact UI block and states affected.
3. Write down the invariants that must not change.
4. Make the smallest cohesive diff using local components, tokens, and icon libraries.
5. Check the diff for accidental data, routing, grouping, persistence, or API changes.
6. Verify the actual route in a browser for the affected viewport and states when the change is visible.

If a screenshot is provided, treat it as evidence for the named UI problem, not permission to redesign surrounding areas.

## Verification Checklist

- Default, hover, focus, active, disabled, loading, empty, error, and narrow-screen states are covered as relevant.
- Text does not overlap, clip unexpectedly, or change container size in normal use.
- Interactive targets are keyboard reachable and have accessible names.
- Hover-only controls are visible while focused and do not create invisible tab stops.
- Async states do not show false empty content before loading completes.
- Visual hierarchy supports the next user decision.
- The diff does not remove features or hide real failures.
- Browser verification uses the real app entrypoint and route, not only an isolated component.

## Common Failure Modes

- Treating a screenshot as a broad product spec.
- Fixing visual discomfort by deleting behavior, data, or controls.
- Adding layout space for controls that only appear on hover.
- Moving timestamps, badges, or metadata to make room for actions.
- Adding explanatory text where a clear label, icon, or state would be better.
- Creating cards inside cards, oversized headers inside compact panels, or marketing visuals inside workflow screens.
- Making mobile layouts by stacking everything instead of prioritizing content and actions.
- Claiming a UI fix is complete without checking the actual route and interaction state.

## When To Use Other Skills

- Use a broad frontend-design skill for greenfield aesthetics, brand direction, marketing pages, or highly expressive visual concepts.
- Use design-system or Figma skills when there is a source design file or token library to follow.
- Use browser/playwright verification skills when the work affects visible behavior.
