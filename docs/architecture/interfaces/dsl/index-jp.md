---
title: "dsl Interfaces"
created: 2026-06-04
updated: 2026-06-04
published: 2026-06-04
version: "0.0.4"
edition: "Draft"
status: "Refactor"
issuer: ai-kernel@aikernel.net
maintainer: "拓也（AIKernel プロジェクト メンテナー）"
tags:
  - aikernel
  - architecture
  - interfaces
  - dsl
  - japanese
---

英語版: [dsl/index.md](index.md)

# dsl Interfaces

## 1. 責務境界
DSL contract は、AI が生成した JSON plan を governed pipeline へ compile するための
決定論的 Semantic IR と host boundary を定義する。これは contract のみであり、
parse、validation、ResultStep 展開、provider 実行は implementation 側の責務である。

## 2. 公開 Contract
- `IDslPipelineCompiler`
- `IDslCapabilityRegistry`
- `IKernelPipeline`
- `IDslRomRegistry`
- `IDslRomStore`

## 3. DTO Surface
- `DslDocument`
- `PipelineNode` と具体 node record
- `DslPipelineValue`
- `DslPipelineState`
- `DslPipelineExecutionContext`
- `DslPipelineExecutionResult`
- `DslRomMetadata`
- `DslRomSnapshot`

## 4. 関連 Spec
- `docs/architecture/18.DSL_PIPELINE_AND_ROM_SPEC-jp.md`
- `docs/operations/MIGRATION_GUIDE-jp.md`

## 境界ルール
- `AIKernel.Abstractions.Dsl` は `AIKernel.Core` や `AIKernel.Common` に依存してはならない。
- Core は内部の `Result<T>` / `ResultStep<TState,TValue>` を package 境界でこれらの DTO contract へ adapter してよい。
- DSL ROM 公開は caller が渡す Vfs session を使う。runtime 実装は contract の背後に writable global state を隠してはならない。

---

# 変更履歴
- v0.0.4 (2026-06-04): package-public contract のため DSL interface category を追加。
