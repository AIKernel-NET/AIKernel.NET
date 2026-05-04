---
id: ischeduler
version: 0.0.0
issuer: ai-kernel@tkysoftware.xsrv.jp
title: "IScheduler"
created: 2026-05-03
tags:
  - aikernel
  - architecture
  - interfaces
  - english
---

For Japanese version, see $(System.Collections.Hashtable.name)-jp.md.

# IScheduler

## Responsibility
Define the contract boundary for IScheduler within AIKernel orchestration, governance, and runtime operations.

## Key Members
| Member | Type | Description |
| --- | --- | --- |
| `GetJobAsync(string jobId)` | `Task<IScheduledJob?>` | Get scheduled job by id. |
| `ScheduleAsync(IScheduleSpec job)` | `Task<IScheduledJob>` | Schedule a new job. |
| `CancelAsync(string jobId)` | `Task<bool>` | Cancel scheduled job. |
| `ListJobsAsync()` | `Task<IReadOnlyList<IScheduledJob>>` | List all jobs. |
| `GetExecutionResultAsync(string jobId)` | `Task<IExecutionResult?>` | Get execution result by job id. |

## Related Use Cases
See ../../use-cases/AIKernel_UseCaseCatalog.md for references where $(System.Collections.Hashtable.name) appears.

## Notes
- This interface is currently extension-point oriented and may not yet be referenced by runtime implementations.
- Implementations must preserve fail-closed and deterministic replay principles where applicable.
