---
version: 0.0.0
issuer: ai-kernel@tkysoftware.xsrv.jp
title: "AIKernel Architecture — Index"
created: 2026-04-30
tags:
  - aikernel
  - architecture
  - index
---

# AIKernel Architecture Index
AIKernel.NET のアーキテクチャ思想を体系的にまとめたドキュメント群への入口。

AIKernel は「AI アプリケーションの OS」を目指すフレームワークであり、  
その中心思想は **情報カテゴリ分離・前処理中心・Attention 汚染防止・推論と表現の分離** にある。

この index は、AIKernel の設計原則・理論背景・構造比較を理解するためのガイドとして機能する。

---

# 1. Core Architectural Principles

## 1.1 情報カテゴリ分離の原則
**ファイル:** `CATEGORY_SEPARATION_PRINCIPLES.md`

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
> — CATEGORY_SEPARATION_PRINCIPLES.md より

---

## 1.2 コンテキスト隔離仕様
**ファイル:** `CONTEXT_ISOLATION_SPEC.md`

AIKernel は LLM に渡す前に情報を **Orchestration / Expression / Material** の 3 層に分離する。

- **OrchestrationContext**（推論）
- **ExpressionContext**（表現）
- **MaterialContext**（素材）

例・文体・RAG の断片は推論に混ぜてはならない。

---

## 1.3 Attention 汚染理論
**ファイル:** `ATTENTION_POLLUTION_THEORY.md`

LLM の推論能力は attention の純度に依存する。  
例・文体模倣・RAG の断片・履歴が混ざると attention が表面構造に吸われ、推論が停止する。

> 「attention が表面構造に吸われると、推論は停止し、表面模写モードに落ちる。」  
> — ATTENTION_POLLUTION_THEORY.md より

---

## 1.4 表面模写モードの危険性
**ファイル:** `LLM_SURFACE_MODE_FAILURE.md`

例を見ると LLM は「推論しないモード」に落ちる。  
これは AIKernel が例を隔離する理由のひとつ。

---

## 1.5 Preprocessing vs Prompting
**ファイル:** `PREPROCESSING_VS_PROMPTING.md`

プロンプト設計よりも **前処理の構造化** が本質。  
何を attention に乗せ、何を隔離するかが推論精度を決める。

---

# 2. Comparative Architecture

## 2.1 AIKernel vs LangChain
**ファイル:** `AIKERNEL_VS_LANGCHAIN.md`

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
**ファイル:** `../design/DESIGN_INTENT.md`

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

1. CATEGORY_SEPARATION_PRINCIPLES  
2. CONTEXT_ISOLATION_SPEC  
3. ATTENTION_POLLUTION_THEORY  
4. LLM_SURFACE_MODE_FAILURE  
5. PREPROCESSING_VS_PROMPTING  
6. AIKERNEL_VS_LANGCHAIN  
7. DESIGN_INTENT（設計意図）

---

# 6. 最後に

AIKernel のアーキテクチャは「偶然うまくいく」ものではなく、  
**構造的に正しく動くために設計された OS 的アプローチ**である。

この index はその全体像を理解するための入口である。

