---
title: 'IRuleEngine'
created: 2026-05-06
updated: 2026-05-16
published: 2026-05-16
version: "0.0.2"
edition: "Draft"
status: "Refactor"
issuer: ai-kernel@aikernel.net
maintainer: "Takuya (AIKernel Project Maintainer)"
tags:
  - aikernel
  - architecture
  - interfaces
  - english
---

For Japanese version, see [IRuleEngine-jp.md](./IRuleEngine-jp.md).

# IRuleEngine (Rule Engine Specification)

## 1. Responsibility Boundary
`IRuleEngine` evaluates whether inputs, outputs, and execution process signals comply with organizational guardrails and invariant policies.

- Role:
  Return rule-evaluation outcomes including compliance, severity, and violation rationale.
- Non-role:
  Rule definition storage/lifecycle management is out of scope; this contract focuses on evaluation execution.

## 2. Contract Signature
```csharp
namespace AIKernel.Abstractions.Rules;

public interface IRuleEngine
{
    ValueTask<RuleEvaluationResult> EvaluateAsync(
        string ruleId,
        RuleEvaluationContext context,
        CancellationToken cancellationToken = default);
}
```

## 3. Related Use Cases
- `UC-13` Runtime signature verification and governance:
  Validates policy compliance in addition to signature integrity.
- `UC-04` Generation and output polishing:
  Checks generated content against formatting/safety rules.
- `UC-21` Policy execution:
  Acts as core evaluator for guardrail enforcement.

## 4. Governance & Determinism
- Deterministic evaluation:
  Identical `ruleId` and `RuleEvaluationContext` should yield identical results.
- Invariant enforcement:
  Critical violations must enable fail-closed interruption by upstream orchestration.
- Side-effect free:
  `EvaluateAsync` must not mutate input context or external system state.

## 5. Exception Contract
This interface does not hard-code exception types. Implementations should explicitly surface:

- Rule resolution failures:
  `ruleId` not found/unavailable.
- Evaluation runtime failures:
  Timeouts or engine-level execution errors.

## 6. Implementation Notes
- Engine diversity:
  Implementations may use deterministic rule logic, regex policies, or specialized evaluators.
- Score integration:
  Violations can be propagated into broader health signals such as SNR/HealthScore.
---

# Changelog
- v0.0.0 / v0.0.0.0: Initial draft
- v0.0.1 (2026-05-06): Version upgrade aligned with documentation guidelines
