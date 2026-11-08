---
title: "Doom デモの概要"
lang: ja
description: "Doom デモの概要"
tags: [AIKernel, AIKernel.NET, v0.1.3]
category: docs
source: "generated-from-repository-inventory"
generated: true
release: "0.1.3"
updated: "2026-11-08"
---

# Doom デモの概要

DOOM エンジンはブラウザー内の WASM で実行されます。統治された実行制御、センシング、HUD の証跡を WebGPU と CPU 描画モードで確認できます。ユーザーがダウンロードに同意するまではゲームを起動しません。

## デモのバージョン

配置候補では `/demo/doom/` が一覧です。反映後は承認済みの各版を `/demo/doom/versions/v<version>/` に置き、JS・Worker・WASM・プロファイルを版ごとに分けます。初回の候補は既存の `v0.1.2` のみで、`v0.1.3` はローカルプレビューです。WAD とモデルは共通の配信先から同意後に取得します。

## 関連ページ

- [AIKernel.Doom](https://github.com/AIKernel-NET/AIKernel.Doom)
- [デモプログラムガイド](../operations/DEMO_PROGRAMS_GUIDE-jp.md)
