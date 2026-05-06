---
id: icomputeshapeadvisor
version: 0.0.1
issuer: ai-kernel@tkysoftware.xsrv.jp
title: "IComputeShapeAdvisor"
created: 2026-05-03
updated: 2026-05-06
tags:
  - aikernel
  - architecture
  - interfaces
  - english
---

For Japanese version, see IComputeShapeAdvisor-jp.md.

# IComputeShapeAdvisor

## Responsibility
Define the contract boundary for IComputeShapeAdvisor within AIKernel orchestration and governance flows.

## Key Members (Draft)
| Member | Type | Description |
| --- | --- | --- |
| `AdvisedPhysicalCardinality(int logicalLength, string deviceType)` | `int` | Compute hardware-optimized physical cardinality from logical length. |
| `SelectOptimalCardinality(IEnumerable<int> candidates, string deviceType)` | `int` | Select best cardinality for a target device. |
| `GetPaddingStrategy(int logicalLength, string deviceType)` | `PaddingStrategy` | Return padding strategy and rationale. |
| `AdvisedQuantizationLevel(int cardinality, string deviceType, float targetThroughputTflops)` | `string` | Recommend quantization level under throughput target. |
| `GetOptimalShape(IExecutionConstraints constraints)` | `ComputeShape` | Resolve optimal tensor shape under constraints. |
| `EstimatePaddingOverhead(int logicalLength, int physicalLength)` | `ComputeOverhead` | Estimate memory and latency overhead after padding. |
| `GetCardinalityAlignment(string deviceType)` | `int` | Return required alignment unit for the device. |

## Related Use Cases
See ../../use-cases/AIKernel_UseCaseCatalog.md for references where IComputeShapeAdvisor appears.

## Notes
- This document is an interface-level draft.
- Implementations must preserve fail-closed and deterministic replay principles.
---

# Changelog
- v0.0.0 / v0.0.0.0: Initial draft
- v0.0.1 (2026-05-06): Version upgrade aligned with documentation guidelines
