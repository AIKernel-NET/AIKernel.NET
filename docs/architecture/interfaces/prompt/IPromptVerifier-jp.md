---
id: ipromptverifier
version: 0.0.0
issuer: ai-kernel@tkysoftware.xsrv.jp
title: "IPromptVerifier"
created: 2026-05-03
tags:
  - aikernel
  - architecture
  - interfaces
  - japanese
---

英語版は IPromptVerifier.md を参照。

# IPromptVerifier

## Responsibility
IPromptVerifier が AIKernel のオーケストレーションおよび統治フローで担う契約境界を定義する。

## 主要メンバー（Draft）
| Member | Type | 説明 |
| --- | --- | --- |
| `VerifyAsync(string promptContent, string signature, CancellationToken ct = default)` | `Task<bool>` | Verify signature validity. |
| `VerifyWithKeyAsync(string promptContent, string signature, string keyId, CancellationToken ct = default)` | `Task<bool>` | Verify with explicit key id. |
| `FailClosed` | `bool` | Verification failure must stop execution. |

## 関連ユースケース
../../use-cases/AIKernel_UseCaseCatalog-jp.md の IPromptVerifier 参照箇所を基準とする。

## Notes
- 本文書は Interface レベルのドラフトである。
- 実装は fail-closed と deterministic replay の原則を維持すること。



