---
title: "Providers"
lang: en
description: "AIKernel.Providers package family と Provider Reference への入口です。"
tags: [AIKernel, AIKernel.NET, v0.1.2]
category: docs
source: "generated-from-repository-inventory"
generated: true
release: "0.1.2"
updated: "2026-06-17"
---

# Providers

## Summary

### EN

Provider pages explain the extension driver model.

### JA

Providers は 0.1.2 の repository metadata、package metadata、既存 docs を根拠に説明します。

## Why

### EN

This guide page keeps generated Reference separate from explanatory material, which helps avoid low-value API dump pages.

### JA

この guide page は explanatory material と generated Reference を分離し、低品質な API dump page になることを避けます。

## Usage

### EN

Use the package table to locate the implementation or wrapper package, then open Reference for exact API members.

### JA

package table で実装または wrapper package を探し、正確な API member は Reference で確認します。

## Examples

### Related packages

| Package | Kind | Version | Description | Source |
|---|---|---|---|---|
| [`AIKernel.Providers.Audio`](/reference/aikernel-providers/aikernel-providers-audio/) | nuget | `0.1.2` | EN: Pure managed audio provider substrate with format validation, capability descriptors, and backend-independent base classes. JA: format validation、capabil... | `AIKernel.Providers/src/Audio/AIKernel.Providers.Audio/AIKernel.Providers.Audio.csproj` |
| [`AIKernel.Providers.ChatHistory`](/reference/aikernel-providers/aikernel-providers-chathistory/) | nuget | `0.1.2` | EN: Official AIKernel.NET extension provider for deterministic chat history records. JA: deterministic chat history record を AIKernel 上で扱うための AIKernel.NET 公式... | `AIKernel.Providers/src/Chat/ChatHistoryProvider/ChatHistoryProvider.csproj` |
| [`AIKernel.Providers.ChatOpenAI`](/reference/aikernel-providers/aikernel-providers-chatopenai/) | nuget | `0.1.2` | EN: Official AIKernel.NET extension provider for OpenAI-compatible ChatCompletion, Embedding, and Moderation endpoints. JA: OpenAI 互換 ChatCompletion、Embeddin... | `AIKernel.Providers/src/Chat/ChatOpenAIProvider/ChatOpenAIProvider.csproj` |
| [`AIKernel.Providers.Compute`](/reference/aikernel-providers/aikernel-providers-compute/) | nuget | `0.1.2` | EN: Pure managed compute provider substrate with backend-neutral buffer metadata descriptors. JA: backend-neutral な buffer metadata descriptor を含む pure manag... | `AIKernel.Providers/src/Compute/AIKernel.Providers.Compute/AIKernel.Providers.Compute.csproj` |
| [`AIKernel.Providers.Council`](/reference/aikernel-providers/aikernel-providers-council/) | nuget | `0.1.2` | EN: Council semantic evaluation provider contracts and minimal runtime-configurable providers for AIKernel CTG orchestration. JA: AIKernel CTG orchestration... | `AIKernel.Providers/src/Council/AIKernel.Providers.Council/AIKernel.Providers.Council.csproj` |
| [`AIKernel.Providers.CudaCompute`](/reference/aikernel-providers/aikernel-providers-cudacompute/) | nuget | `0.1.2` | EN: Official AIKernel.NET extension provider for native CUDA compute modules. JA: Native CUDA compute module を AIKernel 上で扱うための AIKernel.NET 公式拡張 Provider です。 | `AIKernel.Providers/src/Compute/CudaComputeProvider/CudaComputeProvider.csproj` |
| [`AIKernel.Providers.DynamicPipelineCompiler`](/reference/aikernel-providers/aikernel-providers-dynamicpipelinecompiler/) | nuget | `0.1.2` | EN: Official AIKernel.NET extension provider for dynamic semantic pipeline compilation. JA: 動的 semantic pipeline compile を AIKernel 上で扱うための AIKernel.NET 公式拡張... | `AIKernel.Providers/src/Pipeline/DynamicPipelineCompilerProvider/DynamicPipelineCompilerProvider.csproj` |
| [`AIKernel.Providers.LocalLlm`](/reference/aikernel-providers/aikernel-providers-localllm/) | nuget | `0.1.2` | EN: Official AIKernel.NET extension provider for local LLM runtimes such as Ollama, llama.cpp, and vLLM. JA: Ollama、llama.cpp、vLLM などの local LLM runtime を AI... | `AIKernel.Providers/src/Llm/LocalLlmProvider/LocalLlmProvider.csproj` |
| [`AIKernel.Providers.MicrosoftAI`](/reference/aikernel-providers/aikernel-providers-microsoftai/) | nuget | `0.1.2` | EN: Microsoft.Extensions.AI based provider implementation for AIKernel.NET. Enables OpenAI-compatible model execution while preserving AIKernel's capability-... | `AIKernel.Providers/src/Llm/MicrosoftAIProvider/AIKernel.Providers.MicrosoftAI.csproj` |
| [`AIKernel.Providers.Perception`](/reference/aikernel-providers/aikernel-providers-perception/) | nuget | `0.1.2` | EN: Pure managed perception provider substrate with capability descriptors and deterministic routing policies. JA: capability descriptor と deterministic rout... | `AIKernel.Providers/src/Perception/AIKernel.Providers.Perception/AIKernel.Providers.Perception.csproj` |
| [`AIKernel.Providers.Standard`](/reference/aikernel-providers/aikernel-providers-standard/) | nuget | `0.1.2` | EN: Official AIKernel.NET standard OS driver providers for compute, file system, logging, process supervision, event bus, network, scheduling, and profiling.... | `AIKernel.Providers/src/Standard/AIKernel.Providers.Standard/AIKernel.Providers.Standard.csproj` |
| [`AIKernel.Providers.Substrate`](/reference/aikernel-providers/aikernel-providers-substrate/) | nuget | `0.1.2` | EN: Pure managed provider manifest, registry, and deterministic routing substrate for AIKernel.Providers. JA: AIKernel.Providers 向けの pure managed な provider... | `AIKernel.Providers/src/ProviderSubstrate/AIKernel.Providers.Substrate/AIKernel.Providers.Substrate.csproj` |
| [`aikernel-providers`](/reference/aikernel-providers/python/aikernel-providers/) | python | `0.1.2` | Python wrapper for AIKernel.Providers v0.1.2 official extension providers with bundled managed assemblies and pythonnet loading. | `AIKernel.Providers/python/pyproject.toml` |


## Notes

- Examples are limited to package and command shapes confirmed in repository metadata.
- For behavior details, inspect the linked source path and tests.
- If a runtime asset is hosted outside the source repository, the page treats it as deployment configuration rather than source behavior.

## See Also

- [Architecture](../architecture/index.md)
- [Reference](/reference/)
- [Generation Report](../docs-generation-report.md)
