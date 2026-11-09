---
updated: 2026-06-23
published: 2026-06-16
version: "0.1.3"
edition: "Canonical Series"
status: "Active"
issuer: ai-kernel@aikernel.net
maintainer: "拓也（AIKernel プロジェクト メンテナー）"
---

# 正典 Interface Set v0.1.3

[English](canonical-interface-set-v0.1.3.md)

この文書は、0.1.3 line で正典として扱う public interface family を要約します。

## Canonical Families

| Family | 開発者にとっての意味 |
|---|---|
| Contracts and DTOs | request、response、evidence、policy exchange の安定形状。 |
| Runtime and hosting | Kernel、VFS、process、memory、ROM、execution boundary。 |
| Control | Intent、objective、action、governance、arbitration、fallback evidence。 |
| Providers | Standard、chat、compute、local LLM、Microsoft AI、CUDA、WebGPU、Dawn path。 |
| WASM | Browser runtime、sandbox、WebGPU bridge、WebAudio、display、HUD、Aisthesis。 |
| Tools | CLI、inspector、formatter、verification、package-integrity check。 |
| Demo and Doom | canonical runtime、Control、GPU HUD、Aisthesis surface の scenario validation。 |

## GPU Interface Set

0.1.3 の GPU interface set は provider-neutral に保ちます。

- WebGPU は browser/WASM provider path。
- Dawn は native WebGPU provider path。
- CUDA 13.0 は platform capability provider path。

3 つの path は、capability、readiness、zero-copy state、fallback metadata を canonical name で報告します。

## Documentation Interface

documentation interface も正典 surface として扱います。

- 公開 developer path に入る Markdown source file は、英語版と日本語版のペアを維持する。
- public .NET member は、バイリンガル XML documentation comment または paired include file を使う。
- 生成 HTML と reference page は下流生成物であり、source of truth ではない。
