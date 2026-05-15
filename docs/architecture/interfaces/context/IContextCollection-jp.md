---
id: icontextcollection
title: "IContextCollection"
created: 2026-05-03
updated: 2026-05-16
published: 2026-05-16
version: "0.0.2"
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

英語版は [IContextCollection.md](./IContextCollection.md)を参照。

# IContextCollection (インターフェース仕様)

## 1. 責務の境界 (Responsibility Boundary)
`IContextCollection` は、推論サイクルで使用するコンテキスト断片を一元管理し、フェーズ別バッファ境界を維持する境界インターフェースです。

- 役割:
  カテゴリ化された `ContextFragment` の管理と、`Orchestration/Material/Expression/History` 各バッファの提供を担います。
- 非役割:
  永続化、外部検索、ストレージ連携は責務外です。本インターフェースは実行中ワーキングメモリに集中します。

## 2. 契約シグネチャ (Signature)
```csharp
namespace AIKernel.Abstractions.Context;

public interface IContextCollection
{
    IEnumerable<ContextFragment> GetAll();
    IEnumerable<ContextFragment> GetByCategory(ContextCategory category);
    OrchestrationBuffer GetOrchestrationBuffer();
    ExpressionBuffer GetExpressionBuffer();
    MaterialBuffer GetMaterialBuffer();
    HistoryBuffer GetHistoryBuffer();
}
```

## 3. 関連ユースケース (Related UCs)
- `UC-06` 3層バッファ境界（Context Isolation）:
  指示・素材・出力の分離を維持し、Attention 汚染を抑制します。
- `UC-02` Structure フェーズ実行:
  `IThoughtProcess` の論理構築に必要な入力集合を提供します。

## 4. 統治上の制約 (Governance & Determinism)
- 不変性尊重:
  同一推論サイクル中のバッファ内容は、実装上不変として扱う運用を前提とします。
- 決定論的順序:
  同一入力に対して `GetAll()` / `GetByCategory()` の返却順序は一定である必要があります。
- Fail-Closed:
  必須カテゴリ欠落時は不完全実行を許容せず、拒否側で終了させる設計が推奨されます。

## 5. 実装時の注意 (Notes)
- 境界明確化:
  バッファ間の境界が曖昧化しないよう、レンダリング時の区切り規約を統一してください。
- メモリ効率:
  大容量素材は参照保持を優先し、実体コピーを最小化する構成を推奨します。
---

# 変更履歴
- v0.0.0 / v0.0.0.0: 初期ドラフト
- v0.0.1 (2026-05-06): ドキュメント規約に基づくバージョン更新
