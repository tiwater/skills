---
name: ux-design
description: Design, refine and implement user interfaces and user journeys, including landing pages, dashboards and documentation surfaces. Use when asked to create, redesign, improve or fix UI/UX, or implement accepted review findings. Preserve review-only requests; use ux-review for independent audits and critiques. Not for backend-only refactors or standalone brand artwork.
license: MIT
---

# UX design

Turn an authorized user goal into a coherent, implemented and verified interface. Use the existing product, accepted visual direction and real capabilities as constraints. Do not invent capabilities or replace user preferences with an imported aesthetic.

## Establish the design task

Identify the user, goal, affected surface, requested deliverable and change boundary from available context. A design-only request permits a design artifact, not product implementation or deployment. A request to fix the UI permits implementation; existing authorization persists. Ask only when a consequential missing decision cannot be inferred, and continue independent work.

Distinguish a local correction, refinement and redesign. For refinement, inspect the rendered baseline and name the strengths that must survive. For new work, derive a direction from product truth, local conventions and relevant mature references. Avoid requiring a formal product blueprint for a small change. A prior ux-review report is useful input, not a prerequisite or proof that its prescribed remedy is right. Revalidate old findings against current behavior.

Choose the surface's purpose: completing work (Operate), understanding content (Read), evaluating an offer (Persuade), or engaging with an artifact (Experience). These are lenses, not mutually exclusive templates; a page can contain regions with different jobs.

## Choose and implement a justified change

Read [craft-and-slop.md](references/craft-and-slop.md) for contextual design moves. For controls, navigation, forms and operational workflows, also read [interface-design.md](references/interface-design.md).

Before editing, connect the observed problem to a mechanism, a proposed change and its likely tradeoff. Preserve explicit user choices and necessary information. Reference pages demonstrate possible solutions; copy only compatible patterns within local requirements. Familiar layouts, gradients, cards and restrained screens are not defects merely because a style guide dislikes them. Standards, local rules, heuristics and taste have different authority.

When a visual defect repeats across routes or layout regions, first define a shared surface and hierarchy contract using the global consistency guidance in [interface-design.md](references/interface-design.md). Review its consumers before editing; do not repair a systemic mismatch with page-specific patches.

Use existing tokens and components. Fix the cause at the narrowest correct level; update connected help or consumers when a behavior or terminology change requires it. Keep product data, permissions, saved meaning and navigation contracts intact unless the task authorizes changing them. Do not hide necessary options merely to satisfy a button-count rule or simplify a screenshot.

For substantial work, record the direction and tradeoffs in the project's existing documentation. For local work, a short explanation and diff are enough. Follow the project's tracker, search for existing findings, and keep live status there; do not create a second Markdown backlog.

## Verify the result and stop

Use [verification.md](references/verification.md) to inspect the implemented route and affected journey. Evaluate function, rendered integrity and visual quality separately. Compare before and after at equivalent sizes, content, locale, theme and settled state; inspect transition behavior separately. A single attractive frame or clean build does not establish a working or better interface.

If a candidate fixes a defect but weakens an accepted focal point, information hierarchy or interaction, revise it. If an optional aesthetic experiment has no supported benefit, retain the accepted baseline rather than accumulating changes. Stop when the scoped outcome works, the intended gain is visible, no material regression is known in the affected path, and remaining uncertainty is explicit. Do not claim improved conversion or broad user preference without corresponding evidence.

Delivery states what changed, why, what was actually exercised and what remains unverified. Publishing or deployment follows user authorization, not the existence of this skill. A separate ux-review can provide independent critique when requested or required by the project; this skill remains usable without it.
