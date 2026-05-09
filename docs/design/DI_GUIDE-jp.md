---
version: 0.0.1
issuer: ai-kernel@tkysoftware.xsrv.jp
title: DI ガイド
description: AIKernel.Core の拡張ポイントと DI 登録パターン（利用者向け）
created: 2026-01-01
tags:
  - aikernel
  - architecture
  - preprocessing
  - prompt-design
  - japanese
updated: 2026-05-06
---

# 目的
本ガイドは、AIKernel.Core の抽象インターフェイスに対する依存性注入（DI）登録パターン、ライフサイクル指針、サンプルコードを示す。利用者が独自の Provider を容易に差し替えられることを目的とする。

# 範囲
- 対象: `AIKernel.NET`（契約）および `AIKernel.Core`（抽象）を参照する実装
- 想定読者: Provider 実装者、サービス開発者、運用エンジニア

# 用語と前提
- **契約層（AIKernel.NET）**: インターフェイス、DTO、Enum、イベント契約のみを含む。実装は含めない。
- **Core（AIKernel.Core）**: 抽象インターフェイス群と最小 NoOp 実装を提供する。実運用実装は別リポジトリまたは利用者側で提供する。

# 拡張ポイント一覧（抜粋）
- **IModelProvider**: モデル推論を行うインターフェイス。Singleton 推奨。
- **IRagProvider**: 検索・取得（RAG）インターフェイス。Singleton 推奨。
- **IEmbeddingProvider**: 埋め込み生成インターフェイス。Singleton 推奨。
- **IVirtualFileProvider**: Vfs 抽象（Git/S3/Blob 等）。Singleton 推奨。
- **IScheduler**: ジョブスケジューラ。Singleton 推奨。
- **IEventBus**: イベント配信。Singleton 推奨。

# ライフサイクル指針
- **Singleton**: スレッドセーフでコネクションやモデルを内部に保持する実装に使用。
- **Scoped**: リクエスト単位で状態を持つ必要がある場合に使用。
- **Transient**: 軽量で短命なユーティリティに限定して使用。

# DI 登録パターン（雛形）
```csharp
var builder = WebApplication.CreateBuilder(args);

// Core の契約と最小実装を登録
builder.Services.AddAIKernelCoreContracts();

// 利用者が Provider を注入（例）
builder.Services.AddSingleton<IModelProvider, OpenAIModelProvider>();
builder.Services.AddSingleton<IVirtualFileProvider, GitVfsProvider>();

var app = builder.Build();
app.MapControllers();
app.Run();

```
# NoOp 実装について
Core 初期段階では NoOp/Stub 実装を提供する。NoOp はテスト起動用に限定し、本番では必ず実運用実装に差し替えること。

# エラーハンドリングとタイムアウト
- Provider 実装はキャンセルトークンを尊重すること。
- ネットワーク呼び出しは必ずタイムアウトを設定すること。
- 再試行ポリシーは呼び出し側（Pipeline）で制御することを推奨する。

# セキュリティと認証
- シークレットは Vault/KMS 等で管理し、コードやイメージに埋め込まないこと。
- 認証情報の取得は DI で注入するか、環境プロバイダ経由で行うこと。

# テスト指針
- モック可能なインターフェイス設計を行うこと。
- Provider の統合テストはサンプル実装を使って E2E を自動化すること。
- NoOp 実装を用いた最小起動テストを CI に組み込むこと。

# バージョン互換性と移行
- AIKernel.NET（契約）は後方互換を優先する。破壊的変更はメジャーバージョンで管理し、移行手順を design/MIGRATION_GUIDE.md に記載すること。

# 参照
- AIKernel.NET/docs/design/DESIGN_INTENT.md
- AIKernel.Core/docs//NOOP_IMPLEMENTATION.md

# 変更履歴
- 2026-05-01 初版作成
- v0.0.1 (2026-05-06): ドキュメント規約に基づくバージョン更新

