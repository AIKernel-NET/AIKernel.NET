---
updated: 2026-06-23
published: 2026-06-16
version: "0.1.3"
edition: "Canonical Series"
status: "Active"
issuer: ai-kernel@aikernel.net
maintainer: "拓也（AIKernel プロジェクト メンテナー）"
---

# Interface Canonicalization Roadmap v0.1.3

[English](interface-canonicalization-roadmap-v0.1.3.md)

この roadmap は、0.1.3 line において Doom / Demo pilot から GPU と cognition surface を
正典 package interface へ昇格する基準を説明します。

## Scope

0.1.3 の canonicalization は次を対象にします。

- GPU execution identity、capability metadata、zero-copy readiness。
- WebGPU、Dawn、CUDA provider family を兄弟関係の GPU provider path として扱うこと。
- GPU HUD と GPU Aisthesis DTO を browser/runtime の正典 surface として扱うこと。
- GPU / CPU / fallback execution に関する Control-plane arbitration metadata。
- public .NET member に対するバイリンガル documentation requirement。

## Promotion Rule

不安定な実装実験は Demo や Doom に置いてよいです。ただし、provider や tools を跨いで再利用する
surface になった時点で、境界を所有する package へ contract shape を昇格します。

| Surface | 正典 owner |
|---|---|
| Public interface、DTO、enum、comment contract | `AIKernel.NET` |
| Runtime implementation | `AIKernel.Core` または `AIKernel.Wasm` |
| Provider-specific binding | `AIKernel.Providers`、`AIKernel.Cuda13.0`、または Dawn/WebGPU provider package |
| Control arbitration | `AIKernel.Control` |
| Developer verification | `AIKernel.Tools` |
| Scenario validation | `AIKernel.Demo` と `AIKernel.Doom` |

## Documentation Rule

昇格した public member にはバイリンガル XML documentation が必要です。公開ドキュメント導線に入る
developer guide は、英語 Markdown と日本語 Markdown のペアを維持します。

## Exit Criteria

- public name に `rev3` などの開発用 suffix が残っていない。
- CLI command が canonical name を使っている。
- provider manifest が canonical capability metadata を公開している。
- Demo と Doom が private copy ではなく canonical DTO を利用している。
- site generation 前に documentation source link が解決できる。
