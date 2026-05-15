---
title: 'IRomValidator'
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

英語版は [IRomValidator.md](./IRomValidator.md) を参照。

# IRomValidator (ROM バリデーター仕様)

## 1. 責務の境界 (Responsibility Boundary)
`IRomValidator` は、ROM資産が RCS 系規約に適合しているかを検査し、不完全な知能資産の実行流入を遮断する品質保証ゲートです。

- 役割:
  スキーマ、リンク解決性、型一貫性、循環参照を検証します。
- 非役割:
  正準化・署名照合・物理I/Oは他コンポーネント責務です。

## 2. 契約シグネチャ (Signature)
```csharp
namespace AIKernel.Abstractions.Rom;

/// <summary>
/// ROM バリデーターの契約。
/// RCS-F002: リンク未解決時は推論入力を拒否。
/// RCS-F004: Type Consistency の検証。
/// RCS-F005: Circular Reference Guard。
/// </summary>
public interface IRomValidator
{
    /// <summary>
    /// ROM ドキュメントのスキーマを検証します。
    /// RCS-001: 必須項目 (entity.id, entity.type, version) の存在確認。
    /// RCS-F001: 必須 ID 欠落時は ROM 無効。
    /// </summary>
    /// <param name="document">検証対象の ROM ドキュメント</param>
    /// <param name="cancellationToken">キャンセルトークン</param>
    /// <returns>スキーマ検証結果</returns>
    Task<AIKernel.Dtos.Rom.RomSchemaValidationResult> ValidateSchemaAsync(
        IRomDocument document,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// ROM ドキュメント内の関係参照（[[id]]）がすべて解決可能であることを検証します。
    /// RCS-002: [[id]] は解決可能な参照でなければならない（MUST）。
    /// RCS-F002: リンク未解決時は推論入力を拒否。
    /// </summary>
    /// <param name="document">検証対象の ROM ドキュメント</param>
    /// <param name="relationResolver">関係解決サービス</param>
    /// <param name="cancellationToken">キャンセルトークン</param>
    /// <returns>リンク検証結果</returns>
    Task<AIKernel.Dtos.Rom.RomLinkageValidationResult> ValidateLinkageAsync(
        IRomDocument document,
        IRelationResolver relationResolver,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Type Consistency を検証します。
    /// RCS-F004: entity.type とプロパティ定義が矛盾する場合、入力を拒否。
    /// 必須プロパティ欠落も含む。
    /// </summary>
    /// <param name="document">検証対象の ROM ドキュメント</param>
    /// <param name="typeSchema">型スキーマ定義</param>
    /// <param name="cancellationToken">キャンセルトークン</param>
    /// <returns>型一貫性検証結果</returns>
    Task<AIKernel.Dtos.Rom.RomTypeConsistencyResult> ValidateTypeConsistencyAsync(
        IRomDocument document,
        AIKernel.Dtos.Rom.EntityTypeSchema typeSchema,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// 循環参照を検出します。
    /// RCS-F005: Circular Reference Guard - 循環参照が推論ループを誘発する場合、停止しなければならない。
    /// </summary>
    /// <param name="document">検証対象の ROM ドキュメント</param>
    /// <param name="relationResolver">関係解決サービス</param>
    /// <param name="maxDepth">探索の最大深度（無限ループ防止）</param>
    /// <param name="cancellationToken">キャンセルトークン</param>
    /// <returns>循環参照検出結果</returns>
    Task<AIKernel.Dtos.Rom.CircularReferenceDetectionResult> DetectCircularReferencesAsync(
        IRomDocument document,
        IRelationResolver relationResolver,
        int maxDepth = 10,
        CancellationToken cancellationToken = default);
}
```

## 3. 関連ユースケース (Related UCs)
- `UC-01` ROM 構造ロードと解析:
  ロード直後の初期品質ゲートとして機能します。
- `UC-15` コンテキスト・ハイドレーション:
  参照整合性を保証して推論前提を安定化します。
- `UC-12` 参照整合検証:
  動的リンク妥当性を事前確認します。

## 4. 統治上の制約 (Governance & Determinism)
- 決定論的検証:
  同一ドキュメント・同一リゾルバ状態・同一スキーマで同一判定を返す必要があります。
- Fail-Closed:
  `IsValid=false` 相当結果時は当該ROMを実行系に流してはなりません。
- 深度制限:
  `maxDepth` は計算量爆発と無限追跡を防ぐ安全装置として機能します。

## 5. 例外契約 (Exception Contract)
本インターフェース自体は例外型を固定しません。実装では以下の失敗類型を明示することが推奨されます。

- 規約重大違反:
  実行継続不能な構造欠陥を検知した場合。
- 検証中断:
  タイムアウトやキャンセル要求により検証不能となった場合。

## 6. 実装時の注意 (Notes)
- 部分検証戦略:
  段階検証は許容されますが、推論開始前に最終総合Passが必要です。
- 動的スキーマ:
  ドメイン/バージョン別 `EntityTypeSchema` 切替に耐えるルックアップ設計を推奨します。
---

# 変更履歴
- v0.0.0 / v0.0.0.0: 初期ドラフト
- v0.0.1 (2026-05-06): ドキュメント規約に基づくバージョン更新
