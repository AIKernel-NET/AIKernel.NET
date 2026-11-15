# v0.1.3 外部レビューの基準記録（S0）

対象は 2026-11-10 時点の `D:\AIKernel\repos` にある10リポジトリ。記録は `AIKernel.NET` の `review/S0` に集約する。Doom は `dev` をビルド・テストし、ローカルの作り直しは別の参照として調査した。

## Git の基準点

開始時点では全10件が `dev` で、各 `origin/dev` と同じコミットを指していた。追跡済みファイルの変更と未追跡ファイルは0件。`review/*` と `dev` 履歴上の `[S0]` は0件だった。リモートの `v0.1.3` は `git ls-remote --tags` で照会し、既にローカルにあるコミットを比較に使った。

| リポジトリ | `dev` | 比較元 | 比較元のみ / `dev` のみ | ファイル差分 |
|---|---|---|---:|---|
| NET | `02b116f` | `v0.1.3` `3f10f16` | 0 / 97 | 0 |
| Core | `dd8b258` | `v0.1.3` `f85fdc5` | 0 / 254 | 0 |
| Providers | `db7e989` | `v0.1.3` `75f3c3d` | 0 / 22 | 0 |
| Cuda13.0 | `9e3ef82` | `v0.1.3` `202ae0f` | 0 / 23 | 0 |
| Control | `2229477` | `v0.1.3` `5dc0b50` | 0 / 27 | 0 |
| Tools | `05ec021` | `v0.1.3` `40e3018` | 0 / 26 | 0 |
| Wasm | `2c6b11f` | `v0.1.3` `b6021f3` | 0 / 6 | 0 |
| Demo | `b3fcb62` | `v0.1.3` `8c960f5` | 0 / 21 | 0 |
| Doom | `3df7008` | `main` `a6e521d` | 0 / 4 | 275ファイル |
| RH | `cd2bce4` | `main` `89b3728` | 1 / 52 | 0 |

Doom と RH の `main` は `v0.1.3` タグが存在しないための参考値。Doom の `backup/pre-dev-sync-20261109-185432Z` (`e5fe167`) は `dev` の2コミット先で、`dev` との差分は189ファイル。Doom の作り直しを対象とする BZ1 と DO2 では、このブランチの取り込み状況を確認してから修正対象を選ぶ。

## ビルドとテスト

Windows、.NET SDK `10.0.401`、各リポジトリの `.slnx` を `dotnet build` / `dotnet test` の `Release` で実行。RH は `lean/` で `lake build`（Lean `4.31.0-rc1`）。Ubuntu、CUDA 実機での推論、ブラウザーの実 GPU はこの基準記録の実行範囲外。

| リポジトリ | ビルド | テスト合格 | テスト失敗 |
|---|---|---:|---:|
| NET | 成功 | 173 | 0 |
| Core | 成功 | 439 | 0 |
| Providers | 成功 | 120 | 0 |
| Cuda13.0 | 成功 | 21 | 0 |
| Control | 成功 | 42 | 0 |
| Tools | 成功 | 34 | 0 |
| Wasm | 成功 | 64 | 0 |
| Demo | 成功 | 71 | 0 |
| Doom | 成功 | 133 | 2 |
| RH | `lake build` 成功（5899ジョブ） | 対象外 | 対象外 |

初回の Core restore と RH の mathlib 取得はサンドボックスの DNS 制約で失敗した。ネットワーク接続を許可した再実行の結果を基準とする。初回の .NET 並列起動でも診断なしの終了コード1が出たため、再実行はリポジトリ単位で直列化した。

Doom `dev` (`3df7008`) の既存失敗は次の2件。再実行でも同じ結果だった。

- `DoomWebGpuProvider_SeparatesRawFramebufferAndHudCompositeTargets`（`DoomWebGuiTests.cs:293`）
- `DoomPrompt_UsesCanonicalAisthesisNoesisKrisisKinesisPanelMapping`（`DoomWebGuiTests.cs:705`）

どちらも `gpu-contracts.js` の `HUD_UNIFORM_FLOAT_COUNT` の期待値が `32`、実装が `36`。ローカルチェックポイント `e5fe167` のソースでは両テストの期待値が実装の `36` と一致する。表の実行結果は `dev` のもの。

Demo の `NuGet.config` は `nuget.org` のみを指定し、既定の依存版は `0.1.3`。この構成でビルドとテストが成功した。NET の旧パッケージ整合ガイドに代わる [v0.1.3 のガイド](../development/package-release-alignment-v0.1.3-ja.md) も確認した。

## 主要指摘の現状

| ID | 根拠 |
|---|---|
| G1 / G2 | 対象10件の追跡ファイルにルートの `.gitattributes` と `global.json` がない。Core などには PyPI 公開ワークフロー、Cuda13.0 には手動の公開ワークフローがある。`dev` の push / PR で Windows・Ubuntu の restore / build / test / pack を実行する検証ワークフローは見つからなかった。RH の Lean ワークフローは `lean/.github/workflows/` にある。 |
| CT1 | Core の公開ゲートを実行。Logos と Pathos を Approve に固定すると、Ethos が `-1`、`4`、`int.MinValue` の各ケースで `Allow` になった。Control の `ProviderVoteAdapter` も `VoteValue` をそのまま渡す。 |
| PV1 / PV2 | ソースを確認。物理ファイルセッションはルート境界を持たず、削除は `Directory.Delete(..., recursive: true)`。HTTP は既定または注入された `HttpClient` に委譲し、TCP と WebSocket は渡されたホストへ直接接続する。実ネットワークの内部アドレスへの接続は試験対象から外した。 |
| B1 | `KernelClock.System()` を使った `LocalExecutionInvoker` を実行。30秒・3反復で本体の実行数は0、リプレイ記録は1件、公開ステータスは `Succeeded` だった。`CompiledDslPipeline` は Unix epoch の開始時刻との差で初回から `timeout_reached` に分岐する。 |
| B2 / B3 | `"1"` は inline DSL に受理された。両パーサーは `InvariantCulture` を指定している。重複 `name` は最後の値を採用し、未知のノードフィールドも受理した。 |
| PV3 / WS1 | `OpenAICompatibleProvider` は Debug に限って完了理由を含む投影を作り、成功時は本文を返す。`WebGpuResidentModelProvider` は `ManifestRef` をメタデータに残すが、モデルとカーネルのハッシュを照合していない。 |
| H1a / TL1 / TL3 | `ResultStepIdentity` の StepId と ReplayLogHash に `AppendLine` が残る。`CanonicalFormatter` は辞書を整列する一方、文字列をそのまま出力し、曖昧さのない正規エンコードには使えない。Tools の `RomExporter` では、生成時刻によって署名欄のコンテンツハッシュが変わる。`romId` の値そのものは入力から決まる。 |
| DM2 | 英日 README は `/v1/chat/completions` を案内するが、`AIKernel.Demo.WebApi/Program.cs` は `/` と `/demo/pipeline` の GET のみ。 |

CT1、B1、B2、B3 は一時プローブで実行した。B3 の候補は JSON ノードの `type` を追跡済みのテキストから検索し、NET の仕様・原稿4ファイル、Core のテスト3ファイル、Tools の仕様・テスト3ファイルを抽出した。Core の `DslRomTests.cs` には ROM 内の JSON フィクスチャもある。Doom の `dev` とローカルチェックポイントから、この書式の候補は見つからなかった。

## Cuda13.0 の棚卸し

| 観点 | 確認結果 |
|---|---|
| SHA-256 | `LibTorchCapabilityInvoker.cs:372` と `LlamaForwardResult.cs:36` の2箇所で直接 `SHA256.HashData` を呼ぶ。出力は既に `sha256:` と小文字16進。ロード時の `model_path_hash` はパス文字列を識別する。ロード結果の `OutputHash` はモデルハンドルとパスに依存するため、モデルバイトの整合性検証やプロセスをまたぐ内容 ID には使えない。 |
| 未知の値 | 未知の操作名・pass ID は拒否される。管理側の `FromNativePointer` も未定義の status/reason を `NotInitialized` / `DeviceUnavailable` に変換する。未知の操作がネイティブライブラリをロードせず失敗する既存テストがある。 |
| モデル境界 | `ResolveMappedModelPath` はマッパーがないと指定パスをそのまま使用する。`torch::jit::load` の前に許可ルートやコンテンツハッシュを検証する処理は見つからなかった。DLL 探索の `loader.json` と環境変数は別のホスト設定境界。 |
| ABI とリソース境界 | ネイティブ dispatch は最小バッファ長、ABI、既知 pass を確認してから失敗応答を返す。`header_size` の上限、`payload_bytes` と実際の長さの整合、管理側の応答ポインターと受信長の対応は未検証。dispatch は現在コマンド送信を拒否する。`forward` の管理側にトークン数上限はあるが、ネイティブ単独呼び出しは正の長さのみを要求する。logits は CPU 転送・連続化の後に4096要素へ制限し、トークン選択もその範囲で行う。 |

追加所見として、Wasm の `IWebGpuBackend.cs:320` にもベクトル加算の部分文字列判定がある。Providers の WS2 と同じ識別の問題が別経路に残る。範囲追加の判断用に記録する。

## ▲ の選択肢と推奨

### P1

| ID | 影響範囲 | 選択肢と推奨 |
|---|---|---|
| CT2 | Control の `CouncilDecisionBuilder` と `CouncilDecisionToGateInputAdapter` がともに `VoteId` 順で代表票を選ぶ。 | 重複をすべて拒否する案と、同値をまとめて競合を `Unknown` にする案。後者を推奨。両経路で同じ規則を適用し、同値とみなす範囲は評議会と投票値に限定する。票の出所は診断に残す。 |
| PV1 | Providers の `PhysicalFileSystemProvider` と物理 VFS セッションの読み書き・列挙・削除。既定コンストラクターで操作する契約テストがある。 | 明示ルート必須の既定拒否を推奨。既存の無制限動作を既定に残す互換案では境界を保証できない。ルート相対で各操作を解決し、シンボリックリンク・ジャンクション・差し替えを検査から実操作まで防ぐ。安全な解決ができない環境ではリンクを拒否し、再帰削除は明示設定にする。 |
| PV2 | Providers の HTTP GET/POST、TCP、WebSocket。注入 `HttpClient` と host/port 形式の WebSocket API にも影響する。 | ホスト・ポート・スキーム許可リストを空なら拒否とする案を推奨。DNS の全応答を検査し、許可済み IP に接続を固定する。HTTP/WS の自動リダイレクトを止め、各遷移を再検証する。IPv4-mapped IPv6、非公開・予約範囲、プロキシの迂回も扱う。任意の注入クライアントに委譲する案は接続先を保証できる場合に限る。 |
| PV3 | Providers の `OpenAICompatibleProvider`、完了理由の投影、呼び出し側の失敗処理。 | 部分本文を成功のまま返す案と、`length` / `content_filter` を別々の失敗コードにする案。後者を推奨。SDK の表記を含めて1箇所で判定し、Debug の有無を変えたテストを追加する。 |
| WS1 | Wasm の resident model 記述子、GPU アップロード、Doom などのアセット作成・配布。 | 信頼できる版付きマニフェストにモデルバイトと WGSL の期待値を宣言し、両方をアップロード・実行前に照合する案を推奨。既存マニフェストには移行ツールを用意する。実測値だけを記録する案では改ざんを拒否できない。 |
| B2 | Core の inline JSON と ROM DSL の両パーサー。追跡済みソース・文書・ROM の timeout を検索した結果、NET の英日 DSL 仕様は `"00:00:10"`、Core のテストは `"00:00:00"`、`"00:00:10"` と、範囲外の数値 `1000000000000000` を使う。追跡済みの ROM に別書式は見つからなかった。現行 JSON の数値単位は秒。 | 新しい DSL 版は `PT10S` / `PT0S` のような固定長 ISO 8601 期間に限定する案を推奨。旧版の読み取りと変換を版で分離する。即時に全入力を切り替える案は既存テストと外部 DSL に影響するため、版と移行範囲を承認時に決める。 |
| B3 | `DslDocumentParser` と `LocalExecutionInvoker` の inline/ROM 経路。JSON の `args` は能力固有のキーを持つ。 | 両経路を単一パーサーにまとめ、ノード種別ごとの既知フィールドと全階層の重複キーを検査する案を推奨。`args` はマップとして重複を検査し、個々のキーは能力側に任せる。既存の JSON フィクスチャ、仕様例、ROM 抽出結果を受理コーパスにし、未使用フィールドを捨てる互換モードは既存版の読み取りに限る。 |

### P2

| ID | 影響範囲 | 選択肢と推奨 |
|---|---|---|
| I2 | `Result<T>.Success(null)` と `Map` / `Bind`、nullable payload の利用箇所。 | 全 `Result<T>` で `NULL_VALUE` にする案と、null を明示的に許可する別表現を残す案。通常の `Success(null)` は失敗にし、意図的な欠損は `Option<T>` 等へ移す案を推奨。既存の nullable 成功ケースと利用者契約は先に棚卸しする。 |
| PF2 | Core の JSON と DTO コンパイル経路。入れ子の `Loop` / `LoopUntil` と能力呼び出しが対象。 | ノード数だけに上限を設ける案と、最悪実行ステップ数・深さの双方を制限する案。後者を推奨。加算・乗算は上限で飽和させ、超過は `DSL_COMPILE_ERROR`。上限値は既存コーパスと運用予算に基づいて決める。 |
| CT3 | Control の `ProviderVoteAdapter`、`CtgGateTelemetryValidator`、票とゲートトレースの契約。 | キーのブラックリストを延長する案と、診断用テレメトリを専用の型・フィールドに分離する案。後者を推奨。離散ゲートには型付き投票と許可された離散メタデータのみを渡し、旧メタデータの取り込みで連続値が混入しないようにする。 |
| WS3 | Wasm の `WebGpuResidentModelProvider` の capability と `WasmProviderBase` の `MaximumRiskLevel` 比較。ReadOnly 上限の利用者は分類変更後に選択できなくなる。Control 内にはこの capability 専用のリスク比較は見つからなかった。 | 既存 `Medium` を使う案と、新しい実行区分を契約に追加する案。まず既存 `Medium` で明示ポリシーを要求する案を推奨。ReadOnly、Medium、既定上限で Wasm の選択と下流のフォールバックを検証する。 |
| BZ1 | 共通の Logos/Ethos/Pathos provider は `Unknown` を返す。Doom の `e5fe167` には独自の決定論的な評議会があり、Ethos も3値を返すが、共通 provider の Bonsai 制約デコードを置き換えた形跡はない。 | 自由文の解析と、3ラベルだけを採点する制約デコードを比較し、後者を推奨。既存の拒否を維持し、同点・閾値未満・非有限スコア・不正出力は Reject。CT1・WS1 の後に、GGUF の実測ハッシュ、カーネル ID、実バックエンド、DSL プロファイル版とハッシュ、同意の有無を記録し、再推論に依存しないリプレイを検証する。閾値とスコア単位は版付きプロファイルで決める。 |

### P3

| ID | 影響範囲 | 選択肢と推奨 |
|---|---|---|
| F2 | NET / Core の共通バイト表現。H1b、F1、F4、TL2b、TL3 の前提。 | 型タグ・版・長さ付きフィールドを共通バイナリ表現にする案と、JCS を共通 JSON 表現にする案。正確な整数・バイト列を含む共通ハッシュ入力には前者を推奨。UTF-8、NFC、LF は対象フィールドごとに明文化する。JCS は文字列の Unicode 正規化を行わないため、採用時の NFC/LF は JCS 適用前の版付きプロファイルで定義する。[RFC 8785](https://www.rfc-editor.org/rfc/rfc8785.html#section-3.1) |
| H1b | Core の StepId 生成・既存 ReplayLog 検証と下流の照合。 | 区切りのエスケープと、F2 で v2 の長さ付きフィールドを導入する案。後者を推奨。`\n` と `=` を含む値の衝突例、v1 の既存 ID 検証、v2 のドメイン分離を固定ベクトルで確認する。 |
| F1 | NET の `rom/governance`、Core の生テキストハッシュ、Tools の `aik rom`。基準点では英日 `gate.decision` の行末空白は各28行。 | 全行の空白除去と、版付きの構文理解による正規形を比較し、後者を推奨。Markdown の意味を持つ末尾空白やコードブロックを保護する。`fmt` は明示操作、`verify` は読み取り専用とし、v1 と v2 の検証を共存させる。 |
| TL1 | Tools の `CanonicalFormatter` / `ICanonicalFormatter`、`Inspector`、`CanonicalSerializer` と Demo の呼び出し。 | 表示形式をその場で正規化する案と、表示用の名前へ移し旧 API を `Obsolete` で残す案。後者を推奨。文字列や辞書の現行表示を維持し、ハッシュ用には F2 の入口を使う。 |
| TL2b | 各パッケージの JSON、トレース、ハッシュ比較と保存済みデータ。 | 一括置換と、版付きで新規書き込みだけを `<alg>:<小文字16進>` に統一する案。後者を推奨。旧表記を検証できる読み取り経路と、アルゴリズムごとの形式・長さチェックを用意する。 |
| TL3 | Tools のエクスポート、生成日時の表示、署名欄のコンテンツハッシュ。Core の別 exporter にも生成時刻を含むハッシュがある。 | 時刻を外した内容ハッシュを版付きで発行する案を推奨。生成日時は来歴に保存し、対象の内容フィールドと ROM 名の扱いを明記する。旧ハッシュは旧版の式で検証する。Core の exporter を含める場合は範囲を明示する。 |
| I3 | Core の `ResultStep` と ReplayLogHash、保存済みの失敗トレース。 | 末尾を上書きする現方式と、失敗イベントを追記する新版。追記を推奨。元ステップの ID と内容を保持し、失敗イベントを結び付け、旧ログの検証を残す。 |
| C1 | NET の `ExecutionStatus`、Core の DSL 結果投影、LocalExecution と下流の status 判定。`Rejected`、`Canceled`、`TimedOut` は既存 enum 値。LoopUntil の期限到達は今回のプローブで `Succeeded`。 | 期限を正常な制御遷移として扱う DSL と、実行全体の期限切れを区別する案を推奨。実行全体の拒否・キャンセル・期限切れは既存値へ明示対応させる。`Suspend` は再開契約まで決まった場合に新版の状態として追加する。 |
| C2 | Core の CTG 分類器、診断・理由コードと消費側。 | 共通 Unknown 理由に補足を付ける案と、Ethos 未評価専用の版付き理由を導入する案。後者を推奨。実際の Reject、Ethos 未評価、他評議会の Unknown を区別し、複数該当時の優先順位を固定する。 |
| C3 | NET の CTG Technical Note（Paper 12）の英日原稿と decision / trajectory ROM。 | 文書を ROM の規則へ合わせる案を推奨。`Approve, Abstain, Abstain` のように正の総和と2票要件で結果が異なる例、Ethos veto、空の軌跡は事前条件違反のため Halt になることを示す。公開版は別の改訂として扱う。 |
| C4 | NET の拡張識別子と契約、Core のゲートと ROM 由来トレース。 | 任意差し替えと、Canon の判定に追加制約を重ねる案。後者を推奨。Canon が Deny なら拡張後も Deny、理由は `Canon.CTG.<codename>.*`、適用順と ROM ハッシュを記録する。 |
| F3 | NET の署名・ハッシュ契約、Core の検証と信頼済み鍵、移行履歴。 | 自由なアルゴリズム指定と、用途別の版付き許可リスト。後者を推奨。新規の最小構成は SHA-256 と ECDSA P-256/SHA-256。RSA 互換が必要なら RSA-PSS/SHA-256 と3072ビット以上を別枠で承認する。移行は旧鍵と新鍵で同じ記録に署名する。.NET 10 の実験的 PQC 署名 API は独立した試験枠とする。[.NET 10 の暗号化 API](https://learn.microsoft.com/en-us/dotnet/core/whats-new/dotnet-10/libraries#post-quantum-cryptography) |
| F4 | Core の ChatChain のターン、連結ハッシュ、ルートと検証。 | 現行形式の延長と、JCS＋ドメイン分離された版付きチェーン。後者を推奨。F2 が定義する文字列前処理を適用し、leaf / link / root を区別する。旧チェーンをその版で検証できるようにする。 |
| DM4 | Demo / NET の HTTP 契約、認証、モデルルーティング、CTG の拒否表示。 | 一括で互換範囲を広げる案と、非ストリーミング `POST /v1/chat/completions` から仕様を固定する案。後者を推奨。成功、入力不正、CTG 拒否、上流エラーの HTTP 状態と OpenAI 形式のエラー本文を明示し、CTG 拒否を HTTP 403 と安定した `error.code` で検証できる仕様にする。 |
| DO2 | Core の JSON ノードと Doom の `DynamicPipelineDslParser` / `DynamicPipelineDslStatementParser`。両方の Doom ブランチに独自パーサーがある。 | Doom 文法を直ちに置換する案と、既存のテキスト構文を版付きの共通中間表現へ変換する案。後者を推奨。Doom 固有の CTG・センサー・行動語彙は拡張として表現し、同じ入力で行動・拒否・トレースが一致することを確認する。 |

## 次の項目

G1 を NET と Core から進める。Cuda13.0 の Windows ネイティブ公開レーンと Ubuntu のマネージド検証は別扱い。Demo の公開パッケージ検証は、空のパッケージキャッシュと NuGet.org の明示ソースで独立させる。▲ は承認された行の選択に従う。
