---
title: "必要なパッケージを選ぶ"
lang: ja
description: "AIKernelのパッケージは、共通の型、実行の仕組み、外部機能、開発用ツールに分かれています。作るアプリに必要な役割から依存関係を選ぶと、すべてのパッケージを調べずに始められます。"
category: docs
source: "maintained-guide"
generated: false
release: "0.1.4"
documentation_target: "0.1.4"
updated: "2026-11-24"
---

# 必要なパッケージを選ぶ

AIKernelのパッケージは、共通の型、実行の仕組み、外部機能、開発用ツールに分かれています。作るアプリに必要な役割から依存関係を選ぶと、すべてのパッケージを調べずに始められます。

## 最小の.NETアプリから広げる

入門サンプルはCore、Hosting、Kernelなどを利用します。モデル接続が必要になったときにProviderを、ブラウザー上で動かすときにWasmを検討します。CUDAパッケージは基本入門の必須条件ではありません。

| リポジトリ | 主な役割 | 必要になる場面 |
| --- | --- | --- |
| AIKernel.NET | インターフェース、DTO、列挙型などの共通契約 | 複数の部品で共通の入力・出力を定義する |
| AIKernel.Core | 実行基盤、Hosting、Kernel、VFSなど | .NETアプリで基本のランタイムを組み込む |
| AIKernel.Providers | モデル・サービス・計算などの外部機能 | 外部への接続や実装を選ぶ |
| AIKernel.Control | 実行エンジンと制御のための部品 | 制御面やエミュレーターを扱う |
| AIKernel.Tools | CLI、検査、記録の確認など | 動作状態や実行記録を調べる |
| AIKernel.Wasm | ブラウザー・WebAssembly向け機能 | Web上での実行や描画を組み込む |
| AIKernel.Cuda13.0 | CUDA・LibTorchに関わる外部計算機能 | 対応するGPU環境を使う |
| AIKernel.Demo | 利用例 | アプリ側の組み立て方を学ぶ |

## 依存の考え方

アプリケーションは契約を使って実装を呼び出します。Provider固有の通信やGPU設定を共通DTOへ入れず、接続を持つ実装側に置きます。これにより、同じ契約を使うテスト用実装と実サービスを切り替えやすくなります。

初めての導入では、[サンプルのプロジェクトファイル](https://github.com/AIKernel-NET/AIKernel.Demo/blob/8c960f57bdf6f431663a1ca33de7584f5e882140/src/AIKernel.Demo.CoreRuntime/AIKernel.Demo.CoreRuntime.csproj)を見ると、どのパッケージが実際に必要かを確認できます。

## バージョンをそろえる

入門サンプルは公開済みの AIKernel SDK 0.1.4 を使います。用途別の Provider と共有契約の版は[パッケージ導入ガイド](../operations/PACKAGE_INSTALLATION_GUIDE-jp.md)で確認してください。

正確な型名やメンバーは[APIリファレンス](/reference-ja/)で調べます。導入の順番は[Quick Start](../overview/quick-start-jp.md)、失敗時の切り分けは[実行環境の確認](../runtime/index-jp.md)へ進んでください。
