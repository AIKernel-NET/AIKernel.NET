---
id: istructuredmaterial
version: 0.0.0
issuer: ai-kernel@tkysoftware.xsrv.jp
title: "IStructuredMaterial"
created: 2026-05-03
tags:
  - aikernel
  - architecture
  - interfaces
  - japanese
---

英語版は IStructuredMaterial.md を参照。

# IStructuredMaterial

## Responsibility
IStructuredMaterial が AIKernel のオーケストレーションおよび統治フローで担う契約境界を定義する。

## 主要メンバー（Draft）
| Member | Type | 説明 |
| --- | --- | --- |
| `RawContent` | `string` | Original source content before normalization. |
| `NormalizedContent` | `string` | Sanitized and normalized content for inference. |
| `Weight` | `double` | Importance/trust weight between 0.0 and 1.0. |
| `SourceInfo` | `SourceInfo` | Source provenance metadata. |

## 関連ユースケース
../../use-cases/AIKernel_UseCaseCatalog-jp.md の IStructuredMaterial 参照箇所を基準とする。

## Notes
- 本文書は Interface レベルのドラフトである。
- 実装は fail-closed と deterministic replay の原則を維持すること。



