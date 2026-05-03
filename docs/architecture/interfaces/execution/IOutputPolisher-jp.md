---
id: ioutputpolisher
version: 0.0.0
issuer: ai-kernel@tkysoftware.xsrv.jp
title: "IOutputPolisher"
created: 2026-05-03
tags:
  - aikernel
  - architecture
  - interfaces
  - japanese
---

英語版は IOutputPolisher.md を参照。

# IOutputPolisher

## Responsibility
IOutputPolisher が AIKernel のオーケストレーションおよび統治フローで担う契約境界を定義する。

## 主要メンバー（Draft）
| Member | Type | 説明 |
| --- | --- | --- |
| `RequiredCapacity` | `ModelCapacityVector` | Required capacity vector for output polishing. |
| `RenderAsync(RawLogic logic, ExpressionContext expressionContext, CancellationToken ct = default)` | `Task<string>` | Render final output from intermediate logic and expression context. |

## 関連ユースケース
../../use-cases/AIKernel_UseCaseCatalog-jp.md の IOutputPolisher 参照箇所を基準とする。

## Notes
- 本文書は Interface レベルのドラフトである。
- 実装は fail-closed と deterministic replay の原則を維持すること。



