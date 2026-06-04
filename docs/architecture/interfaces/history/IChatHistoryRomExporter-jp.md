---
title: "IChatHistoryRomExporter"
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
  - history
  - japanese
---

英語版: [IChatHistoryRomExporter.md](IChatHistoryRomExporter.md)

# IChatHistoryRomExporter

## 責務
chat history record を deterministic History ROM Markdown へ export する境界です。

## 主要メンバー
| Member | Type | 説明 |
| --- | --- | --- |
| `ToRomMarkdownAsync(IReadOnlyList<ChatHistoryRomRecord> records, ChatHistoryRomOptions options, CancellationToken cancellationToken = default)` | `Task<string>` | caller-provided options に基づき、structured record を ROM Markdown へ変換する。 |

## 境界ルール
- exporter は hidden ambient state を読んではならない。
- timestamp、entity identity、version、security tag は record または options から渡す。
