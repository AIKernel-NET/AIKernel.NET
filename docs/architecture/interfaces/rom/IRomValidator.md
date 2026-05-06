---
version: 0.0.1
issuer: ai-kernel@tkysoftware.xsrv.jp
title: 'IRomValidator'
created: 2026-05-06
tags:
  - aikernel
  - architecture
  - interfaces
  - english
updated: 2026-05-06
---

For Japanese version, see [IRomValidator-jp.md](./IRomValidator-jp.md).

# IRomValidator (ROM Validator Specification)

## 1. Responsibility Boundary
`IRomValidator` verifies ROM assets against RCS governance constraints and blocks structurally unsafe intelligence assets before execution.

- Role:
  Validate schema, linkage resolvability, type consistency, and circular references.
- Non-role:
  Canonicalization, signature matching, and physical I/O are delegated elsewhere.

## 2. Contract Signature
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

## 3. Related Use Cases
- `UC-01` ROM loading and parsing:
  Serves as first quality gate after ROM load.
- `UC-15` Context hydration:
  Ensures reference completeness before context expansion.
- `UC-12` Reference integrity validation:
  Confirms dynamic link soundness pre-execution.

## 4. Governance & Determinism
- Deterministic validation:
  Same document/resolver/schema state must produce identical outcomes.
- Fail-Closed:
  Invalid ROM must be rejected from all execution pipelines.
- Depth guard:
  `maxDepth` prevents runaway traversal and pathological graph expansion.

## 5. Exception Contract
This interface does not hard-code exception types. Implementations should clearly expose:

- Critical validation violations:
  Structural failures that must stop execution.
- Validation interruption:
  Timeout/cancellation conditions preventing completion.

## 6. Implementation Notes
- Staged validation:
  Partial checks are acceptable only if full pass is guaranteed before inference starts.
- Dynamic schema lookup:
  Support domain/version-aware `EntityTypeSchema` resolution strategies.
---

# Changelog
- v0.0.0 / v0.0.0.0: Initial draft
- v0.0.1 (2026-05-06): Version upgrade aligned with documentation guidelines
