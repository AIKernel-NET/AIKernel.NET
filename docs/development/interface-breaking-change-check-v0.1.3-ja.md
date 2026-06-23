---
updated: 2026-06-23
published: 2026-06-16
version: "0.1.3"
edition: "Canonical Series"
status: "Active"
issuer: ai-kernel@aikernel.net
maintainer: "拓也（AIKernel プロジェクト メンテナー）"
---

# Interface Breaking Change Check v0.1.3

[English](interface-breaking-change-check-v0.1.3.md)

この文書は、0.1.3 public-interface review の判断を記録します。

## Decision

0.1.3 正典 line は、repository 固有の release task が破壊的変更を明示しない限り、
additive promotion line として扱います。

想定する変更は次のとおりです。

- 再利用可能になった GPU、HUD、Aisthesis、Control metadata を canonical package へ昇格する。
- public command、manifest、DTO metadata key から `rev3` などの開発専用名を取り除く。
- 古い version number を持つ履歴文書は migration record として維持する。
- stable package family と local development package family を分離する。

## Reviewer Checklist

- public package に開発専用の `rev3` identifier が露出していない。
- 現行 install example が古い package line を指していない。
- public .NET member がバイリンガル XML comment で説明されている。
- public XML documentation を出すべき package surface で `CS1591` が抑止されていない。
- Demo と Doom が canonical DTO を利用している、または private pilot logic を明示している。
- 公開 developer path の Markdown document に英語版と日本語版の source pair がある。
