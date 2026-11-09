---
title: "Doom デモの仕組み"
lang: ja
description: "Doom デモの仕組み"
tags: [AIKernel, AIKernel.NET, v0.1.3]
category: docs
source: "generated-from-repository-inventory"
generated: true
release: "0.1.3"
updated: "2026-11-08"
---

# Doom デモの仕組み

- `DoomProvider` は WASM プロセスを管理し、`DoomCapabilities` は開始・停止・状態取得を提供します。
- `DoomWasm` は ROM とアセットの情報を解決し、`DoomWasm.Native` は Emscripten でエンジンをビルドします。
- `DoomWeb` は画面、Worker、同意手順を管理します。`DoomDemo` は CLI サンプル、`DoomOptimizer` は開発ツールです。

## デモのバージョン

配置候補では `/demo/doom/` が一覧です。反映後は承認済みの各版を `/demo/doom/versions/v<version>/` に置き、JS・Worker・WASM・プロファイルを版ごとに分けます。初回の候補は既存の `v0.1.2` のみで、`v0.1.3` はローカルプレビューです。WAD とモデルは共通の配信先から同意後に取得します。

## 関連ページ

- [AIKernel.Doom](https://github.com/AIKernel-NET/AIKernel.Doom)
- [デモプログラムガイド](../operations/DEMO_PROGRAMS_GUIDE-jp.md)
