---
title: "AIKernel Paper Implementation Status"
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
  - architecture
  - papers
  - implementation-status
  - japanese
---

English version: [Paper Implementation Status](PAPER_IMPLEMENTATION_STATUS.md)

# AIKernel Paper Implementation Status

この文書は、DOI 付き論文シリーズが現在の package surface にどこまで反映されているかを追跡します。
Zenodo 管理対象である `docs/papers` 配下の論文本体は変更しません。

## Scope

`AIKernel.NET` は contract package リポジトリです。
そのため、以下の状態を分けて扱います。

- **Contracted**: `AIKernel.Abstractions`、`AIKernel.Contracts`、`AIKernel.Dtos`、`AIKernel.Enums` に公開 interface / DTO / enum が存在する。
- **Runtime-owned elsewhere**: 振る舞いは `AIKernel.Core`、provider package、`AIKernel.RH`、`AIKernel.Tools`、host application が所有する。
- **Partial**: 一部の contract surface はあるが、論文モデル全体を公開 contract として表現しきってはいない。

## Status Matrix

| Paper | Topic | AIKernel.NET status | Runtime / next implementation owner |
|---|---|---|---|
| 01 | ROM Format & Knowledge Snapshot | **Contracted**。ROM DTO と `AIKernel.Abstractions.Rom` に反映済み。 | canonicalization、storage、signing、validation behavior は Core/runtime package が所有する。 |
| 02 | VFS Architecture & Semantic Storage | **Contracted**。`AIKernel.Abstractions` 内の公開 namespace `AIKernel.Vfs` に反映済み。個別の `AIKernel.Vfs` package/project は削除済み。 | 具象 VFS provider は Core/provider package が所有する。 |
| 03 | Pre-Inference Admissibility Governance | **Partially contracted**。PDP、Guard、prompt validation、policy evaluation、fail-closed DTO/enum、admissibility replay vocabulary（`AdmissibilityGateKind`、`AdmissibilityDecisionKind`、`AdmissibilityReplayRecord`）に反映済み。 | 完全な admission orchestration は Core/runtime package が所有する。 |
| 04 | Trajectory Governance Model | **Partially contracted**。attention observer/guard、lifecycle、governance stats、failure enum、DynamicSLM trajectory metadata、ReplayLog-compatible thought-artifact record に反映済み。 | semantic trajectory / ellipsoid runtime 全体と trajectory scoring は AIKernel.NET には未実装であり、Core/runtime package が所有する。 |
| 05 | Async Result Pipeline | **Intentionally not exposed**。AIKernel.NET では `Result<T>` を公開しない。boundary result は DTO として運ぶ。 | `AIKernel.Common` / Core が Result、Option、Either、ResultStep、LINQ composition、exception capture behavior を所有する。 |
| 06 | Semantic Compilation Architecture | **Partially contracted**。context、routing、DSL、pipeline、replay 関連 DTO/interface、および共有 `SemanticIrSlot` G/T/C/B vocabulary に反映済み。 | semantic compiler runtime と graph execution は Core/runtime package が所有する。 |
| 07 | Chat-Turn HashChain Governance | **Contracted**。専用 ChatChain governance interface と replay/hash DTO に反映済み。 | canonicalization、hashing、signature verification、quarantine、replay behavior は Core/runtime package が所有する。 |
| 08 | Operator Architecture | **Out of AIKernel.NET scope**。外部 capability/provider 統合 contract 以外は対象外。 | Lean/C/C# operator export と native execution は `AIKernel.RH` および host/native package が所有する。 |
| 09 | Hash-Anchored Trust Layer (HATL) | **Contract foundation added**。HATL ledger entry、anchor document、Digital Deed、verification result、外部 cryptographic operator interface を追加済み。 | cryptographic runtime、ratchet、Merkle proof construction、public-anchor publication、secret handling は AIKernel.RH ベース operator または監査済み Core/HATL module が所有する。 |
| 10 | Semantic DSL Compiler | **Contracted**。DSL IR、DSL ROM、capability registry、pipeline compiler、kernel pipeline、deterministic clock、History ROM contract に反映済み。 | JSON parsing、admissibility checking、ResultStep execution、ReplayLog hashing、suspend/resume runtime、DSL ROM execution は Core/runtime package が所有する。 |
| 11 | DynamicSLM | **Contracted for v0.0.5**。Model ABI、capability graph、compatibility、lineage、payload loading、scheduling、gap detection、graph evolution、distillation planning、offload job scheduling、fallback metadata、pipeline status DTO/enum、SeedSLM discipline / delegation / thought-artifact / memory-placement DTO に反映済み。 | model loading、accelerator placement、SeedSLM discipline enforcement、thought-artifact persistence、delegation execution、Teacher fallback execution、background distillation、artifact publication、self-improvement runtime は Core/provider package が所有する。 |

## Current Completion Summary

- Phase-1 の contract foundation は interface / DTO 境界として概ね存在する。
- runtime behavior は意図的にこのリポジトリの外に置いている。
- Paper 03、06、10、11 は、admission evidence、Semantic IR slot、DSL compilation、DynamicSLM / SeedSLM discipline の共有 contract vocabulary を公開する。ただし runtime behavior は AIKernel.NET へ移動しない。
- Paper 09 (HATL) は contract foundation を追加済み。ただし cryptographic runtime は外部に残す。
- Paper 05 は contract package へ露出せず、`AIKernel.Common` と Core に委譲する方針。

## Release Notes

- v0.0.5 (2026-06-05): 現在の AIKernel.NET package surface に対する paper-to-contract 実装状況を追加。
