# NET S0・G1・G2 統合候補の検証記録

検証日: 2026-11-16。0.1.4 に向けた基盤整備の統合候補であり、リリース成果物ではない。

## 対象と統合結果

- ベース: `dev` = `02b116f3203951184b223478e5ce6dbb767c22f8`
- 候補ブランチ: `review/NET-S0-G1-G2-integration`
- 専用 worktree: `C:/Users/HP/.codex/worktrees/net-s0-g1-g2-integration/AIKernel.NET`
- 検証した実装・設定: `eead76a`。この後のコミットは本記録のみ。

| 取り込んだブランチ | 元の先端 | 統合コミット | 内容 |
|---|---|---|---|
| `review/S0` | `7ddca8f46541adf00e71d507dc6ef5b26e5cc8f8` | `ef551d4` | 現状、既存失敗、承認待ち項目の基準記録 |
| `review/G1` | `cabb1a6d16ac9e1302bc7fcf05da616e8d83516e` | `c9721e6` | dev の push / PR を対象にした Windows・Ubuntu の restore / build / test / pack |
| `review/G2` | `73695c0f41606fd83933f2b877580099facb9491` | `3aee624` | LF 属性、SDK 固定、0.1.3 を基準にしたパッケージ検証 |

3 回とも Git の競合なし。S0・G1・G2 の先端が候補の祖先であることを確認した。
統合時の調整は CI の SDK 選択だけで、`eead76a` に記録した。
`setup-dotnet` の `dotnet-version: '10.0.x'` を `global-json-file: global.json` に変更し、
G2 が指定する `10.0.401`（`latestPatch`、preview 不可）との不一致を防いだ。
入力名は [setup-dotnet v6 の公式定義](https://github.com/actions/setup-dotnet/blob/v6/action.yml)で確認。

`src/` は dev から差分なし。公開 API・DTO・enum・ハッシュ計算・既存テスト期待値は変更していない。
バージョンも変更していない。既存ファイルへの一括 `--renormalize` は実行していない。

## 検証方法

Windows の .NET SDK `10.0.401`、Release 構成で実行した。
NET は候補 worktree、下流 8 件は各 dev の `git archive` から作成した隔離コピーを使った。
他の review ブランチと元の未コミット変更は検証用ソースに含めていない。

NuGet は既存の公開版キャッシュから複製した 71 パッケージを使用し、元ファイルの SHA-256 を記録した。
公開済み NET 0.1.3 を保持する `baseline-feed` と、新しく生成した NET 4 パッケージを置く
`candidate-feed`、NET 用と下流用の復元キャッシュを分離した。共有キャッシュは書き換えていない。

1. NET の既定設定 `0.1.3-dev0` で restore / build / test / pack。
2. NET の `UseLocalPackageVersion=false` で restore / build / test / pack。
   下流の厳密な `[0.1.3]` 参照を保ったまま候補を検証するための隔離用パッケージを作成。
   **この 0.1.3 パッケージは公開・配布用ではない。**
3. 新しく生成した `AIKernel.Enums` / `Dtos` / `Contracts` / `Abstractions` を candidate-feed へ配置。
   下流 8 件の restore / build / test を順番に実行。
4. NET のビルド DLL、nupkg 内 DLL、下流の復元キャッシュ、下流の Release 出力にコピーされた
   DLL の SHA-256 を全件照合し、候補の実体が使われたことを検証。

NET では `EnablePackageValidation=true`、`PackageValidationBaselineVersion=0.1.3` を維持し、
元の公開版を基準にした検証を有効にしたまま両構成の build / pack が成功した。
API 互換性の除外・抑制は追加していない。

代表コマンド（`SOLUTION` は各リポジトリの `.slnx`。NET は `src/AIKernel.NET.slnx`）:

```powershell
dotnet restore SOLUTION --configfile LOCAL_FEED_CONFIG --packages ISOLATED_CACHE --force --no-http-cache -p:NuGetAudit=false -m:2 -nr:false
dotnet build SOLUTION -c Release --no-restore -m:2 -nr:false -p:UseSharedCompilation=false
dotnet test SOLUTION -c Release --no-build --no-restore --logger 'trx;LogFilePrefix=REPO' --results-directory RESULTS -m:2 -nr:false
dotnet pack src/AIKernel.NET.slnx -c Release --no-build --no-restore -o OUTPUT -m:2 -nr:false
```

NET の stable 検証では全コマンドへ `-p:UseLocalPackageVersion=false` を追加。
ローカル限定の検証では脆弱性情報取得を `NuGetAudit=false` で無効にした。CI にはこの設定を追加していない。
Core の最初の sandbox 内 restore は診断出力なしで終了コード 1 となったため、同一の隔離コピー・ローカルフィードで
sandbox 外から再実行した。下表は再実行後の結果。

## 結果

| リポジトリ | 検証ソース | restore | build | テスト合格 | テスト失敗 |
|---|---|---|---|---:|---:|
| NET | `eead76a (統合候補)` | 成功 | 成功 | 173 | 0 |
| Core | `dd8b258eba1d` | 成功 | 成功 | 439 | 0 |
| Providers | `db7e989fad73` | 成功 | 成功 | 120 | 0 |
| Cuda13.0 | `9e3ef8268b09` | 成功 | 成功 | 21 | 0 |
| Control | `2229477a719f` | 成功 | 成功 | 42 | 0 |
| Tools | `05ec02165ae8` | 成功 | 成功 | 34 | 0 |
| Wasm | `2c6b11f47c81` | 成功 | 成功 | 64 | 0 |
| Demo | `b3fcb62035f4` | 成功 | 成功 | 71 | 0 |
| Doom | `3df7008d990a` | 成功 | 成功 | 133 | 2 |

NET を 1 構成として数えた合計は **1,097 合格、既存 2 失敗、新規失敗 0**。
NET の stable 構成も別途 173 / 173 合格。NET は両構成とも pack 成功、build は警告 0・エラー 0。
新規テストは追加していない。既存テストとパッケージ互換性検証で統合を確認した。

Doom の既存失敗は [S0 の記録](REVIEW_S0-v0.1.3-jp.md)と同じ次の 2 件:

- `DoomWebGpuProvider_SeparatesRawFramebufferAndHudCompositeTargets`
- `DoomPrompt_UsesCanonicalAisthesisNoesisKrisisKinesisPanelMapping`

どちらも `HUD_UNIFORM_FLOAT_COUNT = 32` の期待と、実装の `36` の不一致。
テスト名・失敗内容を照合し、既存テストと実装は変更していない。

追加確認:

- `actionlint 1.7.12 -shellcheck= -pyflakes= .github/workflows/ci.yml`: 成功。
- `git diff --check dev`: 成功。
- `git check-attr`: テキストは `text=auto eol=lf`、PNG / GGUF / DLL は `text` 無効。
- `git diff dev -- src`: 空。製品コードとテストは統合前と同一。

### 候補 DLL の照合

| パッケージ | 候補 DLL SHA-256 | 一致した下流出力数 |
|---|---|---:|
| AIKernel.Enums | `215c170f1e1480de146a51d1077d55670fc526f9601abd10473e4390195a4943` | 31 |
| AIKernel.Dtos | `2c3942a460eb47b614fd541d5daf79f15ff5a9d2dff25cdb99e78e1f87b95e5a` | 31 |
| AIKernel.Contracts | `0ba18a9da2c0ec5579f7fcf1e48a971321ca9ebddc6f1c43278acd54b64642c2` | 1 |
| AIKernel.Abstractions | `e501622bd6d832e920b2a85b680ee94ae1484d1de8565ae0ab2dd2d433a9a8f0` | 28 |

## 未コミット変更の保持

元の `D:/AIKernel/repos/AIKernel.NET` は `review/G2` のまま。
変更済みの追跡文書 30 件と未追跡ファイル 3 件について、前後の状態と SHA-256 が一致した。
ステージ済みツリーも同一。新規の候補ブランチを除き、既存のローカル・リモート追跡参照・タグ・stash は変更していない。
下流の dev 参照 8 件も検証開始時の値を維持している。

## 実行していない検証と次の判断

- Ubuntu の既存 WSL 環境では PATH 上に .NET SDK がなく、Linux 実行は未検証。
  GitHub Actions の `windows-latest` / `ubuntu-latest` 実行も未実施。CI 定義の構文検査とローカル Windows 検証まで。
- NuGet.org からの新規取得とオンライン脆弱性監査は未実施。既存キャッシュを使った再現可能なローカル検証。
- CUDA / WebGPU / Cosmos の実機検証、TheoriaCast 共同受入、下流の review ブランチ同士の統合は対象外。
- RH は NET 契約パッケージの下流ではないため今回の再実行対象外。
- dev への取り込み・push・PR・タグ作成・公開は行っていない。

次はこの候補のレビューと、dev へ取り込むかどうかの判断。
本記録だけで 0.1.4 の公開条件全体が満たされたことにはしない。

## ローカル証跡

`D:/AIKernel/.codex_tmp/net-s0-g1-g2-integration-20261116/` に次を保持する:

- `run-validation.ps1` / `prepare_validation.py` / `verify-validation.py`: 検証手順。
- `dev-heads.json` / `source-package-hashes.json`: 検証対象と元パッケージの識別。
- `NET-status.json` / `Downstream-status.json` / `verified-results.json`: 終了コード、TRX 集計、DLL 照合。
- `*-restore.log` / `*-build.log` / `*-test.log` / `NET-*-pack.log` と `results/`: 実行ログと TRX。
- `source-preservation-before.json`: 元 worktree の状態、未コミット 33 ファイルのハッシュ、既存参照とステージ状態。

これらの隔離フィード・キャッシュ・生成物は Git へ追加しない。
