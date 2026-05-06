---
version: 0.0.1
issuer: ai-kernel@tkysoftware.xsrv.jp
title: 'IAuditLogger'
created: 2026-05-06
tags:
  - aikernel
  - architecture
  - interfaces
  - english
updated: 2026-05-06
---

For Japanese version, see [IAuditLogger-jp.md](./IAuditLogger-jp.md).

# IAuditLogger (Audit Logger Specification)

## 1. Responsibility Boundary
`IAuditLogger` records tamper-resistant audit evidence for decisions, executions, governance checks, and data transfers across AIKernel lifecycle.

- Role:
  Persist categorized records for execution, guard, pipeline, provider, and transfer events to ensure accountability and replay explainability.
- Non-role:
  Real-time event fan-out is owned by `IEventBus`; this contract focuses on durable audit logging.

## 2. Contract Signature
```csharp
namespace AIKernel.Abstractions.Events;

public interface IAuditLogger
{
    ValueTask LogAuditEventAsync(AuditEvent auditEvent, CancellationToken cancellationToken = default);

    ValueTask LogExecutionEventAsync(ExecutionEvent executionEvent, CancellationToken cancellationToken = default);

    ValueTask LogGuardEventAsync(GuardEvent guardEvent, CancellationToken cancellationToken = default);

    ValueTask LogPipelineEventAsync(PipelineEvent pipelineEvent, CancellationToken cancellationToken = default);

    ValueTask LogProviderEventAsync(ProviderEvent providerEvent, CancellationToken cancellationToken = default);

    ValueTask LogTransferTraceAsync(TransferTrace transferTrace, CancellationToken cancellationToken = default);
}
```

## 3. Related Use Cases
- `UC-20` Deterministic replay and audit trail:
  Capture sufficient execution evidence for timeline reconstruction.
- `UC-13` Runtime signature verification and governance:
  Persist verification failures and policy violations as security-relevant audit records.
- `UC-24` Audit trail export:
  Feed structured evidence into external compliance pipelines.

## 4. Governance & Determinism
- Chronological integrity:
  Append order must preserve causal timeline reconstruction.
- Immutability:
  Audit persistence is expected to be append-only with no retroactive mutation.
- Fail-Closed:
  If audit persistence is unavailable, enforce safe-stop or strict fallback to avoid unauditable execution.

## 5. Exception Contract
This interface does not hard-code exception types. Implementations should explicitly surface:

- Storage failures:
  Sink write failures or capacity exhaustion.
- Serialization failures:
  Structured log encoding failures.

## 6. Implementation Notes
- Structured logging:
  Persist in queryable structured formats (e.g., JSON).
- Sensitive data handling:
  Mask/tokenize secrets and PII in provider/execution records.
- Performance:
  Use async buffering and efficient sinks to minimize critical-path impact.
---

# Changelog
- v0.0.0 / v0.0.0.0: Initial draft
- v0.0.1 (2026-05-06): Version upgrade aligned with documentation guidelines
