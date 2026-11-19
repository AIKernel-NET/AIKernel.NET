---
title: "Before running in the browser"
lang: en
description: "Check browser, WebAssembly, WebGPU, and asset requirements before moving an AIKernel workload into the browser."
category: docs
source: "maintained-guide"
generated: false
release: "0.1.3"
documentation_target: "0.1.4"
updated: "2026-11-12"
---

# Before running in the browser

AIKernel.Wasm covers browser and WebAssembly execution, rendering, input, and related runtime facilities. A successful .NET console example does not validate browser GPU support, assets, or permissions.

## Explore an existing demo first

Open the [Doom demo guide](../doom/demo-overview.md). Observe game execution, automated control, and HUD status separately. A visible frame does not establish that every backend is working.

## Integrate the capability you need

Decide whether your application needs process execution, files, rendering, audio, or input. Follow the [Wasm README](https://github.com/AIKernel-NET/AIKernel.Wasm/blob/main/README.md) and [browser sample](https://github.com/AIKernel-NET/AIKernel.Demo/blob/main/src/AIKernel.Demo.Wasm/README.md) for the relevant prerequisites.

Opening an HTML file directly can prevent workers or asset requests from working under browser restrictions. Use the development-server instructions provided by the sample, then inspect the requested URLs and the first failing network request.

## Verify the selected backend

WebGPU availability depends on the browser and device. Record whether execution used GPU support or a CPU fallback. Inspect backend and diagnostic information instead of inferring GPU execution from a successful output alone.

For a reproducible report, include browser/version, OS, backend, execution URL, demo revision, and first error. State whether required models or assets were prepared. See [troubleshooting](../runtime/index.md) and [package responsibilities](../architecture/module-map.md) for the next steps.
