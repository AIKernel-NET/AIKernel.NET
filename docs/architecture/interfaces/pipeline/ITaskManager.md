---
id: itaskmanager
version: 0.0.1
issuer: ai-kernel@tkysoftware.xsrv.jp
title: "ITaskManager"
created: 2026-05-03
updated: 2026-05-06
tags:
  - aikernel
  - architecture
  - interfaces
  - english
---

For Japanese version, see $(System.Collections.Hashtable.name)-jp.md.

# ITaskManager

## Responsibility
Define the contract boundary for ITaskManager within AIKernel orchestration, governance, and runtime operations.

## Key Members
| Member | Type | Description |
| --- | --- | --- |
| `RegisterPipelineAsync(IPipeline pipeline)` | `Task<string>` | Register pipeline definition. |
| `ExecutePipelineAsync(string pipelineId, ITaskContext context, CancellationToken cancellationToken = default)` | `Task<IPipelineExecutionResult>` | Execute pipeline by id. |
| `ExecuteTaskAsync(ITask task, ITaskContext context, CancellationToken cancellationToken = default)` | `Task<ITaskExecutionResult>` | Execute single task. |
| `PausePipelineAsync(string executionId)` | `Task<bool>` | Pause running pipeline. |
| `ResumePipelineAsync(string executionId)` | `Task<bool>` | Resume paused pipeline. |
| `CancelPipelineAsync(string executionId)` | `Task<bool>` | Cancel running pipeline. |
| `GetExecutionResultAsync(string executionId)` | `Task<IPipelineExecutionResult?>` | Get pipeline result by execution id. |

## Related Use Cases
See ../../use-cases/AIKernel_UseCaseCatalog.md for references where $(System.Collections.Hashtable.name) appears.

## Notes
- This interface is currently extension-point oriented and may not yet be referenced by runtime implementations.
- Implementations must preserve fail-closed and deterministic replay principles where applicable.
---

# Changelog
- v0.0.0 / v0.0.0.0: Initial draft
- v0.0.1 (2026-05-06): Version upgrade aligned with documentation guidelines
