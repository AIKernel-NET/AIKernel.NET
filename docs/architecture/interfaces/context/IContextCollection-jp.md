---
id: icontextcollection
version: 0.0.0
issuer: ai-kernel@tkysoftware.xsrv.jp
title: "IContextCollection"
created: 2026-05-03
tags:
  - aikernel
  - architecture
  - interfaces
  - japanese
---

英語版は IContextCollection.md を参照。

# IContextCollection

## Responsibility
IContextCollection が AIKernel のオーケストレーションおよび統治フローで担う契約境界を定義する。

## 主要メンバー（Draft）
| Member | Type | 説明 |
| --- | --- | --- |
| `GetAll()` | `IEnumerable<ContextFragment>` | Return all fragments across categories. |
| `GetByCategory(ContextCategory category)` | `IEnumerable<ContextFragment>` | Return fragments in a single category. |
| `GetOrchestrationBuffer()` | `OrchestrationBuffer` | Return orchestration-phase read buffer. |
| `GetExpressionBuffer()` | `ExpressionBuffer` | Return expression-phase read buffer. |
| `GetMaterialBuffer()` | `MaterialBuffer` | Return material-phase read buffer. |
| `GetHistoryBuffer()` | `HistoryBuffer` | Return history-phase read buffer. |

## 関連ユースケース
../../use-cases/AIKernel_UseCaseCatalog-jp.md の IContextCollection 参照箇所を基準とする。

## Notes
- 本文書は Interface レベルのドラフトである。
- 実装は fail-closed と deterministic replay の原則を維持すること。



