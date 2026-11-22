---
title: "0.1.3から0.1.4へ移行する"
lang: ja
description: "既存アプリの更新前に、モデルと実行環境を選び、Cosmosのローカルホストで最初の回答と監査記録を確かめる手順です。"
category: docs
source: "maintained-guide"
generated: false
documentation_target: "0.1.4"
updated: "2026-11-20"
---

# 0.1.3から0.1.4へ移行する

アップグレードする前に、0.1.3で使っているパッケージの版、モデル、入力、期待する出力を記録します。初めて使う方は、モデルの準備に入る前に[0.1.3のサンプル](quick-start-jp.md)で.NET環境を確認できます。変更の一覧は[0.1.4のリリースノート](https://github.com/AIKernel-NET/AIKernel.NET/releases/tag/v0.1.4)に掲載しています。

## 用途に合わせて選ぶ

| やりたいこと | 0.1.4で使う機能 | 準備するもの |
| --- | --- | --- |
| 画像や動画について質問する | Cosmos 3 Edge／Nanoが文章・RGB画像・時刻付きフレームを読み、文章で回答します。最初の動作確認には重みの小さいEdgeを使えます。 | 取り込み済みのreasoner重みとマニフェスト。CPUで実行できます。 |
| ローカルで文章を生成する | Bonsai 1.7B／4BまたはGemma 4 E2B。GemmaにはNVIDIA GPU上でforward全体を実行する経路もあります。 | 選んだモデルに対応するGGUF。CUDA経路を選ぶ場合は対応ドライバーとネイティブライブラリ。 |
| RAMより大きなモデルを使う | GPT-OSS-20BのCPUホストは、AIKernelの仮想メモリで重みをSSDから必要に応じて読み込みます。 | 対応する重み、SSD、ホストのメモリ予算。 |
| 操作を実行してよいか評価する | Bonsai 1.7BのCTGが、操作の提案とホストが取得した観測を別々に受け取ります。 | ホスト側の権限確認と、ハッシュを固定した `rom/governance` の三規則。  通常のチャットは登録JSONの固定票を使います。操作ごとの評議には[ホスト統合例](inference-api-0-1-4-jp.md#bonsaictgcouncilevaluator)を参照してください。 |

まず検証用プロジェクトで契約パッケージとCoreの参照を0.1.4にそろえます。旧LibTorch追加パッケージを使うアプリは0.1.3の構成を保存し、CUDA Driver経路への切り替えを個別に試してください。[パッケージの役割](../architecture/module-map-jp.md) · [モデルごとのアクセラレーター](https://github.com/AIKernel-NET/AIKernel.Core/blob/dev/docs/inference-accelerators-0.1.4.md)

## Cosmosで最初の回答を確かめる

開発版のCore・Providers・Monolithを同じ親ディレクトリに置き、.NET SDK 10.0.404系を用意します。[Monolithの起動手順](https://github.com/AIKernel-NET/AIKernel.Monolith/blob/dev/README.md#run-the-monolith)に沿って4つのディレクトリを作り、Edgeを `models/edge` に取り込み、検証用の[登録JSON](https://github.com/AIKernel-NET/AIKernel.Monolith/blob/dev/samples/cosmos-edge.json)を `models/cosmos-edge.json` に配置します。手順中のインストーラーは既知のマニフェストと照合し、ディスク上のSHA-256を登録します。登録IDは `cosmos-edge` です。[取り込みに必要なツールと容量](https://github.com/AIKernel-NET/AIKernel.Core/blob/dev/docs/cosmos3-inference.md)

ホストが `127.0.0.1:8080` で起動したら、クライアントの環境変数 `AIKERNEL_API_KEY` にホストと同じ認証トークンを設定し、受付状態を確認します。

```bash
curl --fail-with-body -H "Authorization: Bearer $AIKERNEL_API_KEY" \
  'http://127.0.0.1:8080/v1/models/admission?model=cosmos-edge'
```

`admissible` が `true` なら、同じ登録IDで質問を送ります。初回の生成時には重みの検証と読み込みも行います。

```bash
curl --fail-with-body -H "Authorization: Bearer $AIKERNEL_API_KEY" \
  -H 'Content-Type: application/json' \
  -d '{"model":"cosmos-edge","messages":[{"role":"system","content":"You are helpful."},{"role":"user","content":"What is 2 + 2? Answer briefly."}]}' \
  http://127.0.0.1:8080/v1/chat/completions
```

この入力に対する参照回答は `4` です。`choices[0].message.content` で回答、`choices[0].finish_reason` で終了理由 `stop` を確認します。HTTP 401ならホストの認証トークンを確認してください。受付不可なら先に登録ID、モデルの配置、マニフェスト、トークナイザーの有無を確認します。

## 7 GB枠で運用するとき

Serverで再現した設定は、4ワーカー、`maximumResidentBytes=7000000000`、`weightCacheBytes=3221225472`（3 GiB）、`kvCacheBytes=128000000`（128 MB）です。6条件で参照トークン列が一致し、最大RSSは3.564 GBでした。KVを8 MiBに絞ると、同じ6条件のSSD書き込み合計は84 KiBから18.09 GBに増えました。RAMを節約するときは、実際の入力で最大RSSと書き込み量を一緒に確認してください。[入力・測定条件と結果](https://github.com/AIKernel-NET/AIKernel.Core/blob/dev/docs/development/evidence/cosmos3-server-7gb-20261120/README.md)

初回応答が遅いときは、非公開監査ログの `model_load_ms` と `prefill_ms` を先に見ます。前者には重みの検証、後者には入力トークンの処理が含まれます。Windows Native AOTでは `cosmos.profilePrefill` を有効にすると、実行ファイルが選んだBF16内積と射影時間も記録されます。実モデルでの汎用版とAVX2版の速度差は検証待ちです。[監査項目と計測手順](https://github.com/AIKernel-NET/AIKernel.Monolith/blob/dev/README.md)
