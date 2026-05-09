---
version: 0.0.1
issuer: ai-kernel@tkysoftware.xsrv.jp
title: "AIKernel Architecture — Index"
created: 2026-04-30
updated: 2026-05-06
tags:
  - aikernel
  - architecture
  - index
  - japanese
---

# AIKernel Architecture Index
AIKernel.NET のアーキテクチャ思想を体系的にまとめたドキュメント群への入口。

AIKernel は「AI アプリケーションの OS」を目指すフレームワークであり、  
その中心思想は **情報カテゴリ分離・前処理中心・Attention 汚染防止・推論と表現の分離** にある。

この index は、AIKernel の設計原則・理論背景・構造比較を理解するためのガイドとして機能する。

---

# 1. Core Architectural Principles

## 1.1 情報カテゴリ分離の原則
**ファイル:** `1.CATEGORY_SEPARATION_PRINCIPLES-jp.md`

LLM に渡す情報は単一コンテキストに混在させてはならない。  
混在は attention を破壊し、推論を停止させ、表面模写モードを誘発する。

**カテゴリ例:**
- purpose（目的）
- constraints（制約）
- structure（抽象構造）
- history（履歴）
- rag_material（RAG 素材）
- expression（表現）
- metadata（メタ情報）

> 「LLM に渡す情報は、単一のコンテキストに混在させてはならない。」  
> — 1.CATEGORY_SEPARATION_PRINCIPLES.md より

---

## 1.2 コンテキスト隔離仕様
**ファイル:** `2.CONTEXT_ISOLATION_SPEC-jp.md`

AIKernel は LLM に渡す前に情報を **Orchestration / Expression / Material** の 3 層に分離する。

- **OrchestrationContext**（推論）
- **ExpressionContext**（表現）
- **MaterialContext**（素材）

例・文体・RAG の断片は推論に混ぜてはならない。

---

## 1.3 Attention 汚染理論
**ファイル:** `3.ATTENTION_POLLUTION_THEORY-jp.md`

LLM の推論能力は attention の純度に依存する。  
例・文体模倣・RAG の断片・履歴が混ざると attention が表面構造に吸われ、推論が停止する。

> 「attention が表面構造に吸われると、推論は停止し、表面模写モードに落ちる。」  
> — 3.ATTENTION_POLLUTION_THEORY.md より

---

## 1.4 表面模写モードの危険性
**ファイル:** `4.LLM_SURFACE_MODE_FAILURE-jp.md`

例を見ると LLM は「推論しないモード」に落ちる。  
これは AIKernel が例を隔離する理由のひとつ。

---

## 1.5 Preprocessing vs Prompting
**ファイル:** `5.PREPROCESSING_VS_PROMPTING-jp.md`

プロンプト設計よりも **前処理の構造化** が本質。  
何を attention に乗せ、何を隔離するかが推論精度を決める。

---

## 1.6 DI Composition and Pipeline Bootstrap
**ファイル:** `7.DI_COMPOSITION_AND_PIPELINE_BOOTSTRAP-jp.md`

AIKernel が DI でモデル選定、Provider 解決、パイプライン実行を合成する方法を定義する。
- `IServiceRegistrar` / `IProviderRegistrar`
- `IKernelModule` / `IKernelHost`
- `IModelVectorRouter` / `IProviderRouter` / `IModelProvider`
- `IPipelineOrchestrator` / `ITaskManager`

あわせて `IPromptVerifier` を Fail-Closed な起動ゲートとして規定する。

---

## 1.7 Execution Contract Architecture
**ファイル:** `8.EXECUTION_CONTRACT_ARCHITECTURE-jp.md`

`Structure -> Generation -> Polish` のフェーズ境界を定義し、推論層と表現層の越境を防止する。

---

## 1.8 PDP Guard Decision Plane
**ファイル:** `9.PDP_GUARD_DECISION_PLANE-jp.md`

統治責務を分離し、次の運用原則を強制する。
- LLM は提案
- PDP が決定

---

## 1.9 Dynamic Capacity Routing
**ファイル:** `10.DYNAMIC_CAPACITY_ROUTING-jp.md`

動的軸を含む能力ベクトル駆動ルーティングを定義する。
- `ModelCapacityVector`
- `IDynamicCapacityProvider`
- `IVectorMatcher`
- `IModelVectorRouter`

---

## 1.10 Material Quarantine Trust Model
**ファイル:** `11.MATERIAL_QUARANTINE_TRUST_MODEL-jp.md`

外部素材を推論経路へ投入する前の検疫・正規化・出典追跡の規則を定義する。

---

## 1.11 Semantic Memory Management Spec
**ファイル:** `12.SEMANTIC_MEMORY_MANAGEMENT_SPEC-jp.md`

トークン予算制約下での意味メモリ管理を定義する。
- 層別 purge/swap 優先度
- provenance を保持した要約
- コンテキスト圧迫時の Fail-Closed 条件

---

## 1.12 Capability Definition Schema
**ファイル:** `13.CAPABILITY_DEFINITION_SCHEMA-jp.md`

モデル/Provider のオンボーディングとルーティング整合性のため、能力次元と宣言スキーマを定義する。

---

## 1.13 Signed Prompt Governance Workflow
**ファイル:** `14.SIGNED_PROMPT_GOVERNANCE_WORKFLOW-jp.md`

Prompt Artifact 読み込みから実行可否判定までのシーケンスレベル Fail-Closed 検証を定義する。

---

## 1.14 Replayable Execution Dump Format
**ファイル:** `15.REPLAYABLE_EXECUTION_DUMP_FORMAT-jp.md`

決定論的リプレイダンプ構造（seed、hash 群、provider manifest、execution outcome chain）を定義する。

---

## 1.15 Semantic Context OS ビジョン
**ファイル:** `16.SEMANTIC_CONTEXT_OS_VISION-jp.md`

AIKernel の最終アーキテクチャ目標は **Semantic Context OS** であり、推論・素材・表現を独立統治する。

本章では次を中核要件として定義する。
- System Integrity Requirements（`SIR-001`〜`SIR-004`）
- Kernel 起動ステートマシン（Inactive -> Initializing -> Governing -> Ready -> Executing）
- 論理的整合性監査（Replay 固定 / PDP 推論隔離 / ROM 正準化）

この文書は、AIKernel を「AI を厳格なステートマシンと不変制約下に置く OS」として拘束する北極星である。

---

## 1.16 Phase 1 Query Processing
**ファイル:** `17.QUERY_PROCESSING_PHASE1-jp.md`

Query 補間・分解・意味空間化・query routing を Phase 1 Context Build の責務として定義する。

本章は RAG を Core の検索実装から切り離し、Query Processing を ROM、CacheDB、Material Quarantine、Governance と整合させる。

---

# 2. Comparative Architecture

## 2.1 AIKernel vs LangChain
**ファイル:** `6.AIKERNEL_VS_LANGCHAIN-jp.md`

LangChain の問題点：
- 全情報を単一コンテキストに混在
- RAG をそのまま渡す
- 例と履歴が混ざる
- attention が破壊される

AIKernel の特徴：
- 情報カテゴリ分離
- 推論層と表現層の分離
- 例の隔離
- RAG の素材化
- attention 汚染防止

> 「LangChain は“偶然うまくいく”構造。AIKernel は“構造的に正しく動く”アーキテクチャ。」

---

# 3. Architectural Philosophy

## 3.1 設計意図（Design Intent）
**ファイル:** `../design/DESIGN_INTENT-jp.md`

AIKernel の設計哲学：
- Markdown 第一主義（人間可読性）
- Core = 抽象 + Contracts（JSON Schema）
- Provider = Capability ベース
- LLM は提案者、PDP が決定者
- Pipeline = DAG
- PromptRules = 署名付き Markdown
- Deterministic Replay（再現性）

---

# 4. How to Use This Architecture Section

この `architecture/` ディレクトリは以下の目的で構成されている：

- AIKernel の思想を理解する  
- なぜカテゴリ分離が必要かを説明する  
- LangChain など他フレームワークとの構造的違いを明確化する  
- 実装（Core / Kernel / Providers）を読む前に前提知識を提供する  

AIKernel のコードを読む前に、この index と各ドキュメントを順番に読むことで、  
**AIKernel が「AI アプリケーションの OS」である理由**が理解できる。

---

# 5. 推奨読書順

注記: `17` までが `architecture/` 本編であり、`18` は設計文書（`/design/DESIGN_INTENT`）への参照番号として予約している。

1. CATEGORY_SEPARATION_PRINCIPLES  
2. CONTEXT_ISOLATION_SPEC  
3. ATTENTION_POLLUTION_THEORY  
4. LLM_SURFACE_MODE_FAILURE  
5. PREPROCESSING_VS_PROMPTING  
6. AIKERNEL_VS_LANGCHAIN  
7. DI_COMPOSITION_AND_PIPELINE_BOOTSTRAP  
8. EXECUTION_CONTRACT_ARCHITECTURE  
9. PDP_GUARD_DECISION_PLANE  
10. DYNAMIC_CAPACITY_ROUTING  
11. MATERIAL_QUARANTINE_TRUST_MODEL  
12. SEMANTIC_MEMORY_MANAGEMENT_SPEC  
13. CAPABILITY_DEFINITION_SCHEMA  
14. SIGNED_PROMPT_GOVERNANCE_WORKFLOW  
15. REPLAYABLE_EXECUTION_DUMP_FORMAT  
16. SEMANTIC_CONTEXT_OS_VISION  
17. QUERY_PROCESSING_PHASE1  
18. /design/DESIGN_INTENT（設計意図）

---

# 6. 最後に

AIKernel のアーキテクチャは「偶然うまくいく」ものではなく、  
**構造的に正しく動くために設計された OS 的アプローチ**である。

この index はその全体像を理解するための入口である。

---
---

# 変更履歴
- v0.0.0 / v0.0.0.0: 初期ドラフト
- v0.0.1 (2026-05-06): ドキュメント規約に基づくバージョン更新
