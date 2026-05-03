---
id: contract-versioning
version: 0.0.0
issuer: ai-kernel@tkysoftware.xsrv.jp
title: "CONTRACT_VERSIONING — 契約（Interface/DTO/Enum）バージョニング方針"
created: 2026-05-01
tags:
- aikernel
- design
- contracts
- versioning
- governance
- japanese
---

# CONTRACT_VERSIONING — 契約（Interface/DTO/Enum）バージョニング方針

## 概要
本書は、AIKernel.NET の契約（Interface/DTO/Enum/Schema 等）のバージョニング方針を定義する。  
AIKernel.NET は契約駆動を中核に据えるため、契約の互換性ルールは OS のガバナンスそのものである。

---

## 1. 適用範囲（What is a “Contract”）
本書でいう契約は、以下を含む：
- 公開 Interface（Core の抽象 API）
- 交換型（DTO）・列挙（Enum）  
- JSON Schema 等の形式仕様（保存・通信のための固定点）
- 監査イベントや実行コンテキストの固定スキーマ（再現性の根拠）

---

## 2. バージョニングの基本方針（SemVer）
### 2.1 0.0.0 フェーズ（レビュー段階）
現段階はレビュー段階であり、契約・ドキュメントの version は 0.0.0 を用いる。  
この期間は破壊的変更が起こりうるため、公開時点で「安定 API ではない」ことを明示する。

### 2.2 SemVer の扱い
- **Major**：破壊的変更（Breaking Change）
- **Minor**：後方互換な追加（新機能の追加）
- **Patch**：バグ修正、コメント修正、ドキュメント修正など（互換性に影響しない）

---

## 3. 破壊的変更（Breaking Change）の定義
以下は破壊的変更として扱う：
- Interface のメソッド/プロパティの削除、シグネチャ変更
- DTO/Enum の削除、意味の変更、互換性を壊す変更
- Schema の必須項目追加（互換性を壊す）

原則：
- 破壊的変更は Issue/ADR とセットで理由・影響範囲・移行方針を残す。

---

## 4. 後方互換な変更（Non-breaking）のルール
以下は原則として後方互換な変更とみなす：
- DTO への **任意（optional）**フィールド追加
- Enum への値追加（ただし既存値の意味を変えない）
- Interface への新メンバー追加（既存実装が破壊されない形を前提）  

注意：
- Interface 追加は実装側に影響するため、互換性影響を必ず明記する。

---

## 5. 非推奨（Deprecation）ポリシー
- 破壊的変更の前に、可能なら非推奨（Obsolete）期間を設ける
- ドキュメントとコメントで代替手段を提示する
- 非推奨から削除までの移行は `MIGRATION_GUIDE`（operations）に集約する（作成予定）。

---

## 6. 契約の分類と責務（混在防止）
AIKernel は情報カテゴリ分離・コンテキスト隔離を思想の中心に置くため、契約も混在させない。 
- 推論用（Orchestration）と表現用（Expression）と素材（Material）を同一契約に混ぜない  
- 実装依存（例外スロー、特定アルゴリズム）を契約に混ぜない（実装側へ）

---

## 7. リリース時に明示すべき情報（契約メタデータ）
各リリースで明示する：
- Contract version（SemVer）
- Breaking / Non-breaking の区分
- 影響範囲（どの Interface / DTO / Enum が変わったか）
- 移行の要点（運用側ドキュメントへリンク）

---

## 8. 関連ドキュメント
- `./DESIGN_INTENT-jp.md`
- `ARCHITECTURE_DECISIONS-jp.md`
- `EXTENSION_POINTS-jp.md`
- `../architecture/index-jp.md`
- `../guidelines/DOCUMENTATION_GUIDELINES-jp.md`
