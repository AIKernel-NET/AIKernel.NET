---
title: "0.1.4で使う推論・操作評価API"
lang: ja
description: "Cosmos、Gemmaの最小呼び出しと、Bonsaiで操作を評価するホストの実装例。"
category: docs
source: "maintained-guide"
generated: false
documentation_target: "0.1.4"
updated: "2026-11-20"
---

# 0.1.4で使う推論・操作評価API

3型とも `AIKernel.Kernel` の0.1.4に含まれます。NuGetで `AIKernel.Kernel` を参照し、`AIKernel.Kernel.Inference` 名前空間を使用します。

## Cosmos3Model

取り込んだEdgeディレクトリと、信頼できる経路で取得したマニフェストのSHA-256を渡します。この例では退避先にホスト専用のSSDディレクトリを指定し、ページングを有効にします。`GenerateAsync` は文章・画像・時刻付き動画フレームを受け取り、`GenerateChatAsync` は会話履歴を引き継ぎます。

```csharp
using AIKernel.Kernel.Inference;

using var model = new Cosmos3Model(directory, Cosmos3Variant.Edge, new()
{
    EnableThinking = false,
    Memory = new() { SwapDirectory = privateSwapDirectory, ExpectedImportManifestSha256 = trustedManifestSha256 }
});
var reply = await model.GenerateAsync("You are helpful.",
    [new CosmosContent.Text("What is 2 + 2? Answer briefly.")], maxNewTokens: 32);
```

[モデルの取り込み](https://github.com/AIKernel-NET/AIKernel.Core/blob/dev/docs/cosmos3-inference.md) · [Cosmos3Model.cs](https://github.com/AIKernel-NET/AIKernel.Core/blob/dev/src/AIKernel.Kernel/Inference/Cosmos/Cosmos3Model.cs)

## Gemma4E2BCpuModel

対応するGemma 4 E2BのGGUFファイルを指定します。`GenerateAsync` にはシステム指示とユーザーの質問を別々に渡します。`maxNewTokens` は生成の上限です。

```csharp
using AIKernel.Kernel.Inference;

using var model = new Gemma4E2BCpuModel(ggufPath, cpuThreads: 4);
var reply = await model.GenerateAsync("You are helpful.", "What is 2 + 2?", maxNewTokens: 32);
```

[Gemma4E2BCpuModel.cs](https://github.com/AIKernel-NET/AIKernel.Core/blob/dev/src/AIKernel.Kernel/Inference/Gemma4E2BCpuModel.cs)

## BonsaiCtgCouncilEvaluator

ホストが提案文と信頼できる観測を分けて用意し、検証済みの3つのgovernance規則とBonsai 1.7Bを渡します。`hostAdmission` はホストの権限判定、`execute` は許可時の操作です。必要な証拠が欠けた場合やホストが拒否した場合、操作は実行されません。

```csharp
using AIKernel.Kernel.Inference;

using var council = BonsaiCtgCouncilEvaluator.CreateForGovernedOperations(
    bonsaiPath, verifiedCouncilRules);
var decision = await council.RunProposalWithEvidenceIfAllowedAsync(
    request, proposal, requiredEvidence, hostAdmission, execute, cancellationToken);
```

76例の検証はこの操作評価経路の記録です。16例を実行し、60例の記録をリプレイしました。Monolithの通常チャットは登録JSONの固定票を使います。 [操作と検証の記録](https://github.com/AIKernel-NET/AIKernel.Core/blob/dev/docs/development/bonsai-ctg-operations-jp.md)
