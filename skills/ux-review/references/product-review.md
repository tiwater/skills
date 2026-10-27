# Product review method

## Establish intent before judging implementation

Read existing product strategy, requirements, architecture and user decisions. Identify authoritative sources and contradictions. Summarize users, problems, promised value, non-goals and observable success. Do not treat a menu, schema or shipped endpoint as evidence that a capability is wanted. A stated vision may be too vague to settle a decision: record the unresolved question and continue independent inspection rather than silently resolving it by preference.

Assess necessity and product fit before usability. For each significant capability ask what goal it supports, which role owns it, why this product should provide it and what conceptual/operational cost it introduces. Internal supporting capabilities can be necessary without being directly visible to users. Lack of a UI is not a reason to remove an API. Distinguish accidental complexity, missing capability and legitimate external responsibility.

A recommendation may retain, redesign, consolidate, move or retire a capability. Record its rationale, alternatives, dependent consumers and confidence. Before implementing retirement inspect adoption, contracts, permissions, retained data, migration and rollback. An audit recommendation alone authorizes none of these changes.

## Structural review gate

Follow [structure-and-language.md](structure-and-language.md) before treating the route inventory as a coverage plan. Derive intended task groups, compare related surfaces and record a reasoned boundary decision for each major group. Test both redundant peers and fragmented tasks; also preserve justified specialist views. Carry the intended role's knowledge assumptions into every walkthrough.

## Build the blueprint

The blueprint describes how the intended value is delivered, not just how existing pages connect. Include:

- Actors and their knowledge, responsibilities and authority.
- Core objects, ownership, lifecycle and relationships.
- Capabilities mapped to user goals and appropriate product boundaries.
- Journeys from realistic starting conditions to durable, useful outcomes.
- Prerequisites, external services and handoffs between actors.
- Information architecture and entry points supporting those journeys.
- Relevant UI, API and operational implementations, with gaps and mismatches.

Use a diagram or tables when they clarify relationships. Maintain a small intended/current gap record rather than two drifting copies of the full blueprint. Do not mistake a desired blueprint for an approved implementation plan.

## Walk the goal, not the menu

Define scenarios as goals with context and outcomes, not click instructions that reveal the solution. Cover first value, routine use, finding past work, correction/recovery and lifecycle changes where relevant. Use the actual intended role and starting state; prepared administrator data cannot prove ordinary-user onboarding.

At consequential steps ask whether the user understands the needed next result, can find an action, can associate it with that result and can recognize progress. Use only knowledge available to that user. Direct URLs and source inspection can diagnose a gap but cannot establish discoverability. Inspect repeated effort and lost context for returning users as well as learnability for new users.

Follow prerequisites to their owners and completion signals. External work can be valid if instructions, ownership, return path and progress are usable. Detect circular dependencies, unreachable setup and missing handoffs. Continue beyond a successful submission to finding and using the saved result.

## Account for coverage

Maintain a task register:

`goal/journey | role | initial state | prerequisites | expected outcome | branches checked | evidence | status`

Also inventory surface families and distinct variants for visual review. Inspect every in-scope core journey and major surface. Sample equivalent secondary cases with an explicit rationale; expand when behavior or implementation differs. Do not enumerate all theoretical combinations or imply exhaustive coverage from sampling.

Check applicable normal, empty, unconfigured, loading, failure, permission, invalid-input, conflict, ambiguous-completion and revisit states. Use `verified`, `failed`, `partially inspected`, `unverified` or `not applicable`, with reasons. Distinguish live execution, fixture results and source-only inference. Do not mutate live settings, spend money or grant access to complete an audit.

## Diagnose and prioritize

Record findings at the appropriate level: vision/boundary, capability/architecture, journey, interaction, visual system or detail. Link each to goal, evidence, user consequence, governing criterion, affected surfaces and a verification condition. Keep observations separate from inferred root causes and proposed fixes.

Cluster repeated symptoms under supported systemic causes without losing manifestations. Prioritize by outcome impact, frequency, affected roles and recovery cost. Order repairs by dependencies: removing an unjustified workflow may supersede its local visual defects. Do not average serious failures into a flattering score or dismiss a visual communication problem because the controls work.

Reassess whether fixing the proposed list would actually enable the core outcomes. If not, the audit is missing structural work or has an unresolved product decision; say which. No number of small improvements establishes readiness.

## Method sources and limits

- [NN/g task scenarios](https://www.nngroup.com/articles/task-scenarios-usability-testing/) supports goal-based scenarios rather than leading instructions.
- [NN/g cognitive walkthroughs](https://www.nngroup.com/articles/cognitive-walkthroughs/) supports stepwise learnability inspection for unfamiliar or complex tasks.
- [NN/g service blueprints](https://www.nngroup.com/articles/service-blueprints-definition/) connects user actions to supporting operations and actors.
- [NN/g heuristic evaluation](https://www.nngroup.com/articles/how-to-conduct-a-heuristic-evaluation/) supplies a complementary inspection method, not a replacement for user research.

The blueprint structure and coverage records here are operational adaptations, not external certification requirements. Expert inspection and agent role-play do not establish measured user success. Identify focused real-user evaluation where comprehension, value or efficiency remains uncertain.
