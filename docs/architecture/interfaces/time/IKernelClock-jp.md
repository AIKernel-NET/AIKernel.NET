---
title: "IKernelClock"
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
  - time
  - japanese
---

英語版: [IKernelClock.md](IKernelClock.md)

# IKernelClock

## 責務
Kernel、DSL、ROM、replay component に deterministic time を提供する境界です。

## 主要メンバー
| Member | Type | 説明 |
| --- | --- | --- |
| `GetCurrentTimestamp()` | `KernelTimestamp` | 現在の deterministic timestamp record を返す。 |

## 境界ルール
- replay、ROM hash、loop timeout decision、audit metadata に影響する runtime code はこの Interface に依存する。
- nondeterministic system time は host boundary で明示化する。
