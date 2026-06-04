---
title: "time Interfaces"
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

英語版: [time/index.md](index.md)

# time Interfaces

## 1. 責務境界
Time contract は、host を `DateTimeOffset.UtcNow`、`TimeProvider.System`、
Core 固有 clock に結合せず、決定論的 Kernel time を提供する。

## 2. 公開 Contract
- `IKernelClock`

## 3. DTO Surface
- `KernelTimestamp`

## 境界ルール
- replay、ROM hash、loop timeout 判定、audit metadata に影響する runtime code は `IKernelClock` を使う。
- contract package は内部で現在時刻を生成してはならない。

---

# 変更履歴
- v0.0.4 (2026-06-04): 決定論的 Kernel clock interface category を追加。
