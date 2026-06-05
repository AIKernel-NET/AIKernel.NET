---
title: "HATL Interface Contracts"
created: 2026-06-05
updated: 2026-06-05
published: 2026-05-16
version: "0.0.5"
edition: "Draft"
status: "Refactor"
issuer: ai-kernel@aikernel.net
maintainer: "拓也（AIKernel プロジェクト メンテナー）"
tags:
  - aikernel
  - interfaces
  - hatl
  - japanese
---

English version: [Index](index.md)

# HATL Interface Contracts

HATL contract は、Hash-Anchored Trust Layer の ledger、anchor、deed、外部 cryptographic operator 統合の package 境界を定義します。
AIKernel.NET は cryptography、key handling、ratchet、Merkle proof、public-anchor publication logic を実装しません。

## Contract Surface

| Contract | 責務 |
|---|---|
| `IHatlLedgerStore` | HATL micro-ledger entry を append / read する。 |
| `IHatlAnchorPublisher` | runtime/provider 境界から public anchor document を publish する。 |
| `IHatlAnchorVerifier` | public anchor document と ledger-entry inclusion proof を検証する。 |
| `IHatlDigitalDeedResolver` | governed identity の Digital Deed status を解決・検証する。 |
| `IHatlCryptographicOperator` | BlockMAC、ratchet advancement、anchor-signature verification を AIKernel.RH ベース module などの外部 cryptographic operator へ委譲する。 |

## DTO Ownership

HATL DTO は `AIKernel.Dtos.Hatl` が所有します。
共有 HATL enum primitive は `AIKernel.Enums` が所有します。
runtime cryptographic implementation は `AIKernel.Abstractions` ではなく、外部 operator/provider package が所有します。

## External Crypto Boundary

`IHatlCryptographicOperator` は意図的に capability 境界です。
Core または host application は、AIKernel.RH ベース native module、hardware-backed crypto provider、または監査済み operator をこの境界に bind できます。

contract surface が運ぶのは hash、MAC、commitment、anchor document、receipt、verification outcome、metadata のみです。
raw secret、mutable key material、secret-erasure behavior はこの repository 外の runtime concern です。

## ResultStep / LINQ Boundary

HATL contract は、意図的に `Result<T>` や `ResultStep<TState, TValue>` ではなく DTO ベースの `ValueTask` result を返します。
これにより、`AIKernel.Abstractions` は `AIKernel.Common` および Core runtime package から独立したままになります。

Monad LINQ composition が必要な Core 実装は、Core 側で `IHatlCryptographicOperator` を adapter で包んでください。
その adapter が、HATL DTO outcome を fail-closed な `Result<T>` または `ResultStep<TState, TValue>` へ変換し、`SemanticDelta`、replay metadata、`hatl_anchor_id` や `hatl_merkle_root_hash` などの HATL metadata key を付与します。

---

# 変更履歴
- v0.0.5 (2026-06-05): HATL external cryptographic operator と Core/Common LINQ adapter の境界を明確化。
