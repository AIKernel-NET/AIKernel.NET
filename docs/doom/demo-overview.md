---
title: "Doom Demo Overview"
lang: en
description: "Doom Demo Overview"
tags: [AIKernel, AIKernel.NET, v0.1.3]
category: docs
source: "generated-from-repository-inventory"
generated: true
release: "0.1.3"
updated: "2026-11-08"
---

# Doom Demo Overview

The browser runs the DOOM engine in WASM. The demo illustrates governed runtime control, sensing and HUD evidence, with WebGPU and a CPU rendering mode. The game runtime stays suspended until the visitor approves the download.

## Demo Versions

The version selector is staged at `/demo/doom/`. When deployed, each approved build will live under `/demo/doom/versions/v<version>/` with its own JS, worker, WASM, and profile. The first staged update includes the existing `v0.1.2` release only; `v0.1.3` is a local preview. WAD and model files stay at the shared host paths and are downloaded only after consent.

## See Also

- [AIKernel.Doom](https://github.com/AIKernel-NET/AIKernel.Doom)
- [Demo Programs Guide](../operations/DEMO_PROGRAMS_GUIDE.md)
