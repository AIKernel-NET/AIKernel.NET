---
id: interface-extension-prep-v0-1-1-1
title: "AIKernel.NET v0.1.1.1 Interface Extension Preparation"
created: 2026-06-13
updated: 2026-06-14
version: "0.1.1.1"
edition: "Preparation"
status: "Draft"
tags:
- aikernel
- interface
- package
- compatibility
- nuget
---

# AIKernel.NET v0.1.1.1 Interface Extension Preparation

この文書は、`AIKernel.NET` に対する Interface 追加作業の準備メモです。今回の作業は GitHub release を伴わず、公開済み個別 NuGet package に対する contract surface の後方互換な拡張として扱います。

## 対象リポジトリ

- Git repository: `AIKernel.NET`
- Branch: `dev`
- Solution: `src/AIKernel.NET.slnx`
- Shared package metadata: `Directory.Build.props`

## 公開パッケージ

今回の Interface 追加では、以下の package family を同じ version line で扱います。

| Package | Project | 責務 |
| --- | --- | --- |
| `AIKernel.Abstractions` | `src/AIKernel.Abstractions/AIKernel.Abstractions.csproj` | runtime / provider / storage adapter 向けの基盤 interface |
| `AIKernel.Contracts` | `src/AIKernel.Contracts/AIKernel.Contracts.csproj` | orchestration / context projection の interface-only contract |
| `AIKernel.Dtos` | `src/AIKernel.Dtos/AIKernel.Dtos.csproj` | DTO、wire metadata key、record / POCO data carrier |
| `AIKernel.Enums` | `src/AIKernel.Enums/AIKernel.Enums.csproj` | 依存を持たない共有 enum primitive |

## バージョン方針

- 公開更新 version: `0.1.1.1`
- GitHub release: 作成しない
- ローカル開発 package version: `0.1.1-dev{buildNumber}`
- stable pack 例: `dotnet pack src/AIKernel.NET.slnx -c Release`
- local dev pack 例: `dotnet pack src/AIKernel.NET.slnx -c Release -p:UseLocalPackageVersion=true -p:LocalPackageBuildNumber=42`

`Directory.Build.props` は通常 pack では `PackageVersion=0.1.1.1` を使い、`UseLocalPackageVersion=true` の場合だけ `PackageVersion=0.1.1-dev{LocalPackageBuildNumber}` を使います。assembly/file version は `0.1.1.1` に揃えます。

## 後方互換性ルール

- 既存 public interface の member 削除、rename、signature 変更は行わない。
- 既存 DTO constructor / required property / enum value の意味変更は避ける。
- 新しい DTO field は optional / nullable / default 付きにする。
- 新しい enum value を追加する場合、既存値の numeric value と意味を変更しない。
- 新規 domain enum は `Unknown = 0` を持ち、未知値は fail-closed に扱う。
- 追加 interface は semantic name を使い、機械的な expansion suffix を使わない。
- public API にはバイリンガル XML documentation を付与する。
- `AIKernel.Abstractions` と `AIKernel.Contracts` は interface-only を維持する。
- DTO は `AIKernel.Dtos`、enum は `AIKernel.Enums` に置く。
- runtime behavior、exception 実装、Result adapter、Core 実装は `AIKernel.NET` に入れない。

## 参照すべき文書

- `src/README.md`: package 境界、dependency rule、Vfs namespace ownership
- `docs/design/CONTRACT_VERSIONING.md`: breaking / non-breaking change の判定
- `docs/operations/MIGRATION_GUIDE.md`: package 利用者向け migration note
- `docs/architecture/19.DOMAIN_CONTRACT_SURFACE-v0.1.1.1-jp.md`: v0.1.1.1 additive contract surface
- `docs/operations/INTERFACE_EXTENSION_NAMING-v0.1.1.1-jp.md`: semantic interface naming
- `docs/operations/ENUM_HANDLING_POLICY-v0.1.1.1-jp.md`: enum unknown value handling
- `docs/operations/XML_DOCUMENTATION_POLICY-v0.1.1.1-jp.md`: bilingual XML documentation
- `docs/architecture/interfaces/*`: interface category ごとの既存公開 surface
- `src/tests/AIKernel.Abstractions.Tests`: interface composition / package DAG / spec alignment tests

## 変更時の確認観点

- `AIKernel.Abstractions` -> `AIKernel.Dtos`, `AIKernel.Enums`
- `AIKernel.Contracts` -> `AIKernel.Dtos`, `AIKernel.Enums`
- `AIKernel.Dtos` -> `AIKernel.Enums`
- `AIKernel.Enums` -> none

禁止される依存方向:

- `AIKernel.Abstractions` -> `AIKernel.Contracts`
- `AIKernel.Contracts` -> `AIKernel.Abstractions`
- `AIKernel.Dtos` -> `AIKernel.Abstractions` / `AIKernel.Contracts`
- `AIKernel.Enums` -> any project

## 推奨検証

Interface 追加後は、最低限以下を確認します。

```powershell
dotnet build src/AIKernel.NET.slnx
dotnet test src/tests/AIKernel.Abstractions.Tests/AIKernel.Abstractions.Tests.csproj --no-build
dotnet pack src/AIKernel.NET.slnx -c Release
dotnet pack src/AIKernel.NET.slnx -c Release -p:UseLocalPackageVersion=true -p:LocalPackageBuildNumber=42
```

必要に応じて、pack された `.nupkg` の version が stable / local dev の両方で期待どおりか確認します。
