# Structure and language review

Use for whole-product or structural review; for local work apply it to the affected task and sibling surfaces. This is a required decision exercise, not a requirement to redesign every product.

## Derive the model independently of the menu

Start with authoritative intent and the intended actors. Describe what each actor wants to accomplish in their words, what object is affected, who owns it, what scope applies, and how completion is recognized. State assumed domain knowledge and unresolved product decisions. Do not use existing screen names as goals or infer a need from a database table, API endpoint or current component.

Then group related tasks by user purpose, object lifecycle, ownership and frequency. This is a proposed model, not approved product strategy. Compare it with the running product only after the task model is recorded. When existing UI has already been inspected, disclose that exposure and deliberately construct at least one plausible alternative grouping; do not pretend the exercise was blind.

## Challenge boundaries and relationships

For each group of related capabilities, record:

`user task | actor/knowledge | object and scope | proposed primary home | current entry points | boundary problem or justified separation | decision direction | evidence/verification`

Explicitly evaluate retain, combine, split, move and retire where relevant. Justify the chosen direction rather than prescribing fewer screens. Check:

- **Overlapping responsibility:** Can users predict which destination owns an action or authoritative saved value? Are two peers distinguished only by implementation vocabulary? Compare their contents and actions side by side.
- **Fragmented task:** Must the same user traverse unrelated destinations to finish one outcome, reconstruct context, or discover an undisclosed prerequisite? Is the handoff visible and scope preserved?
- **Mixed responsibility:** Does one surface combine unrelated users, scopes, lifecycle stages or confidential data? Would separating responsibilities reduce errors?
- **Unjustified surface:** If a page disappeared, which necessary user task would be lost? Could its useful function live naturally in another task without losing deep links, role boundaries or necessary expert access? An API may remain valid without its own page.
- **Missing ownership:** Does a necessary task have no discoverable home or actor responsible for completion?

Repeated information is not inherently duplication of responsibility. A balance beside checkout, a filtered drill-down, an expert workspace and a summary may all be useful views of the same object. Separate permissions, audiences, frequency or lifecycle can justify distinct destinations. Record such counterevidence. Do not require one screen per task or one URL per object.

Use goal prompts that omit destination names. Predict the first navigation choice using only user-visible labels and context; inspect actual discoverability. Expert prediction is a hypothesis, not a measured tree test. When the grouping remains ambiguous, propose focused tree testing/card sorting or user observation rather than presenting personal preference as fact.

Do not repair an unresolved structural issue solely with longer explanations. First decide whether the separation belongs. If a structural choice remains open, present alternatives and consequences before prescribing labels or padding.

## Apply a user knowledge boundary

For each consequential step record `what the user must know | why the role can reasonably know it | where the product explains or reveals it | what fails without it`.

Technical audiences can reasonably know domain concepts; they cannot be assumed to know this product's adapters, storage entities, internal state machines or implementation exceptions. Use recognizable choices and task consequences. Retain necessary technical precision in appropriate developer/expert contexts; explain new product concepts at their first decision point. Do not replace precise familiar domain language with vague euphemisms.

Inspect names, navigation, selectors, defaults, statuses, validation, errors, empty states, setup commands and help as one conceptual system. Ask whether the user can identify the target and scope, choose an action, anticipate its effect, recognize completion and recover without private coaching. An explanation in source code, a successful administrator workaround or prior reviewer familiarity does not count as user-facing evidence.

When a term is ambiguous, distinguish a wording defect from a missing product concept or ownership decision. A glossary cannot compensate for a workflow that exposes unnecessary implementation mechanisms.

## Evidence and acceptance

A structural finding needs the compared surfaces, actual task ambiguity/handoff, relevant intent, competing explanation, proposed direction and consequences for navigation/permissions/data/deep links. Separate observed overlap from inferred user confusion. Do not assert measured task failure without observing it.

Completion requires a boundary judgment for each major capability group and a knowledge-boundary check across core journeys, including groups retained unchanged. A long page inventory or successful happy paths cannot substitute. Keep unresolved decisions and inaccessible states explicit; old findings are leads, not proof that a new audit is complete.

## Sources and authority

- [NN/g usability heuristics](https://www.nngroup.com/articles/ten-usability-heuristics/), especially match with the real world, consistency and recognition rather than recall, support familiar language and predictable decisions.
- [NN/g mental models](https://www.nngroup.com/articles/mental-models/) explains the gap between designer knowledge and user expectations; it does not establish the mental model of a particular audience without evidence.
- [NN/g task scenarios](https://www.nngroup.com/articles/task-scenarios-usability-testing/) supports outcome-based prompts without revealing the solution.

The independent task model, boundary matrix and knowledge checks are this skill's operational adaptation of those principles, not published conformance requirements or evidence that all repeated content is bad.
