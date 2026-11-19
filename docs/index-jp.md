---
title: "AIKernelを使い始める"
lang: ja
description: "AIKernelでアプリを作るためのガイドです。まず一つのサンプルを動かし、結果の読み方を学んでから、必要なモデルや実行環境を追加していきます。"
category: docs
source: "maintained-guide"
generated: false
release: "0.1.3"
documentation_target: "0.1.4"
updated: "2026-11-12"
---

# AIKernelを使い始める

AIKernelでアプリを作るためのガイドです。まず一つのサンプルを動かし、結果の読み方を学んでから、必要なモデルや実行環境を追加していきます。

## 初めての方へ

1. [AIKernelでできること](overview/what-is-aikernel-jp.md)で、用途と前提をつかむ。
2. [最初のサンプルを動かす](overview/quick-start-jp.md)。APIキーやGPUを用意せずに始められます。
3. [サンプルを読む](tutorials/first-kernel-jp.md)。入力を変え、出力との関係を確かめます。

## やりたいことから探す

| やりたいこと | ガイド |
| --- | --- |
| 必要なNuGetパッケージを選ぶ | [構成と依存関係](architecture/module-map-jp.md) |
| モデルや外部サービスを接続する | [Providerを選ぶ](providers/provider-model-jp.md) |
| 設定や起動の問題を解決する | [実行環境の確認とトラブル対応](runtime/index-jp.md) |
| CLIで状態や記録を調べる | [ツールを使う](tools/tool-execution-jp.md) |
| ブラウザーで実行する | [Wasmの前提](wasm/runtime-jp.md) |
| 実際のデモを観察する | [Doomデモの見方](doom/demo-overview-jp.md) |

## 仕組みを理解する・仕様を調べる

[概念説明](concepts/index-jp.md)は、一つのアプリを例に部品の役割を説明します。言葉を確認したいときは[用語集](glossary/index-jp.md)、型名・メソッド・パッケージを正確に調べるときは[APIリファレンス](/reference-ja/)を使います。

開発に参加する方は[開発ガイドライン](guidelines/AIKERNEL_DEVELOPMENT_GUIDELINES-jp.md)、研究や設計の背景を読みたい方は[論文と設計資料](papers/12-canonical-trajectory-governance/README.md)へ進んでください。過去の資料はその文書に記載された版を対象にしています。

## このガイドの対象

現在の入門サンプルは0.1.3を基準にしています。0.1.4に向けて文章と導線を改訂していますが、パッケージの公開状態とは区別します。Quick Startには確認したソースと出力を記載しています。
