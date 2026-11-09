---
title: "Doom Demo Tutorial"
lang: en
description: "Doom Demo Tutorial"
tags: [AIKernel, AIKernel.NET, v0.1.3]
category: tutorials
source: "generated-from-repository-inventory"
generated: true
release: "0.1.3"
updated: "2026-11-08"
---

# Doom Demo Tutorial

1. Open the [embedded Doom demo](https://aikernel.net/#doom-demo).
2. Review the terms and license notices. Choose GPU or CPU mode to approve the downloads, or leave the demo suspended.
3. After loading, use Start or the runtime controls. If the GPU is unavailable or VRAM is limited, use CPU mode.

## Demo Versions

The version selector is staged at `/demo/doom/`. When deployed, each approved build will live under `/demo/doom/versions/v<version>/` with its own JS, worker, WASM, and profile. The first staged update includes the existing `v0.1.2` release only; `v0.1.3` is a local preview. WAD and model files stay at the shared host paths and are downloaded only after consent.

## See Also

- [AIKernel.Doom](https://github.com/AIKernel-NET/AIKernel.Doom)
- [Demo Programs Guide](../operations/DEMO_PROGRAMS_GUIDE.md)
