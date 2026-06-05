---
title: "HATL Interface Contracts"
created: 2026-06-05
updated: 2026-06-05
published: 2026-05-16
version: "0.0.5"
edition: "Draft"
status: "Refactor"
issuer: ai-kernel@aikernel.net
maintainer: "Takuya (AIKernel Project Maintainer)"
tags:
  - aikernel
  - interfaces
  - hatl
  - english
---

Japanese version: [Index](index-jp.md)

# HATL Interface Contracts

HATL contracts define the package boundary for Hash-Anchored Trust Layer ledger, anchor, deed, and external cryptographic operator integration.
AIKernel.NET does not implement cryptography, key handling, ratchets, Merkle proofs, or public-anchor publication logic.

## Contract Surface

| Contract | Responsibility |
|---|---|
| `IHatlLedgerStore` | Append and read HATL micro-ledger entries. |
| `IHatlAnchorPublisher` | Publish public anchor documents through a runtime/provider boundary. |
| `IHatlAnchorVerifier` | Verify public anchor documents and ledger-entry inclusion proofs. |
| `IHatlDigitalDeedResolver` | Resolve and verify Digital Deed status for governed identities. |
| `IHatlCryptographicOperator` | Delegate BlockMAC, ratchet advancement, and anchor-signature verification to an external cryptographic operator, such as an AIKernel.RH-backed module. |

## DTO Ownership

HATL DTOs are owned by `AIKernel.Dtos.Hatl`.
Shared HATL enum primitives are owned by `AIKernel.Enums`.
Runtime cryptographic implementations belong to external operator/provider packages, not to `AIKernel.Abstractions`.

## External Crypto Boundary

`IHatlCryptographicOperator` is intentionally a capability boundary.
It allows Core or host applications to bind an AIKernel.RH-based native module, hardware-backed crypto provider, or other audited operator without adding cryptographic implementation to AIKernel.NET.

The contract surface carries hashes, MACs, commitments, anchor documents, receipts, verification outcomes, and metadata only.
Raw secrets, mutable key material, and secret-erasure behavior are runtime concerns outside this repository.

---

# Changelog
- v0.0.5 (2026-06-05): Added HATL ledger, anchor, deed, and external cryptographic operator contract category.
