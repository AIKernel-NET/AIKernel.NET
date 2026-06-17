---
title: "Glossary"
lang: en
description: "AIKernel.NET 0.1.2 の Kernel、Provider、Tool、Runtime、Wasm、Doom、Control、Capability などの用語集です。"
tags: [AIKernel, AIKernel.NET, v0.1.2]
category: glossary
source: "generated-from-repository-inventory"
generated: true
release: "0.1.2"
updated: "2026-06-17"
---

# Glossary

## Summary

### EN

Glossary defines recurring AIKernel.NET terms, including the philosophical vocabulary from the canonical language dictionary, and links each term to the most relevant guide or Reference section.

### JA

Glossary は AIKernel.NET の主要用語と canonical language dictionary の哲学語彙を定義し、関連 guide や Reference へ接続します。

## Why

### EN

Shared terms prevent documentation pages from redefining the same concept inconsistently.

### JA

共有用語により、複数ページで同じ概念を別々に再定義して不整合になることを防ぎます。

## Usage

### EN

Use this page when a guide uses a domain term such as Provider, Tool, Capability, CTG, Wasm, Doom, Ethos, Pathos, Logos, Telos, or Kairos.

### JA

Provider、Tool、Capability、CTG、Wasm、Doom、Ethos、Pathos、Logos、Telos、Kairos などの domain term / concept term が出たときに参照します。

## Examples

| Term | English definition | Japanese definition | Related page |
|---|---|---|---|
| Kernel | Runtime facade and execution boundary owned by Core. | Core が所有する runtime facade と execution boundary。 | [Kernel](/docs/concepts/kernel/) |
| Provider | Extension boundary for model, capability, platform, or service behavior. | model、capability、platform、service behavior の extension boundary。 | [Providers](/docs/providers/provider-model/) |
| Tool | Developer or operations surface around inspection, replay, CLI, and ROM workflows. | inspection、replay、CLI、ROM workflow のための developer / operations surface。 | [Tools](/docs/tools/tool-model/) |
| Runtime | Execution flow spanning contracts, Core, providers, control evidence, and tools. | contracts、Core、providers、control evidence、tools をまたぐ execution flow。 | [Runtime](/docs/runtime/) |
| Wasm | Browser/WebAssembly isolation package family. | browser / WebAssembly isolation の package family。 | [Wasm](/docs/wasm/runtime/) |
| Doom | Official demo that validates provider, WASM, consent, and perception boundaries. | provider、WASM、consent、perception boundary を検証する official demo。 | [Doom Demo](/docs/doom/demo-overview/) |
| CTG | Canonical Trajectory Governance evidence and decision surface. | trajectory governance の evidence / decision surface。 | [Control](/docs/runtime/error-handling/) |
| Capability | Package-exposed operation boundary that can be routed, invoked, inspected, or governed. | routing、invoke、inspect、governance の対象になる package-exposed operation boundary。 | [Extensions](/docs/concepts/extensions/) |
| Ethos | Habit, character, and moral disposition; the concept layer for ethics, safety, and norms. | 習慣、性格、道徳的気風。AIKernel では倫理・安全・規範の概念層を指す。 | [Canonical Language](/docs/canonical-language/) |
| Pathos | Emotion, passion, and passive experience; the concept layer for risk signals, intuition, and anomaly detection. | 感情、情念、受動的経験。危険・直感・異常検知の概念層を指す。 | [Canonical Language](/docs/canonical-language/) |
| Logos | Word, logic, reason, and truth; the concept layer for logical consistency and verification. | 言葉、論理、理性、真理。論理・整合性・検証の概念層を指す。 | [Canonical Language](/docs/canonical-language/) |
| Nomos | Law, rule, and convention; the concept layer for ROM, canon, and rules. | 法律、規則、慣習。ROM、Canon、Rule の概念層を指す。 | [Canonical Language](/docs/canonical-language/) |
| Dike | Justice, order, and judgment; the concept layer for justice, order, and safety. | 正義、秩序、裁判。正義・秩序・安全性の概念層を指す。 | [Canonical Language](/docs/canonical-language/) |
| Aisthesis | Sensation, perception, and raw sense data; the concept layer for raw observations. | 感覚、知覚、生の感覚与件。生データと observation の概念層を指す。 | [Canonical Language](/docs/canonical-language/) |
| Phantasia | Representation, imagination, and mental image; the concept layer for scene graphs and inner world models. | 表象、想像力、心像。Scene Graph と内的世界モデルの概念層を指す。 | [Canonical Language](/docs/canonical-language/) |
| Chronos | Continuous, objective, physical time; the concept layer for buffers, windows, and replay timelines. | 連続的・客観的・物理的な時間。Buffer、Window、Replay Timeline の概念層を指す。 | [Canonical Language](/docs/canonical-language/) |
| Kairos | Qualitative time and the opportune moment; the concept layer for triggers and timing policy. | 主観的・質的な時間、好機。Trigger と最適タイミングの概念層を指す。 | [Canonical Language](/docs/canonical-language/) |
| Telos | End, purpose, and ultimate goal; the concept layer for goals, intent, and objectives. | 目的、終局、究極の目標。Goal、Intent、Objective の概念層を指す。 | [Canonical Language](/docs/canonical-language/) |
| Eidos | Form, essence, and shape; the concept layer for concepts, graphs, and types. | 形相、本質、もののかたち。Concept、Graph、Type の概念層を指す。 | [Canonical Language](/docs/canonical-language/) |
| Kratos | Power, rule, and executive force; reserved vocabulary for action authority and executors. | 権力、支配、実行力。Action authority / executor の将来語彙。 | [Canonical Language](/docs/canonical-language/) |
| Dynamis | Potentiality and capability; reserved vocabulary for embeddings and latent space. | 潜勢力、可能態。Embedding や latent space の将来語彙。 | [Canonical Language](/docs/canonical-language/) |
| Energeia | Actuality and activity; reserved vocabulary for action and execution. | 現実態、活動。Action / Execution の将来語彙。 | [Canonical Language](/docs/canonical-language/) |
| Nous | Intellect and reason; reserved vocabulary for supervisors and planners. | 知性、理性、宇宙の精神。Supervisor / Planner の将来語彙。 | [Canonical Language](/docs/canonical-language/) |
| Apatheia | Freedom from domination by passions; reserved vocabulary for normalization and stabilization. | 情念に支配されない状態。Normalizer / Stabilizer の将来語彙。 | [Canonical Language](/docs/canonical-language/) |
| Ataraxia | Calm and undisturbed state; reserved vocabulary for safe mode and fallback. | 魂の平静、乱されない心。SafeMode / Fallback の将来語彙。 | [Canonical Language](/docs/canonical-language/) |


## Notes

- Terms are intentionally bilingual because the source repository contains English and Japanese documentation.
- Philosophical vocabulary is sourced from `docs/canonical-language/index.md`.
- If a term lacks source evidence, future updates should add `TODO: source required` rather than inventing a definition.

## See Also

- [Concepts](/docs/concepts/)
- [Reference](/reference/)
- [Tutorials](/tutorials/)
