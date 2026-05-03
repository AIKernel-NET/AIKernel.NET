---
id: imaterialquarantine
version: 0.0.0
issuer: ai-kernel@tkysoftware.xsrv.jp
title: "IMaterialQuarantine"
created: 2026-05-03
tags:
  - aikernel
  - architecture
  - interfaces
  - japanese
---

英語版は IMaterialQuarantine.md を参照。

# IMaterialQuarantine

## Responsibility
IMaterialQuarantine が AIKernel のオーケストレーションおよび統治フローで担う契約境界を定義する。

## 主要メンバー（Draft）
| Member | Type | 説明 |
| --- | --- | --- |
| `QuarantineAsync(ContextFragment rawFragment, CancellationToken ct = default)` | `Task<IStructuredMaterial>` | Validate and normalize raw fragment or fail with quarantine exception. |

## 関連ユースケース
../../use-cases/AIKernel_UseCaseCatalog-jp.md の IMaterialQuarantine 参照箇所を基準とする。

## Notes
- 本文書は Interface レベルのドラフトである。
- 実装は fail-closed と deterministic replay の原則を維持すること。



