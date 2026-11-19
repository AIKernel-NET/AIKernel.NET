---
title: "Configuration and troubleshooting"
lang: en
description: "Locate an AIKernel failure in restoration, build, startup, external connections, or execution, and collect useful diagnostic evidence."
category: docs
source: "maintained-guide"
generated: false
release: "0.1.3"
documentation_target: "0.1.4"
updated: "2026-11-12"
---

# Configuration and troubleshooting

Separate failures into source download, package restore, build, startup, and external capability invocation. Identify the first failing stage before changing unrelated settings.

## Establish a baseline

If [Quick Start](../overview/quick-start.md) works, .NET and the basic packages can run. If a failure begins after adding an external model, investigate its endpoint, credentials, registration, and required model or native library.

| Stage | Keep this evidence | Investigate |
| --- | --- | --- |
| Restore | Error code, package ID, version | NuGet sources, connectivity, dependency versions |
| Build | First compiler error | SDK, framework, source/package compatibility |
| Startup | Exception or validation result | DI registration and required configuration |
| Provider invocation | Selected provider, operation, error result | Endpoint, credentials, input, provider prerequisites |
| GPU or Wasm | Backend, browser, failing stage | Runtime support, permissions, libraries, assets |

## Configuration belongs with the connection

Providers do not necessarily use the same environment variables or option names. Follow the chosen provider's README. Supply secrets through the host's configuration or secret-management facilities, rather than hard-coding them. Remove secrets before sharing logs.

## A denial is not a successful execution

Distinguish a policy denial from a communication error. Continuing after a failure, or loosening a rule without examining the decision, obscures the actual execution conditions. Check the result, its input, and the applicable rule first.

Likewise, having a replay record does not prove that the current run reproduced it. Compare inputs, referenced assets, providers, and package versions when investigating differences.

## Report a reproducible problem

Include the OS, relevant SDK details from `dotnet --info`, source commit, package versions, reproduction command, expected output, and the first actual error. State whether the minimal sample also fails.

Continue with [provider selection](../providers/provider-model.md), [inspection tools](../tools/tool-execution.md), or [contact the project](/contact/).
