---
title: "Learn by running a sample"
lang: en
description: "Follow the AIKernel learning sequence from a first console run to code changes, provider selection, and browser experiments."
category: tutorials
source: "maintained-guide"
generated: false
release: "0.1.3"
documentation_target: "0.1.4"
updated: "2026-11-12"
---

# Learn by running a sample

Learn in stages: establish the execution environment, understand the code, then connect external capabilities. You do not need to integrate every package at once.

## 1. Run the basic sample

[Quick Start](../overview/quick-start.md) prints routing and VFS information in a .NET console. You need Git and the .NET SDK. Initial downloads require a network connection, but execution needs no model or API key.

## 2. Change one input

[Read and change the sample](first-kernel.md) changes an input string and runs the same router again. Observe what changes and what stays the same to distinguish routing from model inference.

## 3. Move toward your application

For an external model, read [Choose a provider](../providers/provider-model.md). For a web application, read [browser prerequisites](../wasm/runtime.md). To observe an existing application first, explore the [Doom demo](../doom/demo-overview.md).

Use the [glossary](../glossary/index.md) for terminology and [troubleshooting](../runtime/index.md) for execution failures. Verify each stage before adding another capability so that you can identify where a failure begins.
