---
id: ipipelineorchestrator
version: 0.0.0
issuer: ai-kernel@tkysoftware.xsrv.jp
title: "IPipelineOrchestrator"
created: 2026-05-03
tags:
  - aikernel
  - architecture
  - interfaces
  - japanese
---

英語版は IPipelineOrchestrator.md を参照。

# IPipelineOrchestrator

## Responsibility
IPipelineOrchestrator が AIKernel のオーケストレーションおよび統治フローで担う契約境界を定義する。

## 主要メンバー（Draft）
| Member | Type | 説明 |
| --- | --- | --- |
| `Name` | `string` | 契約インスタンスの論理識別名。 |
| `Version` | `string` | 互換性確認に用いる契約バージョン。 |
| `Metadata` | `IReadOnlyDictionary<string, string>` | 実装固有拡張のためのメタデータ。 |

## 関連ユースケース
../../use-cases/AIKernel_UseCaseCatalog-jp.md の IPipelineOrchestrator 参照箇所を基準とする。

## Notes
- 本文書は Interface レベルのドラフトである。
- 実装は fail-closed と deterministic replay の原則を維持すること。



