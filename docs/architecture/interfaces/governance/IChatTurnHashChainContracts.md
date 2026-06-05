---
title: "IChatTurn HashChain Contracts"
created: 2026-06-04
updated: 2026-06-05
published: 2026-06-04
version: "0.0.5"
edition: "Draft"
status: "Refactor"
issuer: ai-kernel@aikernel.net
maintainer: "Takuya (AIKernel Project Maintainer)"
tags:
  - aikernel
  - architecture
  - interfaces
  - governance
  - english
---

Japanese version: [IChatTurn HashChain Contracts](IChatTurnHashChainContracts-jp.md)

# IChatTurn HashChain Contracts

## 1. Responsibility Boundary
The ChatChain contracts define the deterministic governance boundary for chat-turn replay evidence:

- `IChatTurn` captures the actor, body, and timestamp of one conversational turn.
- `IHashChainNode` links a turn to `PrevHash`, `Hash`, and an optional signature.
- `IChatTurnCanonicalizer` converts a turn into deterministic canonical content.
- `IChatTurnSemanticHasher` computes the next hash from canonical content and the previous hash.
- `IChatTurnSignatureProvider` signs and verifies turn hashes.
- `IChatTurnChainVerifier` validates chain continuity and fail-closed acceptance.
- `IChatTurnVerificationResult` reports success or the rejection reason.

These interfaces are governance contracts only. They do not own storage, provider execution, prompt generation, or UI state.

## 2. Governance Flow
Chat-turn governance follows a fixed order:

1. Canonicalize the turn with `IChatTurnCanonicalizer`.
2. Compute the semantic hash with `IChatTurnSemanticHasher`.
3. Attach the hash to `IHashChainNode` with the previous tail hash.
4. Optionally sign the hash with `IChatTurnSignatureProvider`.
5. Verify continuity and signature acceptance with `IChatTurnChainVerifier`.

Verification must fail closed. A malformed chain, mismatched previous hash, invalid signature, or policy rejection is represented by `IChatTurnVerificationResult.IsSuccess = false` and a non-empty `Error` when available.

## 3. Determinism Rules
- Canonicalization must be stable for equivalent `IChatTurn` values.
- Hashing must depend only on canonical content and the previous hash.
- Verification must not introduce hidden state or provider-specific behavior.
- Signatures should use algorithm-tagged formats when encoded outside the interface boundary.

## 4. Dependency Boundary
- Depends on: `System`, `System.Collections.Generic`, `System.Threading`, `System.Threading.Tasks`.
- Called by: governance validators, replay-log verifiers, and chat-history ROM pipelines.
- Must not depend on: Core executor implementations, provider implementations, VFS implementations, or hosting-specific services.

## 5. Migration Notes
v0.0.4 introduced specific names for the ambiguous ChatChain contracts, and v0.0.5 removes the legacy ambiguous interface names from the package surface:

- `AIKernel.Abstractions.Governance.ChatChain.IResult` -> `IChatTurnVerificationResult`
- `AIKernel.Abstractions.Governance.ChatChain.ISemanticHasher` -> `IChatTurnSemanticHasher`

Use the specific ChatChain names when integrating deterministic replay or chat-history ROM validation. Do not consume or reintroduce the legacy `IResult` or `ISemanticHasher` names inside the ChatChain namespace.

---

# Changelog
- v0.0.4 (2026-06-04): Added ChatChain governance contract documentation.
- v0.0.5 (2026-06-05): Clarified removal of the legacy ambiguous ChatChain interface names.
