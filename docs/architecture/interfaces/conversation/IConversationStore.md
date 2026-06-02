---
id: iconversationstore
title: "IConversationStore"
created: 2026-05-03
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

Japanese version: [IConversationStore](architecture/interfaces/conversation/IConversationStore-jp.md)

# IConversationStore

## 1. Overview
`IConversationStore` is the abstraction layer responsible for persisting conversation history (message sets) and execution state in AIKernel.NET.  
It is not only a storage interface: based on RDS (Replay/Resource Data Spec), it must preserve the metadata set required for deterministic replay at a later time.

## 2. Design Principles
- Immutability (MRS linkage): persisted message resources are non-tamperable and traceable by stable identifiers.
- Deterministic Traceability: message payload must be stored together with `Seed`, `Temperature`, and `RCS-ID` (tool/contract version context).
- Fail-Closed Retrieval: checksum mismatch or broken trust/signature chain must reject load and stop execution.

## 3. Signature
| Member | Type | Description |
| --- | --- | --- |
| `SaveSnapshotAsync(IConversationSnapshot snapshot, CancellationToken ct = default)` | `Task` | Persist conversation snapshot. |
| `GetSnapshotAsync(string snapshotId, CancellationToken ct = default)` | `Task<IConversationSnapshot?>` | Load snapshot by id. |
| `ListBranchesAsync(CancellationToken ct = default)` | `Task<IReadOnlyList<IConversationBranch>>` | Enumerate branches. |
| `DeleteSnapshotAsync(string snapshotId, CancellationToken ct = default)` | `Task` | Delete snapshot by id. |

## 4. Related Use Cases
See ../../use-cases/AIKernel_UseCaseCatalog.md for references where IConversationStore appears.

## 5. Spec Links
- [04.MODEL_ROUTING_SPEC.md](../../../specs/04.MODEL_ROUTING_SPEC.md) / `MRS-001`, `MRS-004`  
  Message identity and routing-rationale auditability must remain stable across persistence/reload.
- [02.SIGNED_PROMPT_GOVERNANCE_SPEC.md](../../../specs/02.SIGNED_PROMPT_GOVERNANCE_SPEC.md) / `SGS-006`  
  Trust-chain validation (signer/key state) must remain consistent on reload.
- [06.REPLAY_DUMP_SPEC.md](../../../specs/06.REPLAY_DUMP_SPEC.md) / `RDS-001`, `RDS-002`  
  Replay requires mandatory metadata and hash-resolvable references.

## 6. Constraints
- Persisted entries must keep semantic consistency and hash stability.
- If even one bit is inconsistent on load, execution must stop with deterministic replay integrity failure.
- Identical input and ordering must yield identical retrieval ordering to preserve deterministic replay.
---

# Changelog
- v0.0.0 / v0.0.0.0: Initial draft
- v0.0.1 (2026-05-06): Version upgrade aligned with documentation guidelines
