---
title: "Data Flow"
lang: ja
description: "AIKernel.NET の contract、request/response、provider routing、control evidence、tool inspection の流れを説明します。"
tags: [AIKernel, AIKernel.NET, v0.1.3]
category: docs
source: "generated-from-repository-inventory"
generated: true
release: "0.1.3"
updated: "2026-06-17"
---
# Data Flow

## 概要

Data Flow は application code から contract、runtime routing、provider execution、control evidence、inspection tools へ情報が流れる経路を説明します。

## 背景

この project には多くの DTO と interface があるため、各 type がどこで使われるかを flow として理解する必要があります。

## 使い方

Core、Providers、Control、Tools をひとつの workflow として接続する場合に読みます。

## 例

```mermaid
sequenceDiagram
    participant App as Application
    participant Contract as AIKernel.NET Contracts
    participant Core as AIKernel.Core
    participant Provider as Provider
    participant Control as Control
    participant Tool as Tooling
    App->>Contract: Build request and context DTOs
    Contract->>Core: Pass typed contracts
    Core->>Provider: Resolve capability or model provider
    Provider->>Control: Emit evidence when governance applies
    Core->>Tool: Export trace, ROM, or inspection surface
```

## 補足

- The diagram is conceptual and source-backed by package boundaries, not a claim about one mandatory call stack.
- Tests in each repo remain the authority for expected behavior.
- Reference pages include source paths for deeper inspection.

## 関連ページ

- [Runtime Lifecycle](../runtime/lifecycle.md)
- [Messages](../concepts/messages.md)
- [Reference](/reference/)
