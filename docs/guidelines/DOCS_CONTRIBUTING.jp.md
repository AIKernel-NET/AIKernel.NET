---
version: 0.0.0
issuer: ai-kernel@tkysoftware.xsrv.jp
title: "AIKernel Documentation Guidelines"
description: ドキュメントの書き方、PR ルール、CI チェックについて
created: 2026-05-01
tags:
  - aikernel
  - documentation
  - guideline
  - japanese
---

# 目的
このガイドは、AIKernel プロジェクトのドキュメント作成・更新手順と品質チェックを定義する。

# Front matter 必須項目
各ドキュメントは以下の Front matter を先頭に含めてください:
- title
- description
- lang
- last_updated
- owners

# PR ルール
- ドキュメント変更は必ず PR で行うこと。
- 最低 1 名の `owners` 承認を必須とする。
- 重大な設計変更を伴う場合はアーキテクト承認を追加で取得する。

# CI チェック（PR 実行）
- Markdown lint（スタイル）
- リンクチェック（外部/内部）
- 静的サイトビルド（Docusaurus/MkDocs 等）
- 翻訳ステータスチェック（英日が必要なページは未翻訳フラグ）

# テンプレート（見出し構成）
1. 目的（Why）
2. 範囲（Scope）
3. 仕様／手順（What / How）
4. 参照（References）
5. 変更履歴（Changelog）
6. オーナー（Owners）

# 翻訳運用
- 重要ページは英日両方を用意する。
- 翻訳は別ブランチで管理し、翻訳ステータスを `AIKernel.Docs/translations_status.md` に記載する。

# ドキュメント更新チェックリスト（PR 作成者用）
- [ ] Front matter が正しく記載されている
- [ ] 目的・範囲が明確に書かれている
- [ ] コード例は最小実行可能である
- [ ] 内部リンク・外部リンクが有効である
- [ ] 画像に alt テキストとライセンス情報がある
- [ ] `owners` の承認を得るためのレビュワーを指定した

# 変更履歴
- 2026-05-01 初版