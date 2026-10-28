---
name: ux-review
description: Review, design, and improve product UX from vision and product blueprint through user journeys, interactions, visual systems, and UI implementation. Use for whole-product audits, project UX documentation, workflow design, and actionable UI feedback. Preserve review-only scope; scale local changes to the affected task. Not for backend-only refactors or standalone brand artwork.
license: MIT
---

# UX review

Evaluate whether a product delivers its intended value before optimizing how its existing screens look. Existing features, pages and APIs are hypotheses to assess, not automatic requirements to preserve. Combine product review and UI design in this single entry point.

## Choose the scope and mode

- **Whole-product review:** follow the top-down method below and maintain the project's review record, normally in `docs/ux`. Read [product-review.md](references/product-review.md) and [documentation.md](references/documentation.md).
- **Journey or feature review:** trace the affected goal, dependencies and downstream outcome against the existing blueprint. Expand only where evidence shows a connected issue.
- **Design or implementation:** establish the relevant product and journey decisions, then use [interface-design.md](references/interface-design.md) and [visual-review.md](references/visual-review.md) to design, implement and verify within authorization.
- **Local UI correction:** inspect the affected component, neighboring surfaces and relevant states. Do not require a new vision document or product-wide audit for an isolated fix.

Review-only work does not authorize product changes. Maintaining review documents is appropriate when requested or included in a product-wide review, but respect instructions forbidding file edits. Proposed removal is not permission to delete features, routes, APIs or data. Preserve user decisions, repository rules, real data and compatibility until an authorized change addresses them.

## Challenge the product model before its screens

For whole-product and structural reviews, derive a task/ownership model from intended users and outcomes **before using the current navigation as the review plan**. Existing pages, API resources, component boundaries and past audit findings are evidence, not the target architecture. Read [structure-and-language.md](references/structure-and-language.md) and produce the boundary comparison it requires. A route inventory alone cannot pass this gate.

Review as an intended customer, not a teammate: explicitly separate reasonable role knowledge from product-internal knowledge learned from source, previous turns or administrator access. Source inspection may diagnose a failure but cannot repair missing information in the user's journey. Apply this distinction to navigation, input choices, status, errors, examples and help, not just labels.

## Review from the top down

1. **Vision and boundaries:** establish intended users, needs, value, success conditions and non-goals from authoritative project evidence. Mark assumptions; do not invent a vision to justify the current implementation.
2. **Value-delivery paths:** identify how each core user goal reaches a useful result, including prerequisites, roles, external dependencies and ongoing use.
3. **Product blueprint:** map capabilities, objects, ownership, information architecture, journeys, dependencies and role handoffs. Separate intended structure from current implementation and expose missing or unjustified parts.
4. **Capability and journey review:** assess whether each capability belongs, whether the system can fulfill the goal, and whether its dependencies and recovery paths are coherent. Recommend retaining, reshaping, combining, relocating or retiring capabilities when warranted.
5. **Page and interaction review:** inspect discovery, decisions, input, state feedback, navigation, persistence and recovery for each supported journey.
6. **Visual system and details:** assess composition, hierarchy, typography, density, responsive behavior and accessibility across page families; then inspect spacing, labels, icons and individual control states.

Record lower-level observations whenever encountered, but resolve structural uncertainty before specifying detailed redesigns that depend on it. An unresolved vision question does not prevent independent evidence gathering. Do not use a pixel-level defect list as a substitute for product readiness assessment.

## Coordinate review work with Beads

Prefer **Beads (`bd`) for actionable review findings and follow-up coordination** when available, following the repository's tracking rules. Read `bd prime`, search by the stable finding/reference before creating a task, and update or reopen an existing bead when the cause is already tracked. Capture the affected goal/trigger, impact, source revision, evidence limits and observable acceptance criteria. Use parent/related links for shared causes and blocking edges only for actual prerequisites. Claim work before implementation and leave verification pending until its evidence exists.

Beads owns current task status, priority, ownership, dependencies, blockers and handoff. Markdown owns durable intent, blueprint, review observations, decisions and dated verification evidence; cross-link it to beads rather than maintaining parallel TODO lists or live status tables. Historical dispositions are evidence, not a current backlog. Use GitHub Issues only when requested or justified by external/public discussion, and link them instead of automatically mirroring review tasks.

Task capture does not authorize product changes in review-only mode, nor external publication, delegation or changes to tracking infrastructure. If Beads is unavailable, preserve findings in the authorized review output and state the tracking limitation; do not silently create a second tracker or require installation before continuing independent review. See [documentation.md](references/documentation.md) for evidence and task boundaries.

## Evidence and traceability

Link `goal → journey → capability/surface → finding → decision → verification`. Distinguish confirmed intent, assumptions, observed behavior, expert judgment and hypotheses needing user research. Sources establish criteria; they do not prove that a particular interface fails them.

Use [product-review.md](references/product-review.md) for coverage and task walkthroughs. Use [visual-review.md](references/visual-review.md) for independent visual evidence and its required whole-screen critique. Follow relevant mature-product references and local design systems, but copy neither unsupported capabilities nor unrelated visual conventions.

## Design and implementation

In authorized implementation, fix causes and connected consumers rather than merely describing defects. Choose the smallest cohesive change that restores the intended outcome; structural problems may require structural changes. For local visual requests, preserve behavior and data semantics. For broader authorized redesigns, explicitly address affected compatibility, migration, permissions and dependent tasks.

Use existing components and tokens. Keep canonical values separate from display formatting. Verify the actual rendered route, open controls and relevant keyboard/responsive states. For a dense or persistent control cluster in scope, use the measured layout and interaction ledger in [visual-review.md](references/visual-review.md); a viewport sweep without component-width, row-allocation and control-effect evidence is not responsive acceptance. Exercise saved results and downstream use with authorized fixtures where needed. Review-only scope never permits writes merely to obtain evidence.

**Concrete-component review gate:** When the user names a component/control or supplies a screenshot, make that surface the center of the review. Do not stop at describing the screenshot or inspecting source: capture the uncropped rendered component, operate every safe in-scope control, and record each control's visible name, actual effect, resulting state, and return/dismiss path where applicable. Measure the component's own available width, occupied rows/height, and the work area left to the primary task; repeat in the expanded state and at widths where its composition changes. If a transition cannot be exercised, mark it unverified. Do not call the component reviewed until its interaction and composition evidence exists; do not broaden into unrelated product areas while this scoped review remains incomplete.

## Delivery and readiness

A complete review accounts for its agreed scope; it does not promise to discover every issue. Report:

- Core goals that work, fail, require assistance or remain unverified, by relevant role and starting condition.
- Vision/blueprint mismatches and systemic causes before local symptoms. Include explicit retain/combine/split/move/retire judgments for related surface groups, with evidence and legitimate reasons for separation; do not silently accept the current partition.
- Knowledge assumptions the interface requires, how users obtain that knowledge, and unresolved terminology or ownership ambiguities.
- Visual findings separately from functional completion.
- Decisions needed, proposed repair order and observable verification criteria.
- Coverage gaps and remaining assumptions.

Do not claim readiness while a core outcome has a serious known failure or an unverified critical transition. In implementation mode, verify repaired components upward through the journey and blueprint before marking findings verified. Do not equate issue closure, passing tests, attractive screenshots or a high page count with product usability.

Improve this skill using observed review outcomes and validate changes before publishing them within the user-authorized scope. Project-specific intent, findings, evidence and decisions belong in project documentation, not in universal skill rules. Publishing a version does not establish general effectiveness or exhaustive review coverage.

## Iterative review and stopping

For comprehensive audits or explicit skill refinement, read [review-convergence.md](references/review-convergence.md). Track uncovered branches and challenge earlier conclusions before reporting completion. A documented gap is not a reason to leave feasible, authorized inspection undone. Separate coverage completion, diagnostic saturation and product readiness; none implies the others.

## Calibrate and validate the method

Read [calibration.md](references/calibration.md) when evaluating or improving the skill. Check transfer to unfamiliar product domains and legitimate counterexamples. Structural validation alone does not demonstrate review quality. Validate with real scoped audits: establish the blueprint, identify unsupported core outcomes, trace findings to evidence, and assess whether the proposed repair sequence would restore those outcomes. Record missed issues and unsupported judgments separately, then improve their underlying method rather than adding incident-specific rules. Do not equate running the audit with proving its effectiveness.
