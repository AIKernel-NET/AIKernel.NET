---
id: ischeduler
title: "IScheduler"
created: 2026-05-03
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

For Japanese version, see [IScheduler-jp.md](./IScheduler-jp.md).

# IScheduler (Interface Specification)

## 1. Responsibility Boundary
`IScheduler` governs timing, priority, and lifecycle of intelligence tasks in a time-sharing execution model.

- Role:
  Provide job admission, lookup, cancellation, listing, and result retrieval for execution coordination.
- Non-role:
  Actual inference execution remains with model/reasoning engines.

## 2. Contract Signature
```csharp
namespace AIKernel.Abstractions.Scheduling;

public interface IScheduler : IProvider
{
    Task<IScheduledJob?> GetJobAsync(string jobId);
    Task<IScheduledJob> ScheduleAsync(IScheduleSpec job);
    Task<bool> CancelAsync(string jobId);
    Task<IReadOnlyList<IScheduledJob>> ListJobsAsync();
    Task<IExecutionResult?> GetExecutionResultAsync(string jobId);
}
```

## 3. Related Use Cases
- `UC-19` Parallel multi-model execution:
  Coordinates concurrent job scheduling and result convergence points.
- `UC-22` Dynamic capacity control:
  Enables backoff and rescheduling under rate-limit pressure.
- `UC-28` Job scheduling:
  Unifies interactive, delayed, and batch execution control.

## 4. Governance & Determinism
- Job immutability:
  Accepted `IScheduleSpec` should be treated as immutable; changes require cancel-and-resubmit.
- Replay integrity:
  Record acceptance/execution ordering and timestamps for deterministic timeline reconstruction.
- Fail-Closed:
  Under queue saturation, apply explicit admission control instead of unbounded backlog growth.

## 5. Implementation Notes
- Durability:
  Persist scheduler state when workflows must survive process restarts.
- Priority policy:
  Implement dispatch rules that can prioritize critical governance-sensitive jobs.
---

# Changelog
- v0.0.0 / v0.0.0.0: Initial draft
- v0.0.1 (2026-05-06): Version upgrade aligned with documentation guidelines
