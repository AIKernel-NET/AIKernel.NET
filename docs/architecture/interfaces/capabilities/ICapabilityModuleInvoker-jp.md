---
title: "ICapabilityModuleInvoker"
created: 2026-06-05
updated: 2026-06-05
published: 2026-06-05
version: "0.0.5"
edition: "Draft"
status: "Refactor"
issuer: ai-kernel@aikernel.net
maintainer: "拓也（AIKernel プロジェクト メンテナー）"
tags:
  - aikernel
  - architecture
  - interfaces
  - capabilities
  - japanese
---

英語版: [ICapabilityModuleInvoker.md](ICapabilityModuleInvoker.md)

# ICapabilityModuleInvoker

## 責務
admission 済み Capability module の抽象 invocation boundary を定義する。

## 主要メンバー
| Member | Type | 説明 |
| --- | --- | --- |
| `InvokeAsync(CapabilityInvocationRequest request, CancellationToken cancellationToken = default)` | `ValueTask<CapabilityInvocationResult>` | implementation が所有する境界を通じて registered capability module を呼び出す。 |

## 境界ルール
- request/result envelope は deterministic かつ replay-friendly にする。
- この interface は invocation が CLI、managed assembly、native ABI、DSL ROM、remote endpoint のどれであるかを規定しない。
- permission check、sandboxing、transport、exception-to-failure conversion は Core / Tools / provider の責務。
