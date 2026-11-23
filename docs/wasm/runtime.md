---
title: "Before running in the browser"
lang: en
description: "Check browser, WebAssembly, WebGPU, and asset requirements before moving an AIKernel workload into the browser."
category: docs
source: "maintained-guide"
generated: false
release: "0.1.3"
documentation_target: "0.1.4"
updated: "2026-11-23"
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

## Page model weights in the browser

[`BrowserWeightMemory` in AIKernel.Wasm.WebGpuComputeProvider 0.1.5](https://www.nuget.org/packages/AIKernel.Wasm.WebGpuComputeProvider/0.1.5) connects immutable weights in OPFS to AIKernel's virtual memory. It uses the AIKernel 0.1.4 SDK dependencies.

```bash
dotnet add package AIKernel.Wasm.WebGpuComputeProvider --version 0.1.5
```

From .NET WebAssembly in a dedicated worker, open the packaged `runtime/browser/opfs-weight-memory.mjs` module and a verified weight file prepared in OPFS. Supply the WebGPU device and a buffer configured with `COPY_DST`.

```csharp
using var weights = await BrowserWeightMemory.OpenAsync(moduleUrl, "weights.bin",
    pageSize: 1 << 20, ramPages: 8);
weights.UploadPage(pageIndex, device, uploadBuffer);
```

`ramPages` limits the resident page count. Allow memory for transfer buffers and use `GetRamUsage()` and `GetStatistics().BackingReads` to inspect the cache. A smoke test in Edge matched the reference on all five real GPU dispatches and made four OPFS reads with a one-page RAM cache. The test covers page transfer and WebGPU execution.

[Browser smoke test source for 0.1.5](https://github.com/AIKernel-NET/AIKernel.Wasm/tree/webgpu-v0.1.5/tests/browser/WeightMemorySmoke)

## Run WebGPU in a native host

[AIKernel.Dawn.Provider 0.1.4](https://www.nuget.org/packages/AIKernel.Dawn.Provider/0.1.4) exposes `compute.vector_add` for .NET 10, using D3D12 on Windows x64 and Vulkan on Linux x64. The WGSL results matched the CPU reference on Intel UHD P630 under Windows and RTX 3080 Ti under Ubuntu 24.04. [Installation guide](../operations/PACKAGE_INSTALLATION_GUIDE.md) · [Source and build instructions for 0.1.4](https://github.com/AIKernel-NET/AIKernel.Dawn/tree/v0.1.4)
