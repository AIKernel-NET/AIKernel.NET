<#
AIKernel.NET Core Generator (PSCustomObject版)
- Fixes Hashtable expansion bug by using PSCustomObject for project metadata
- Creates src/AIKernel.NET.sln and 7 core projects
- Writes csproj templates with package metadata and descriptions (EN + JP)
- Sets project references according to dependency rules
- Generates README.md (EN) and README.jp.md (JP) with UTF-8 BOM
Usage:
  powershell -ExecutionPolicy Bypass -File .\init-aikernel-core.ps1
  or (if pwsh installed)
  pwsh -ExecutionPolicy Bypass -File ./init-aikernel-core.ps1
#>

# --- Configuration ---------------------------------------------------------
$root = "src"
$solutionName = "AIKernel.NET"
$solutionFile = Join-Path $root "$solutionName.slnx"

$authors = "Takuya Sogawa"
$company = "AIKernel-NET"
$copyright = "Copyright © 2026 Takuya Sogawa of AIKernel-NET"
$license = "MIT"
$repoUrl = "https://github.com/AIKernel-NET/AIKernel.NET"

# Common description prefix (English / Japanese)
$commonDescriptionEN = "AIKernel is an operating-system-style framework for AI applications, designed around strict category separation, context isolation, and contract-driven orchestration. This package is part of the AIKernel Core and provides foundational components required by Kernel, Providers, and VFS layers."
$commonDescriptionJP = "AIKernel は AI アプリケーション向けの OS 的フレームワークであり、カテゴリ分離、コンテキスト隔離、契約駆動の設計思想に基づいています。本パッケージは AIKernel Core の一部であり、Kernel、Provider、VFS 層が利用する基盤コンポーネントを提供します。"

# --- Projects defined as PSCustomObject to avoid Hashtable expansion issues ---
$projects = @(
    [PSCustomObject]@{
        Name   = "AIKernel.Abstractions"
        DescEN = "Defines the syscall-level abstractions of the AIKernel OS, including IKernel, IProvider, IGuard, and IPdp. These interfaces form the stable execution boundary for all Kernel and Provider implementations."
        DescJP = "AIKernel OS の syscall レベルの抽象を定義します。IKernel、IProvider、IGuard、IPdp などを含み、Kernel と Provider 実装の安定した実行境界を提供します。"
    },
    [PSCustomObject]@{
        Name   = "AIKernel.Contracts"
        DescEN = "Provides the orchestration contracts and context schemas used by the AIKernel OS, including OrchestrationContext, MaterialContext, and ExpressionContext. These contracts define the immutable input format for Kernel execution."
        DescJP = "OrchestrationContext、MaterialContext、ExpressionContext など、AIKernel OS で使用されるオーケストレーション契約とコンテキストスキーマを提供します。これらは Kernel 実行の不変な入力形式を定義します。"
    },
    [PSCustomObject]@{
        Name   = "AIKernel.Dtos"
        DescEN = "Contains lightweight data transfer objects used across AIKernel components, including MaterialItem, TransferTrace, and Purpose. DTOs are designed for interchangeability without affecting contract stability."
        DescJP = "MaterialItem、TransferTrace、Purpose など、AIKernel コンポーネント間で使用される軽量な DTO を含みます。DTO は契約の安定性に影響を与えず交換可能に設計されています。"
    },
    [PSCustomObject]@{
        Name   = "AIKernel.Enums"
        DescEN = "Defines core enumerations used throughout the AIKernel OS, including RejectCode, PdpDecision, and DataClassification. These enums form the shared vocabulary for Kernel, Providers, and VFS."
        DescJP = "RejectCode、PdpDecision、DataClassification など、AIKernel OS 全体で使用されるコア列挙型を定義します。これらは Kernel、Provider、VFS の共通語彙を形成します。"
    },
    [PSCustomObject]@{
        Name   = "AIKernel.Events"
        DescEN = "Provides audit and system event definitions for the AIKernel OS. Events represent observable state transitions and are designed for logging, monitoring, and governance without depending on syscall abstractions."
        DescJP = "AIKernel OS の監査およびシステムイベント定義を提供します。イベントは観測可能な状態遷移を表し、syscall 抽象に依存せずログ、監視、ガバナンス用途に設計されています。"
    },
    [PSCustomObject]@{
        Name   = "AIKernel.KernelContext"
        DescEN = "Defines the execution context model for the AIKernel OS, including identity, permissions, resource budgets, and data classification. KernelContext provides the runtime information required for Guard and PDP evaluation."
        DescJP = "Identity、Permission、Budget、DataClassification などを含む AIKernel OS の実行コンテキストモデルを定義します。KernelContext は Guard や PDP の評価に必要なランタイム情報を提供します。"
    },
    [PSCustomObject]@{
        Name   = "AIKernel.VFS"
        DescEN = "Provides the virtual file system abstractions for the AIKernel OS, defining the boundary between Kernel execution and external data sources such as RAG materials, logs, and historical records."
        DescJP = "AIKernel OS の仮想ファイルシステム抽象を提供し、RAG 素材、ログ、履歴などの外部データソースと Kernel 実行の境界を定義します。"
    }
)

# --- Ensure root directory exists ------------------------------------------
if (-Not (Test-Path $root)) {
    New-Item -ItemType Directory -Path $root | Out-Null
}

# Create solution
Write-Host "Creating solution $solutionName in $root ..."
Push-Location $root
dotnet new sln --name $solutionName | Out-Null
Pop-Location

# --- Create projects and write csproj templates -----------------------------
foreach ($p in $projects) {
    $projName = $p.Name
    $projDir = Join-Path $root $projName
    if (-Not (Test-Path $projDir)) {
        New-Item -ItemType Directory -Path $projDir | Out-Null
    }

    # Minimal Class1.cs
    $classContent = @"
namespace $projName
{
    public class Class1
    {
    }
}
"@
    $classPath = Join-Path $projDir "Class1.cs"
    $classContent | Out-File -FilePath $classPath -Encoding utf8

    # Compose descriptions (safe expansion)
    $descEN = $p.DescEN
    $descJP = $p.DescJP

    # csproj content (here-string expands variables)
    $csprojContent = @"
<Project Sdk="Microsoft.NET.Sdk">
  <PropertyGroup>
    <TargetFramework>net10.0</TargetFramework>
    <Nullable>enable</Nullable>
    <ImplicitUsings>enable</ImplicitUsings>

    <!-- Package metadata -->
    <Authors>$authors</Authors>
    <Company>$company</Company>
    <PackageLicenseExpression>$license</PackageLicenseExpression>
    <RepositoryUrl>$repoUrl</RepositoryUrl>
    <Copyright>$copyright</Copyright>

    <!-- Description: English then Japanese -->
    <Description>
$commonDescriptionEN

$descEN

$commonDescriptionJP

$descJP
    </Description>

    <!-- Package settings -->
    <GeneratePackageOnBuild>false</GeneratePackageOnBuild>
    <PackageRequireLicenseAcceptance>false</PackageRequireLicenseAcceptance>
    <PackageProjectUrl>https://www.nuget.org/profiles/AIKernel</PackageProjectUrl>
    <PackageIcon>aikernel-logo128x128.png</PackageIcon>
    <PackageReadmeFile>README.md</PackageReadmeFile>
    <PackageTags>aikernel;aikernel-core;ai-os;architecture;category-separation;context-isolation;contract-driven;governance;preprocessing;</PackageTags>
  </PropertyGroup>

  <ItemGroup>
    <None Include="..\aikernel-logo128x128.png">
      <Pack>True</Pack>
      <PackagePath>\</PackagePath>
    </None>
    <None Include="..\README.md">
      <Pack>True</Pack>
      <PackagePath>\</PackagePath>
    </None>
  </ItemGroup>
</Project>
"@

    $csprojPath = Join-Path $projDir "$projName.csproj"
    $csprojContent | Out-File -FilePath $csprojPath -Encoding utf8BOM
    Write-Host "Created project $projName"
}

# --- Add projects to solution ----------------------------------------------
Write-Host "Adding projects to solution..."
foreach ($p in $projects) {
    $projName = $p.Name
    $projCsproj = Join-Path $root "$projName\$projName.csproj"
    dotnet sln $solutionFile add $projCsproj | Out-Null
}

# --- Apply dependency rules (project references) ---------------------------
Write-Host "Applying dependency rules (project references)..."

function Add-Ref($fromProj, $toProj) {
    $fromPath = Join-Path $root "$fromProj\$fromProj.csproj"
    $toPath = Join-Path $root "$toProj\$toProj.csproj"
    dotnet add $fromPath reference $toPath | Out-Null
    Write-Host "  $fromProj -> $toProj"
}

# AIKernel.Enums -> none

# AIKernel.Dtos -> AIKernel.Enums
Add-Ref "AIKernel.Dtos" "AIKernel.Enums"

# AIKernel.Contracts -> AIKernel.Enums
Add-Ref "AIKernel.Contracts" "AIKernel.Enums"

# AIKernel.Events -> AIKernel.Enums, AIKernel.Dtos
Add-Ref "AIKernel.Events" "AIKernel.Enums"
Add-Ref "AIKernel.Events" "AIKernel.Dtos"

# AIKernel.KernelContext -> AIKernel.Enums, AIKernel.Dtos
Add-Ref "AIKernel.KernelContext" "AIKernel.Enums"
Add-Ref "AIKernel.KernelContext" "AIKernel.Dtos"

# AIKernel.VFS -> AIKernel.Enums, AIKernel.Dtos, AIKernel.KernelContext
Add-Ref "AIKernel.VFS" "AIKernel.Enums"
Add-Ref "AIKernel.VFS" "AIKernel.Dtos"
Add-Ref "AIKernel.VFS" "AIKernel.KernelContext"

# AIKernel.Abstractions -> AIKernel.Enums, AIKernel.Contracts, AIKernel.KernelContext, AIKernel.VFS
Add-Ref "AIKernel.Abstractions" "AIKernel.Enums"
Add-Ref "AIKernel.Abstractions" "AIKernel.Contracts"
Add-Ref "AIKernel.Abstractions" "AIKernel.KernelContext"
Add-Ref "AIKernel.Abstractions" "AIKernel.VFS"

Write-Host "Project references applied."

# --- Generate README.md (English) ------------------------------------------
$readmeEN = @"
# AIKernel.NET
AIKernel is an operating-system-style framework for AI applications, built on strict category separation, context isolation, and contract-driven orchestration.
This repository contains the Core layer of the AIKernel OS, including abstractions, contracts, DTOs, enums, events, execution context, and virtual file system interfaces.

---

## Core Architecture Overview

AIKernel Core is divided into **7 foundational modules**, each representing a strict OS boundary:

- **AIKernel.Abstractions**     – Syscall-level interfaces (IKernel, IProvider, IGuard, IPdp)
- **AIKernel.Contracts**        – Orchestration and context schemas (immutable input formats)
- **AIKernel.Dtos**             – Lightweight data transfer objects
- **AIKernel.Enums**            – Shared enumerations across the OS
- **AIKernel.Events**           – Audit and system event definitions
- **AIKernel.KernelContext**    – Execution context (identity, permissions, budgets, classification)
- **AIKernel.VFS**              – Virtual file system abstractions (external data boundary)

This structure enforces the AIKernel design principles:

- **Category Separation** — No mixing of abstractions, contracts, DTOs, or events
- **Context Isolation** — Runtime context is never mixed with LLM inference
- **Contract-Driven Execution** — Kernel behavior is defined by immutable schemas
- **Boundary Enforcement** — Kernel, Providers, and VFS interact only through stable interfaces

---

## NuGet Packages

Each module is published as an independent NuGet package:

- AIKernel.Abstractions
- AIKernel.Contracts
- AIKernel.Dtos
- AIKernel.Enums
- AIKernel.Events
- AIKernel.KernelContext
- AIKernel.VFS

All packages follow:

- MIT License
- Semantic Versioning
- Strict dependency rules (see below)

---

## Dependency Rules (Critical for OS Integrity)

To prevent architectural erosion, the following dependency graph is enforced:

- AIKernel.Abstractions   →  AIKernel.Contracts, AIKernel.Enums
- AIKernel.Contracts      →  AIKernel.Enums
- AIKernel.Dtos           →  AIKernel.Enums
- AIKernel.Events         →  AIKernel.Enums, AIKernel.Dtos
- AIKernel.KernelContext  →  AIKernel.Enums, AIKernel.Dtos
- AIKernel.VFS            →  AIKernel.Enums, AIKernel.Dtos, AIKernel.KernelContext
- tests/*                 →  Free (but must not be referenced by src)

**Prohibited dependencies:**

- Contracts → Dtos
- Events → Abstractions
- KernelContext → Abstractions
- VFS → Abstractions

---

## Testing Structure

- tests/AIKernel.Abstractions.Tests   – Contract tests for IKernel / IProvider / IGuard / IPdp
- tests/AIKernel.Contracts.Tests      – Schema and context validation tests

Mocks and test utilities live in:

- AIKernel.Testing

---

## License

MIT License
$copyright

---

## Repository

$repoUrl
"@

$readmeENPath = Join-Path $root "README.md"
$readmeEN | Out-File -FilePath $readmeENPath -Encoding utf8BOM
Write-Host "Generated README.md (English)."

# --- Generate README.jp.md (Japanese) -------------------------------------
$readmeJP = @"
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
$copyright

---

## リポジトリ

$repoUrl
"@

$readmeJPPath = Join-Path $root "README.jp.md"
$readmeJP | Out-File -FilePath $readmeJPPath -Encoding utf8BOM
Write-Host "Generated README.jp.md (Japanese)."

# --- Final output ----------------------------------------------------------
Write-Host ""
Write-Host "AIKernel.NET core scaffold created successfully under '$root'."
Write-Host "Solution: $solutionFile"
Write-Host "Projects:"
foreach ($p in $projects) { Write-Host " - " $p.Name }
Write-Host ""
Write-Host "Next recommended steps:"
Write-Host " 1) Open the solution in VS2026 or run 'dotnet build $solutionFile'"
Write-Host " 2) Implement interfaces and DTOs according to your design"
Write-Host " 3) Add tests under a tests/ folder and ensure they do not reference src projects directly"
Write-Host ""
Write-Host "If you want, I can also:"
Write-Host " - generate csproj package metadata with PackageId/Version/Authors per package"
Write-Host " - create initial interface/contract files (IKernel, OrchestrationContext, etc.)"
Write-Host " - add GitHub Actions workflow for build and package publishing"
