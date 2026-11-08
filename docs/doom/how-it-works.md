---
title: "How the Doom Demo Works"
lang: en
description: "How the Doom Demo Works"
tags: [AIKernel, AIKernel.NET, v0.1.3]
category: docs
source: "generated-from-repository-inventory"
generated: true
release: "0.1.3"
updated: "2026-11-08"
---

# How the Doom Demo Works

- `DoomProvider` hosts the WASM process; `DoomCapabilities` exposes start, stop, and status.
- `DoomWasm` resolves ROM and asset metadata. `DoomWasm.Native` builds the engine overlay with Emscripten.
- `DoomWeb` owns the browser UI, worker, and consent gate. `DoomDemo` is the CLI example; `DoomOptimizer` is a development tool.

## Demo Versions

The version selector is staged at `/demo/doom/`. When deployed, each approved build will live under `/demo/doom/versions/v<version>/` with its own JS, worker, WASM, and profile. The first staged update includes the existing `v0.1.2` release only; `v0.1.3` is a local preview. WAD and model files stay at the shared host paths and are downloaded only after consent.

## See Also

- [AIKernel.Doom](https://github.com/AIKernel-NET/AIKernel.Doom)
- [Demo Programs Guide](../operations/DEMO_PROGRAMS_GUIDE.md)
