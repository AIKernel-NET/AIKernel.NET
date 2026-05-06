---
id: itokenizer
version: 0.0.1
issuer: ai-kernel@tkysoftware.xsrv.jp
title: "ITokenizer"
created: 2026-05-03
updated: 2026-05-06
tags:
  - aikernel
  - architecture
  - interfaces
  - japanese
---

英語版は $(System.Collections.Hashtable.name).md を参照。

# ITokenizer

## Responsibility
ITokenizer が AIKernel のオーケストレーション、統治、ランタイム運用で担う契約境界を定義する。

## 主要メンバー
| Member | Type | 説明 |
| --- | --- | --- |
| `CountTokens(string text)` | `int` | Count token length for text input. |
| `Tokenize(string text)` | `IReadOnlyList<int>` | Tokenize text into token ids. |
| `Decode(IReadOnlyList<int> tokens)` | `string` | Decode token ids into text. |

## 関連ユースケース
../../use-cases/AIKernel_UseCaseCatalog-jp.md の $(System.Collections.Hashtable.name) 参照箇所を基準とする。

## Notes
- 本 Interface は拡張ポイント用途が中心で、現時点でランタイム参照が未接続のものを含む。
- 適用可能な箇所では fail-closed と deterministic replay の原則を維持すること。
---

# 変更履歴
- v0.0.0 / v0.0.0.0: 初期ドラフト
- v0.0.1 (2026-05-06): ドキュメント規約に基づくバージョン更新
