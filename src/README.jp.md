# AIKernel.NET

AIKernel.NET は、Semantic Context OS の契約を定義する仕様先行リポジトリです。
`src` 配下には、インターフェース、DTO、列挙型、および外部境界契約を定義する正典プロジェクト群があります。

---

## プロジェクト一覧

### AIKernel.Abstractions
- 役割: インターフェース層（具象ビジネスロジックを持たない）。
- 主な名前空間:
  - `AIKernel.Abstractions.Context`
  - `AIKernel.Abstractions.Conversation`
  - `AIKernel.Abstractions.Events`
  - `AIKernel.Abstractions.Execution`
  - `AIKernel.Abstractions.Governance`
  - `AIKernel.Abstractions.History`
  - `AIKernel.Abstractions.Hosting`
  - `AIKernel.Abstractions.Kernel`
  - `AIKernel.Abstractions.Material`
  - `AIKernel.Abstractions.Models`
  - `AIKernel.Abstractions.Prompt`
  - `AIKernel.Abstractions.Providers`
  - `AIKernel.Abstractions.Rom`
  - `AIKernel.Abstractions.Routing`
  - `AIKernel.Abstractions.Scheduling`
  - `AIKernel.Abstractions.Security`
  - `AIKernel.Abstractions.Tasks`
  - `AIKernel.Abstractions.Tooling`
- 参照: `AIKernel.Dtos`, `AIKernel.Enums`

### AIKernel.Contracts
- 役割: オーケストレーション/コンテキスト投影の境界契約インターフェース。
- 主な名前空間: `AIKernel.Contracts`
- 参照: `AIKernel.Dtos`, `AIKernel.Enums`

### AIKernel.Dtos
- 役割: POCO/record のデータ運搬体のみ（ビジネスロジックなし）。
- 主な名前空間:
  - `AIKernel.Dtos.Context`
  - `AIKernel.Dtos.Core`
  - `AIKernel.Dtos.Events`
  - `AIKernel.Dtos.Execution`
  - `AIKernel.Dtos.Governance`
  - `AIKernel.Dtos.Kernel`
  - `AIKernel.Dtos.KernelContext`
  - `AIKernel.Dtos.Material`
  - `AIKernel.Dtos.Prompt`
  - `AIKernel.Dtos.Rom`
  - `AIKernel.Dtos.Routing`
  - `AIKernel.Dtos.Rules`
  - `AIKernel.Dtos.Sandbox`
  - `AIKernel.Dtos.Security`
  - `AIKernel.Dtos.Tokenization`
  - `AIKernel.Dtos.Vfs`
- 参照: `AIKernel.Enums`

### AIKernel.Enums
- 役割: 仕様層全体で共有する enum プリミティブ。
- 主な名前空間: `AIKernel.Enums`
- 参照: なし

### AIKernel.VFS
- 役割: プロバイダー非依存の Virtual File System 契約。
- 主な名前空間: `AIKernel.VFS`
- 参照: `AIKernel.Dtos`

---

## 依存ルール（規範）

- `AIKernel.Abstractions` -> `AIKernel.Dtos`, `AIKernel.Enums`
- `AIKernel.Contracts` -> `AIKernel.Dtos`, `AIKernel.Enums`
- `AIKernel.Dtos` -> `AIKernel.Enums`
- `AIKernel.Enums` -> （なし）
- `AIKernel.VFS` -> `AIKernel.Dtos`

禁止例:
- `Abstractions` -> `Contracts`
- `Contracts` -> `Abstractions`
- `VFS` -> `Abstractions`

---

## 解体・再配置メモ

- `AIKernel.KernelContext` は解体し、モデルを `AIKernel.Dtos.KernelContext`、契約を `AIKernel.Abstractions` 側へ再配置しました。
- `AIKernel.Events` は解体し、モデルを `AIKernel.Dtos.Events`、契約を `AIKernel.Abstractions.Events` 側へ再配置しました。
- 具象ランタイム実装は本リポジトリの責務外であり、`AIKernel.Core` 側で扱います。

---

## テスト

- `src/tests/AIKernel.Abstractions.Tests`: 仕様整合テストとインターフェース結合テスト。

---

## ライセンス

MIT License  
Copyright © 2026 Takuya Sogawa
