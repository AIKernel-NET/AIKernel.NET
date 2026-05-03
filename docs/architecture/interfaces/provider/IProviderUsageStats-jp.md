---
id: iproviderusagestats
version: 0.0.0
issuer: ai-kernel@tkysoftware.xsrv.jp
title: "IProviderUsageStats"
created: 2026-05-03
tags:
  - aikernel
  - architecture
  - interfaces
  - provider
  - usage
  - japanese
---

英語版は `IProviderUsageStats.md` を参照。

# IProviderUsageStats

## Responsibility
スループット、トークン量、レート制限圧力を準リアルタイムで可視化する利用統計を提供する。

## プロパティ一覧
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

## 利用シナリオ（Use Cases）
- UC-19 マルチモデル並列推論
- UC-23 AI クレジット管理

## `IModelVectorRouter` との連携
`RateLimitUtilization` と `AvgLatencyMs` を使って飽和 Provider を減点し、待ち行列の増幅を回避する。

## 円グラフ UI に必要なデータ項目
- request share: `RequestsCount`
- input-token share: `InputTokens`
- output-token share: `OutputTokens`
- rate-limit slice: `RateLimitUtilization`
- ラベル: `ProviderId`, `WindowStartUtc`, `WindowEndUtc`




