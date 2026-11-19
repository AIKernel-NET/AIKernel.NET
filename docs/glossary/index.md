---
title: "Glossary with practical examples"
lang: en
description: "Find plain definitions of AIKernel terms and follow links to guides that show how each concept is used."
category: glossary
source: "maintained-guide"
generated: false
release: "0.1.3"
documentation_target: "0.1.4"
updated: "2026-11-12"
---

# Glossary with practical examples

Use this glossary when a term interrupts your reading. Each entry describes a responsibility in ordinary language before you look up exact API types.

| Term | Meaning | Example |
| --- | --- | --- |
| Kernel | A central facade coordinating runtime components | An entry point to composed execution |
| Contract | Shared types and calling conventions | Interfaces and DTOs |
| DTO | A data carrier between components | Typed input or result data |
| Provider | An external capability implementation | Model connection, files, computation |
| Capability | An exposed operation available to an application | A registered operation that can be selected and invoked |
| Context | Inputs and conditions associated with execution | Referenced information and rules |
| VFS | A common interface to file resources | Memory-backed file access |
| ROM | Knowledge assets treated as fixed after loading | A knowledge snapshot used in execution |
| Operator | A role managing execution order and result flow | Continuing after checking the previous result |
| Observer | A role recording or monitoring execution | Evidence of what happened and where |
| Replay | Inspection or reproduction using recorded information | Comparing inputs or provider selection |
| Fail-Closed | Preventing execution when conditions are not met | Rejecting an operation without permission |
| DAG | A directed acyclic graph | Dependencies and ordering between steps |
| Wasm | WebAssembly | A code format used in browsers and other runtimes |

Adding a Provider does not automatically configure recording, replay, and permission rules. Check the host, registrations, and settings together. Likewise, deterministic execution should not be read as a promise of identical text from an external LLM.

Read [Core concepts](../concepts/index.md) to connect these terms in one example. Use [API Reference](/reference/) for exact members and the [development guidelines](../guidelines/AIKERNEL_DEVELOPMENT_GUIDELINES.md) for the detailed design vocabulary.
