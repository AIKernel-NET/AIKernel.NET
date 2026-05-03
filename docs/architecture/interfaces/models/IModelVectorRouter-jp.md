---
id: imodelvectorrouter
version: 0.0.0
issuer: ai-kernel@tkysoftware.xsrv.jp
title: "IModelVectorRouter"
created: 2026-05-03
tags:
  - aikernel
  - architecture
  - interfaces
  - japanese
---

英語版は IModelVectorRouter.md を参照。

# IModelVectorRouter

## Responsibility
IModelVectorRouter が AIKernel のオーケストレーションおよび統治フローで担う契約境界を定義する。

## 主要メンバー（Draft）
| Member | Type | 説明 |
| --- | --- | --- |
| `SelectOptimalModel(ModelCapacityVector requirement, IEnumerable<ModelType> candidates)` | `ModelType` | Select nearest or minimal satisfying model for requirement vector. |
| `RankModels(ModelCapacityVector requirement, IEnumerable<ModelType> candidates)` | `IEnumerable<(ModelType Model, float Score)>` | Return score-ranked candidate models. |

## 関連ユースケース
../../use-cases/AIKernel_UseCaseCatalog-jp.md の IModelVectorRouter 参照箇所を基準とする。

## Notes
- 本文書は Interface レベルのドラフトである。
- 実装は fail-closed と deterministic replay の原則を維持すること。



