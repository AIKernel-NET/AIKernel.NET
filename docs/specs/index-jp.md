---
version: 0.0.0.0
issuer: ai-kernel@tkysoftware.xsrv.jp
title: "AIKernel Specs — Index"
created: 2026-05-04
updated: 2026-05-04
tags:
  - aikernel
  - specs
  - index
  - japanese
---

# docs/specs — Index（What / Contract）

このディレクトリは、AIKernel の実装・検証に直接使う「仕様契約（Spec Sheet）」を定義する。

## 概要
- `01.EXECUTION_PIPELINE_SPEC`: `Structure -> Generation -> Polish` の実行境界、不変性、ハッシュ連鎖を定義する。
- `02.SIGNED_PROMPT_GOVERNANCE_SPEC`: 署名検証、信頼連鎖、動的スコープ束縛を Fail-Closed で定義する。
- `03.ROM_CORE_SPEC`: ROM の最小文法、正規化、関係記法、整合性検証を定義する。
- `04.MODEL_ROUTING_SPEC`: 能力ベクトル、動的制約、ハードウェア適応を含むモデル選定を定義する。
- `05.MATERIAL_QUARANTINE_SPEC`: 素材検疫、TrustVector、再帰再投入ガードを定義する。
- `06.REPLAY_DUMP_SPEC`: 再現実行のためのダンプ構造、環境整合性、監査証跡を定義する。

## ドキュメント一覧
1. 01.EXECUTION_PIPELINE_SPEC-jp.md — Structure/Generation/Polish の実行契約
2. 02.SIGNED_PROMPT_GOVERNANCE_SPEC-jp.md — 署名統治と Fail-Closed 検証契約
3. 03.ROM_CORE_SPEC-jp.md — Relation-Oriented Markdown（ROM）の最小文法と検証規約
4. 04.MODEL_ROUTING_SPEC-jp.md — `IModelVectorRouter` と Capacity Vector の選定契約
5. 05.MATERIAL_QUARANTINE_SPEC-jp.md — `IMaterialQuarantine` による素材検疫契約
6. 06.REPLAY_DUMP_SPEC-jp.md — 決定論的再実行ダンプ契約

## 推奨読書順
1. EXECUTION_PIPELINE_SPEC
2. SIGNED_PROMPT_GOVERNANCE_SPEC
3. ROM_CORE_SPEC
4. MODEL_ROUTING_SPEC
5. MATERIAL_QUARANTINE_SPEC
6. REPLAY_DUMP_SPEC
