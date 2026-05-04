---
id: iragprovider
version: 0.0.0
issuer: ai-kernel@tkysoftware.xsrv.jp
title: "IRagProvider"
created: 2026-05-03
tags:
  - aikernel
  - architecture
  - interfaces
  - japanese
---

英語版は $(System.Collections.Hashtable.name).md を参照。

# IRagProvider

## Responsibility
IRagProvider が AIKernel のオーケストレーション、統治、ランタイム運用で担う契約境界を定義する。

## 主要メンバー
| Member | Type | 説明 |
| --- | --- | --- |
| `SearchAsync(string query, int topK = 10, CancellationToken cancellationToken = default)` | `Task<IReadOnlyList<MaterialContextDto>>` | Search relevant material entries. |
| `IndexAsync(string documentId, string content, IReadOnlyDictionary<string, string>? metadata = null, CancellationToken cancellationToken = default)` | `Task` | Index a document into retrieval storage. |
| `DeleteAsync(string documentId, CancellationToken cancellationToken = default)` | `Task` | Delete indexed document. |
| `ClearAsync(CancellationToken cancellationToken = default)` | `Task` | Clear index entries. |

## 関連ユースケース
../../use-cases/AIKernel_UseCaseCatalog-jp.md の $(System.Collections.Hashtable.name) 参照箇所を基準とする。

## Notes
- 本 Interface は拡張ポイント用途が中心で、現時点でランタイム参照が未接続のものを含む。
- 適用可能な箇所では fail-closed と deterministic replay の原則を維持すること。
