---
id: repo-dependency-rules
version: 0.0.1
issuer: ai-kernel@tkysoftware.xsrv.jp
title: "AIKernel.NET Repository Dependency Rules — 依存方向規約"
created: 2026-04-30
tags:
- aikernel
- repository
- dependency
- architecture
- governance
- japanese
updated: 2026-05-06
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

- Core（syscall）: Abstractions / Contracts / Dtos / Enums / Events / KernelContext / Vfs
- Kernel（実装）: Scheduler / Router / Controller / Pipeline / RagEngine / Rules
- Providers（ドライバ）: Capability 実装
- VfsProviders（外部データ）: Git 等のデータソース
- Server（アダプタ）: 外部 API 互換
- Hosting（統合）: DI / 既定パイプライン / 設定
- Enterprise（運用）: SIEM / マルチテナント / SLO

---

## 3. Core 内の依存規約（AIKernel.* 構成）

### 3.1 モジュール一覧（例）

- AIKernel.Abstractions  : IKernel / IProvider / IGuard / IPdp
- AIKernel.Contracts     : OrchestrationContext / Contract Schema
- AIKernel.Dtos          : MaterialItem / TransferTrace / Purpose
- AIKernel.Enums         : RejectCode / PdpDecision
- AIKernel.Events        : AuditEvent / GuardEvent
- AIKernel.KernelContext : Identity / Permission / Budget / DataClassification
- AIKernel.Vfs           : Vfs 抽象（外部データ境界）

---

## 4. 依存表（固定）

以下の依存表を **規約として固定**する。  
ここに記載のない依存は原則禁止とし、例外が必要な場合は Issue/ADR で理由を明文化する。

### 4.1 固定依存（Allowed Dependencies）

| Project | Allowed References |
|---|---|
| AIKernel.Abstractions | AIKernel.Contracts, AIKernel.Enums |
| AIKernel.Contracts | AIKernel.Enums |
| AIKernel.Dtos | AIKernel.Enums |
| AIKernel.Events | AIKernel.Enums, AIKernel.Dtos |
| AIKernel.KernelContext | AIKernel.Enums |
| AIKernel.Vfs | AIKernel.Dtos |
| tests/* | 参照自由（逆流禁止） |

### 4.2 禁止事項（Forbidden）

- 循環依存（A → B → A）
- src が tests を参照すること（逆流）
- Core が Kernel/Providers/Server/Hosting/Enterprise を参照すること
- Vfs インターフェースに具象データ型を内包すること（具象データは AIKernel.Dtos に定義する）

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
