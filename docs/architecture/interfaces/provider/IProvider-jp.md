---
id: iprovider
version: 0.0.1
issuer: ai-kernel@tkysoftware.xsrv.jp
title: "IProvider"
created: 2026-05-03
updated: 2026-05-06
tags:
  - aikernel
  - architecture
  - interfaces
  - japanese
---

英語版は [IProvider.md](./IProvider.md) を参照。

# IProvider (インターフェース仕様)

## 1. 責務の境界 (Responsibility Boundary)
`IProvider` は、外部AIサービス差異を吸収し、カーネルに一貫した計算資源インターフェースを提供する抽象境界です。

- 役割:
  プロバイダー識別、能力提示、可用性確認、初期化/停止、ヘルス診断の共通ライフサイクルを定義します。
- 非役割:
  ルーティング決定は `IModelVectorRouter`、上位推論ロジックはオーケストレーション側責務です。

## 2. 契約シグネチャ (Signature)
```csharp
namespace AIKernel.Abstractions.Providers;

public interface IProvider
{
    string ProviderId { get; }
    string Name { get; }
    string Version { get; }
    IProviderCapabilities GetCapabilities();
    Task<bool> IsAvailableAsync();
    Task InitializeAsync();
    Task ShutdownAsync();
    Task<ProviderHealthStatus> GetHealthAsync();
}
```

## 3. 関連ユースケース (Related UCs)
- `UC-03` モデルベクトルルーティング:
  `GetCapabilities()` が候補選定の前提データを提供します。
- `UC-22` 動的キャパシティ制御とモデルルーティング:
  `GetHealthAsync()` / `IsAvailableAsync()` が動的重み付けや候補除外に寄与します。
- `UC-23` マルチプロバイダー切替・フェイルオーバー:
  可用性変動時の安全な切替運用を支えます。

## 4. 統治上の制約 (Governance & Determinism)
- Fail-Closed:
  `IsAvailableAsync()` 失敗や `InitializeAsync()` 異常時は、当該プロバイダーを実行経路から除外します。
- 状態透過性:
  `GetCapabilities()` と `GetHealthAsync()` は実運用状態を反映し、監査説明可能性を担保する必要があります。

## 5. 実装時の注意 (Notes)
- レジリエンス:
  リトライやサーキットブレーカを導入する場合でも、状態を `GetHealthAsync()` で観測可能にしてください。
- 認証秘匿:
  APIキー等の機密情報は実装内部で保護し、契約シグネチャへ露出させないでください。
---

# 変更履歴
- v0.0.0 / v0.0.0.0: 初期ドラフト
- v0.0.1 (2026-05-06): ドキュメント規約に基づくバージョン更新
