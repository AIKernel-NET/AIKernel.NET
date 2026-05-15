---
id: imodelmessage
title: "IModelMessage"
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

英語版は [IModelMessage.md](./IModelMessage.md) を参照。

# IModelMessage (インターフェース仕様)

## 1. 責務の境界 (Responsibility Boundary)
`IModelMessage` は、モデル対話における最小単位の発話を正規化し、プロバイダー非依存な共通対話形式を提供する境界インターフェースです。

- 役割:
  発話者ロールと本文を保持し、履歴管理・監査記録の共通化を支えます。
- 非役割:
  配送方式、SDK固有メッセージ構造、バイナリ添付管理は責務外です。

## 2. 契約シグネチャ (Signature)
```csharp
namespace AIKernel.Abstractions.Providers;

public interface IModelMessage
{
    string Role { get; }
    string Content { get; }
}
```

## 3. 関連ユースケース (Related UCs)
- `UC-06` 3層バッファ境界:
  History系データの正規化単位として扱われます。
- `UC-20` 決定論的リプレイと監査証跡:
  対話履歴再現の不変レコードとして利用されます。

## 4. 統治上の制約 (Governance & Determinism)
- 不変性:
  一度確定した `Role` と `Content` は改変しない運用を前提とします。
- ロール正規化:
  実装はプロバイダー差異を吸収し、カーネル標準ロールへマップする責務を負います。
- 順序再現性:
  メッセージ列は順序と内容を安定保持し、再実行時の一致性を担保します。

## 5. 実装時の注意 (Notes)
- 拡張性:
  ツール呼び出しやマルチモーダル拡張は上位/派生契約で段階導入してください。
- 直列化:
  監査・保存用途を考慮し、単純で安定したプロパティ構造を維持してください。
---

# 変更履歴
- v0.0.0 / v0.0.0.0: 初期ドラフト
- v0.0.1 (2026-05-06): ドキュメント規約に基づくバージョン更新
