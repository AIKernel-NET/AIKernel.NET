---
title: "IDslPipelineCompiler"
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

Japanese version: [IDslPipelineCompiler-jp.md](IDslPipelineCompiler-jp.md)

# IDslPipelineCompiler

## Responsibility
Compiles a parsed `DslDocument` into an executable `IKernelPipeline`.

## Key Members
| Member | Type | Description |
| --- | --- | --- |
| `CompileAsync(DslDocument document, CancellationToken cancellationToken = default)` | `Task<IKernelPipeline>` | Validates and compiles DSL semantic IR into a pipeline contract. |

## Boundary Rules
- The DSL is structured data, not C# source code.
- Compilation must be deterministic for the same document and registry state.
- Invalid DSL must be represented as a fail-closed implementation result.
