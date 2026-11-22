# AIKernel.NET リリースノート

[English](RELEASE_NOTES.md)

## 0.1.4（公開準備中）

HTTP API と MCP ツールから同じ業務処理を呼ぶアプリ向けに、エンドポイント、ツール、認証、接続先管理と生存確認の契約を追加しました。Kestrel と MCP の実装は任意パッケージ `AIKernel.Providers.Distributed` から登録できます。

Perception、Cosmos、Council、マニフェスト読み込み・検証の公開契約を共有パッケージに収録しました。既存の名前空間と旧アセンブリからの型転送を維持しています。

0.1.3から更新する方は、[モデルの選び方と最初の回答の確認手順](docs/overview/upgrade-0-1-4-jp.md)から始めてください。 SDKから呼び出す場合は[Cosmos・Gemma・Bonsai CTGのAPI例](docs/overview/inference-api-0-1-4-jp.md)を参照してください。

- Cosmos 3 Edge／Nano の取り込み済み重みで、文章・RGB画像・時刻付き動画フレームから応答を生成できます。CPU推論は CUDA と LibTorch が不要です。対話APIは各ターンの発言者と画像を保って次の質問を処理します。
- Monolith のモデル登録で、使用するモデルと import-manifest.json の SHA-256 を固定できます。WebSite の日英チャットでは、接続状態を確認し、同じ写真について続けて質問できます。利用者のAPIキーは不要です。
- Cosmos のモデル登録とローカルチャットの起動引数で、実メモリ予算と重み・KVキャッシュの容量を指定できます。ホストの監査ログには、要求ごとの重みとKVの読み戻し回数を記録します。受付時にトークナイザーや前処理ファイルの欠落も検出します。Monolith の `/health` では実行中のホストのバージョンを確認できます。
- Cosmos 3 Edge／Nano を4ワーカー、モデルホストの7 GB枠で実行し、文章・画像・動画の全6条件で参照回答と生成トークン列が一致しました。標準KV設定（128 MB）での最大RSSは3.564 GBです。6件合計のSSD書き込み量は標準設定で84 KiB、KVを8 MiBに制限した試験で18.09 GBでした。 [開発機との比較と測定条件](https://github.com/AIKernel-NET/AIKernel.Core/blob/c502bfda7017779783809507b18e3929ad5b6e52/docs/development/evidence/cosmos3-server-7gb-20261120/README.md)
- GPT-OSS-20B は Server の実メモリ7GB枠でSSDへのページングを使用し、検証用2入力で llama.cpp と生成トークン列を照合しました。
- Gemma 4 E2Bでテキストを生成できます。CPU実行と、対応するNVIDIA GPUに重み・KV・forward処理を置く実行に対応します。[対応GGUFと数値検証](https://github.com/AIKernel-NET/AIKernel.Core/blob/dev/docs/gemma4-e2b-inference.md)
- Bonsai 1.7B のCTGは、操作の提案とホストが取得した観測を分け、governance ROMの規則で判断します。Serverでの再生成16例と保存応答の再生60例を合わせた76例で、期待した許可30件・拒否46件と一致しました。[運用手順と評価の内訳](https://github.com/AIKernel-NET/AIKernel.Core/blob/dev/docs/development/bonsai-ctg-operations-jp.md)
- Cosmosの重みがキャッシュに収まらない場合、Prefillは最大32トークンずつ重みページを共有します。ホストの非公開監査で初回読み込み、入力処理、生成にかかった時間を確認できます。[メモリ設定と監査](https://github.com/AIKernel-NET/AIKernel.Core/blob/dev/docs/cosmos3-inference.md)
- CPU版を標準とし、対応GPUには CUDA Driver 経路を用意します。旧 LibTorch 追加パッケージの配布版は 0.1.3 です。

## 0.1.3

- GPU Provider と各パスのインターフェース、フレーム／ターゲット DTO、能力フラグ、診断メタデータ、共有検証を契約パッケージに追加します。契約パッケージに GPU ランタイムは含めません。
- raw framebuffer を HUD・表示用ターゲットから分離し、Provider／ブリッジの境界でレイアウト、能力、診断を検証します。
- 移行とローカル検証の手順は [GPU 移行ガイド](docs/migration/v0.1.3-gpu-canonical-migration-jp.md) と [リリース整合ガイド](docs/development/package-release-alignment-v0.1.3-ja.md) を参照してください。

## 0.1.2

**2026年6月16日 - 正典 Interface line。**

AIKernel.NET 0.1.2 は、AIKernel Semantic OS family の正典 contract package line です。

- `AIKernel.Abstractions`、`AIKernel.Contracts`、`AIKernel.Dtos`、`AIKernel.Enums` を同期公開します。
- public documentation、package installation guidance、migration notes を 0.1.2 package family に揃えます。
- CTG と v0.1.1.1 の履歴ドキュメントは migration reference として維持し、active public line は 0.1.2 に統一します。
- downstream の Core、Control、Providers、CUDA、Wasm、Tools package を 0.1.2 dependency chain で支えます。
