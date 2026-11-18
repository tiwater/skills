# Interface design and implementation

Use this reference primarily for **Operate** (dashboards, editors, tables, settings, admin tools) and **Read** (documentation, guides, references) surfaces that people use repeatedly to get work done or understand a system. Optimize for clarity, earned familiarity, spatial stability, speed, and trust before visual novelty.

For **Persuade** (landing pages, launches, pricing) and **Experience** (interactive showcases, live demos) surfaces — as well as the contextual craft guidance, anti-slop diagnostic rules, and design steering moves (`distill`, `bolder`, `quieter`, `layout`, `typeset`, `colorize`, `animate`, `clarify`, `harden`, `adapt`, `polish`) across all surfaces — read [craft-and-slop.md](craft-and-slop.md) alongside this file. For operational screens, keep marketing decoration out of workflow areas; for persuasive landing screens, do not flatten narrative proof into timid operational card grids.

## Operating Contract

Before changing UI, identify which layer the user asked about:

- **Visual:** spacing, hierarchy, alignment, density, color, icon, typography.
- **Interaction:** hover, focus, active, disabled, keyboard, touch, drag, menu, dialog.
- **Content:** labels, empty-state copy, timestamps, badges, counters, summaries.
- **Behavior:** sorting, filtering, grouping, persistence, navigation, polling, mutation.
- **Data/API:** schema, request timing, cache, loading, errors, optimistic updates.

For a local correction, do not cross layers without evidence. A full product review may challenge all these layers, but implementation remains limited to authorized changes. A visual request does not imply behavior, data, grouping, persistence, or navigation changes.

For scoped implementation, identify and preserve relevant invariants: information order, keyboard path, loading behavior, compatibility, user data and local design-system conventions. During structural review, assess whether current patterns serve the approved blueprint; existing implementation is not itself a requirement. Explain necessary changes and their consequences before editing within authorization.

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
   Icon buttons need accessible names and recognizable icons. Disabled controls should explain why when practical. A control that looks clickable must do something. Use confirmation or recovery proportionate to the actual consequence; reversible low-risk actions need not require interruption.

6. **Responsiveness preserves the job, not the desktop layout.**
   On narrow screens, keep the most important content and actions in one coherent flow. Collapse secondary metadata, menus, and panes before creating two-row headers, clipped text, or overlapping controls.

7. **Accessibility is part of layout quality.**
   Verify keyboard focus, visible focus indicators, semantic names, sufficient contrast, non-color-only status, reduced motion where relevant, and pointer targets. WCAG 2.2 AA target size is at least 24 by 24 CSS pixels unless an allowed exception applies.

8. **Reuse the visual system; verify the conceptual language.**
   Reuse local tokens, components, icon families, radius, density, and state patterns. Existing internal names and page boundaries are not protected conventions: validate them against user tasks and role knowledge. Introduce new visual patterns only when the existing system cannot express the needed behavior cleanly.

## Global Surface and Hierarchy Contract

For a repeated visual problem or an authorized global redesign, inspect the application shell and representative populated routes before changing individual screens. Inventory which backgrounds, borders, radii and elevations come from semantic tokens, shared components, layout wrappers and local overrides. Define the intended roles and their relationships in the project's existing design record before implementation; an existing CSS declaration is not a design rationale.

Use a small, explicit surface vocabulary appropriate to the product:

- **Canvas:** the continuous working background. Headers, split panes and scroll regions belonging to the same workspace normally inherit it or stay transparent. A layout column alone does not justify a different color.
- **Navigation chrome:** a persistent navigation region may have a distinct surface when that distinction supports orientation. Do not reuse a sidebar color for every auxiliary content pane merely because it sits at an edge.
- **Content surface:** bounded objects, editors or framed tools may have their own fill, inset, border and radius. Ordinary headings and sections can rely on spacing and typography. Avoid nested cards that add no meaningful grouping.
- **Interaction state:** selection, hover and focus belong to the affected control or object. Their fills should not accidentally repaint the surrounding layout; preserve distinguishable semantic statuses.
- **Overlay:** menus, dialogs and sheets have deliberate separation and elevation. An inline pane is not an overlay and should not inherit its treatment by accident.

Assign each visible surface a role, then use shared semantic tokens and components to express it consistently. Preserve the product's brand and accepted theme; a reference product can inform geometry or interaction without donating its palette. These roles do not require new token names when existing tokens already express them.

Inspect boundaries, not just isolated cards. Differently colored, edge-to-edge columns meeting a header can create hard rectangular bands and T-junctions even when every card is rounded. First decide whether those regions should share a canvas. Adding corner radii to each column does not resolve an incorrect surface hierarchy. Use spacing or a restrained divider for peer panes; if an independent surface is justified, give its boundary, inset, radius and scrolling behavior one coherent treatment. Square edges are not inherently defects when they express an intentional structural boundary.

Implement at the owning layer: tokens for semantic colors, shared shell or pane components for workspace relationships, and object components for local states. Remove superseded declarations and conflicting overrides rather than appending another cascade layer. Apply the contract across affected consumers as one cohesive change; preserve resizing, scrolling, navigation, drafts and primary work context. Do not delete useful panels or controls merely to simplify the composition.

Verify the whole composition across representative populated routes, relevant themes, wide and narrow layouts, and open/closed auxiliary panes. Check header-to-body joins, pane-to-pane joins, scroll edges, selected rows and overlay boundaries. Computed styles help locate the cause; actual rendered frames and interactions establish whether the system works. Record remaining exceptions and their concrete rationale rather than declaring global consistency from one attractive screen.

## Component Guidance

### Sidebars, Lists, and Rows

- Keep title, timestamp, badges, counters, and actions in predictable slots.
- Default rows should optimize scanning; hover rows may reveal actions without moving primary content.
- Allocate space for conditional actions deliberately so their appearance does not displace primary content; choose persistent or revealed actions according to task frequency and input mode.
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

- Menus should be anchored to the triggering control and make their object, selection or global scope clear.
- Ensure overlays escape clipping ancestors: an absolutely positioned menu, tooltip, or popover inside `overflow: hidden` or `overflow: auto` gets cut off; use portals, `<dialog>`, Popover primitives, or fixed positioning.
- Exhaust inline or progressive disclosure before reaching for a modal; reserve dialogs for tasks requiring interruption, protected focus, or explicit consequence confirmation.
- Dialogs should make consequence, target object, and escape path clear.
- Avoid overlays that obscure the title, current focus, or active work area.
- Do not use native browser alert/confirm/prompt in projects that have a dialog system.

### Resilience, Internationalization, and Adaptation

- **Flex and grid overflow safety:** set `min-width: 0` (and `min-height: 0` where needed) on flex and grid children so long tokens, URLs, filenames, or localized strings truncate or wrap cleanly instead of blowing out layout tracks.
- **Localization and script resilience:** test actual supported translations rather than relying on a fixed expansion percentage or narrow button/column widths; use logical CSS properties (`margin-inline`, `padding-inline`, `border-inline-start`) where bidirectional layouts apply; test mixed scripts (such as CJK paired with Latin/numerals) and `Intl` number/date formatting.
- **Typography and motion restraint in Operate surfaces:** use the established type hierarchy and short, interruptible transitions; avoid motion that delays access to repeated tasks.
- **Input method and gesture resilience:** separate `@media (hover: hover)` from coarse touch devices (`pointer: coarse`); never gate essential actions behind hover alone; clear custom drag/slider states cleanly on `pointercancel`, `lostpointercapture`, and window `blur`.

## Implementation Workflow

1. Confirm the affected task, scope and conceptual home against the blueprint; do not preserve an unjustified page boundary by default. Inspect the local implementation and at least one adjacent similar component.
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
- The diff preserves required capabilities and exposes real failures; any intentional retirement follows the approved decision and compatibility plan.
- Browser verification uses the real app entrypoint and route, not only an isolated component.

## Common Failure Modes

- Treating a screenshot as a broad product spec.
- Deleting required behavior or data merely to fix visual discomfort, without a product-level rationale and authorization.
- Letting conditional controls destabilize the layout or consume unjustified space.
- Moving metadata inconsistently or obscuring required information to make room for actions.
- Adding explanatory text where a clear label, icon, or state would be better.
- Creating cards inside cards, oversized headers inside compact panels, or marketing visuals inside workflow screens.
- Making mobile layouts by stacking everything instead of prioritizing content and actions.
- Claiming a UI fix is complete without checking the actual route and interaction state.

## Applying the guidance

These are contextual design defaults, not universal bans on cards, wrapping or different compositions. Justify exceptions by the user task, content and product constraints. Use [verification.md](verification.md) for implementation evidence and visual coverage. Avoid introducing a mandatory external design tool or a separate skill invocation to complete this workflow.
