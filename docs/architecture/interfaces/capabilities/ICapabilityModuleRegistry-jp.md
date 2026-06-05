---
title: "ICapabilityModuleRegistry"
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

英語版: [ICapabilityModuleRegistry.md](ICapabilityModuleRegistry.md)

# ICapabilityModuleRegistry

## 責務
admission 済み external Capability module descriptor を登録・解決・列挙する境界です。

## 主要メンバー
| Member | Type | 説明 |
| --- | --- | --- |
| `RegisterAsync(CapabilityModuleDescriptor descriptor, CancellationToken cancellationToken = default)` | `ValueTask` | admission 済み capability module descriptor を登録する。 |
| `ResolveAsync(string capabilityId, CancellationToken cancellationToken = default)` | `ValueTask<CapabilityModuleDescriptor?>` | stable capability id から module descriptor を解決する。 |
| `ListAsync(CancellationToken cancellationToken = default)` | `ValueTask<IReadOnlyList<CapabilityModuleDescriptor>>` | admission 済み capability module descriptor を列挙する。 |

## 境界ルール
- Registry entry は module identity と invocation boundary のみを記述する。
- runtime loading、assembly binding、native ABI binding、CLI process execution は AIKernel.NET の外に残す。
- unknown または未 admission の capability id は implementation layer で fail-closed にする。
