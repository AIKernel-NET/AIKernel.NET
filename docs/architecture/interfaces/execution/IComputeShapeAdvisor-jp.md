---
id: icomputeshapeadvisor
title: "IComputeShapeAdvisor"
created: 2026-05-03
updated: 2026-05-16
published: 2026-05-16
version: "0.0.2"
edition: "Draft"
status: "Refactor"
issuer: ai-kernel@aikernel.net
maintainer: "拓也（AIKernel プロジェクト メンテナー）"
tags:
  - aikernel
  - architecture
  - interfaces
  - japanese
---

英語版: [IComputeShapeAdvisor](architecture/interfaces/execution/IComputeShapeAdvisor.md)

# IComputeShapeAdvisor

## Responsibility
IComputeShapeAdvisor が AIKernel のオーケストレーションおよび統治フローで担う契約境界を定義する。

## 主要メンバー（Draft）
| Member | Type | 説明 |
| --- | --- | --- |
| `AdvisedPhysicalCardinality(int logicalLength, string deviceType)` | `int` | Compute hardware-optimized physical cardinality from logical length. |
| `SelectOptimalCardinality(IEnumerable<int> candidates, string deviceType)` | `int` | Select best cardinality for a target device. |
| `GetPaddingStrategy(int logicalLength, string deviceType)` | `PaddingStrategy` | Return padding strategy and rationale. |
| `AdvisedQuantizationLevel(int cardinality, string deviceType, float targetThroughputTflops)` | `string` | Recommend quantization level under throughput target. |
| `GetOptimalShape(IExecutionConstraints constraints)` | `ComputeShape` | Resolve optimal tensor shape under constraints. |
| `EstimatePaddingOverhead(int logicalLength, int physicalLength)` | `ComputeOverhead` | Estimate memory and latency overhead after padding. |
| `GetCardinalityAlignment(string deviceType)` | `int` | Return required alignment unit for the device. |

## 関連ユースケース
../../use-cases/AIKernel_UseCaseCatalog-jp.md の IComputeShapeAdvisor 参照箇所を基準とする。

## Notes
- 本文書は Interface レベルのドラフトである。
- 実装は fail-closed と deterministic replay の原則を維持すること。
---

# 変更履歴
- v0.0.0 / v0.0.0.0: 初期ドラフト
- v0.0.1 (2026-05-06): ドキュメント規約に基づくバージョン更新
