---
title: "用語集"
lang: ja
description: "AIKernel.NET 0.1.3 の主要用語と哲学由来の概念語彙を、日本語定義、英語定義、カタカナ発音、ローマ字表記つきで整理します。"
tags: [AIKernel, AIKernel.NET, v0.1.3]
category: glossary
source: "generated-from-repository-inventory"
generated: true
release: "0.1.3"
updated: "2026-06-17"
---

# 用語集

## 概要

このページは AIKernel.NET の主要用語を日本語で確認するための用語集です。英語ページと対になる日本語ページとして、各用語の意味、関連ページ、発音をまとめます。

## 基本用語

| Term | カタカナ | Romaji | 日本語定義 | English definition | Related page |
|---|---|---|---|---|---|
| Kernel | カーネル | kaaneru | Core が所有する runtime facade と execution boundary。 | Runtime facade and execution boundary owned by Core. | [Kernel](/docs/concepts/kernel/) |
| Provider | プロバイダー | purobaidaa | model、capability、platform、service behavior の extension boundary。 | Extension boundary for model, capability, platform, or service behavior. | [Providers](/docs/providers/provider-model/) |
| Tool | ツール | tsuuru | inspection、replay、CLI、ROM workflow のための developer / operations surface。 | Developer or operations surface around inspection, replay, CLI, and ROM workflows. | [Tools](/docs/tools/tool-model/) |
| Runtime | ランタイム | rantaimu | contracts、Core、providers、control evidence、tools をまたぐ execution flow。 | Execution flow spanning contracts, Core, providers, control evidence, and tools. | [Runtime](/docs/runtime/) |
| Wasm | ワズム | wazumu | browser / WebAssembly isolation の package family。 | Browser/WebAssembly isolation package family. | [Wasm](/docs/wasm/runtime/) |
| Doom | ドゥーム | duumu | provider、WASM、consent、perception boundary を検証する official demo。 | Official demo that validates provider, WASM, consent, and perception boundaries. | [Doom Demo](/docs/doom/demo-overview/) |
| CTG | シーティージー | shiitii jii | trajectory governance の evidence / decision surface。 | Canonical Trajectory Governance evidence and decision surface. | [Control](/docs/runtime/error-handling/) |
| Capability | ケイパビリティ | keipabiriti | routing、invoke、inspect、governance の対象になる package-exposed operation boundary。 | Package-exposed operation boundary that can be routed, invoked, inspected, or governed. | [Extensions](/docs/concepts/extensions/) |


## 哲学由来の概念語彙

以下の語彙は `docs/canonical-language/index.md` で定義されている concept-layer naming dictionary に基づきます。日本語ページでは、読みをカタカナとローマ字で併記します。

| Term | カタカナ | Romaji | 日本語定義 | English definition | Status |
|---|---|---|---|---|---|
| Ethos | エトス | etosu | 習慣、性格、道徳的気風。AIKernel では倫理・安全・規範の概念層を指す。 | Habit, character, and moral disposition; the concept layer for ethics, safety, and norms. | Core Concept |
| Pathos | パトス | patosu | 感情、情念、受動的経験。危険・直感・異常検知の概念層を指す。 | Emotion, passion, and passive experience; the concept layer for risk signals, intuition, and anomaly detection. | Core Concept |
| Logos | ロゴス | rogosu | 言葉、論理、理性、真理。論理・整合性・検証の概念層を指す。 | Word, logic, reason, and truth; the concept layer for logical consistency and verification. | Core Concept |
| Nomos | ノモス | nomosu | 法律、規則、慣習。ROM、Canon、Rule の概念層を指す。 | Law, rule, and convention; the concept layer for ROM, canon, and rules. | Core Concept |
| Dike | ディケー | dikee | 正義、秩序、裁判。正義・秩序・安全性の概念層を指す。 | Justice, order, and judgment; the concept layer for justice, order, and safety. | Core Concept |
| Aisthesis | アイステーシス | aisuteeshisu | 感覚、知覚、生の感覚与件。生データと observation の概念層を指す。 | Sensation, perception, and raw sense data; the concept layer for raw observations. | Core Concept |
| Phantasia | ファンタシア | fantashia | 表象、想像力、心像。Scene Graph と内的世界モデルの概念層を指す。 | Representation, imagination, and mental image; the concept layer for scene graphs and inner world models. | Core Concept |
| Chronos | クロノス | kuronosu | 連続的・客観的・物理的な時間。Buffer、Window、Replay Timeline の概念層を指す。 | Continuous, objective, physical time; the concept layer for buffers, windows, and replay timelines. | Core Concept |
| Kairos | カイロス | kairosu | 主観的・質的な時間、好機。Trigger と最適タイミングの概念層を指す。 | Qualitative time and the opportune moment; the concept layer for triggers and timing policy. | Core Concept |
| Telos | テロス | terosu | 目的、終局、究極の目標。Goal、Intent、Objective の概念層を指す。 | End, purpose, and ultimate goal; the concept layer for goals, intent, and objectives. | Core Concept |
| Eidos | エイドス | eidosu | 形相、本質、もののかたち。Concept、Graph、Type の概念層を指す。 | Form, essence, and shape; the concept layer for concepts, graphs, and types. | Core Concept |
| Kratos | クラトス | kuratosu | 権力、支配、実行力。Action authority / executor の将来語彙。 | Power, rule, and executive force; reserved vocabulary for action authority and executors. | Reserved Vocabulary |
| Dynamis | デュナミス | dyunamisu | 潜勢力、可能態。Embedding や latent space の将来語彙。 | Potentiality and capability; reserved vocabulary for embeddings and latent space. | Reserved Vocabulary |
| Energeia | エネルゲイア | enerugeia | 現実態、活動。Action / Execution の将来語彙。 | Actuality and activity; reserved vocabulary for action and execution. | Reserved Vocabulary |
| Nous | ヌース | nuusu | 知性、理性、宇宙の精神。Supervisor / Planner の将来語彙。 | Intellect and reason; reserved vocabulary for supervisors and planners. | Reserved Vocabulary |
| Apatheia | アパテイア | apateia | 情念に支配されない状態。Normalizer / Stabilizer の将来語彙。 | Freedom from domination by passions; reserved vocabulary for normalization and stabilization. | Reserved Vocabulary |
| Ataraxia | アタラクシア | atarakushia | 魂の平静、乱されない心。SafeMode / Fallback の将来語彙。 | Calm and undisturbed state; reserved vocabulary for safe mode and fallback. | Reserved Vocabulary |

## 運用メモ

- 哲学語は概念層に属し、DTO、Request、Result、Mapper、Adapter、Serializer、Converter、HttpClient、JSInterop、NativeBridge、provider implementation 名には使いません。
- Ethos / Pathos / Logos は既に CTG council term として canonical です。この用語集は概念層での読み方と使い方を整理し、CTG contract を再定義しません。
- Reserved Vocabulary は、対象 repository に migration notes と architecture tests が用意されるまで実装コードへ導入しません。

## 関連ページ

- [Canonical Language Dictionary](/docs/canonical-language/)
- [Concepts](/docs/concepts/)
- [Reference](/reference/)
