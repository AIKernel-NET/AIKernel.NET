---
title: "Core concepts through one example"
lang: en
description: "Learn the roles of routing, capabilities, providers, runtime state, time, and file access through one small example."
category: docs
source: "maintained-guide"
generated: false
release: "0.1.3"
documentation_target: "0.1.4"
updated: "2026-11-12"
---

# Core concepts through one example

Connect the vocabulary to three questions: what does the application use, under which conditions does it execute, and what can you inspect afterward?

## Follow a file-backed question

An application reads a file and asks a model a question. The file implementation and model connection can be replaced independently. The logic deciding what happens next can remain separate from both connections.

| Term | Responsibility | Example |
| --- | --- | --- |
| Contract | Shared types and calling conventions | Interfaces and input/result DTOs |
| Provider | An implementation of a model, file, compute, or service capability | A model API adapter or in-memory files |
| Capability | An available operation exposed to the application | Selecting a registered operation by its descriptor |
| Context | Inputs and conditions associated with an execution | Referenced information and applicable rules |
| VFS | A common interface to file resources | Memory-backed and Git-backed resources |
| Replay | Inspecting or reproducing an execution from recorded information | Comparing selected providers and conditions |

## Provider, Operator, and Observer

A Provider supplies an external capability. An Operator manages execution order and result flow. An Observer records or monitors execution. Putting model communication in a Provider keeps endpoint-specific behavior out of the scheduling logic.

These are architectural responsibilities. Check the registrations and configuration of a particular sample: mentioning these types does not automatically enable governance or auditing.

## Deterministic execution and model output

Making a process inspectable under recorded conditions is different from promising identical generated text from an external model. Inputs, results, and execution conditions are the evidence you use to investigate the process. Provider boundaries help contain uncertain external behavior.

In the first sample, `MemoryFileProvider` is a VFS implementation and `InMemoryCapabilityRegistry` is a registry for available operations. The sample constructs them and prints their types; it does not exercise file I/O or an external model.

Return to [the sample walkthrough](../tutorials/first-kernel.md), or read the [development guidelines](../guidelines/AIKERNEL_DEVELOPMENT_GUIDELINES.md) for the full architectural discipline.
