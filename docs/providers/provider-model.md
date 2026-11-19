---
title: "Choose and connect a provider"
lang: en
description: "Choose a provider for your model or service, identify its configuration requirements, and separate connection failures from runtime failures."
category: docs
source: "maintained-guide"
generated: false
release: "0.1.3"
documentation_target: "0.1.4"
updated: "2026-11-12"
---

# Choose and connect a provider

A Provider implements a capability such as a model connection, file access, an external service, or computation. Choose by the operation you need, then establish the application's wiring before adding credentials or hardware dependencies.

| Task | Implementation or example to inspect | Prerequisites |
| --- | --- | --- |
| Learn without external calls | CoreRuntime and Mock Provider | .NET and matching package versions |
| Connect a conversation model | ChatOpenAI, MicrosoftAI, or LocalLlm README | Endpoint and credentials, or a local model |
| Use OS services | StandardProviders example | Settings and permissions for the operation |
| Run GPU computation | CudaCompute or Wasm WebGPU | Supported backend and runtime |

## Check before connecting

Confirm that the exposed operation matches your application's request; package versions align with Core and contracts; the provider is registered in the host; and its required options are supplied. Understand its failures and external effects, including transmission, cost, and permissions.

Provider configuration differs by implementation. Follow the relevant guide from the [AIKernel.Providers README](https://github.com/AIKernel-NET/AIKernel.Providers/blob/main/README.md) and compare it with the source version you use, rather than assuming one registration snippet works for every provider.

## Implementing your own provider

Start with the contract and input/output types. Read a minimal existing provider. Keep external communication in that implementation, separate from execution ordering and monitoring. Test invalid input, authentication failure, cancellation, and service failure as well as successful responses.

[Package responsibilities](../architecture/module-map.md) explains where shared types belong. The [development guidelines](../guidelines/AIKERNEL_DEVELOPMENT_GUIDELINES.md) describe the architectural rules.

After connecting, inspect the selected provider, operation, and actual result. A dry-run example proves wiring, not successful external communication. Switch from the minimal example to a live connection in stages and use [runtime troubleshooting](../runtime/index.md) to isolate failures.
