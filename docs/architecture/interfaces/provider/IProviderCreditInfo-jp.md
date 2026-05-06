---
id: iprovidercreditinfo
version: 0.0.1
issuer: ai-kernel@tkysoftware.xsrv.jp
title: "IProviderCreditInfo"
created: 2026-05-03
updated: 2026-05-06
tags:
  - aikernel
  - architecture
  - interfaces
  - provider
  - credit
  - japanese
---

英語版は [IProviderCreditInfo.md](./IProviderCreditInfo.md) を参照。

# IProviderCreditInfo (インターフェース仕様)

## 1. 責務の境界 (Responsibility Boundary)
`IProviderCreditInfo` は、プロバイダー別の残高・予約・上限情報を公開し、経済リスクを加味した実行統治を可能にする境界インターフェースです。

- 役割:
  実行可能残高、予約残高、ハード/ソフト上限、更新時刻を提示します。
- 非役割:
  課金決済や返金処理そのものは責務外です。

## 2. プロパティ定義 (Properties)
| Property | Type | 説明 |
| --- | --- | --- |
| `ProviderId` | `string` | Provider の論理識別子。 |
| `CurrencyCode` | `string` | 請求通貨（ISO 4217）。 |
| `CurrentBalance` | `decimal` | 現在利用可能な残高。 |
| `ReservedBalance` | `decimal` | 実行中ジョブに予約済みの残高。 |
| `HardLimit` | `decimal` | 絶対支出上限。 |
| `SoftLimit` | `decimal` | 警告閾値。 |
| `LastUpdatedUtc` | `DateTimeOffset` | 最終更新時刻。 |

## 3. 利用シナリオ (Use Cases)
- `UC-23` AI クレジット管理:
  残高不足時の通知・低コスト経路切替・実行抑止に利用します。
- `UC-19` マルチモデル並列推論:
  `ReservedBalance` により同時実行時の二重消費を抑制します。

## 4. `IModelVectorRouter` との連携
- 生存判定:
  見積コストが `CurrentBalance - ReservedBalance` を超える候補は除外します。
- ソフト制約:
  `SoftLimit` 逼迫候補は減点し、余力のある候補を優先します。
- 強制迂回:
  `HardLimit` 到達または残高枯渇時は対象候補を隔離し、代替経路へ迂回します。

## 5. 可視化（円グラフ UI）への応用
- 利用可能シェア:
  `CurrentBalance - ReservedBalance`
- 予約中シェア:
  `ReservedBalance`
- 既消費シェア:
  `HardLimit - CurrentBalance`
- ラベル:
  `ProviderId`, `CurrencyCode`, `LastUpdatedUtc`

## 6. 統治上の制約 (Governance & Determinism)
- 情報鮮度:
  `LastUpdatedUtc` が古すぎる場合は不確実実行を避けるため安全側制限を適用します。
- リプレイ整合:
  実行時クレジット状態をスナップショット化し、後続監査で再現可能にします。
- 予約清算:
  `ReservedBalance` は完了時に速やかに解放/消費確定し、デッドロックを防ぎます。
---

# 変更履歴
- v0.0.0 / v0.0.0.0: 初期ドラフト
- v0.0.1 (2026-05-06): ドキュメント規約に基づくバージョン更新
