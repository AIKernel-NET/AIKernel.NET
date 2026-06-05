# AIKernel.NET

AIKernel.NET は、Semantic Context OS の契約を定義する仕様先行リポジトリです。
`src` 配下には、インターフェース、DTO、列挙型、および外部境界契約を定義する正典プロジェクト群があります。

---

## 現在のパッケージ基準

v0.0.5 時点:

- `AIKernel.Abstractions` と `AIKernel.Contracts` は Interface のみを公開します。
- DTO は `AIKernel.Dtos` が所有します。
- 共有 enum primitive は `AIKernel.Enums` が所有します。
- `AIKernel.Vfs` は `AIKernel.Abstractions` 内の公開 namespace です。個別の `AIKernel.Vfs` package/project は存在しません。
- `IResult` や `ISemanticHasher` などの曖昧な ChatChain 旧名は公開されません。`IChatTurnVerificationResult` と `IChatTurnSemanticHasher` を使用してください。

AIKernel.NET の各 package は同じ version line に揃えてください。`AIKernel.Abstractions` v0.0.5 と古い `AIKernel.Dtos` / `AIKernel.Enums` を混在させないでください。

---

## プロジェクト一覧

### AIKernel.Abstractions
- 役割: インターフェース層（具象ビジネスロジックを持たない）。
- 主な名前空間:
  - `AIKernel.Abstractions.Context`
  - `AIKernel.Abstractions.Conversation`
  - `AIKernel.Abstractions.DynamicSlm`
  - `AIKernel.Abstractions.Dsl`
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
  - `AIKernel.Abstractions.Time`
  - `AIKernel.Abstractions.Tooling`
  - `AIKernel.Vfs`（Vfs contract。所有 assembly は `AIKernel.Abstractions`）
- 参照: `AIKernel.Dtos`, `AIKernel.Enums`

### AIKernel.Contracts
- 役割: オーケストレーション/コンテキスト投影の境界契約インターフェース。
- 主な名前空間: `AIKernel.Contracts`
- 参照: `AIKernel.Dtos`, `AIKernel.Enums`

### AIKernel.Dtos
- 役割: POCO/record のデータ運搬体、および wire metadata key 定数のみ（ビジネスロジックなし）。
- 主な名前空間:
  - `AIKernel.Dtos.Context`
  - `AIKernel.Dtos.Core`
  - `AIKernel.Dtos.DynamicSlm`
  - `AIKernel.Dtos.Dsl`
  - `AIKernel.Dtos.Events`
  - `AIKernel.Dtos.Execution`
  - `AIKernel.Dtos.Governance`
  - `AIKernel.Dtos.History`
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
  - `AIKernel.Dtos.Time`
  - `AIKernel.Dtos.Vfs`
- 参照: `AIKernel.Enums`

DTO package は DSL ROM / History ROM などの wire format に必要な安定 metadata key 定数を公開できます。
これらの定数は直列化 contract surface の一部です。parse、validation、runtime behavior は Core/Common または host 実装側の責務です。
DynamicSLM DTO は Model ABI record のみを表現します。Registry、lineage 検証、payload materialization、scheduling、differential distillation の振る舞いは、`AIKernel.Abstractions.DynamicSlm` の背後にある Core / Provider 実装が所有します。

### AIKernel.Enums
- 役割: 仕様層全体で共有する enum プリミティブ。
- 主な名前空間: `AIKernel.Enums`
- 参照: なし

## 依存ルール（規範）

- `AIKernel.Abstractions` -> `AIKernel.Dtos`, `AIKernel.Enums`
- `AIKernel.Contracts` -> `AIKernel.Dtos`, `AIKernel.Enums`
- `AIKernel.Dtos` -> `AIKernel.Enums`
- `AIKernel.Enums` -> （なし）

禁止例:
- `Abstractions` -> `Contracts`
- `Contracts` -> `Abstractions`
- `Abstractions` -> separate Vfs package/project

`AIKernel.Vfs` は `AIKernel.Abstractions` 内の公開 namespace です。個別の `AIKernel.Vfs` 互換 project は v0.0.4 で削除されました。

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
