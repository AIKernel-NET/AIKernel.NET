---
id: iproviderusagestats
version: 0.0.1
issuer: ai-kernel@tkysoftware.xsrv.jp
title: "IProviderUsageStats"
created: 2026-05-03
updated: 2026-05-06
tags:
  - aikernel
  - architecture
  - interfaces
  - provider
  - usage
  - japanese
---

英語版は [IProviderUsageStats.md](./IProviderUsageStats.md) を参照。

# IProviderUsageStats (利用統計インターフェース仕様)

## 1. 責務の境界 (Responsibility Boundary)
`IProviderUsageStats` は、スループット・トークン消費・レート制限圧力を準リアルタイムで可視化し、動的ルーティング判断を支える境界インターフェースです。

- 役割:
  直近ウィンドウの利用実績と性能指標を提供します。
- 非役割:
  長期アーカイブや監査保管の責務は持ちません。

## 2. プロパティ定義 (Properties)
| Property | Type | 説明 |
| --- | --- | --- |
| `ProviderId` | `string` | Provider 識別子。 |
| `WindowStartUtc` | `DateTimeOffset` | 集計ウィンドウ開始時刻。 |
| `WindowEndUtc` | `DateTimeOffset` | 集計ウィンドウ終了時刻。 |
| `RequestsCount` | `long` | ウィンドウ内総リクエスト数。 |
| `InputTokens` | `long` | ウィンドウ内入力トークン総数。 |
| `OutputTokens` | `long` | ウィンドウ内出力トークン総数。 |
| `AvgLatencyMs` | `double` | 平均応答遅延。 |
| `RateLimitUtilization` | `double` | レート制限使用率（0.0 から 1.0+）。 |

## 3. 利用シナリオ (Use Cases)
- `UC-19` マルチモデル並列推論:
  `AvgLatencyMs` と利用圧力を参照してトラフィック配分を最適化します。
- `UC-23` AI クレジット管理:
  トークン実績を予算消費ペース監視に利用します。

## 4. `IModelVectorRouter` との連携
- 渋滞回避:
  `RateLimitUtilization` 高騰や `AvgLatencyMs` 悪化時に候補スコアを減点します。
- 配分最適化:
  入出力トークン負荷が高い経路を一時回避し、全体可用性を維持します。

## 5. 可視化（円グラフ・ダッシュボード）への応用
- リクエストシェア:
  `RequestsCount`
- トークンスループット:
  `InputTokens`, `OutputTokens`
- レート制限圧力:
  `RateLimitUtilization`
- ラベル:
  `ProviderId`, `WindowStartUtc`, `WindowEndUtc`

## 6. 統治上の制約 (Governance & Determinism)
- 観測精度:
  429等の失敗実績も圧力評価に反映し、過度に楽観的な判断を避けます。
- リプレイ整合:
  実行時に参照した統計スナップショットを保存し、混雑条件を再現可能にします。
- ウィンドウ整合:
  比較対象統計のウィンドウ境界を揃えるか、補間ルールを明示して運用します。
---

# 変更履歴
- v0.0.0 / v0.0.0.0: 初期ドラフト
- v0.0.1 (2026-05-06): ドキュメント規約に基づくバージョン更新
