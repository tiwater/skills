# Project UX documentation

For substantial product-wide reviews, maintain a review workspace in `docs/ux` unless the project already has an equivalent authoritative location. Inspect existing documentation first. Link to strategy, requirements, architecture and design-system sources rather than copying them. This workspace supports decisions and continuing review; it must not become a second invented product specification.

## Small, connected document set

Start only files with substantive content; combine sections for a small product. Suggested organization:

| Document | Purpose |
| --- | --- |
| `README.md` | Scope, review date/revision, navigation, readiness summary, important open decisions and coverage gaps. |
| `vision.md` | Concise sourced interpretation of users, needs, value, success and boundaries; link to canonical strategy. Mark unresolved assumptions and disagreements. Omit this file when a link to existing material suffices. |
| `blueprint.md` | Roles, objects, capabilities, journeys and dependencies; intended/current gaps; links to implementation and decisions. |
| `coverage.md` | Task and surface coverage, roles/states/viewports inspected, evidence and explicit unverified branches. |
| `findings.md` | Findings, systemic clusters, affected goals, evidence and verification criteria, linked to Beads; no duplicate live backlog. Split by domain only when size warrants it. |
| `decisions.md` | Accepted/rejected/deferred proposals with rationale, authority, date and consequences; link existing ADRs instead of duplicating them. |

Keep supporting visual evidence in an appropriate project location or reference accessible artifacts. Never copy secrets, personal records or private environment paths into a public repository. Redact screenshots and sensitive values; record access limitations without exposing the protected data.

## Traceability without bureaucracy

Assign stable references to goals, journeys and findings when cross-linking needs them; reuse existing project IDs. A finding needs:

`ID / bead reference | level | goal/journey | observation and trigger | evidence | impact/severity | proposed direction | dated decision | verification`

When Beads is available, keep current priority, assignee, status, dependencies and next action there. Markdown records the observation, rationale and dated verification, with a bead reference; do not maintain duplicate live owner/status tables or TODO lists. Distinguish proposed, accepted, implemented, verified, deferred and rejected dispositions in their dated evidence. Implemented is not verified. Close a bead only after its scoped acceptance evidence exists, or with an explicit duplicate/rejected/superseded reason; closure alone does not establish product readiness. Preserve a superseded finding's explanation when a structural decision makes the original fix unnecessary. Do not accumulate duplicate findings for the same cause without explaining their relationship.

For substantial sampling, record `journey | view/transition | role | starting state | content variety | viewport/input mode | evidence level | result | next gap`. Explain shared-implementation coverage and exclusions; do not mark an entire journey verified from a route visit.

Document statuses are not product state. Record source date/revision and tested environment so later readers can recognize stale evidence. When the implementation, vision or a dependency changes, reassess affected journeys and mark invalidated evidence; do not carry a historical pass forward automatically.

## Review sequence and maintenance

1. Reconcile authoritative intent and existing decisions; flag contradictions.
2. Draft or update the blueprint and identify gaps before detailed inspection.
3. Record the task-to-surface boundary comparison and role knowledge assumptions in the blueprint. Include proposed consolidation, separation, relocation or retirement and justified retention. Plan coverage from required outcomes, then walk the journeys and inspect surfaces.
4. Record evidence and findings as work proceeds; distinguish observed facts from hypotheses. Search existing beads before capturing actionable findings; record source/revision and acceptance criteria, and link each task to its evidence. Task creation preserves review-only scope.
5. Synthesize structural issues, visual assessment and readiness in the index. Link to Beads for current repair dependencies and execution status; keep dated reasoning in the review evidence. GitHub Issues are optional external discussion records, not an automatically mirrored backlog.
6. After authorized implementation, update verification and revisit connected outcomes.

Do not ask the user to approve every intermediate document. Ask only for a material missing decision that cannot be inferred; continue independent work. Never present an agent-authored target blueprint as approved intent. Keep project documentation in the project's language and format conventions.

For review-only requests, document findings without changing product behavior. If the user requests no file edits, present these records in the response instead. Local corrections should update existing affected records when useful, not generate a mandatory six-document dossier.

## Shared skill boundary

The shared skill contains methods, source-backed criteria and reusable reasoning. The project contains its vision, local policies, concrete findings and accepted design choices. Improve the shared method when a review reveals a transferable gap; do not turn a project's page order, dimensions, entities or latest complaint into global rules.
