---
title: "Read and change the sample"
lang: en
description: "Match the CoreRuntime output to its C# source, change one input, and explain why the route stays the same."
category: tutorials
source: "maintained-guide"
generated: false
release: "0.1.3"
documentation_target: "0.1.4"
updated: "2026-11-12"
---

# Read and change the sample

After [running the sample](../overview/quick-start.md), connect its output to the code. Then change one input and check whether the selected route changes.

## Start with two files

In `AIKernel.Demo`, `src/AIKernel.Demo.CoreRuntime/Program.cs` prints each line returned by `CoreRuntimeDemo.RunAsync()`. The neighboring `CoreRuntimeDemo.cs` constructs the components:

```csharp
var router = new PassThroughSemanticRouter();
var route = await router.RouteAsync("demo core runtime").ConfigureAwait(false);
var registry = new InMemoryCapabilityRegistry();
var clock = KernelClock.System();
var memory = new MemoryFileProvider(new MemoryFileProviderOptions());
```

This is an excerpt from the pinned sample, not a complete standalone program.

| Output | What happened | What it does not establish |
| --- | --- | --- |
| `router.route=local.default` | The router returned a destination | An LLM understood the input |
| `registry=InMemoryCapabilityRegistry` | An in-memory registry was constructed | An external provider was registered or invoked |
| `clock.replaying=False` | A normal clock was constructed | A past execution was replayed |
| `vfs.provider=MemoryFileProvider` | An in-memory file provider was constructed | A disk or Git repository was mounted |

The `contract.map` line names public API entry points. Listing those types does not start every service.

## Change one input

In `CoreRuntimeDemo.cs`, replace `"demo core runtime"` with `"hello AIKernel"`. Repeat the `dotnet run` command from Quick Start. The route remains `local.default`: that is the default destination of `PassThroughSemanticRouter`. Changing a sentence does not add content-based model selection. That behavior requires an appropriate router implementation or configuration.

When finished, change the string back and save. There is no need to discard unrelated changes in the file.

## Choose your next step

Read [Choose a provider](../providers/provider-model.md) to connect an external capability, [Package responsibilities](../architecture/module-map.md) to choose dependencies, or [Configuration and troubleshooting](../runtime/index.md) to investigate failures.

Compare the exercise with the [verified source revision](https://github.com/AIKernel-NET/AIKernel.Demo/blob/8c960f57bdf6f431663a1ca33de7584f5e882140/src/AIKernel.Demo.CoreRuntime/CoreRuntimeDemo.cs).
