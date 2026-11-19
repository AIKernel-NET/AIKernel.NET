---
title: "Providerを選び、接続する"
lang: ja
description: "Providerは、モデルや外部サービス、ファイル、計算などをアプリから利用できるようにする実装です。接続したい機能から選び、最初に認証やハードウェアを必要としない経路でアプリ側の配線を確かめます。"
category: docs
source: "maintained-guide"
generated: false
release: "0.1.3"
documentation_target: "0.1.4"
updated: "2026-11-12"
---

# Providerを選び、接続する

Providerは、モデルや外部サービス、ファイル、計算などをアプリから利用できるようにする実装です。接続したい機能から選び、最初に認証やハードウェアを必要としない経路でアプリ側の配線を確かめます。

## 最初に選ぶもの

| 目的 | 確認する実装・サンプル | 準備すること |
| --- | --- | --- |
| 外部通信なしで学ぶ | CoreRuntime、Mock Provider | .NETと同じ版のパッケージ |
| 会話モデルに接続する | ChatOpenAI、MicrosoftAI、LocalLlmの各README | 接続先・認証、またはローカルモデル |
| 標準のOS機能を使う | StandardProvidersのサンプル | 使用する機能の設定と権限 |
| GPUで計算する | CudaComputeやWasm側のWebGPU | 対応バックエンドと実行環境 |

名前が似ていても、モデル接続用とOS機能用のProviderは用途が異なります。必要な機能に対応するパッケージだけを選びます。

## 接続前に確認する四点

1. Providerが公開する処理と、アプリから呼ぶ処理が一致するか。
2. パッケージ版がCore・契約の版とそろっているか。
3. ホストへ登録する手順と、Provider固有の設定キーは何か。
4. 失敗時の戻り値と、外部送信・費用・権限の扱いはどうなるか。

設定方法はProviderごとに異なるため、ここでは架空の共通登録コードを示しません。[AIKernel.Providersの日本語README](https://github.com/AIKernel-NET/AIKernel.Providers/blob/main/README-ja.md)から対象の説明へ進み、使う版のソースと照合してください。

## 自作する場合

まず契約と入力・出力を決め、既存Providerの最小例を読みます。外部との通信はProviderに閉じ込め、処理順序や監視の責務を混ぜないようにします。テストでは正常応答だけでなく、認証失敗、不正入力、キャンセル、外部サービスの失敗も確認します。

契約・DTO・列挙型の配置は[パッケージの役割](../architecture/module-map-jp.md)、詳しい設計規律は[開発ガイドライン](../guidelines/AIKERNEL_DEVELOPMENT_GUIDELINES-jp.md)にあります。

## 接続後の確認

選ばれたProviderと処理名、実際の戻り値を確認します。サンプルがdry-runの場合は、外部接続を成功させた証拠にはなりません。最小例と実接続を段階的に切り替え、問題が出たら[トラブル対応](../runtime/index-jp.md)へ戻ってください。
