---
id: icontextlifecyclemanager
version: 0.0.0
issuer: ai-kernel@tkysoftware.xsrv.jp
title: "IContextLifecycleManager"
created: 2026-05-03
tags:
  - aikernel
  - architecture
  - interfaces
  - japanese
---

英語版は $(System.Collections.Hashtable.name).md を参照。

# IContextLifecycleManager

## Responsibility
IContextLifecycleManager が AIKernel のオーケストレーション、統治、ランタイム運用で担う契約境界を定義する。

## 主要メンバー
| Member | Type | 説明 |
| --- | --- | --- |
| `BeginContext(string contextId)` | `void` | Start context lifecycle. |
| `CompleteContext(string contextId)` | `void` | Complete context lifecycle. |
| `AbortContext(string contextId, string reason)` | `void` | Abort context lifecycle with reason. |

## 関連ユースケース
../../use-cases/AIKernel_UseCaseCatalog-jp.md の $(System.Collections.Hashtable.name) 参照箇所を基準とする。

## Notes
- 本 Interface は拡張ポイント用途が中心で、現時点でランタイム参照が未接続のものを含む。
- 適用可能な箇所では fail-closed と deterministic replay の原則を維持すること。
