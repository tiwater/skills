# Design verification

Verify the actual implementation, not a mocked component or an imagined state. Builds and static checks are code hygiene. Use current-input interaction and independently inspect final artifacts for outcome evidence; follow any stricter project testing rules.

## Three separate judgments

- **Function:** walk the affected user goal, including meaningful failure, recovery, permission and persistence branches. Verify the durable result when the task writes data. Mark unavailable branches unverified.
- **Rendered integrity:** inspect the full route at wide, intermediate and narrow available widths; check actual component bounds, clipping, fonts/assets, console failures, focus, keyboard access and relevant open states. Operate every changed safe control, including returning or dismissing it. Select states by the changed behavior, not an indiscriminate test matrix.
- **Visual quality:** compare the accepted baseline and candidate at equivalent content, locale, theme and state. Explain what gained emphasis or clarity and what lost it. Measure space where it explains a problem, but do not treat a preferred ratio or fewer DOM elements as aesthetic proof. Inspect full frames before crops.

For a persistent control cluster, record its available width, rows/height, control grouping and remaining work area; measure expanded states where composition changes. Avoid inventing a universal one-row layout. For a small label edit, inspect wrapping and related states without requiring this larger ledger.

A useful evidence note is: surface/revision, user goal, viewport and component width, state/action, observed outcome, screenshot or artifact, limitation. Reuse project evidence conventions; never put secrets or private records in public documentation.

For shared surface-system changes, verify representative consumers together: shell/header joins, split panes, selected content and overlays in relevant themes and widths. Inspect continuous canvas and intentional surface boundaries in full-frame screenshots; neither rounded cards nor matching token values alone prove coherent composition.

## Accessibility and local conventions

Apply criteria with their scope and exceptions. Inspect text and applicable non-text contrast, focus, keyboard access, reflow, meaningful semantics, target sizes and reduced-motion support. Do not call a bounded inspection a complete accessibility audit. Local component and design-system rules remain binding even where a generic alternative could work.

Sources: [WCAG 2.2](https://www.w3.org/TR/WCAG22/), [WAI-ARIA patterns](https://www.w3.org/WAI/ARIA/apg/patterns/), and [NN/g visual design principles](https://www.nngroup.com/articles/principles-visual-design/). These establish criteria, not a finding about a particular page.

## Decision after verification

Keep a correction when its scoped outcome is demonstrated and the affected journey remains coherent. Revise a regression. Leave an uncertain optional style experiment out of the delivered product. Record uncovered consequential behavior instead of silently calling it a pass. Do not continue polishing unrelated areas to make the change seem more substantial.
