# Review convergence and learning from misses

Use for comprehensive review and iterative skill evaluation, not as overhead for a local UI correction.

## Coverage debt drives the next pass

Before another pass, select the highest-impact unresolved branch from the blueprint. For each core outcome distinguish **not visited**, **observed**, **operated**, **saved/revisited**, and **blocked by authorization/environment**. A page read cannot close an interaction or lifecycle branch. Keep functional, visual and role coverage separate. Before treating a branch as blocked, verify the specific missing access or state using an authorized, non-mutating check; a missing independent persona does not make every surface for that role inaccessible. Continue available source/contract inspection separately, without promoting it to executed role evidence. Complete feasible read-only work before ending; do not use an honest coverage appendix as a substitute for the requested review.

Before repeating a page pass, challenge the current and previously proposed information architecture using [structure-and-language.md](structure-and-language.md). A past blueprint can itself preserve the implementation bias. A new audit must not inherit an old completion claim.

Choose complementary passes: one follows the user from a realistic starting condition; another works backward from the required useful result to prerequisites and owners; a visual pass inspects rendered compositions with meaningful populated/error/overlay states. Repeating the same navigation with the same privileged data is weak evidence of convergence.

At each decision or handoff establish:

- What object and scope does the user believe they are acting on, and does the next surface preserve them?
- What is usable now, what is only configured, what remains uncertain, and who owns the next step? Distinguish transport completion, business completion, partial output and usable result; inspect terminal empty/partial branches rather than assuming a successful response means the user goal is fulfilled. Follow capability claims into their downstream action under missing, stale or failed metadata. Unknown capability must not silently become positive eligibility for a convenient default; preserve legitimate compatibility paths using evidence rather than names or UI familiarity.
- For collections, distinguish page length, filtered count, whole-collection total and data completeness. Inspect cursor/partial-result handling and a boundary beyond the ordinary sample; establish whether users can reach the remaining authorized records. A deliberate recent-items preview is valid when its scope and continuation are clear. [GOV.UK pagination guidance](https://design-system.service.gov.uk/components/pagination/) supports navigable continuation when splitting content improves the task, not mandatory pagination or loading every record at once.
- For rankings, recommendations and availability claims, what evidence, scope and time window support the label? Check empty-history and failed-data fallbacks: a useful default ordering must not silently acquire the authority of a measured ranking.
- Can the user locate the exact records behind an actionable warning or aggregate, distinguish the affected subset, and find a supported remedy? A generic history link may be insufficient.
- When a consequential concept has multiple entry points, compare its creation, editing, summary, downstream use and help. Sample a second producer/consumer even if the first looks correct. Check that units, defaults, scope, eligibility effects and explanations agree; do not assume shared backend behavior implies consistent composed UI. Expand only to variants with different behavior or implementation.
- At consequential selection, assignment or restoration, inspect the preview as its own decision surface. Does it identify the affected objects and relevant effects, or replace meaningful differences with a count? Resolve historical references without presenting current details as historical truth; make unavailable or changed configuration explicit. A compact summary is valid when the decision-relevant differences remain inspectable.
- For consequential multi-section editing, carry an unsaved change across navigation and compare the visible, pending and submitted scopes at the commit point. Can users inspect what will change and discard it? Check whether a section-local action silently saves hidden changes elsewhere, or whether navigation silently loses substantial work. Distinguish saved summaries from draft summaries. Atomic whole-object saves are valid when the editing boundary and pending changes are understandable; do not prescribe confirmation dialogs for harmless filters or every save.
- Include the help, examples, generated commands, notifications and external/support surfaces actually used by the task. Follow at least the task-critical handoff: compare names, scope, prerequisites and instructions with the running product. Separately shipped documentation may be stale even when application code is current. Do not equate reading repository requirements with checking customer-facing guidance.
- Does a completed local step produce a usable downstream result, or require an undisclosed activation, actor, external procedure or configuration? For materially different supported variants, follow the outcome into retrieval, reporting and reconciliation consumers. A consumer handling one subtype does not cover another with different units, lifecycle or ownership. Compare explicit inclusion/exclusion and empty-state meaning with the actual dataset; a purpose-specific view is valid when its scope and handoff are clear.
- For durable outcomes, leave the producing screen and test rediscovery from a realistic later starting point. Distinguish the source record, output reference, retained copy and reusable asset when the product does. Check ownership, availability, source context and supported lifecycle management. Existing persistence or a successful reopen does not by itself establish discoverability; conversely, an expired reference does not prove retained data loss. Apply this only to intended user outcomes, not as a demand that every product have an asset library.

These are probes, not mandatory UI features. A read-only report, deliberate one-time secret display or externally managed operation can be valid if its purpose, boundaries and handoff are clear.

## Diagnose misses before adding rules

For every newly confirmed finding compare the prior audit with evidence available **at that time**. Classify the miss:

| Cause | Appropriate change |
| --- | --- |
| Product changed after inspection | Version/revalidation correction; not a skill failure |
| Relevant surface/role/state never inspected | Coverage selection or continuation rule |
| DOM/source substituted for rendered inspection | Visual evidence requirement |
| Existing criterion was read but not applied | Concrete decision probe or completion gate, not another synonym of the principle |
| Rule would reject a legitimate design | Narrow applicability, add counterevidence and downgrade unsupported findings |
| Truly absent transferable criterion | Add the smallest source-supported criterion |
| Evidence unavailable under scope | Record a blocker; do not claim detection or clearance |

Keep the actual miss, reproduction and before/after evaluation in the project's review record. Shared guidance contains the mechanism, not product nouns, fixed layout values or remedies memorized from the incident.

## Visual sampling must represent risk

Select representatives by distinct composition, information density and implementation, not by the easiest page. An empty list cannot represent a populated management table; a short dialog cannot represent a long editor. Inspect ordinary desktop, intermediate available width, narrow layout and relevant open controls. Expand when an exception or different implementation appears.

For tables inspect the task's identity, decision information and action together. Horizontal scrolling is legitimate for comparison; establish whether important actions or row identity are hard to discover or associate, rather than treating any scroll as a defect. For themes inspect meaningful assets as well as text and controls; do not label decorative-logo visibility as a WCAG failure without checking applicability. Readable DOM labels do not prove visual recognition.

## Challenge the sampling plan

For a whole-product review, keep a compact sample register: `journey | view/transition | role | starting state | content variety | viewport/input mode | evidence level | result | next gap`. A route visited is not a completed sample. Record why one shared implementation represents others and inspect exceptions separately.

Supplement task-driven samples with independently selected views/states from the declared inventory, rather than choosing only places likely to confirm the latest rule. Record the selection method. If these expose a new content type, implementation family or failure mechanism, expand the structured sample and its connected process. Do not count rereading a known finding as a new holdout.

This adapts the structured/random sampling and complete-process approach of [W3C WCAG-EM 2.0, 23 July 2026](https://www.w3.org/TR/2026/NOTE-wcag-em-2-20260723/) to broader UX inspection. It is not a WCAG evaluation or conformance claim. Formal WCAG-EM use requires its own full methodology, including its specified random-sample size; a small UX spot check cannot substitute for it.

## Challenge and forward-test

After changing a rule, first revisit the missed case, then use the rule on an uninspected surface or different task without carrying over the expected remedy. Record both new findings and legitimate counterexamples. Reproduction of a known issue is regression evidence, not independent validation. Broaden transfer to another product/domain before presenting the skill as generally validated.

When evaluating severity, actively seek contrary evidence: an intended external setup contract, contextual help, existing successful handoff, role restriction, or changed implementation. Retain a narrowed finding if that is all the evidence supports. Do not manufacture issues to demonstrate iteration.

## Stop with a falsifiable boundary

An explicit request to continue until no further genuine issues are found calls for more than one pass. Continue while feasible material branches remain uninspected or new confirmed issues reveal untested related surfaces. For a stable, bounded scope, a practical saturation check is two complementary passes yielding no new confirmed material findings, after accounting for every core path and distinct visual family. This is an operational threshold, not a scientific guarantee or a mandated count for ordinary reviews.

State the scope, version, roles/states actually covered, excluded/blocked branches, passes performed and newly confirmed findings per pass. If access or allowed execution prevents further progress, report **bounded or blocked coverage**, not saturation. Existing unfixed issues remain issues even when discovery saturates. Never equate no new findings with no defects, a successful user study, accessibility conformance or release readiness.

## Basis

This procedure operationalizes [NN/g cognitive walkthroughs](https://www.nngroup.com/articles/cognitive-walkthroughs/), [heuristic evaluation](https://www.nngroup.com/articles/how-to-conduct-a-heuristic-evaluation/), and [usability heuristics](https://www.nngroup.com/articles/ten-usability-heuristics/). These support task-step evaluation, complementary inspection, meaningful status and recovery. The coverage ledger and saturation threshold above are explicitly this skill's evaluation procedure, not a requirement claimed from those sources. Use the source-specific criteria and exceptions in visual-review.md for visual/accessibility claims.
