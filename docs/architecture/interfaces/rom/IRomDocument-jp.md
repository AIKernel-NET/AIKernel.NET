---
title: 'IRomDocument'
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

英語版は [IRomDocument.md](./IRomDocument.md) を参照。

# IRomDocument (ROM ドキュメント仕様)

## 1. 責務の境界 (Responsibility Boundary)
`IRomDocument` は、Relation-Oriented Markdown (ROM) を人間可読かつ機械検証可能な不変知能資産として扱うための基底インターフェースです。

- 役割:
  ID/型/本文/メタデータ/関係参照を一貫公開し、セマンティックハッシュと正準化への入口を提供します。
- 非役割:
  物理I/Oや保存媒体管理は責務外であり、論理ドキュメント性質の表現に集中します。

## 2. 契約シグネチャ (Signature)
```csharp
namespace AIKernel.Abstractions.Rom;

/// <summary>
/// Relation-Oriented Markdown (ROM) ドキュメントの抽象化。
/// RCS-001: ROM 文書は entity.id と entity.type を持たなければならない（MUST）。
/// RCS-002: [[id]] は解決可能な参照でなければならない（MUST）。
/// </summary>
public interface IRomDocument
{
    /// <summary>
    /// エンティティの ID。
    /// RCS-001: entity.id 必須。
    /// </summary>
    string EntityId { get; }

    /// <summary>
    /// エンティティの型。
    /// RCS-001: entity.type 必須。
    /// </summary>
    string EntityType { get; }

    /// <summary>
    /// ROM ドキュメントのバージョン。
    /// SGS-006 の署名対象に含まれる。
    /// </summary>
    string Version { get; }

    /// <summary>
    /// 本文（Markdown）。
    /// RCS-003: 事実は bullet 形式で宣言的に記述される。
    /// </summary>
    string Body { get; }

    /// <summary>
    /// YAML front matter のメタデータ。
    /// </summary>
    IReadOnlyDictionary<string, string> Metadata { get; }

    /// <summary>
    /// ドキュメント内に含まれるすべての関係参照（[[id]]）。
    /// RCS-002: 参照可能性の検証に用いる。
    /// </summary>
    IReadOnlyList<string> RelationReferences { get; }

    /// <summary>
    /// セマンティックハッシュを取得します。
    /// RCS-004: 正規化後の Semantic Hash を算出できなければならない（MUST）。
    /// </summary>
    /// <returns>ハッシュ値（例: "sha256:a1b2c3d4..."）</returns>
    Task<string> GetSemanticHashAsync();

    /// <summary>
    /// ドキュメントを正規化された形式に変換します。
    /// RCS-004 の正規化処理（Linguistic, Structural, Reference Anchoring）。
    /// </summary>
    /// <returns>正規化されたドキュメント表現</returns>
    Task<CanonicalizedRomDto> CanonicalizeAsync();
}
```

## 3. 関連ユースケース (Related UCs)
- `UC-01` ROM 構造のロードと解析:
  ROM資産をカーネルで解釈可能な形へ引き渡します。
- `UC-13` 実行時署名検証とガバナンス:
  `GetSemanticHashAsync()` により改ざん検知の基盤を提供します。
- `UC-15` コンテキスト・ハイドレーション:
  `RelationReferences` を辿り関連資産を構成します。

## 4. 統治上の制約 (Governance Rules)
- `RCS-001` Identity:
  `EntityId` / `EntityType` 欠落文書は fail-closed で拒否対象です。
- `RCS-002` Integrity:
  未解決参照を含む場合は整合性欠如として扱います。
- `RCS-004` Invariance:
  `CanonicalizeAsync()` は意味同一入力から同一正準結果を返す必要があります。

## 5. 例外契約 (Exception Contract)
本インターフェース自体は例外型を固定しません。実装では以下の失敗類型を明示することが推奨されます。

- 必須属性欠落:
  ID/型/バージョン等の構造要件不備。
- ハッシュ/正準化失敗:
  構文破損や非対応形式により検証不能な場合。

## 6. 実装時の注意 (Notes)
- バイリンガル運用:
  `-jp.md` と `.md` の対文書では `EntityId` 同一性を維持してください。
- 参照抽出:
  `[[id]]` 構文を漏れなく `RelationReferences` に反映し、解決可能性検証へ接続してください。
---

# 変更履歴
- v0.0.0 / v0.0.0.0: 初期ドラフト
- v0.0.1 (2026-05-06): ドキュメント規約に基づくバージョン更新
