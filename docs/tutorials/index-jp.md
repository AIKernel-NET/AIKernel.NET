---
title: "実行して学ぶ"
lang: ja
description: "最初の学習では、基本の実行環境、コードの読み方、外部接続の順に確かめます。一度にすべてのパッケージを組み込む必要はありません。"
category: tutorials
source: "maintained-guide"
generated: false
release: "0.1.3"
documentation_target: "0.1.4"
updated: "2026-11-12"
---

# 実行して学ぶ

最初の学習では、基本の実行環境、コードの読み方、外部接続の順に確かめます。一度にすべてのパッケージを組み込む必要はありません。

## 1. 基本サンプルを実行する

[最初のサンプル](../overview/quick-start-jp.md)では、.NETのコンソールにルーティングやVFSの情報を表示します。必要なのはGitと.NET SDKです。初回取得時にはネットワークを使いますが、サンプルの実行にモデルやAPIキーは不要です。

## 2. 一か所変更し、出力を比べる

[サンプルの読み方](first-kernel-jp.md)では、入力文字列を変えて同じルーターを実行します。何が変わり、何が変わらないかを観察して、ルーティングとモデル推論の違いをつかみます。

## 3. 作りたいアプリに進む

外部モデルを使う場合は[Providerの選び方](../providers/provider-model-jp.md)、Webアプリの場合は[ブラウザー側の前提](../wasm/runtime-jp.md)へ進みます。先に完成した環境を観察したい場合は[Doomデモ](../doom/demo-overview-jp.md)が参考になります。

分からない言葉は[用語集](../glossary/index-jp.md)、実行できないときは[トラブル対応](../runtime/index-jp.md)を参照してください。各段階で動作を確かめてから次の機能を追加すると、失敗の原因を絞りやすくなります。
