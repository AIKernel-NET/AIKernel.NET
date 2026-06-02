---
title: 'IRomDocument'
created: 2026-05-06
updated: 2026-05-16
published: 2026-05-16
version: "0.0.2"
edition: "Draft"
status: "Refactor"
issuer: ai-kernel@aikernel.net
maintainer: "Takuya (AIKernel Project Maintainer)"
tags:
  - aikernel
  - architecture
  - interfaces
  - english
---

For Japanese version, see [IRomDocument-jp.md](./IRomDocument-jp.md).

# IRomDocument (ROM Document Specification)

## 1. Responsibility Boundary
`IRomDocument` is the core contract for treating Relation-Oriented Markdown (ROM) as human-readable yet machine-verifiable invariant intelligence assets.

- Role:
  Expose identity/type/body/metadata/references and provide canonicalization/hash entry points.
- Non-role:
  Physical storage I/O is out of scope; this interface models logical document properties.

## 2. Contract Signature
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

## 3. Related Use Cases
- `UC-01` ROM loading and parsing:
  Supplies structurally valid ROM assets to kernel pipelines.
- `UC-13` Runtime signature verification and governance:
  `GetSemanticHashAsync()` underpins tamper detection and trust checks.
- `UC-15` Context hydration:
  Uses `RelationReferences` to recursively compose contextual assets.

## 4. Governance Rules
- `RCS-001` Identity:
  Missing `EntityId`/`EntityType` should fail closed.
- `RCS-002` Integrity:
  Unresolvable relation references indicate integrity failure.
- `RCS-004` Invariance:
  `CanonicalizeAsync()` must return stable canonical output for semantically identical input.

## 5. Exception Contract
This interface does not hard-code exception types. Implementations should clearly surface:

- Missing required attributes:
  Identity/type/version structural violations.
- Hash/canonicalization failures:
  Malformed or unsupported ROM representations.

## 6. Implementation Notes
- Bilingual asset discipline:
  Keep shared `EntityId` consistency between `-jp.md` and `.md` counterparts.
- Reference extraction:
  Ensure `[[id]]` references are fully materialized in `RelationReferences` for resolver checks.
---

# Changelog
- v0.0.0 / v0.0.0.0: Initial draft
- v0.0.1 (2026-05-06): Version upgrade aligned with documentation guidelines
