---
title: "What AIKernel helps you build"
lang: en
description: "Understand what AIKernel contributes to a .NET application, when its component boundaries are useful, and what a first sample can demonstrate."
category: docs
source: "maintained-guide"
generated: false
release: "0.1.3"
documentation_target: "0.1.4"
updated: "2026-11-12"
---

# What AIKernel helps you build

AIKernel is a .NET foundation for composing AI applications with explicit execution conditions, external capabilities, and inspectable records. It is aimed at developers who need to organize the work around a model call.

## Consider an application that answers from files

You need to know which files were read, which model received the input, whether an operation was allowed, and where a failure occurred. Putting all of these concerns inside a single model integration makes changing providers and diagnosing failures difficult.

AIKernel separates file access through VFS, external implementations through Providers, and available operations through Capabilities. Your application chooses implementations and execution rules. Those boundaries help you change models or execution environments without making every component depend on the same implementation.

## Choose a starting point

| Your task | Start here |
| --- | --- |
| Run something in .NET | [First sample](quick-start.md) |
| Connect a model or service | [Choose a provider](../providers/provider-model.md) |
| Investigate configuration and failures | [Runtime troubleshooting](../runtime/index.md) |
| Explore browser execution | [Understand the Doom demo](../doom/demo-overview.md) |

## Contracts and runtime are separate

The `AIKernel.NET` repository owns shared interfaces and data types. `AIKernel.Core` implements runtime behavior. `AIKernel.Providers` and other packages supply external capabilities. Installing the contract packages alone does not start a chat API server.

The project's “AI operating system” terminology describes management of capabilities, context, and execution rules. In practice, you compose the required pieces in a .NET application or a browser runtime.

Inspecting or replaying an execution process does not guarantee that an external LLM generates identical text on each call. GPU backends and external models also have their own prerequisites. The first sample deliberately checks basic components before introducing them.

The onboarding sample pins 0.1.3 so you can reproduce its output. Use the [0.1.4 migration guide](upgrade-0-1-4.md) to update an existing app or [Package responsibilities](../architecture/module-map.md) to choose dependencies.
