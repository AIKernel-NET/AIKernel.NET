---
title: "IChatTurn HashChain Contracts"
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
  - governance
  - japanese
---

英語版: [IChatTurn HashChain Contracts](IChatTurnHashChainContracts.md)

# IChatTurn HashChain Contracts

## 1. 責務境界
ChatChain 契約は、チャットターンのリプレイ証跡を決定論的に統治する境界です。

- `IChatTurn` は 1 つの会話ターンの actor、body、timestamp を表します。
- `IHashChainNode` は turn を `PrevHash`、`Hash`、任意の signature と結びます。
- `IChatTurnCanonicalizer` は turn を決定論的な正準内容へ変換します。
- `IChatTurnSemanticHasher` は正準内容と前段 hash から次の hash を計算します。
- `IChatTurnSignatureProvider` は turn hash の署名と検証を担います。
- `IChatTurnChainVerifier` は chain の連続性と fail-closed な受理を検証します。
- `IChatTurnVerificationResult` は成功または拒否理由を返します。

これらは governance 専用の契約です。保存、provider 実行、prompt 生成、UI 状態は所有しません。

## 2. Governance Flow
Chat-turn governance は次の順序に固定されます。

1. `IChatTurnCanonicalizer` で turn を正準化する。
2. `IChatTurnSemanticHasher` で semantic hash を計算する。
3. 前段 tail hash とともに `IHashChainNode` へ hash を付与する。
4. 必要に応じて `IChatTurnSignatureProvider` で hash に署名する。
5. `IChatTurnChainVerifier` で連続性と署名受理を検証する。

検証は fail-closed でなければなりません。壊れた chain、前段 hash 不一致、不正署名、policy 拒否は、`IChatTurnVerificationResult.IsSuccess = false` とし、可能なら `Error` に理由を入れます。

## 3. 決定論ルール
- 正準化は等価な `IChatTurn` 値に対して安定であること。
- hash は正準内容と前段 hash のみに依存すること。
- 検証は hidden state や provider 固有挙動を導入しないこと。
- interface 境界の外で署名を符号化する場合は、algorithm-tagged 形式を推奨します。

## 4. 依存境界
- Depends on: `System`, `System.Collections.Generic`, `System.Threading`, `System.Threading.Tasks`。
- Called by: governance validators、replay-log verifiers、chat-history ROM pipelines。
- Must not depend on: Core executor 実装、provider 実装、VFS 実装、hosting 固有 service。

## 5. 移行メモ
v0.0.4 では曖昧だった ChatChain 契約名を次のように変更しました。

- `AIKernel.Abstractions.Governance.ChatChain.IResult` -> `IChatTurnVerificationResult`
- `AIKernel.Abstractions.Governance.ChatChain.ISemanticHasher` -> `IChatTurnSemanticHasher`

決定論的リプレイや chat-history ROM 検証では、具体的な ChatChain 名を使用してください。

---

# 変更履歴
- v0.0.4 (2026-06-04): ChatChain governance contract documentation を追加。
