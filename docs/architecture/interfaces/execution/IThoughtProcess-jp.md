---
id: ithoughtprocess
version: 0.0.0
issuer: ai-kernel@tkysoftware.xsrv.jp
title: "IThoughtProcess"
created: 2026-05-03
tags:
  - aikernel
  - architecture
  - interfaces
  - japanese
---

英語版は IThoughtProcess.md を参照。

# IThoughtProcess

## Responsibility
IThoughtProcess が AIKernel のオーケストレーションおよび統治フローで担う契約境界を定義する。

## 主要メンバー（Draft）
| Member | Type | 説明 |
| --- | --- | --- |
| `RequiredCapacity` | `ModelCapacityVector` | Required capacity vector for this thought process. |
| `BuildLogicAsync(IContextCollection orchestrationContext, CancellationToken ct = default)` | `Task<RawLogic>` | Build intermediate reasoning logic from orchestration context. |

## 関連ユースケース
../../use-cases/AIKernel_UseCaseCatalog-jp.md の IThoughtProcess 参照箇所を基準とする。

## Notes
- 本文書は Interface レベルのドラフトである。
- 実装は fail-closed と deterministic replay の原則を維持すること。



