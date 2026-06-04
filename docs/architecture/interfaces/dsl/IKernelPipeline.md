---
title: "IKernelPipeline"
created: 2026-06-04
updated: 2026-06-04
published: 2026-06-04
version: "0.0.4"
edition: "Draft"
status: "Refactor"
issuer: ai-kernel@aikernel.net
maintainer: "Takuya (AIKernel Project Maintainer)"
tags:
  - aikernel
  - architecture
  - interfaces
  - dsl
  - english
---

Japanese version: [IKernelPipeline-jp.md](IKernelPipeline-jp.md)

# IKernelPipeline

## Responsibility
Executes a compiled DSL pipeline against a deterministic DSL execution context.

## Key Members
| Member | Type | Description |
| --- | --- | --- |
| `ExecuteAsync(DslPipelineExecutionContext context, CancellationToken cancellationToken = default)` | `Task<DslPipelineExecutionResult>` | Runs the compiled pipeline and returns value, metadata, replay log, and status. |

## Boundary Rules
- The contract exposes execution result DTOs, not internal `ResultStep` types.
- Implementations must preserve replay-log and hash determinism for the same input.
