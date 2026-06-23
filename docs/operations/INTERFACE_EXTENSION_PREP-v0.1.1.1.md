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

[Japanese](INTERFACE_EXTENSION_PREP-v0.1.1.1-jp.md)

This note records the preparation rules for adding interfaces to `AIKernel.NET`
during the v0.1.1.1 validation line. The work did not create a GitHub release;
it was treated as a backward-compatible extension of the published individual
NuGet package contract surface.

## Target Repository

- Git repository: `AIKernel.NET`
- Branch: `dev`
- Solution: `src/AIKernel.NET.slnx`
- Shared package metadata: `Directory.Build.props`

## Public Packages

This interface extension work kept the following package family on the same
version line.

| Package | Project | Responsibility |
|---|---|---|
| `AIKernel.Abstractions` | `src/AIKernel.Abstractions/AIKernel.Abstractions.csproj` | Base interfaces for runtime, provider, and storage adapters. |
| `AIKernel.Contracts` | `src/AIKernel.Contracts/AIKernel.Contracts.csproj` | Interface-only orchestration and context-projection contracts. |
| `AIKernel.Dtos` | `src/AIKernel.Dtos/AIKernel.Dtos.csproj` | DTOs, wire metadata keys, records, and POCO data carriers. |
| `AIKernel.Enums` | `src/AIKernel.Enums/AIKernel.Enums.csproj` | Shared dependency-free enum primitives. |

## Version Policy

- Public update version: `0.1.1.1`
- GitHub release: not created
- PyPI package: not created (`0.1.1.1` was .NET / NuGet only)
- Next official release at that time: `0.1.2` canonical series
- Local development package version: `0.1.1.1-dev{buildNumber}`
- Stable pack example: `dotnet pack src/AIKernel.NET.slnx -c Release`
- Local dev pack example:
  `dotnet pack src/AIKernel.NET.slnx -c Release -p:UseLocalPackageVersion=true -p:LocalPackageBuildNumber=42`

`Directory.Build.props` used `PackageVersion=0.1.1.1` for normal packs and
`PackageVersion=0.1.1.1-dev{LocalPackageBuildNumber}` only when
`UseLocalPackageVersion=true`. Assembly and file versions were aligned to
`0.1.1.1`.

## Backward Compatibility Rules

- Do not delete, rename, or change signatures of existing public interface members.
- Avoid changing the meaning of existing DTO constructors, required properties,
  or enum values.
- Add new DTO fields as optional, nullable, or defaulted fields.
- When adding enum values, keep existing numeric values and meanings stable.
- New domain enums should include `Unknown = 0` and treat unknown values as
  fail-closed.
- Additional interfaces should use semantic names, not mechanical expansion
  suffixes.
- Public APIs require bilingual XML documentation.
- `AIKernel.Abstractions` and `AIKernel.Contracts` remain interface-only.
- DTOs belong in `AIKernel.Dtos`; enums belong in `AIKernel.Enums`.
- Runtime behavior, exception implementations, Result adapters, and Core
  implementations do not belong in `AIKernel.NET`.

## Reference Documents

- `src/README.md`: package boundaries, dependency rules, and VFS namespace ownership
- `docs/design/CONTRACT_VERSIONING.md`: breaking / non-breaking classification
- `docs/operations/MIGRATION_GUIDE.md`: user-facing migration notes
- `docs/architecture/19.DOMAIN_CONTRACT_SURFACE-v0.1.1.1.md`: additive contract surface
- `docs/operations/INTERFACE_EXTENSION_NAMING-v0.1.1.1.md`: semantic interface naming
- `docs/operations/ENUM_HANDLING_POLICY-v0.1.1.1.md`: unknown enum handling
- `docs/operations/XML_DOCUMENTATION_POLICY-v0.1.1.1.md`: bilingual XML documentation
- `docs/architecture/interfaces/*`: existing public surface by interface category
- `src/tests/AIKernel.Abstractions.Tests`: interface composition, package DAG, and spec-alignment tests

## Verification

After adding interfaces, verify at least the following commands:

```powershell
dotnet build src/AIKernel.NET.slnx
dotnet test src/tests/AIKernel.Abstractions.Tests/AIKernel.Abstractions.Tests.csproj --no-build
dotnet pack src/AIKernel.NET.slnx -c Release
dotnet pack src/AIKernel.NET.slnx -c Release -p:UseLocalPackageVersion=true -p:LocalPackageBuildNumber=42
```

When needed, inspect the produced `.nupkg` files and confirm that stable and
local dev versions are both correct.
