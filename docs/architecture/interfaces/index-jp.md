---
version: 0.0.0
issuer: ai-kernel@tkysoftware.xsrv.jp
title: "AIKernel Architecture Interfaces — Index"
created: 2026-05-03
tags:
  - aikernel
  - architecture
  - interfaces
  - japanese
---

英語版は index.md を参照。

# AIKernel Architecture Interfaces — Index

## 名前空間別インデックス
- [context/index-jp.md](context/index-jp.md)
- [conversation/index-jp.md](conversation/index-jp.md)
- [execution/index-jp.md](execution/index-jp.md)
- [governance/index-jp.md](governance/index-jp.md)
- [hosting/index-jp.md](hosting/index-jp.md)
- [material/index-jp.md](material/index-jp.md)
- [models/index-jp.md](models/index-jp.md)
- [pipeline/index-jp.md](pipeline/index-jp.md)
- [prompt/index-jp.md](prompt/index-jp.md)
- [provider/index-jp.md](provider/index-jp.md)
- [tooling/index-jp.md](tooling/index-jp.md)
- [vfs/index-jp.md](vfs/index-jp.md)

## 名前空間概要
- `context`: `ContextFragment` のライフサイクル、コンテキストのシリアライズ/スナップショット、入力正規化を担当する。
- `conversation`: 会話状態の分岐、チェックポイント、差分比較の契約を担当する。
- `execution`: 2フェーズ境界（`IThoughtProcess`, `IOutputPolisher`）の契約を担当する。
- `governance`: fail-closed ガード、監査イベント、attention/ライフサイクル観測を担当する。
- `hosting`: Kernel ホスティングライフサイクルと DI/Provider 登録契約を担当する。
- `material`: 素材検疫と構造化素材契約を担当する。
- `models`: 能力ベクトル、ルーティング、トークン/ベクトル推定、shape advisory を担当する。
- `pipeline`: 決定論的パイプラインオーケストレーションとタスク実行契約を担当する。
- `prompt`: 署名付きプロンプト統治と `IPromptVerifier` 検証チェーンを担当する。
- `provider`: Provider 実行、取得/モデル/イベント/スケジューラ契約、経済性プロファイルを担当する。
- `tooling`: ツール権限検証とサンドボックス実行境界を担当する。
- `vfs`: 仮想ファイルシステム Provider とセッション抽象を担当する。
