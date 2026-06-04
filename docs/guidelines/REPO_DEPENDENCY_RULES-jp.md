---
id: repo-dependency-rules
title: "AIKernel.NET Repository Dependency Rules — 依存方向規約"
created: 2026-04-30
updated: 2026-06-04
published: 2026-05-16
version: "0.0.4"
edition: "Draft"
status: "Refactor"
issuer: ai-kernel@aikernel.net
maintainer: "拓也（AIKernel プロジェクト メンテナー）"
tags:
- aikernel
- repository
- dependency
- architecture
- governance
- japanese
---

## 概要

この文書は、AIKernel.NET の **プロジェクト間依存（参照）方向**を固定する規約である。
目的は以下：

- **抽象レイヤーの純度**を守り、実装依存が Core に侵入することを防ぐ
- **参照循環・境界崩壊**を防ぐ
- OS（Kernel / Drivers / Adapters / Ops）としての整合性をコード構造に反映する

本規約は「まず層を作り、依存方向を固定する」ための OS ルールである。  
（Core 分割と OS モジュール化の方針に基づく）[2](https://onedrive.live.com/?id=18d8971a-1d9f-4438-a67f-ffd4cb78b775&cid=b4a8da00b7fc4f27&web=1)[1](https://onedrive.live.com/?id=45fd4b45-525f-4670-b792-b754cad62832&cid=b4a8da00b7fc4f27&web=1)

---

## 1. 依存方向の大原則（最重要）

- 依存は常に **上位層 → 下位層**へ流れる
- **Core は固定点**であり、Core から Kernel/Providers/Server/Hosting/Enterprise へ依存してはならない
- **循環依存は禁止**（A → B → A は全面禁止）

---

## 2. レイヤ（層）定義

- Core（syscall）: Abstractions / Contracts / Dtos / Enums / Vfs facade
- Kernel（実装）: Scheduler / Router / Controller / Pipeline / RagEngine / Rules
- Providers（ドライバ）: Capability 実装
- VfsProviders（外部データ）: Git 等のデータソース
- Server（アダプタ）: 外部 API 互換
- Hosting（統合）: DI / 既定パイプライン / 設定
- Enterprise（運用）: SIEM / マルチテナント / SLO

---

## 3. Core 内の依存規約（AIKernel.* 構成）

### 3.1 モジュール一覧（例）

- AIKernel.Abstractions  : IKernel / IProvider / IGuard / IPdp / Vfs contract ownership
- AIKernel.Contracts     : OrchestrationContext / Contract Schema
- AIKernel.Dtos          : MaterialItem / TransferTrace / Purpose
- AIKernel.Enums         : RejectCode / PdpDecision
- AIKernel.Vfs           : type forwarding による Vfs 互換 facade

---

## 4. 依存表（固定）

以下の依存表を **規約として固定**する。  
ここに記載のない依存は原則禁止とし、例外が必要な場合は Issue/ADR で理由を明文化する。

### 4.1 固定依存（Allowed Dependencies）

| Project | Allowed References |
|---|---|
| AIKernel.Enums | なし |
| AIKernel.Dtos | AIKernel.Enums |
| AIKernel.Contracts | AIKernel.Enums, AIKernel.Dtos |
| AIKernel.Abstractions | AIKernel.Dtos, AIKernel.Enums |
| AIKernel.Vfs | AIKernel.Abstractions |
| Providers / VfsProviders | AIKernel.Abstractions, AIKernel.Core |
| Core | AIKernel.Abstractions |
| tests/* | 参照自由（逆流禁止） |

### 4.2 禁止事項（Forbidden）

- 循環依存（A → B → A）
- src が tests を参照すること（逆流）
- Core が Kernel/Providers/Server/Hosting/Enterprise を参照すること
- AIKernel.Abstractions が AIKernel.Vfs、AIKernel.Core、Providers を参照すること
- Vfs インターフェースに具象データ型を内包すること（具象データは AIKernel.Dtos に定義する）

### 4.3 v0.0.3 Vfs Contract Ownership

v0.0.3 以降、Vfs interface contract の所有元は `AIKernel.Abstractions` である。
公開 namespace は source compatibility のため `AIKernel.Vfs` のままとする。
`AIKernel.Vfs` package は contract 定義の所有元ではなく、type forwarding による互換 facade として `AIKernel.Abstractions` を参照してよい。

Phase-1 の必須 package graph は次の通り。

```text
AIKernel.Enums -> (none)
AIKernel.Dtos -> AIKernel.Enums
AIKernel.Contracts -> AIKernel.Enums, AIKernel.Dtos
AIKernel.Abstractions -> AIKernel.Dtos, AIKernel.Enums
AIKernel.Vfs -> AIKernel.Abstractions
```

### 4.4 v0.0.4 Contract 抽出ルール

v0.0.4 以降、DSL、DSL ROM、History ROM、Kernel clock contract は `AIKernel.Abstractions` と `AIKernel.Dtos` が所有する。
Core 実装は内部でこれらを `AIKernel.Common.Results` に adapter してよいが、Common が安定 contract package として公開されるまで、`AIKernel.Abstractions` は `AIKernel.Common` を参照してはならない。

---

## 5. Kernel / Providers / VfsProviders の依存規約（概要）

- Kernel は Core のみ参照できる
- Providers / VfsProviders は Core（主に Abstractions）にのみ依存し、Kernel の具象に依存しない
- 外部 SDK は Providers/VfsProviders 側に閉じ込め、Core へ漏らさない

（詳細は実装フェーズで別文書に分離してもよい）

---

## 6. CI での強制（推奨）

- 参照循環の検出（ビルド失敗）
- 禁止依存の検出（静的解析で失敗）
- 公開 API（Abstractions/Contracts）の破壊的変更検出（差分チェック）

---

## 結論

依存方向は設計そのものである。  
AIKernel.NET は OS として、境界と依存方向を最初に固定し、以後の拡張でも崩さない。
---

# 変更履歴
- v0.0.0 / v0.0.0.0: 初期ドラフト
- v0.0.1 (2026-05-06): ドキュメント規約に基づくバージョン更新
- v0.0.3 (2026-06-02): Phase-1 依存グラフと Vfs contract 所有元/type-forwarding 規約を修正
- v0.0.4 (2026-06-04): DSL / History ROM / Kernel clock contract 抽出に関する依存ルールを追加
