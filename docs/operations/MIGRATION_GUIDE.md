---
title: "Migration Guide"
status: "Planned"
version: 0.0.2
updated: 2026-05-09
---

# Migration Guide

This guide defines migration steps from the initial concept baseline (`v0.0.0`) to the canonical architecture baseline (`v0.0.1`), and to the naming/capability contract changes introduced in `v0.0.2`.

## 1. Fundamental Changes
In `v0.0.1`, the architecture was rebuilt around `Determinism` and `Non-LLM Governance`.

- `Namespace hardening`:
  `AIKernel.Models` was removed and split into `Routing`, `Rom`, and `Rules`.
- `DTO purification`:
  business logic and custom exceptions were removed from the DTO layer.
- `Trust-chain enforcement`:
  ROM processing is now standardized as `IRomCanonicalizer` first, then `ISemanticHasher`.

## 2. Interface Replacement Mapping
Replacement rules from old terms to canonical terms:

| Legacy Interface (v0.0.0) | Canonical Interface (v0.0.1) | Migration Notes |
|---|---|---|
| `IPromptSigner` | `ISemanticHasher` + `IPromptSignatureProvider` | Move from signer-only flow to canonicalization + semantic hash + signature chain. |
| `IContextSerializer` | (Removed) | Responsibility moved to `IKernelContext` and `IContextSnapshot`. |
| `IRoutingDecisionEngine` | `IModelVectorRouter` | Move from model-name routing to capability-vector routing. |
| `IPromptRuleSet` | `IPolicy` / `IRuleEngine` | Replace loosely-defined rule sets with deterministic policy evaluation. |

## 3. Recommended Migration Steps
1. `Namespace updates`:
   align `using` directives with physical directory structure.
2. `Exception relocation`:
   remove DTO-layer exception assumptions and enforce fail-closed behavior in Provider/Kernel execution layers.
3. `ROM pipeline update`:
   always call `IRomCanonicalizer.Canonicalize()` before hash/signature verification.
4. `Test realignment`:
   remap use-case-driven tests to canonical interfaces and `UC-xx` definitions.

## 4. Verification Checklist
- `Abstractions` do not expose external SDK-specific types in signatures.
- `Dtos` do not contain business logic or exception contracts.
- `IRomDocument -> IRomCanonicalizer -> ISemanticHasher` order is enforced.
- `IPdp` remains deterministic with `Indeterminate => Deny` behavior.

## 5. Migrating to v0.0.2: Vfs Naming Convention
In v0.0.2, acronyms with three or more characters are treated as words according to the .NET Framework Design Guidelines. As a result, `VFS` is normalized to `Vfs` in identifiers.

This is a breaking change that affects namespaces, project/package names, and public documentation.

### 5.1 Replacement Mapping
| Legacy Name | New Name | Notes |
|---|---|---|
| `AIKernel.VFS` | `AIKernel.Vfs` | Namespace / project / NuGet package name normalization. |
| `AIKernel.VFS.csproj` | `AIKernel.Vfs.csproj` | Update ProjectReference and solution entries. |
| `VFS` | `Vfs` | Canonical spelling for code identifiers and package/docs references. |
| `ProviderID` | `ProviderId` | `Id` is normalized as a two-letter word. |
| `IROMCanonicalizer` | `IRomCanonicalizer` | Treat three-letter acronyms as PascalCase words. |

Types that already use the canonical spelling, such as `IVfsProvider`, `IVfsSession`, `VfsProviderHealth`, and `VfsEntry`, remain unchanged.

### 5.2 Migration Steps
1. Replace `using AIKernel.VFS;` with `using AIKernel.Vfs;`.
2. Update `.csproj` / `.slnx` references to `AIKernel.Vfs/AIKernel.Vfs.csproj`.
3. If NuGet package references are used, replace `AIKernel.VFS` with `AIKernel.Vfs`.
4. Normalize remaining `VFS` references in README, design docs, and operational docs to `Vfs`.
5. Excluding migration examples, run a case-sensitive search to confirm that `VFS`, `AIKernel.VFS`, `ProviderID`, and `IROMCanonicalizer` no longer remain.

## 6. Migrating to v0.0.2: Vfs Capability Contracts
This section corresponds to Issue #4, `[RFC] Interface Segregation for VFS: Transitioning to Capability-Based Abstractions`.

In v0.0.2, Vfs permissions are represented by capability interfaces instead of a single monolithic contract.

### 6.1 New Capability Interfaces
| Capability | Purpose |
|---|---|
| `IVfsEntryInfo` | Common identity and metadata for Vfs entries. |
| `IReadableVfsFile` | Read file contents. |
| `IWritableVfsFile` | Write file contents when file-level mutation is supported. |
| `INavigableVfsDirectory` | Enumerate and navigate directories. |
| `IReadableVfsSession` | Read files and check path existence through a session. |
| `IWritableVfsSession` | Write files through a session. |
| `IDeletableVfsSession` | Delete files or directories through a session. |
| `INavigableVfsSession` | Open directories through a session. |
| `IQueryableVfsSession` | Execute provider-defined queries. |

### 6.2 Compatibility Contracts
Existing `IVfsFile`, `IVfsDirectory`, and `IVfsSession` contracts remain as composite compatibility contracts.

- `IVfsFile` extends `IReadableVfsFile`.
- `IVfsDirectory` extends `INavigableVfsDirectory` while preserving legacy `IVfsFile` / `IVfsDirectory` return types.
- `IVfsSession` composes readable / writable / deletable / navigable / queryable / async-disposable capabilities.

As a result, existing implementations that depend on `IVfsSession` do not need to be replaced immediately. However, new implementations and standard providers should narrow their dependencies to the smallest capability interface required.

### 6.3 Implementation Guidance
- Read-only providers should implement only `IReadableVfsSession`, and should not implement `IWritableVfsSession` or `IDeletableVfsSession`.
- Avoid placeholder `WriteFileAsync` implementations that throw `NotSupportedException` for providers that cannot write.
- Callers should check the required capability interface before executing an operation. If the capability is absent, deny before side effects begin.

```csharp
if (session is not IWritableVfsSession writable)
{
    // Deny before side effects begin.
    return;
}

await writable.WriteFileAsync(path, content);
```

## 7. Migrating to v0.0.2: Provider and Security Capability Contracts
After Issue #4, capability-based contracts are also applied to provider and security abstractions where one interface previously exposed unrelated authority surfaces.

### 7.1 Provider Lifecycle Contracts
`IProvider` remains as a composite compatibility contract, but provider identity, capability metadata, availability, lifecycle, and health are now independently expressible.

| Capability | Purpose |
|---|---|
| `IProviderIdentity` | Provider Id, display name, and version. |
| `IProviderCapabilitySource` | Static or dynamic provider capability metadata. |
| `IProviderAvailabilityProbe` | Availability checks. |
| `IProviderLifecycle` | Initialize and shutdown operations. |
| `IProviderHealthProbe` | Health check reporting. |

### 7.2 Provider Router Contracts
`IProviderRouter` remains as a composite compatibility contract, but retrieval, cache, and registry responsibilities are separated.

| Capability | Purpose |
|---|---|
| `IProviderMaterialRetriever` | Retrieve Material Context from one or more sources. |
| `IMaterialCacheReader` | Read Material Context from cache. |
| `IMaterialCacheWriter` | Write Material Context to cache. |
| `IProviderRegistry` | Register, unregister, and enumerate providers. |

Read-only cache adapters should implement `IMaterialCacheReader` without exposing cache write or provider registry capabilities.

### 7.3 Tool Access Validation
`IToolAccessValidator` remains as a composite compatibility contract, but the authority checks are now split into capability interfaces:

| Capability | Purpose |
|---|---|
| `IToolExecutionAccessValidator` | Validate tool execution. |
| `IFileReadAccessValidator` | Validate file reads. |
| `IFileWriteAccessValidator` | Validate file writes. |
| `INetworkAccessValidator` | Validate network access. |
| `IEnvironmentAccessValidator` | Validate environment variable access. |
| `ISystemCommandAccessValidator` | Validate system command execution. |
| `IPermissionLifecycleValidator` | Validate permission lifetime. |
| `IPermissionConstraintValidator` | Validate runtime constraints. |

Callers should depend on the smallest validator capability needed for the operation. Missing capability means denial before execution begins.

### 7.4 RAG Provider Contracts
`IRagProvider` remains as a composite compatibility contract over `IProvider`, search, and index mutation capabilities.

| Capability | Purpose |
|---|---|
| `IRagSearchProvider` | Search RAG material. |
| `IRagIndexWriter` | Add or update indexed documents. |
| `IRagIndexDeleter` | Delete indexed documents. |
| `IRagIndexManager` | Perform whole-index management operations such as clear. |

Read-only RAG providers should implement `IRagSearchProvider` only, plus `IProvider` when provider lifecycle metadata is required. They should not implement write/delete/clear capabilities just to throw `NotSupportedException`.

## 8. v0.0.2 Verification Checklist
- No `using AIKernel.VFS;` remains.
- ProjectReference / solution entries point to `AIKernel.Vfs/AIKernel.Vfs.csproj`.
- Excluding migration examples, public docs / README / csproj metadata no longer contain `VFS`, `ProviderID`, or `IROMCanonicalizer`.
- Read-only Vfs implementations do not expose mutation capabilities.
- Missing capabilities are handled as pre-execution denial, not late `NotSupportedException` failures.
- Read-only RAG providers expose `IRagSearchProvider` without index mutation capabilities.
- Provider/router dependencies are narrowed to identity, lifecycle, retrieval, cache, or registry capabilities where possible.
- Tool access validation dependencies are narrowed to the required capability interface where possible.
---

# Changelog
- v0.0.0 / v0.0.0.0: Initial draft
- v0.0.1 (2026-05-06): Version upgrade aligned with documentation guidelines
- v0.0.2 (2026-05-09): Added Issue #4 Vfs capability contract migration steps, Issue #7 Vfs naming normalization, and provider/security capability contract guidance
