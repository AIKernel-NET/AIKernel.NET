# AIKernel.NET リリースノート

[English](RELEASE_NOTES.md)

## 0.1.3（公開準備中）

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
