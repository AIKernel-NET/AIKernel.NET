---
title: "IChatHistoryRomExporter"
created: 2026-06-04
updated: 2026-06-04
published: 2026-06-04
version: "0.0.4"
edition: "Draft"
status: "Refactor"
issuer: ai-kernel@aikernel.net
maintainer: "Takuya (AIKernel Project Maintainer)"
tags:
  - aikernel
  - architecture
  - interfaces
  - history
  - english
---

Japanese version: [IChatHistoryRomExporter-jp.md](IChatHistoryRomExporter-jp.md)

# IChatHistoryRomExporter

## Responsibility
Exports chat history records into deterministic History ROM Markdown.

## Key Members
| Member | Type | Description |
| --- | --- | --- |
| `ToRomMarkdownAsync(IReadOnlyList<ChatHistoryRomRecord> records, ChatHistoryRomOptions options, CancellationToken cancellationToken = default)` | `Task<string>` | Converts structured records into ROM Markdown using caller-provided options. |

## Boundary Rules
- Exporters must not read hidden ambient state.
- Timestamps, entity identity, version, and security tags must come from records or options.
