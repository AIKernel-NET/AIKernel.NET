---
title: 'IKernelContextContract'
created: 2026-05-06
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

英語版は [IKernelContextContract.md](./IKernelContextContract.md) を参照。

# IKernelContextContract (契約仕様)

## 1. 責務の境界 (Responsibility Boundary)
`IKernelContextContract` は、実行単位の識別・有効期間・要求元属性を定義し、カーネルの統治とリソース管理の基準点を与える契約です。

- 役割:
  実行コンテキストのID、生成時刻、失効時刻、要求元、状態、付帯メタデータを提供します。
- 非役割:
  `ContextFragment` の保持・操作は責務外であり、内容管理は `IContextCollection` 側が担います。

## 2. 契約シグネチャ (Signature)
```csharp
namespace AIKernel.Contracts;

/// <summary>
/// Kernel コンテキスト契約を定義します。
/// カーネルレベルの実行コンテキスト管理を行います。
/// </summary>
public interface IKernelContextContract
{
    /// <summary>
    /// コンテキストの一意識別子を取得します。
    /// </summary>
    string ContextId { get; }

    /// <summary>
    /// コンテキスト作成時刻を取得します。
    /// </summary>
    DateTime CreatedAt { get; }

    /// <summary>
    /// コンテキストの有効期限を取得します。
    /// </summary>
    DateTime ExpiresAt { get; }

    /// <summary>
    /// リクエスト元の識別子を取得します。
    /// </summary>
    string RequesterId { get; }

    /// <summary>
    /// コンテキストの状態を取得します。
    /// </summary>
    string State { get; }

    /// <summary>
    /// コンテキストに関連するメタデータを取得します。
    /// </summary>
    IReadOnlyDictionary<string, object>? Metadata { get; }
}
```

## 3. 関連ユースケース (Related UCs)
- `UC-09` 実行状態の永続化と復元:
  `ContextId` を基点に中断/再開対象を一意識別します。
- `UC-20` 決定論的リプレイと監査証跡:
  実行主体・時刻・状態の監査証跡を構成し、再現条件の固定に寄与します。

## 4. 統治上の制約 (Governance & Determinism)
- 不変項目:
  `ContextId` と `CreatedAt` は生存期間中に変更されない前提です。
- 時間統治:
  `ExpiresAt` 超過後は実行拒否を行う Fail-Closed 運用を前提とします。
- 論理隔離:
  `RequesterId` は境界識別子として扱い、他コンテキストとの混線を防止します。

## 5. 実装時の注意 (Notes)
- リプレイ精度:
  `Metadata` にシードや制約ハッシュ等の再現補助情報を保持することで再実行精度を高められます。
- 直列化容易性:
  永続化・監査連携のため、実装DTOは安定したJSON直列化を前提に設計してください。
---

# 変更履歴
- v0.0.0 / v0.0.0.0: 初期ドラフト
- v0.0.1 (2026-05-06): ドキュメント規約に基づくバージョン更新
