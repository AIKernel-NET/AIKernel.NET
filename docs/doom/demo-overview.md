---
title: "What to observe in the Doom demo"
lang: en
description: "Observe manual play, automated control, and diagnostics separately in the AIKernel Doom demo and report a reproducible failure."
category: docs
source: "maintained-guide"
generated: false
release: "0.1.3"
documentation_target: "0.1.4"
updated: "2026-11-12"
---

# What to observe in the Doom demo

The Doom demo combines browser-hosted game execution with input, observation, and automated control. Test manual operation first, then observe automation and status separately so that failures are easier to isolate.

## Open the demo

Open the [Doom demo](/demo/doom/). Follow its asset preparation and usage conditions before starting. Doom-specific assets are handled separately from AIKernel source code.

| Observe | Check |
| --- | --- |
| Game runtime | Startup, frame updates, response to manual input |
| Automated control | Enabled state, resulting movement/actions, ability to stop |
| Diagnostics | Selected backend, observation/decision evidence, errors |

If manual play works but automation does not progress, begin with automation state and control logs. If the game itself is frozen, investigate startup, assets, workers, and runtime errors first.

## Interpret the result carefully

Successful automation in one scene does not establish completion of other maps or support for every device. A CPU fallback may be active; inspect backend information before concluding that the GPU executed a workload.

To report a problem, include the demo version, browser, OS, actions leading to the issue, and first error. State whether automation was enabled and manual controls worked.

The [Doom documentation](https://github.com/AIKernel-NET/AIKernel.Doom/blob/main/docs/README.md) covers debugging and control in detail. Read [browser prerequisites](../wasm/runtime.md), or start learning the SDK with [the first console sample](../overview/quick-start.md).
