---
id: icapabilityregistry
version: 0.0.0
issuer: ai-kernel@tkysoftware.xsrv.jp
title: "ICapabilityRegistry"
created: 2026-05-03
tags:
  - aikernel
  - architecture
  - interfaces
  - japanese
---

英語版は ICapabilityRegistry.md を参照。

# ICapabilityRegistry

## Responsibility
ICapabilityRegistry が AIKernel のオーケストレーションおよび統治フローで担う契約境界を定義する。

## 主要メンバー（Draft）
| Member | Type | 説明 |
| --- | --- | --- |
| `GetCapacity(ModelType modelType)` | `ModelCapacityVector` | Get default capacity vector for a model type. |
| `FindModelsAbove(ModelCapacityVector threshold)` | `IEnumerable<ModelType>` | Find models whose dimensions are above all thresholds. |
| `GetAllRegisteredModels()` | `IEnumerable<ModelType>` | Enumerate all registered models. |
| `RegisterCapacity(ModelType modelType, ModelCapacityVector capacity)` | `void` | Register or update model capacity vector. |

## 関連ユースケース
../../use-cases/AIKernel_UseCaseCatalog-jp.md の ICapabilityRegistry 参照箇所を基準とする。

## Notes
- 本文書は Interface レベルのドラフトである。
- 実装は fail-closed と deterministic replay の原則を維持すること。



