---
id: imodelprovider
version: 0.0.1
issuer: ai-kernel@tkysoftware.xsrv.jp
title: "IModelProvider"
created: 2026-05-03
updated: 2026-05-06
tags:
  - aikernel
  - architecture
  - interfaces
  - japanese
---

英語版は [IModelProvider.md](./IModelProvider.md) を参照。

# IModelProvider (インターフェース仕様)

## 1. 責務の境界 (Responsibility Boundary)
`IModelProvider` は、正規化メッセージ入力を受けて推論実行を行う知能実行エンジン境界です。

- 役割:
  一括生成、ストリーミング生成、単問応答を提供し、プロバイダー固有通信差異を吸収します。
- 非役割:
  モデル選定は `IModelVectorRouter`、Providerライフサイクル管理は `IProvider` 側責務です。

## 2. 契約シグネチャ (Signature)
```csharp
namespace AIKernel.Abstractions.Providers;

public interface IModelProvider : IProvider
{
    Task<string> GenerateAsync(IReadOnlyList<IModelMessage> messages, CancellationToken cancellationToken = default);
    Task StreamGenerateAsync(IReadOnlyList<IModelMessage> messages, Func<string, Task> onChunk, CancellationToken cancellationToken = default);
    Task<string> AnswerAsync(string question, string? context = null, CancellationToken cancellationToken = default);
}
```

## 3. 関連ユースケース (Related UCs)
- `UC-02` Structure フェーズ実行:
  推論の実行主体として `IThoughtProcess` を下支えします。
- `UC-04` 生成と出力整形:
  生成結果を `IOutputPolisher` が最終化する前段として機能します。

## 4. 統治上の制約 (Governance & Determinism)
- 決定論寄与:
  同一入力に対する再現性向上のため、可能な範囲で推論パラメータ固定を行います。
- Fail-Closed:
  安全フィルタ違反・トークン超過・実行不能時は不完全出力を返さず失敗を返します。
- 隔離遵守:
  供給された `messages` 以外の暗黙コンテキストを無断注入してはなりません。

## 5. 実装時の注意 (Notes)
- トランスポート隠蔽:
  REST/gRPC/ローカル推論の差異は実装内で吸収してください。
- 拡張性:
  マルチモーダル対応は `IModelMessage` 拡張と整合する形で段階導入してください。
---

# 変更履歴
- v0.0.0 / v0.0.0.0: 初期ドラフト
- v0.0.1 (2026-05-06): ドキュメント規約に基づくバージョン更新
