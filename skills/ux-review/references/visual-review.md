# Visual and interaction review

Visual quality is an independent review dimension, not a synonym for functional correctness or accessibility. Apply it after establishing the relevant task and structural decisions; record details early without polishing a surface that may be retired.

## Evidence and coverage

Inspect actual mature-product references relevant to the task and equivalent host pages. Compare compatible states while preserving local tokens and components. Reference differences are not automatically defects. Never imply an unavailable reference was inspected.

Inventory page families such as navigation shells, overview/analytics, lists/search, details, editors, dialogs and specialized workspaces. Review distinct compositions and meaningful empty, populated, loading, error, selected and overlay states. Include realistic long text, dense data, large numbers and supported scripts. For rich-content surfaces, sample the supported structures that carry meaning: ordered/continued/nested lists, heading levels, quotations, code, data tables, links and formulas. Verify visible sequence, hierarchy, alignment and wrapping against semantic structure; a short paragraph cannot represent the renderer. Check copying/export separately when it is part of the task. Do not require decorative list markers in navigation or other compositions where they convey no task meaning. Sample shared implementations with reasons and expand when variants differ.

Record route, role, content state, viewport CSS dimensions, navigation state and source revision for screenshots. Compare wide, intermediate and narrow content areas, including expanded/collapsed navigation and applicable zoom. Separate screenshot pixels from CSS pixels. Side-by-side comparisons reveal system drift; normal-size inspection remains necessary.

Inspect a full-frame screenshot before cropping into controls. Trace all four edges, the content lane and persistent chrome for alignment, unused space, density, clipping and action reach. A page can avoid overflow and still be poorly composed.

For container queries, resizable panes and nested layouts, record the component's actual available width as well as the viewport width. Test relevant layout transitions on both sides of their thresholds; viewport dimensions alone do not establish how much room a component has.

Responsive evidence must combine layout widths with the states that change composition: for example, expanded inputs, open tool panels, long content and persistent navigation. A width-only sweep of the default state can miss clipping or wasted space revealed by an active mode. At each representative width, inspect the whole working area and its high-value mode states; compare how controls pack, wrap, align and consume task space. Confirm that available room is used intentionally and that a control changing modes produces a meaningfully distinct, understandable interaction. Do not count a component as responsive merely because it has no overflow or its default state fits.

## Independent whole-screen critique

For each sampled page family, do a dedicated composition pass after learning the task and before accepting a page as visually reviewed. Inspect an uncropped, settled screenshot at normal scale, then inspect its high-value interaction state. Write down the answers from visible evidence:

- What is the user's likely goal here, what object are they acting on, and what is the clearest next action? Can someone who knows the domain but not this product infer that without learning internal implementation terms?
- How much of the usable viewport is persistent navigation, headings, explanatory copy, repeated status, controls and actual task content? Do persistent elements earn their space through orientation, decision, action or recovery? Identify dead space, duplicate information and low-value chrome that competes with the work.
- Does the layout use its real content lane well? Measure outer gutters, content width, any max-width, persistent-bar height and unused area. A width constraint or large gap needs a task-based reason such as readable line length or a distinct pane, not merely a convenient default container.
- Do sibling pages and equivalent components share coherent alignment, insets, control sizes, typography and density? Compare them at the same viewport and navigation state; list visible drift rather than assuming shared CSS guarantees consistency.
- Is each prominent word, status and icon useful and unambiguous in context? Check the rendered icon and visible label against the control's actual effect. Remove neither information nor labels solely to make a screen shorter; establish redundancy or ambiguity first.

For persistent, high-frequency control surfaces (for example, an editor toolbar or message composer), record the available width, total height, row count and share of the working viewport. At widths where the controls plausibly fit together, inspect whether they can share a row without harming hierarchy, touch/keyboard access or comprehension. If they remain stacked, explain the task-based reason. Inspect the primary work surface with the controls expanded and realistic content present; a default collapsed screenshot cannot establish an efficient composition. Do not impose one-row layouts where the controls or content genuinely need more room.

Keep this critique separate from functional and rendered-integrity checks. A page is not a visual pass because it has no overflow, uses shared components, or passes automated measurements. Record each dimension as **observed pass**, **finding**, or **unverified**, with screenshot/route, viewport, relevant measurements and the evidence for the judgment. For a pass, state the concrete reason the composition works; for a finding, state the visible cause and task consequence before proposing a remedy. Avoid aesthetic scores and ungrounded claims about measured user preference.

When browser tooling is available, add a rendered-integrity pass to screenshot inspection: check the browser console and failed asset requests, and measure relevant element bounds against their clipping/scroll containers. Look for content outside the viewport, clipped or overlapping controls, unexpected wrapping, unreachable actions and large unused regions in the active content lane. Record the actual viewport and component widths. Automated checks can establish measurable faults, but cannot establish good hierarchy or composition; inspect the full screenshot at normal scale as well. If tooling or access is unavailable, mark those checks unverified instead of inferring a pass from source or a cropped image.

## Independent dimensions

| Dimension | Inspect |
| --- | --- |
| Hierarchy | Dominant task, heading levels, action emphasis, supporting information and destructive emphasis. |
| Grouping/composition | Relationships expressed by proximity, alignment, sections and layout; page/header/body continuity. |
| Typography | Role consistency, line length/height, wrapping, truncation, font rendering, numerical alignment and mixed scripts. |
| Density/spacing | Useful information per available working area; accumulated wrappers, both page gutters, field/group/section rhythm. |
| Color/state | Semantic consistency, actual contrast, focus, selected/disabled/error states, and meaning independent of color. |
| Affordance/icons | Recognizable actions, consistent symbol meaning and visual weight, discoverable keyboard/touch equivalents. |
| Tables/charts | Decision-relevant columns, accessible actions, units, time windows, axes, scales, legends, precision and missing-versus-zero data. |
| Responsive behavior | Preserved task order and access at intermediate widths, long content, navigation and open overlays; no reliance on phone-only screenshots. |
| Motion/feedback | Pending state, layout shifts, transition continuity and reduced-motion behavior where relevant; distinguish animation frames from settled defects. |

For each finding cite the criterion, visible discrepancy, task impact, confidence and a verification condition. Do not invent a universal padding number or treat no overflow as a pass. A table may legitimately scroll while the surrounding page must remain usable.

## Interaction and recovery

Walk discovery, input, pending, outcome, revisit and recovery. Preserve valid input on errors; locate problems at the relevant fields. Distinguish no data, no results, missing setup, unavailable service and lack of permission. Recovery actions must address the cause and suit the role. Ambiguous writes require reconciliation appropriate to consequences, not blind duplicate submission.

For dense action surfaces such as composers, toolbars and segmented controls, map each visible control to its actual effect and scope. Activate each safe control and compare the resulting states: identify duplicate outcomes, unexplained distinctions, misleading icon/label pairings, controls whose effect cannot be discovered, and actions displaced despite usable space. Judge the result from the user's visible context; internal state names do not explain a control. Repeat with realistic content and at the actual widths where controls wrap, collapse or move.

For a control cluster that mixes modes and actions, classify each affordance by what it does: selects a persistent mode, opens an accessory, changes an input method, inserts content, modifies a future action, or executes a command. Check whether the grouping and selected state match that behavior. A mode should produce a distinct, predictable working state; when two controls lead to the same state, identify a user-relevant distinction or question the duplication. For each mode, inspect what becomes available, what persists, and how to return without losing work. Do not infer an icon's meaning from its shape alone; compare its visible name or accessible name with its actual effect. At wide and narrow component widths, verify that controls pack or collapse according to their task priority without consuming avoidable work area or making a secondary action look like the primary input path. These are diagnostic checks, not a requirement to use tabs, icons, or any specific control pattern.

Inspect open menus/dialogs, long content, scrolling, focus movement, keyboard operation, dismissal and focus return. Installed primitives reduce risk but do not prove the composed behavior correct. Confirm durable outcomes separately from optimistic feedback when authorized to exercise writes.

## Sources and applicability

- [NN/g visual design principles](https://www.nngroup.com/articles/principles-visual-design/) supports hierarchy and perceptual grouping.
- [NN/g usability heuristics](https://www.nngroup.com/articles/ten-usability-heuristics/) supports consistency, meaningful language, feedback, control and error recovery.
- [Carbon spacing](https://www.carbondesignsystem.com/building-blocks/foundations/spacing/overview), [grid](https://www.carbondesignsystem.com/building-blocks/foundations/2x-grid/guidelines) and [data tables](https://www.carbondesignsystem.com/building-blocks/core/components/data-table/guidelines) inform systematic composition and readable data presentation; their numeric tokens are not a mandate to replace host tokens.
- [GOV.UK validation](https://design-system.service.gov.uk/patterns/validation/) and [error summaries](https://design-system.service.gov.uk/components/error-summary/) inform preserving progress and locating errors; adapt to form complexity and local controls.
- [WAI-ARIA dialog pattern](https://www.w3.org/WAI/ARIA/apg/patterns/dialog-modal/) informs modal focus, keyboard behavior and naming.
- [WCAG 2.2](https://www.w3.org/TR/WCAG22/) supplies measurable accessibility requirements. Check the actual criterion and exceptions before alleging conformance failures.

Selected WCAG checks: normal text contrast 4.5:1 and large text 3:1 (1.4.3); applicable non-text contrast 3:1 (1.4.11); reflow at 320 CSS px with defined exceptions (1.4.10); text resize to 200% (1.4.4); target size 24×24 CSS px or the criterion's exceptions (2.5.8); keyboard, focus and programmatic names/status (2.1.1, 2.4.7, 2.4.11, 4.1.2, 4.1.3). This selection is not a complete accessibility audit. Measure and operate rather than asserting from screenshots.

Published guidance, project requirements and reviewer hypotheses have different authority. Record exceptions and uncertainty. Use evidence-backed visual judgments without claiming objective aesthetic superiority or measured user benefit from inspection alone.

- [W3C WAI content structure](https://www.w3.org/WAI/tutorials/page-structure/content/) explains semantic lists and content relationships. [Tailwind Preflight](https://tailwindcss.com/docs/preflight#lists-are-unstyled) documents how framework resets remove visible list markers and heading styles. These motivate a rendered content-fidelity check; correct markup alone is not proof of visual meaning, and a reset alone is not proof of a defect.
- [Huashu Design](https://github.com/alchaincyf/huashu-design) is a useful workflow reference for inspecting rendered artifacts and separating objective integrity checks from subjective design judgment. Its artifact-generation workflow and style presets are not UX standards and are not requirements for this review method.
