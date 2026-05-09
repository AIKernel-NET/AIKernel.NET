---
version: 0.0.1
issuer: ai-kernel@tkysoftware.xsrv.jp
title: "Design Documentation Index"
created: 2026-05-03
updated: 2026-05-06
tags:
  - aikernel
  - design
  - japanese
---

英語版は index.md を参照。

# Design Documentation Index

## 1. 目的
`docs/design` は、仕様（spec）と実装（src）の間を接続する「設計上の意思決定ログ」です。AIKernel を AIOS として成立させるため、Kernel・Vfs・System Call 相当の責務分離と拡張点を明文化します。

## 2. 設計原則
- Kernel: 実行状態遷移と Fail-Closed ガバナンスの統制点
- Vfs: 知能資産の永続化境界
- System Call 相当: Interface を介した副作用制御（tooling/security/provider）

## 3. 関連仕様
- `docs/specs/01.EXECUTION_PIPELINE_SPEC-jp.md`
- `docs/specs/02.SIGNED_PROMPT_GOVERNANCE_SPEC-jp.md`
- `docs/specs/03.ROM_CORE_SPEC-jp.md`

## 4. ドキュメント一覧
- [DESIGN_INTENT-jp.md](DESIGN_INTENT-jp.md)
- [ARCHITECTURE_DECISIONS-jp.md](ARCHITECTURE_DECISIONS-jp.md)
- [DI_GUIDE-jp.md](DI_GUIDE-jp.md)
- [EXTENSION_POINTS-jp.md](EXTENSION_POINTS-jp.md)
- [CONTRACT_VERSIONING-jp.md](CONTRACT_VERSIONING-jp.md)
- [SEMANTIC_SNAPSHOT_FORMAT-jp.md](SEMANTIC_SNAPSHOT_FORMAT-jp.md)

---

# 変更履歴
- v0.0.0 / v0.0.0.0: 初期ドラフト
- v0.0.1 (2026-05-06): AIOS理論との対応付けを追加
