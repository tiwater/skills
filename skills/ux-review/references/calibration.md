# Calibrating UX judgment

Use this document when revising the skill or testing whether a review generalizes beyond a familiar page. It calibrates the reasoning behind findings; `visual-review.md` supplies sourced criteria and rendered evidence methods. A past defect is evidence to investigate a failure mechanism, not a new universal product requirement.

## Separate the levels of authority

- **General principle:** describe the user outcome and the mechanism that helps or obstructs it. It must remain meaningful across different products, tasks and components.
- **External criterion:** identify the source, scope, version where relevant, and exceptions. Apply an accessibility requirement as specified; do not present a heuristic as a conformance rule. See the source mappings below and `visual-review.md`.
- **Local requirement:** attribute terminology, component choices, ordering conventions and business constraints to the current product or user. Keep these in project instructions rather than encoding them as global UX truth.
- **Design hypothesis:** identify a plausible improvement whose benefit has not been established. Explain what comparison or task observation would support it. Do not silently promote preference to a defect.

A mature reference demonstrates one solution under its own constraints. Reuse the underlying task pattern only after checking that the current product has compatible users, capabilities and constraints.

## Transferable decision criteria

| Principle and source mapping | What the reviewer must establish | Observable failure mechanism |
| --- | --- | --- |
| Organize around user tasks and ownership (information architecture, consistency) | Entry points, names and scope let the intended user predict where an action belongs and what it affects. | Users must understand storage structure or search unrelated sections to complete one task. |
| Put decision-relevant information at the decision (recognition, input relevance, data presentation) | Users can compare choices and understand units, defaults, consequences and prerequisites without reconstructing information from another screen. | An apparently reasonable selection produces an outcome the interface did not make foreseeable. |
| Make hierarchy reflect task importance (visual hierarchy, action hierarchy) | Emphasis, grouping and placement make the next useful action and its context apparent. Evaluate the whole active surface, not isolated controls. | Secondary information competes with the task, related information appears unrelated, or essential actions are visually subordinate. |
| Adapt to available space and content (systematic spacing, responsive composition, reflow) | Layout preserves reading order, meaningful grouping and access to actions as navigation, text length, zoom and viewport change. | A layout technically fits but wastes scarce width, obscures key information or becomes harder to scan. |
| Represent state accurately and support recovery (state distinctions, feedback, input preservation, error location) | Users can distinguish what happened, what remains uncertain, what input is retained and which next action can resolve the condition. | A state is mistaken for another, a retry cannot address the cause, or recovery requires starting over unnecessarily. |
| Preserve meaning across the journey (consistency; product data constraints) | Labels, scope, values and saved outcomes retain their meaning through creation, display, editing, navigation and reuse. | A local presentation improvement changes interpretation, breaks continuity or leaves another entry point inconsistent. |
| Match interaction cost to consequences (input relevance, interaction control; authorized task scope) | Required steps, interruptions and confirmations are justified by the user's task and actual consequences. | Users perform redundant work or face avoidable interruption; consequential choices lack the information needed to make them. |
| Ground claims in actual capabilities (consistency, state distinctions) | Controls, status labels and promises correspond to supported behavior and the user's permissions. | A visual affordance implies unavailable functionality, or an implementation limitation is exposed without a usable explanation. |

These criteria do not prescribe a particular menu order, number of buttons, breakpoint, page structure or input type. Such decisions require local evidence. Concrete external requirements still retain their actual thresholds and exceptions; generalization must not dilute them.

## Structural and knowledge calibration

Use the required comparison in [structure-and-language.md](structure-and-language.md). Include a product whose pages all work but divide one task by backend resources; the review must challenge that partition. Include a counterexample where shared information appears in distinct role-specific views; the review must not merge them merely to remove repetition. Include a technically experienced user who knows the domain but cannot infer the product's internal lifecycle. The review must identify the missing concept without treating all technical vocabulary as forbidden.

## Test transfer, not recollection

For each proposed rule or finding:

1. **Remove the original nouns.** State the user need, failure mechanism and affected outcome without naming the page, business entity or component. If the claim loses all meaning, it is probably a local instruction or example.
2. **Change the context.** Apply the reasoning to a materially different task or product. Identify what evidence would be needed there; do not assume the same remedy remains appropriate.
3. **Find a legitimate counterexample.** Ask when the observed pattern could be useful or necessary. State that boundary instead of turning the pattern into a blanket prohibition.
4. **Make the claim falsifiable.** Specify the observable condition that would establish or disprove the problem. A source citation alone does not show that this interface causes the claimed difficulty.
5. **Separate outcome from remedy.** Several designs may satisfy the same criterion. Justify the chosen remedy using current constraints, a relevant reference and rendered behavior, rather than the original incident.

For example, scrolling can preserve readable comparison in a large dataset. The review must establish which information or action becomes difficult to reach under the actual task; “scrolling exists” is insufficient evidence of a defect. This illustrates a reasoning boundary, not a preferred table implementation.

## Evidence and severity calibration

Record the observed state separately from inferred user impact and proposed remedy. Link each finding to the relevant criterion and describe how it could be checked. A rendered defect can be established directly; an efficiency or comprehension hypothesis may need task observation or comparison before its magnitude is known.

Prioritize by outcome, frequency, affected users, recovery cost and confidence. Do not inflate severity because a pattern differs from a reference, or dismiss visual hierarchy and spacing merely because controls function. Technical correctness, task usability and visual quality require distinct evidence.

A strong review can explain why a suspected issue is not a defect, narrow an overbroad claim, and mark an inaccessible state unverified. Evidence of a few passing screens does not establish product-wide quality.

## Maintaining the skill

When feedback exposes a gap, identify whether an existing principle was missed, evidence was inadequate, or a genuinely new decision criterion is needed. Improve that cause before adding instructions. Keep page names, exact dimensions and product-specific remedies in the project or review record. Retain examples here only when they clarify a boundary that the general criterion does not already explain.

Reject additions that merely memorialize the latest complaint. Accept additions that improve decisions in unrelated scenarios while preserving legitimate alternatives and explicit product constraints.


## Calibration of review completeness

Challenge a proposed audit with these transfer tests:

- Every existing page is polished, but a prerequisite has no discoverable owner or completion path. The review must identify the broken user outcome even though no component is malformed.
- A prepared administrator can complete a task, but its intended role starts without the required access or data. The review must avoid generalizing the administrator result.
- No screen overflows, yet hierarchy, text density and action placement vary across equivalent surfaces. The visual pass must produce evidence beyond an overflow check.
- Many local findings are fixed, but a downstream consumer still cannot use the saved result. Re-evaluate the journey rather than declaring success from the resolved issue count.
- A consequential branch cannot be exercised under review-only authorization. Keep it unverified and explain the evidence needed; neither mutate the product nor declare that branch successful.

These probes test coverage and reasoning. They do not require particular product features or authorize work outside the user's scope.

Also forward-test dense, persistent controls with this independent case: on a wide page, an editor's action cluster still wraps into several rows while substantial horizontal space remains; two neighboring mode icons both appear to enter an editable state. The review must measure the cluster's actual inner width and rendered control bounds, operate both safe modes, and establish whether the remaining space is usable and whether the resulting states differ in a user-relevant way. A narrow viewport or a deliberately separated group may justify wrapping; the audit must not prescribe one row without task evidence. Mark the visual pass failed or unverified until those observations exist. This probe checks execution of [visual-review.md](visual-review.md), not a new layout rule or a requirement to find a defect in every cluster.

For iterative audits, apply [review-convergence.md](review-convergence.md) to classify misses, forward-test changes and distinguish bounded saturation from product readiness.
