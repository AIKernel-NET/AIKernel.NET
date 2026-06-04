---
id: ihistorysummarizer
title: "IHistorySummarizer"
created: 2026-05-03
updated: 2026-06-04
published: 2026-05-16
version: "0.0.4"
edition: "Draft"
status: "Refactor"
issuer: ai-kernel@aikernel.net
maintainer: "拓也（AIKernel プロジェクト メンテナー）"
tags:
  - aikernel
  - architecture
  - interfaces
  - japanese
---

英語版: [IHistorySummarizer.md](IHistorySummarizer.md)

# IHistorySummarizer

## Responsibility
chat / execution history を再利用可能な material と context に投影する境界を定義します。所属は `AIKernel.Abstractions.History` であり、governance は結果を利用できますが、この Interface 自体は governance contract ではありません。

## 主要メンバー
| Member | Type | 説明 |
| --- | --- | --- |
| `SummarizeAsMaterialAsync(IEnumerable<ContextFragment> history, CancellationToken ct = default)` | `Task<IEnumerable<IStructuredMaterial>>` | history fragment を正規化された material として要約する。 |
| `ProjectAsContextAsync(IEnumerable<ContextFragment> history, HistoryPolicy policy, CancellationToken ct = default)` | `Task<IContextCollection>` | history fragment を governed context collection へ投影する。 |

## 関連ユースケース
- UC-32 history summarization and projection.
- History ROM publication flows.

## Notes
- 実装は source conversation storage を mutate してはならない。
- 決定論的な projection policy は `HistoryPolicy` として明示的に渡す。
---

# 変更履歴
- v0.0.0 / v0.0.0.0: 初期ドラフト
- v0.0.1 (2026-05-06): ドキュメント規約に基づくバージョン更新
- v0.0.4 (2026-06-04): governance docs から history docs へ移動し、source と signature を整合。
