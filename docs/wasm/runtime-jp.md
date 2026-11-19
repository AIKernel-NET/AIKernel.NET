---
title: "ブラウザーで動かす前に"
lang: ja
description: "AIKernel.Wasmは、ブラウザーやWebAssemblyの実行、描画、入力などを扱うパッケージ群です。.NETのコンソールサンプルが動いても、ブラウザー側のGPU・アセット・権限まで確認できたことにはなりません。"
category: docs
source: "maintained-guide"
generated: false
release: "0.1.3"
documentation_target: "0.1.4"
updated: "2026-11-12"
---

# ブラウザーで動かす前に

AIKernel.Wasmは、ブラウザーやWebAssemblyの実行、描画、入力などを扱うパッケージ群です。.NETのコンソールサンプルが動いても、ブラウザー側のGPU・アセット・権限まで確認できたことにはなりません。

## まず動作を見たい場合

[Doomデモの案内](../doom/demo-overview-jp.md)から公開デモへ進みます。ゲームが動くこと、AIによる自動操作、HUDの状態表示はそれぞれ別に観察してください。画面が出ただけで、すべてのバックエンドが動作したとは判断できません。

## 自分のアプリへ組み込む場合

必要なのがプロセス実行、ファイル、描画、音声、入力のどれかを先に決めます。[AIKernel.WasmのREADME](https://github.com/AIKernel-NET/AIKernel.Wasm/blob/main/README-ja.md)と[ブラウザー用サンプル](https://github.com/AIKernel-NET/AIKernel.Demo/blob/main/src/AIKernel.Demo.Wasm/README.md)で、その機能に必要な準備を確認します。

ローカルのHTMLを直接開く方法では、Workerやアセット取得などがブラウザーの制約で動かないことがあります。サンプルに記載された開発サーバーの手順を使い、読み込み先のURLと失敗したネットワークリクエストを確認してください。

## GPUの結果を確かめる

WebGPUの利用可否はブラウザーと端末の組み合わせに依存します。CPUへの代替経路で動作した結果と、GPUで実行した結果は分けて記録します。HUDに表示されるバックエンドや診断情報を使って、実際にどちらが選ばれたかを確認します。

## 再現情報を残す

ブラウザーの名前と版、OS、選択したバックエンド、実行URL、デモの版、最初のエラーを残します。モデルやアセットの準備が必要な場合は、その準備が完了しているかも添えてください。

実行全体の切り分けは[トラブル対応](../runtime/index-jp.md)、パッケージ間の位置づけは[構成の説明](../architecture/module-map-jp.md)で確認できます。
