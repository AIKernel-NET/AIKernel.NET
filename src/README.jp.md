# AIKernel.NET
AIKernel は AI アプリケーション向けの OS 的フレームワークであり、カテゴリ分離、コンテキスト隔離、契約駆動の設計思想に基づいて構築されています。
このリポジトリは AIKernel OS の Core 層を含み、抽象、契約、DTO、列挙型、イベント、実行コンテキスト、仮想ファイルシステムのインタフェースを提供します。

---

## コアアーキテクチャ概要

AIKernel Core は **7 つの基盤モジュール** に分割され、それぞれが厳格な OS 境界を表します。

- **AIKernel.Abstractions**     – Syscall レベルのインタフェース（IKernel、IProvider、IGuard、IPdp）
- **AIKernel.Contracts**        – オーケストレーションとコンテキストスキーマ（不変の入力形式）
- **AIKernel.Dtos**             – 軽量なデータ転送オブジェクト
- **AIKernel.Enums**            – OS 全体で共有される列挙型
- **AIKernel.Events**           – 監査およびシステムイベント定義
- **AIKernel.KernelContext**    – 実行コンテキスト（Identity、Permission、Budget、分類）
- **AIKernel.VFS**              – 外部データ境界のための仮想ファイルシステム抽象

この構造は AIKernel の設計原則を強制します：

- **カテゴリ分離** — 抽象、契約、DTO、イベントを混在させない
- **コンテキスト隔離** — 実行コンテキストを推論に混ぜない
- **契約駆動の実行** — Kernel の振る舞いは不変のスキーマで定義される
- **境界の強制** — Kernel、Provider、VFS は安定したインタフェースを通じてのみ相互作用する

---

## NuGet パッケージ

各モジュールは独立した NuGet パッケージとして公開されます：

- AIKernel.Abstractions
- AIKernel.Contracts
- AIKernel.Dtos
- AIKernel.Enums
- AIKernel.Events
- AIKernel.KernelContext
- AIKernel.VFS

すべてのパッケージは以下に従います：

- MIT ライセンス
- セマンティックバージョニング
- 厳格な依存ルール（下記参照）

---

## 依存ルール（OS の整合性のために重要）

アーキテクチャの侵食を防ぐため、以下の依存グラフを厳守してください：

- AIKernel.Abstractions   →  AIKernel.Contracts, AIKernel.Enums
- AIKernel.Contracts      →  AIKernel.Enums
- AIKernel.Dtos           →  AIKernel.Enums
- AIKernel.Events         →  AIKernel.Enums, AIKernel.Dtos
- AIKernel.KernelContext  →  AIKernel.Enums, AIKernel.Dtos
- AIKernel.VFS            →  AIKernel.Enums, AIKernel.Dtos, AIKernel.KernelContext
- tests/*                 →  自由（ただし src から参照されないこと）

**禁止される依存関係：**

- Contracts → Dtos
- Events → Abstractions
- KernelContext → Abstractions
- VFS → Abstractions

---

## テスト構成

- tests/AIKernel.Abstractions.Tests   – IKernel / IProvider / IGuard / IPdp の契約テスト
- tests/AIKernel.Contracts.Tests      – スキーマおよびコンテキストの検証テスト

モックやテストユーティリティは以下に配置します：

- AIKernel.Testing

---

## ライセンス

MIT ライセンス
Copyright © 2026 Takuya Sogawa of AIKernel-NET

---

## リポジトリ

https://github.com/AIKernel-NET/AIKernel.NET
