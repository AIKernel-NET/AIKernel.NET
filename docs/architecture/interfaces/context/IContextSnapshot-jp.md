---
id: icontextsnapshot
title: "IContextSnapshot"
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

英語版は [IContextSnapshot.md](./IContextSnapshot.md) を参照。

# IContextSnapshot (インターフェース仕様)

## 1. 責務の境界 (Responsibility Boundary)
`IContextSnapshot` は、特定時点の `IContextCollection` と整合性情報を固定し、監査と決定論的リプレイの基準点を提供する境界インターフェースです。

- 役割:
  スナップショット識別子、親子関係、生成時刻、整合性ハッシュ、固定化済みコンテキストを提供します。
- 非役割:
  保存先管理やシリアライズ形式の実装は責務外です。

## 2. 契約シグネチャ (Signature)
```csharp
namespace AIKernel.Abstractions.Context;

public interface IContextSnapshot
{
    string SnapshotId { get; }
    string? ParentSnapshotId { get; }
    DateTimeOffset CreatedAtUtc { get; }
    string ContextHash { get; }
    IContextCollection Context { get; }
}
```

## 3. 関連ユースケース (Related UCs)
- `UC-20` 決定論的リプレイと監査証跡:
  同一スナップショット基準で過去実行条件を再現します。
- `UC-09` 実行状態の永続化と復元:
  中断/再開時の一貫した復元基点として機能します。

## 4. 統治上の制約 (Governance & Determinism)
- 不変性:
  一度確定したスナップショット内容は変更不可であることを前提とします。
- 整合性:
  `ContextHash` は `Context` 内容と一貫しなければなりません。
- Fail-Closed:
  `ContextHash` 不一致、必須情報欠落、前提不整合時は復元・再実行を拒否します。

## 5. 実装時の注意 (Notes)
- 連鎖追跡:
  `ParentSnapshotId` を使い、差分系スナップショットの系譜を追跡可能にしてください。
- 時刻規約:
  `CreatedAtUtc` はUTC基準で固定し、監査時系列の曖昧性を排除してください。
---

# 変更履歴
- v0.0.0 / v0.0.0.0: 初期ドラフト
- v0.0.1 (2026-05-06): ドキュメント規約に基づくバージョン更新
