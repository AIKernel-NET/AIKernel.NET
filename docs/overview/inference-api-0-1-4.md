---
title: "Inference and governed operations in 0.1.4"
lang: en
description: "Call Cosmos and Gemma locally and connect Bonsai to a host-authorized operation."
category: docs
source: "maintained-guide"
generated: false
documentation_target: "0.1.4"
updated: "2026-11-20"
---

# Inference and governed operations in 0.1.4

These APIs belong to the 0.1.4 release candidate. Reference the development version of the `AIKernel.Kernel` project. All three types use the `AIKernel.Kernel.Inference` namespace.

## Cosmos3Model

Supply the imported Edge directory and the trusted SHA-256 digest of its manifest. Set `privateSwapDirectory` to a host-private SSD directory to enable paging. `GenerateAsync` accepts text, images and timestamped frames. Use `GenerateChatAsync` to carry conversation history.

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

[Prepare the checkpoint](https://github.com/AIKernel-NET/AIKernel.Core/blob/dev/docs/cosmos3-inference-en.md) · [Cosmos3Model.cs](https://github.com/AIKernel-NET/AIKernel.Core/blob/dev/src/AIKernel.Kernel/Inference/Cosmos/Cosmos3Model.cs)

## Gemma4E2BCpuModel

Pass a compatible Gemma 4 E2B GGUF file. `GenerateAsync` takes the system instruction and user turn separately. `maxNewTokens` caps the generated response.

```csharp
using AIKernel.Kernel.Inference;

using var model = new Gemma4E2BCpuModel(ggufPath, cpuThreads: 4);
var reply = await model.GenerateAsync("You are helpful.", "What is 2 + 2?", maxNewTokens: 32);
```

[Gemma4E2BCpuModel.cs](https://github.com/AIKernel-NET/AIKernel.Core/blob/dev/src/AIKernel.Kernel/Inference/Gemma4E2BCpuModel.cs)

## BonsaiCtgCouncilEvaluator

Prepare the proposal separately from trusted host observations. Supply the pinned Bonsai 1.7B model and all three verified governance rules. In this host integration excerpt, `hostAdmission` checks the caller’s permissions and `execute` performs the operation. Missing required evidence or denied host admission prevents execution.

```csharp
using AIKernel.Kernel.Inference;

using var council = BonsaiCtgCouncilEvaluator.CreateForGovernedOperations(
    bonsaiPath, verifiedCouncilRules);
var decision = await council.RunProposalWithEvidenceIfAllowedAsync(
    request, proposal, requiredEvidence, hostAdmission, execute, cancellationToken);
```

The recorded 76 cases cover this operation evaluator, including 16 live cases and 60 replays. Monolith’s ordinary chat endpoint reads the votes in the model registration. [Host integration and evaluation results (Japanese)](https://github.com/AIKernel-NET/AIKernel.Core/blob/dev/docs/development/bonsai-ctg-operations-jp.md)
