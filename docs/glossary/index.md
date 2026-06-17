---
title: "Glossary"
lang: ja
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

Glossary defines recurring AIKernel.NET terms in English and Japanese and links each term to the most relevant guide or Reference section.

### JA

Glossary は AIKernel.NET の主要用語を English / Japanese で定義し、関連 guide や Reference へ接続します。

## Why

### EN

Shared terms prevent documentation pages from redefining the same concept inconsistently.

### JA

共有用語により、複数ページで同じ概念を別々に再定義して不整合になることを防ぎます。

## Usage

### EN

Use this page when a guide uses a domain term such as Provider, Tool, Capability, CTG, Wasm, or Doom.

### JA

Provider、Tool、Capability、CTG、Wasm、Doom などの domain term が出たときに参照します。

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


## Notes

- Terms are intentionally bilingual because the source repository contains English and Japanese documentation.
- If a term lacks source evidence, future updates should add `TODO: source required` rather than inventing a definition.

## See Also

- [Concepts](/docs/concepts/)
- [Reference](/reference/)
- [Tutorials](/tutorials/)
