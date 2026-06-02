---
id: ipromptverifier
title: "IPromptVerifier"
created: 2026-05-03
updated: 2026-05-16
published: 2026-05-16
version: "0.0.2"
edition: "Draft"
status: "Refactor"
issuer: ai-kernel@aikernel.net
maintainer: "拓也（AIKernel プロジェクト メンテナー）"
tags:
  - aikernel
  - architecture
  - interfaces
  - japanese
---

英語版は [IPromptVerifier.md](./IPromptVerifier.md) を参照。

# IPromptVerifier (インターフェース仕様)

## 1. 責務の境界 (Responsibility Boundary)
`IPromptVerifier` は、実行時にロードされた署名付きプロンプト成果物の整合性を検証する境界インターフェースです。

- 役割:
  `SignedPromptArtifactDto` の内容と署名関連メタデータを照合し、改ざん・欠落・不整合を `PromptVerificationResult` として返却します。
- 非役割:
  署名生成は `IPromptSignatureProvider` の責務であり、`IPromptVerifier` は検証（Verification）に専念します。

## 2. 契約シグネチャ (Signature)
```csharp
namespace AIKernel.Abstractions.Prompt;

/// <summary>
/// UC-11/UC-12/UC-13 に基づく IPromptVerifier の契約を定義します。
/// </summary>
public interface IPromptVerifier
{
    Task<PromptVerificationResult> VerifyAsync(
        SignedPromptArtifactDto artifact,
        CancellationToken ct = default);
}
```

## 3. 関連ユースケース (Related UCs)
- `UC-13` 実行時署名検証:
  プロンプトロード時に署名・ハッシュ整合性を判定する中核コンポーネントです。
- `UC-20` 決定論的リプレイと監査証跡:
  リプレイ対象成果物が過去実行時と同一条件かを確認する検証チェーンに寄与します。

## 4. 統治上の制約 (Governance & Determinism)
- Fail-Closed の遵守:
  `PromptVerificationResult.Decision` が許可条件を満たさない場合、実行を継続してはなりません。
- 正準化前提:
  署名・ハッシュ照合は、署名時と同一の正準化規約（`IRomCanonicalizer`）を前提とします。

## 5. 実装時の注意 (Notes)
- 信頼ストア連携:
  `ISignatureTrustStore` と連携し、失効鍵・未信頼鍵を拒否する設計が推奨されます。
- 意味的ハッシュ活用:
  文字列の表面一致ではなく、`ISemanticHasher` 前提の意味的同一性検証を維持してください。
---

# 変更履歴
- v0.0.0 / v0.0.0.0: 初期ドラフト
- v0.0.1 (2026-05-06): ドキュメント規約に基づくバージョン更新
