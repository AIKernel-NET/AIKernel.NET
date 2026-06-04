---
title: 'IMaterialContract'
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

Japanese version: [IMaterialContract](../contracts/IMaterialContract-jp.md)

# IMaterialContract

## Signature
```csharp
using AIKernel.Dtos.Context;

namespace AIKernel.Contracts;

/// <summary>
/// 素材（Material）契約を定義します。
/// RAG の断片や外部情報の取得・構造化を管理します。
/// 
/// 参照: 2.CONTEXT_ISOLATION_SPEC.jp.md
/// </summary>
public interface IMaterialContract
{
    /// <summary>
    /// 素材層のコンテキストを取得します。
    /// </summary>
    MaterialContextDto GetContext();

    /// <summary>
    /// 取得元ソースを取得します。
    /// </summary>
    string GetSource();

    /// <summary>
    /// 生のデータを取得します。
    /// </summary>
    string GetRawData();

    /// <summary>
    /// 正規化されたデータを取得します。
    /// 不要情報が除去されたバージョン。
    /// </summary>
    string? GetNormalizedData();

    /// <summary>
    /// 構造化されたデータを取得します。
    /// </summary>
    IReadOnlyDictionary<string, object>? GetStructuredData();

    /// <summary>
    /// 関連性スコアを取得します（0.0 ～ 1.0）。
    /// </summary>
    double GetRelevanceScore();
}
```

Normalization, structurization, essential-content extraction, canonicalization, hashing, and quarantine
validation are service responsibilities. Use `IMaterialNormalizer`, `IMaterialStructurizer`,
`IEssentialMaterialExtractor`, `IMaterialCanonicalizer`, `IMaterialHashProvider`, and
`IMaterialQuarantineValidator` instead of adding behavior to the contract object.

## Exception Contract
This interface does not mandate a specific thrown exception type by itself. Exception guarantees are implementation-defined.

## Determinism Note
N/A.
---

# Changelog
- v0.0.0 / v0.0.0.0: Initial draft
- v0.0.1 (2026-05-06): Version upgrade aligned with documentation guidelines
