---
title: "必要なパッケージを選ぶ"
lang: ja
description: "AIKernelのパッケージは、共通の型、実行の仕組み、外部機能、開発用ツールに分かれています。作るアプリに必要な役割から依存関係を選ぶと、すべてのパッケージを調べずに始められます。"
category: docs
source: "maintained-guide"
generated: false
release: "0.1.3"
documentation_target: "0.1.4"
updated: "2026-11-12"
---

# 必要なパッケージを選ぶ

AIKernelのパッケージは、共通の型、実行の仕組み、外部機能、開発用ツールに分かれています。作るアプリに必要な役割から依存関係を選ぶと、すべてのパッケージを調べずに始められます。

## 最小の.NETアプリから広げる

入門サンプルはCore、Hosting、Kernelなどを利用します。モデル接続が必要になったときにProviderを、ブラウザー上で動かすときにWasmを検討します。入門サンプルは CPU で動作します。Windows x64 と Linux x64 で CUDA を使う場合は、`AIKernel.Kernel` 0.1.4 同梱の CUDA Driver を使います。実行時に必要なネイティブ依存は NVIDIA ドライバのみです。

| リポジトリ | 主な役割 | 必要になる場面 |
| --- | --- | --- |
| AIKernel.NET | インターフェース、DTO、列挙型などの共通契約 | 複数の部品で共通の入力・出力を定義する |
| AIKernel.Core | 実行基盤、Hosting、Kernel、VFSなど | .NETアプリで基本のランタイムを組み込む |
| AIKernel.Providers | モデル・サービス・計算などの外部機能 | 外部への接続や実装を選ぶ |
| AIKernel.Control | 実行エンジンと制御のための部品 | 制御面やエミュレーターを扱う |
| AIKernel.Tools | CLI、検査、記録の確認など | 動作状態や実行記録を調べる |
| AIKernel.Wasm | ブラウザー・WebAssembly向け機能 | Web上での実行や描画を組み込む |
| AIKernel.Demo | 利用例 | アプリ側の組み立て方を学ぶ |

## 依存の考え方

アプリケーションは契約を使って実装を呼び出します。Provider固有の通信やGPU設定を共通DTOへ入れず、接続を持つ実装側に置きます。これにより、同じ契約を使うテスト用実装と実サービスを切り替えやすくなります。

初めての導入では、[サンプルのプロジェクトファイル](https://github.com/AIKernel-NET/AIKernel.Demo/blob/8c960f57bdf6f431663a1ca33de7584f5e882140/src/AIKernel.Demo.CoreRuntime/AIKernel.Demo.CoreRuntime.csproj)を見ると、どのパッケージが実際に必要かを確認できます。

## バージョンをそろえる

この入門で使う基準は0.1.3です。0.1.4向けの文章改訂とパッケージ公開は別に扱います。サンプルのソースと依存するパッケージ群を同じ系列にそろえ、異なる版のDLLを手作業で追加しないようにしてください。

正確な型名やメンバーは[APIリファレンス](/reference-ja/)で調べます。導入の順番は[Quick Start](../overview/quick-start-jp.md)、失敗時の切り分けは[実行環境の確認](../runtime/index-jp.md)へ進んでください。
