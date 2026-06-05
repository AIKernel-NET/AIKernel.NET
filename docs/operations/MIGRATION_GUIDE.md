---
title: "Migration Guide"
updated: 2026-06-05
published: 2026-05-16
version: "0.0.5"
edition: "Draft"
status: "Refactor"
issuer: ai-kernel@aikernel.net
maintainer: "Takuya (AIKernel Project Maintainer)"
---

# Migration Guide

This guide defines migration steps from the initial concept baseline (`v0.0.0`) to the canonical architecture baseline (`v0.0.1`, `v0.0.2`, `v0.0.3`), to the DSL / History ROM contract extraction introduced in `v0.0.4`, and to the contract-surface purity cleanup plus external Capability module contracts, DynamicSLM Model ABI / SeedSLM discipline / distillation offload, HATL external cryptographic operator contract preparation, governance admissibility gate and trajectory vocabulary, and Semantic Compilation DTO vocabulary introduced in `v0.0.5`.

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

### 7.4 Event Bus Contracts
`IEventBus` remains as a composite compatibility contract over `IProvider`, event publishing, broadcast, and subscription registry capabilities.

| Capability | Purpose |
|---|---|
| `IEventPublisher` | Publish events. |
| `IEventBroadcaster` | Broadcast events to all subscribers. |
| `IEventSubscriptionRegistry` | Subscribe, unsubscribe, and inspect subscriber counts. |

Subscription-only adapters should implement `IEventSubscriptionRegistry` without exposing publish or broadcast capabilities.

### 7.5 Task and Scheduler Contracts
`ITaskManager` and `IScheduler` remain as composite compatibility contracts, but execution, control, result lookup, and scheduling authority are separated.

| Capability | Purpose |
|---|---|
| `IPipelineRegistrar` | Register pipelines. |
| `IPipelineExecutor` | Execute registered pipelines. |
| `ITaskExecutor` | Execute individual tasks. |
| `IPipelineExecutionController` | Pause, resume, and cancel pipeline executions. |
| `IPipelineExecutionResultReader` | Read pipeline execution results. |
| `IScheduledJobReader` | Read scheduled jobs and list jobs. |
| `IJobScheduler` | Schedule jobs. |
| `IScheduledJobCanceller` | Cancel scheduled jobs. |
| `IScheduledExecutionResultReader` | Read scheduled job execution results. |

Observation-only components should depend on result-reader or job-reader capabilities without receiving execution or cancellation authority.

### 7.6 Tokenizer Contracts
`ITokenizer` remains as a composite compatibility contract, but tokenization, counting, decoding, statistics, model support, and NPU cardinality concerns are separated.

| Capability | Purpose |
|---|---|
| `ITokenizerIdentity` | Tokenizer profile Id and name. |
| `ITextTokenizer` | Convert text into tokens. |
| `ITokenCounter` | Count tokens without exposing token materialization. |
| `ITokenDecoder` | Decode tokens back to text. |
| `ITokenizerStatisticsProvider` | Read tokenizer statistics. |
| `ITokenizerModelSupport` | Check model support. |
| `IPhysicalCardinalityAdvisor` | Convert logical token counts to physical cardinality. |
| `IPaddingInfoProvider` | Read padding information. |

Budget estimators should usually depend on `ITokenCounter` and, only when hardware alignment is required, `IPhysicalCardinalityAdvisor`.

### 7.7 Signature Trust Store Contracts
`ISignatureTrustStore` remains as a composite compatibility contract, but trust resolution, revocation, expiry, chain verification, trusted-anchor lookup, and health probing are separated.

| Capability | Purpose |
|---|---|
| `ISignerTrustResolver` | Resolve signer trust score. |
| `IKeyRevocationChecker` | Check key revocation. |
| `IKeyExpiryReader` | Read key expiry. |
| `ICertificateChainVerifier` | Verify certificate chain. |
| `ITrustedAnchorReader` | Read trusted anchors. |
| `ITrustStoreHealthProbe` | Check trust store reachability. |

Health-only checks should depend on `ITrustStoreHealthProbe` and should not receive trust-resolution or revocation authority.

### 7.8 Kernel Facade Contracts
`IKernel` remains as the top-level facade compatibility contract, but execution, analysis, preprocessing, provider routing, and governance access are independently expressible.

| Capability | Purpose |
|---|---|
| `IKernelVersionProvider` | Read kernel version. |
| `IKernelContextExecutor` | Execute a unified context contract. |
| `IKernelAttentionAnalyzer` | Analyze orchestration attention pollution. |
| `IKernelMaterialPreprocessor` | Normalize and structure Material Context. |
| `IKernelExpressionPreparer` | Prepare Expression Context. |
| `IKernelProviderRouterAccessor` | Access Provider Router. |
| `IKernelGuardAccessor` | Access Guard. |
| `IKernelPdpAccessor` | Access PDP. |

Application code should depend on the narrow kernel capability it needs. `IKernel` should be reserved for composition roots and facade-level orchestration.

### 7.9 RAG Provider Contracts
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
- Event dependencies are narrowed to publisher, broadcaster, or subscription registry capabilities where possible.
- Task and scheduler dependencies are narrowed to execution, control, result reader, job reader, scheduler, or canceller capabilities where possible.
- Tokenizer dependencies are narrowed to counter, tokenizer, decoder, statistics, model support, cardinality, or padding capabilities where possible.
- Signature trust dependencies are narrowed to trust resolver, revocation checker, expiry reader, chain verifier, anchor reader, or health probe capabilities where possible.
- Kernel dependencies are narrowed to execution, analysis, preprocessing, provider-router access, guard access, or PDP access capabilities where possible.
- Tool access validation dependencies are narrowed to the required capability interface where possible.

## 9. Migrating to v0.0.2: Contract Purity
This section corresponds to Issue #8, `Contract Purity`.

Contracts now represent immutable views/descriptors only. Mutation, validation, transformation, canonicalization, hashing, extraction, and analysis responsibilities are moved into explicit service interfaces.

### 9.1 Removed from Contract Objects
| Contract | Removed Members | Replacement Service Interfaces |
|---|---|---|
| `IMaterialContract` | `Normalize`, `Structurize`, `ExtractEssentialContent`, `ValidateQuarantine` | `IMaterialNormalizer`, `IMaterialStructurizer`, `IEssentialMaterialExtractor`, `IMaterialQuarantineValidator` |
| `IUnifiedContextContract` | `ValidateAll`, `ValidateLayerSeparation`, `DetectPollution`, `CalculateSignalToNoiseRatio` | `IUnifiedContextContractValidator`, `ILayerSeparationValidator`, `IAttentionPollutionDetector`, `ISignalToNoiseRatioCalculator` |
| `IOrchestrationContract` | `Validate`, `CalculateSignalToNoiseRatio` | `IOrchestrationContractValidator`, `ISignalToNoiseRatioCalculator` |
| `IExpressionContract` | `ValidateIsolation`, `CanApplyAfterInference` | `IExpressionIsolationValidator`, `IExpressionApplicationGate` |

### 9.2 New Material Processing Services
| Service | Purpose |
|---|---|
| `IMaterialNormalizer` | Normalize material into a new `MaterialContextDto`. |
| `IMaterialStructurizer` | Produce structured material data without mutating the contract. |
| `IMaterialCanonicalizer` | Produce canonical material text. |
| `IMaterialHashProvider` | Compute material hash. |
| `IEssentialMaterialExtractor` | Extract orchestration-safe essential content. |
| `IMaterialQuarantineValidator` | Validate material quarantine state. |

Contract implementations should not mutate themselves. A transformation must return a new DTO/value or derived representation.

## 10. Migrating to v0.0.2: Capability-Driven Providers
This section corresponds to Issue #9, `Capability-Driven Providers`.

Provider contracts now expose optional operations as explicit capability interfaces. Existing broad interfaces remain as composite compatibility contracts.

### 10.1 Model Provider Capabilities
| Capability | Purpose |
|---|---|
| `ITextGenerationProvider` | Text generation via `GenerateAsync`. |
| `IStreamingGenerationProvider` | Streaming text generation via `StreamGenerateAsync`. |
| `IQuestionAnsweringProvider` | Direct question answering via `AnswerAsync`. |
| `IModelProvider` | Composite compatibility contract over all model capabilities plus `IProvider`. |

Text-only providers should implement `ITextGenerationProvider` without pretending to support streaming or question answering.

### 10.2 Embedding Provider Capabilities
| Capability | Purpose |
|---|---|
| `ITextEmbeddingProvider` | Single text embedding. |
| `IBatchEmbeddingProvider` | Batch embedding. |
| `IEmbeddingDimensionProvider` | Embedding dimension metadata. |
| `IEmbeddingProvider` | Composite compatibility contract over all embedding capabilities plus `IProvider`. |

### 10.3 Provider Capability Metadata
| Capability | Purpose |
|---|---|
| `IProviderOperationCapabilities` | Static operation and data-type support. |
| `IProviderConnectionCapabilities` | Concurrency and rate-limit metadata. |
| `IProviderCapacityVectorSource` | Static capacity vector. |
| `IDynamicProviderCapacitySource` | Constraint-dependent dynamic capacities. |
| `IProviderProfileSource` | Capability profile metadata. |
| `IQuantizationSupport` | Quantization support checks. |
| `IProviderCapabilities` | Composite compatibility contract over all provider capability metadata. |

Routers should select providers by the capability interface they actually require.

## 11. Migrating to v0.0.2: Security and Policy Separation
This section corresponds to Issue #10, `Security & Policy Separation`.

Security contracts now separate decision, enforcement, registry, validation, failure handling, and audit category responsibilities. Missing or indeterminate authority must fail closed at the caller boundary.

### 11.1 Guard Capabilities
| Capability | Purpose |
|---|---|
| `IGuardEvaluator` | Execution and context-access checks. |
| `IResourceAccessGuard` | Read/write resource checks. |
| `IGuardEnforcer` | Enforce guard decisions and return fail-closed actions. |
| `IGuardFailureHandler` | Failure-mode handling and fail-closed actions. |
| `IGuard` | Composite compatibility contract. |

### 11.2 PDP Capabilities
| Capability | Purpose |
|---|---|
| `IPolicyDecisionPoint` | Deterministic access decision evaluation. |
| `IPolicyRegistry` | Add/remove policy registry operations. |
| `IPolicySource` | Read registered policies. |
| `IPolicyDecisionEvaluator` | Evaluate policies for a unified context. |
| `IPdp` | Composite compatibility contract. |

### 11.3 Rules Engine Capabilities
| Capability | Purpose |
|---|---|
| `IRuleRegistry` | Register, read, delete, and list prompt rules. |
| `IRuleEvaluator` | Evaluate a rule. |
| `IPreExecutionRuleValidator` | Validate pre-prompt context. |
| `IPostExecutionRuleValidator` | Validate post-prompt context. |
| `IRulesEngine` | Composite compatibility contract. |

### 11.4 Audit Capabilities
| Capability | Purpose |
|---|---|
| `IAuditEventWriter` | Generic audit event logging. |
| `IExecutionAuditLogger` | Execution event logging. |
| `IGuardAuditLogger` | Guard event logging. |
| `IPipelineAuditLogger` | Pipeline event logging. |
| `IProviderAuditLogger` | Provider event logging. |
| `ITransferTraceLogger` | Transfer trace logging. |
| `IAuditLogger` | Composite compatibility contract. |

## 12. Migrating to v0.0.2: Sandbox and Validator Isolation
This section corresponds to Issue #11, `Sandbox & Validator Isolation`.

Execution, file transfer, cleanup, observation, validation, store mutation, and context-buffer access are now separated into capability interfaces. Existing broad interfaces remain as composite compatibility contracts.

### 12.1 Tool Sandbox Capabilities
| Capability | Purpose |
|---|---|
| `IToolSandboxIdentity` | Sandbox identity. |
| `IToolExecutor` | Execute tools in a sandbox. |
| `IToolFileUploadSink` | Upload files into a sandbox. |
| `IToolFileDownloadSource` | Download files from a sandbox. |
| `IToolSandboxCleanup` | Cleanup sandbox state. |
| `IToolResourceUsageSource` | Read sandbox resource usage. |
| `IToolSandbox` | Composite compatibility contract. |

### 12.2 ROM Validator Capabilities
| Capability | Purpose |
|---|---|
| `IRomSchemaValidator` | ROM schema validation. |
| `IRomLinkageValidator` | ROM linkage validation. |
| `IRomTypeConsistencyValidator` | ROM type consistency validation. |
| `IRomCircularReferenceValidator` | ROM circular reference detection. |
| `IRomValidator` | Composite compatibility contract. |

### 12.3 Store, Collection, and Compute Capabilities
| Capability | Purpose |
|---|---|
| `IConversationSnapshotWriter` | Save conversation snapshots. |
| `IConversationSnapshotReader` | Read conversation snapshots. |
| `IConversationBranchLister` | List conversation branches. |
| `IConversationSnapshotDeleter` | Delete conversation snapshots. |
| `IContextFragmentCollection` | Read context fragments. |
| `IPhaseBufferCollection` | Read phase buffers. |
| `IComputeCardinalityAdvisor` | Cardinality advice. |
| `IComputePaddingAdvisor` | Padding strategy and overhead advice. |
| `IQuantizationAdvisor` | Quantization advice. |
| `IComputeShapeOptimizer` | Constraint-based shape optimization. |

Read-only stores and schema-only validators should implement only the capability they actually support.

## 13. Migrating from v0.0.2 to v0.0.3: Dependency Layer Correction
v0.0.3 corrects the package dependency graph around Vfs contracts.

> v0.0.4 supersedes this compatibility facade. If you are upgrading directly to v0.0.4 or later, follow section 14.6 and remove the separate `AIKernel.Vfs` package/project.

The main v0.0.3 change was that Vfs interface contracts became owned by `AIKernel.Abstractions`. In v0.0.3 only, the separate `AIKernel.Vfs` package acted as a compatibility facade through type forwarding, but it was no longer the owner of the contract definitions. v0.0.4 and later remove that separate package/project.

### 13.1 Target Layering
The expected Phase-1 dependency direction is:

```text
AIKernel.Enums -> (none)
AIKernel.Dtos -> AIKernel.Enums
AIKernel.Contracts -> AIKernel.Enums, AIKernel.Dtos
AIKernel.Abstractions -> AIKernel.Dtos, AIKernel.Enums
AIKernel.Vfs -> AIKernel.Abstractions
```

The forbidden direction is:

```text
AIKernel.Abstractions -> AIKernel.Vfs
AIKernel.Abstractions -> AIKernel.Core
AIKernel.Abstractions -> Providers
```

### 13.2 Moved Vfs Contracts
The following contracts moved from the `AIKernel.Vfs` project to the `AIKernel.Abstractions` project:

| Contract | New owner | Compatibility |
|---|---|---|
| `IVfsProvider` | `AIKernel.Abstractions` | Type-forwarded by `AIKernel.Vfs`. |
| `IVfsSession` | `AIKernel.Abstractions` | Type-forwarded by `AIKernel.Vfs`. |
| `IReadableVfsSession` | `AIKernel.Abstractions` | Type-forwarded by `AIKernel.Vfs`. |
| `IWritableVfsSession` | `AIKernel.Abstractions` | Type-forwarded by `AIKernel.Vfs`. |
| `IDeletableVfsSession` | `AIKernel.Abstractions` | Type-forwarded by `AIKernel.Vfs`. |
| `INavigableVfsSession` | `AIKernel.Abstractions` | Type-forwarded by `AIKernel.Vfs`. |
| `IQueryableVfsSession` | `AIKernel.Abstractions` | Type-forwarded by `AIKernel.Vfs`. |
| `IVfsCredentials` | `AIKernel.Abstractions` | Type-forwarded by `AIKernel.Vfs`. |
| `IVfsFile`, `IVfsDirectory` | `AIKernel.Abstractions` | Type-forwarded by `AIKernel.Vfs`. |
| `IReadableVfsFile`, `IWritableVfsFile` | `AIKernel.Abstractions` | Type-forwarded by `AIKernel.Vfs`. |
| `INavigableVfsDirectory` | `AIKernel.Abstractions` | Type-forwarded by `AIKernel.Vfs`. |
| `IVfsEntryInfo` | `AIKernel.Abstractions` | Type-forwarded by `AIKernel.Vfs`. |
| `IVfsQuery`, `IVfsQueryResult` | `AIKernel.Abstractions` | Type-forwarded by `AIKernel.Vfs`. |
| `VfsAuthenticationFailedException` | Removed in `v0.0.4` | In `v0.0.3` this was part of the facade; in `v0.0.4` failures are handled by runtime/Core adapters. |

The public namespace remains `AIKernel.Vfs` for compatibility. The ownership change is at the assembly/package layer.

### 13.3 Project Reference Updates
Consumers should update project references as follows:

```diff
AIKernel.Abstractions.csproj
- <ProjectReference Include="..\AIKernel.Vfs\AIKernel.Vfs.csproj" />

AIKernel.Vfs.csproj
- <ProjectReference Include="..\AIKernel.Dtos\AIKernel.Dtos.csproj" />
+ <ProjectReference Include="..\AIKernel.Abstractions\AIKernel.Abstractions.csproj" />
```

Application projects that only use Vfs contracts can reference `AIKernel.Abstractions` directly. Projects pinned to v0.0.3 and requiring the compatibility facade could reference `AIKernel.Vfs`; v0.0.4 and later consumers should remove that separate package/project.

### 13.4 NuGet Package Updates
When upgrading package references:

```xml
<PackageReference Include="AIKernel.Abstractions" Version="0.0.3" />
<PackageReference Include="AIKernel.Vfs" Version="0.0.3" />
```

Do not mix `AIKernel.Abstractions` `0.0.3` with `AIKernel.Vfs` `0.0.2`; the facade expects the Vfs contract types to be provided by the `0.0.3` Abstractions assembly.

### 13.5 Source Migration Steps
1. Keep existing `using AIKernel.Vfs;` directives because the public namespace remains valid.
2. Remove any direct `AIKernel.Abstractions -> AIKernel.Vfs` project reference.
3. If a library defines only contracts, prefer referencing `AIKernel.Abstractions` rather than `AIKernel.Vfs`.
4. If a runtime/provider package implements Vfs contracts, reference `AIKernel.Abstractions` for v0.0.4 and later package graphs.
5. For v0.0.3-only compatibility builds, rebuild all packages so type-forwarding metadata is emitted consistently.

### 13.6 Verification Commands
Run:

```powershell
dotnet build src\AIKernel.NET.slnx
dotnet test src\tests\AIKernel.Abstractions.Tests\AIKernel.Abstractions.Tests.csproj --no-build
```

Check the project-reference graph:

```text
AIKernel.Abstractions -> AIKernel.Dtos, AIKernel.Enums
AIKernel.Vfs -> AIKernel.Abstractions
CYCLE CHECK: OK (no ProjectReference cycles)
```

Also verify that `AIKernel.Abstractions.csproj` contains no reference to `AIKernel.Vfs`.

## 14. Migrating from v0.0.3 to v0.0.4: DSL / History ROM Contract Extraction
v0.0.4 promotes public contracts that had started inside `AIKernel.Core` into the `AIKernel.NET` contract packages. This prepares external capability modules, server hosts, WASM clients, and future Core packages to share the same interface surface.

This release intentionally keeps `AIKernel.Abstractions` independent from `AIKernel.Core` and `AIKernel.Common`. Core implementations that currently expose `Result<T>` or `ResultStep<TState,TValue>` should adapt those internal results to the DTO contract surface described below.

### 14.1 New DTO Areas
| Area | New DTOs |
|---|---|
| `AIKernel.Dtos.Time` | `KernelTimestamp` |
| `AIKernel.Dtos.Dsl` | `DslDocument`, `PipelineNode`, `PipelineRootNode`, `StepNode`, `CallCapabilityNode`, `LoopNode`, `LoopUntilNode`, `SuspendNode`, `DslPipelineValue`, `DslPipelineState`, `DslPipelineExecutionContext`, `DslPipelineExecutionResult`, `DslRomMetadata`, `DslRomSnapshot` |
| `AIKernel.Dtos.History` | `ChatHistoryRomRecord`, `ChatHistoryRomOptions`, `HistoryRomMetadata`, `HistoryRomSnapshot` |

### 14.2 New Abstraction Areas
| Area | New contracts |
|---|---|
| `AIKernel.Abstractions.Time` | `IKernelClock` |
| `AIKernel.Abstractions.Dsl` | `IKernelPipeline`, `IDslPipelineCompiler`, `IDslCapabilityRegistry`, `IDslRomRegistry`, `IDslRomStore` |
| `AIKernel.Abstractions.History` | `IChatHistoryRomExporter`, `IHistoryRomRegistry`, `IHistoryRomStore` |

### 14.3 Breaking Migration Notes for Core Adapters
Core-side implementations should no longer require downstream consumers to reference Core-only DSL, History ROM, or clock contracts.
`DslNodeTypes` defines canonical DSL node type strings. Parsers may accept paper/example aliases such as `CapabilityCall` and `SuspendForApproval`, but should normalize them to `CallCapability` and `Suspend` before storage or replay hashing.

Recommended replacements:

| Core-local concept | v0.0.4 public contract |
|---|---|
| `AIKernel.Core.Time.IKernelClock` | `AIKernel.Abstractions.Time.IKernelClock` |
| `AIKernel.Core.Time.KernelTimestamp` | `AIKernel.Dtos.Time.KernelTimestamp` |
| Core DSL IR records | `AIKernel.Dtos.Dsl` records |
| Core DSL pipeline interface | `AIKernel.Abstractions.Dsl.IKernelPipeline` |
| Core DSL ROM registry interface | `AIKernel.Abstractions.Dsl.IDslRomRegistry` |
| Core DSL ROM store class boundary | `AIKernel.Abstractions.Dsl.IDslRomStore` |
| Core History ROM registry interface | `AIKernel.Abstractions.History.IHistoryRomRegistry` |
| Core History ROM store class boundary | `AIKernel.Abstractions.History.IHistoryRomStore` |

### 14.4 Ambiguous Interface Renames
v0.0.4 removes public interface names that were too broad for a shared package surface.

| Removed / renamed contract | Replacement |
|---|---|
| `AIKernel.Abstractions.Kernel.IKernelExecutor` | `AIKernel.Abstractions.Kernel.IKernelContextExecutor` |
| `AIKernel.Abstractions.Governance.ChatChain.IResult` | `AIKernel.Abstractions.Governance.ChatChain.IChatTurnVerificationResult` |
| `AIKernel.Abstractions.Governance.ChatChain.ISemanticHasher` | `AIKernel.Abstractions.Governance.ChatChain.IChatTurnSemanticHasher` |
| `AIKernel.Abstractions.Scheduling.IExecutionResult` | `AIKernel.Abstractions.Scheduling.IScheduledExecutionResult` |

`AIKernel.Abstractions.Execution.IKernelExecutor` and `AIKernel.Abstractions.Rom.ISemanticHasher` remain unchanged. The renamed contracts were facade/chat-chain/scheduling-specific names that collided with broader execution and ROM concepts.

When a Core implementation still uses `AIKernel.Common.Results.Result<T>` internally, unwrap it at the package boundary into either:

- a successful DTO return value, or
- an implementation-defined fail-closed exception/result adapter appropriate to the host.

The `AIKernel.NET` contract packages deliberately do not expose `Result<T>` until `AIKernel.Common` is published as a stable package.

### 14.5 NuGet Package Updates
Use a consistent package set:

```xml
<PackageReference Include="AIKernel.Abstractions" Version="0.0.4" />
<PackageReference Include="AIKernel.Dtos" Version="0.0.4" />
<PackageReference Include="AIKernel.Enums" Version="0.0.4" />
```

Do not mix `AIKernel.Abstractions` `0.0.4` with `AIKernel.Dtos` `0.0.3`; the new DSL, History ROM, and time contracts require the v0.0.4 DTO surface.

### 14.6 AIKernel.Vfs Package Removal
v0.0.4 removes the separate `AIKernel.Vfs` compatibility package/project.
Vfs contracts remain available from `AIKernel.Abstractions`, and their public namespace remains `AIKernel.Vfs`.

Migration steps:

1. Remove `PackageReference Include="AIKernel.Vfs"` from application, provider, and test projects.
2. Add or keep `PackageReference Include="AIKernel.Abstractions" Version="0.0.4"` where Vfs contracts are used.
3. Keep source imports such as `using AIKernel.Vfs;`; the namespace is still correct.
4. Remove project references to `AIKernel.Vfs/AIKernel.Vfs.csproj` in local source builds.

### 14.7 Interface-Only Contract Packages
v0.0.4 introduces the target that `AIKernel.Abstractions` and `AIKernel.Contracts` are interface-only packages.
DTOs, enums, exception types, factories, parsing helpers, and runtime behavior must live outside those
contract packages.

> v0.0.5 completes enforcement of this rule by removing the remaining physical DTO, enum, and exception implementations from the contract surface. See section 15 when migrating directly to v0.0.5 or later.

v0.0.4 introduced this ownership rule while extracting DSL, History ROM, and time contracts.
Representative moves include `AIKernel.Contracts.ValidationResult` to `AIKernel.Dtos.Context.ValidationResult`
and `AIKernel.Abstractions.Vfs.VfsCredentials` to `AIKernel.Dtos.Vfs.VfsCredentials`.

For the complete v0.0.5 cleanup of remaining Abstractions-local DTOs, duplicate DTO enums,
and contract-package exceptions, use section 15.

### 14.8 Verification Commands
Run:

```powershell
dotnet build src\AIKernel.NET.slnx
dotnet test src\tests\AIKernel.Abstractions.Tests\AIKernel.Abstractions.Tests.csproj --no-build
dotnet pack src\AIKernel.NET.slnx --no-build
```

Check the project-reference graph remains:

```text
AIKernel.Enums -> (none)
AIKernel.Dtos -> AIKernel.Enums
AIKernel.Contracts -> AIKernel.Enums, AIKernel.Dtos
AIKernel.Abstractions -> AIKernel.Dtos, AIKernel.Enums
CYCLE CHECK: OK
```

## 15. Migrating from v0.0.4 to v0.0.5: Contract Surface Purity Cleanup
v0.0.5 completes the `interface-only` rule for `AIKernel.Abstractions` and `AIKernel.Contracts`.
The release removes remaining DTO, enum, and exception implementations that were still physically located in contract packages after the v0.0.4 extraction.

### 15.1 Removed Abstractions-local DTOs
Use DTO package types instead.

| Removed type | Replacement |
|---|---|
| `AIKernel.Abstractions.Context.ContextAssemblyRequest` | `AIKernel.Dtos.Context.ContextAssemblyRequest` |
| `AIKernel.Abstractions.Context.ContextAssemblyScope` | `AIKernel.Dtos.Context.ContextAssemblyScope` |
| `AIKernel.Abstractions.Context.ContextAssemblyDecision` | `AIKernel.Dtos.Context.ContextAssemblyDecision` |
| `AIKernel.Abstractions.DtoContracts.Execution.GeneratedPrompt` | `AIKernel.Dtos.Execution.GeneratedPrompt` |
| `AIKernel.Abstractions.DtoContracts.Execution.KernelExecutionRequest` | `AIKernel.Dtos.Execution.KernelExecutionRequest` |
| `AIKernel.Abstractions.DtoContracts.Execution.PromptGenerationRequest` | `AIKernel.Dtos.Execution.PromptGenerationRequest` |
| `AIKernel.Abstractions.DtoContracts.Kernel.KernelRequest` | `AIKernel.Dtos.Kernel.KernelRequest` |

### 15.2 Removed duplicate DTO enums
Use enum package types instead.

| Removed type | Replacement |
|---|---|
| `AIKernel.Dtos.Execution.ExecutionStatus` | `AIKernel.Enums.ExecutionStatus` |
| `AIKernel.Dtos.Execution.PromptMessageFormat` | `AIKernel.Enums.PromptMessageFormat` |
| `AIKernel.Dtos.Execution.PromptOverflowPolicy` | `AIKernel.Enums.PromptOverflowPolicy` |

### 15.3 Removed contract-package exceptions
The following exception implementations are no longer exported from `AIKernel.Abstractions`.

- `ContextAssemblyException`
- `ContextAssemblyGovernanceException`
- `PromptGenerationException`
- `PromptTokenBudgetExceededException`
- `UnsupportedPromptCapabilityException`
- `VfsAuthenticationFailedException`

Runtime packages such as `AIKernel.Core` should own these exception or result/failure adapter types.

### 15.4 Removed ambiguous ChatChain interfaces
The following legacy interfaces were removed because their simple names were ambiguous on the shared contract surface.

| Removed type | Replacement |
|---|---|
| `AIKernel.Abstractions.Governance.ChatChain.IResult` | `AIKernel.Abstractions.Governance.ChatChain.IChatTurnVerificationResult` |
| `AIKernel.Abstractions.Governance.ChatChain.ISemanticHasher` | `AIKernel.Abstractions.Governance.ChatChain.IChatTurnSemanticHasher` |

`AIKernel.Abstractions.Rom.ISemanticHasher` remains the ROM semantic hash contract.

### 15.5 Package update
Keep the contract package set aligned.

```xml
<PackageReference Include="AIKernel.Abstractions" Version="0.0.5" />
<PackageReference Include="AIKernel.Dtos" Version="0.0.5" />
<PackageReference Include="AIKernel.Enums" Version="0.0.5" />
<PackageReference Include="AIKernel.Contracts" Version="0.0.5" />
```

Do not mix `AIKernel.Abstractions` `0.0.5` with `AIKernel.Dtos` or `AIKernel.Enums` `0.0.4`.

### 15.6 DynamicSLM / SeedSLM, HATL, governance, and Semantic Compilation vocabulary preparation
v0.0.5 adds non-runtime contracts for future external Capability modules, DynamicSLM capability modules, SeedSLM discipline surfaces, HATL external cryptographic operators, pre-inference governance admission evidence, trajectory governance evidence, and Semantic Compilation descriptors.
These additions are source-compatible for existing consumers, but Core/Provider implementations that plan to support capability-modular SLM artifacts, HATL-backed trust layers, Semantic DSL admission evidence, or semantic compiler runtime artifacts should target the new namespaces.

| Area | New public surface |
|---|---|
| `AIKernel.Abstractions.Capabilities` | `ICapabilityModuleRegistry`, `ICapabilityModuleInvoker` |
| `AIKernel.Abstractions.Governance` | `ICriticalOperationGate`, `IComputationalComplexityGate` |
| `AIKernel.Abstractions.DynamicSlm` | `IDynamicSlmModelAbiProvider`, `IDynamicSlmModuleRegistry`, `IDynamicSlmPipelineContextFactory`, `IDynamicSlmPipelineStep<TInput,TOutput>`, `IDynamicSlmAsyncPipelineStep<TInput,TOutput>`, `IDynamicSlmAsyncPipeline`, `IDynamicSlmPipelineBuilder`, `IDynamicSlmFailure`, `IDynamicSlmCapabilityGraphResolver`, `IDynamicSlmCompatibilityVerifier`, `IDynamicSlmLineageVerifier`, `IDynamicSlmPayloadLoader`, `IDynamicSlmScheduler`, `IDynamicSlmCapabilityGapDetector`, `IDynamicSlmCapabilityGraphEvolutionPlanner`, `IDynamicSlmDistillationPlanner`, `IDynamicSlmDistillationJobScheduler`, `IDynamicSlmBackgroundDistillationService`, `IDynamicSlmArtifactPublisher`, `ISeedSlmDisciplineVerifier`, `IDynamicSlmDelegationPlanner`, `IDynamicSlmThoughtArtifactSink`, `IDynamicSlmMemoryPlacementPlanner` |
| `AIKernel.Abstractions.Hatl` | `IHatlLedgerStore`, `IHatlAnchorPublisher`, `IHatlAnchorVerifier`, `IHatlDigitalDeedResolver`, `IHatlCryptographicOperator` |
| `AIKernel.Dtos.Capabilities` | `CapabilityModuleDescriptor`, `CapabilityInvocationRequest`, and `CapabilityInvocationResult` for CLI executable, managed assembly, native ABI, DSL ROM, and remote endpoint capability boundaries |
| `AIKernel.Dtos.DynamicSlm` | Model ABI records for semantic profile, capability graph, execution profile, lineage, payload descriptors, pipeline context/result/failure/trace metadata, resolved subgraphs, placement plans, capability gaps, graph update plans, distillation requests/plans with metadata, distillation job descriptors, offload requests, fallback strategies, pipeline offload info, admission results, SeedSLM structural constraints, output discipline policies, delegation requests, thought artifacts, ReplayLog entries, trajectory metadata, adapter compatibility, neutrality, resident model descriptors, capability swap descriptors, and memory placement metadata |
| `AIKernel.Dtos.Governance` | `AdmissibilityReplayRecord`, `CriticalOperationProfile`, `CriticalOperationGateResult`, `TaskComplexityProfile`, `ModelExecutionBudget`, and `ComplexityGateResult` for replay-compatible pre-inference admission evidence; `SemanticEllipsoidDescriptor`, `TrajectoryGovernanceScoreReport`, and `CandidateActionEvaluation` for trajectory governance evidence |
| `AIKernel.Dtos.Hatl` | Ledger entries, anchor documents, Digital Deeds, public anchor receipts, verification results, BlockMAC requests/results, ratchet step requests/results, and HATL metadata keys |
| `AIKernel.Dtos.SemanticCompilation` | Semantic state snapshots, Semantic IR elements, governed circuit descriptors, prototype space descriptors, semantic distance reports, deterministic synthesis descriptors, and semantic transition descriptors |
| `AIKernel.Enums` | Capability module/invocation primitives, DynamicSLM payload, accelerator, pipeline stage including distillation offload/fallback selection/strict output/delegation/thought dump/memory placement, failure kind, capability relation, compatibility status, graph update, admission status, distillation job status, fallback kind, pipeline status, SeedSLM strict output/delegation/reasoning/base-state/hot-swap primitives, HATL anchor/deed/verification primitives, `SemanticIrSlot`, `AdmissibilityGateKind`, `AdmissibilityDecisionKind`, `TaskCostClass`, and `CriticalOperationRequirement` |

These contracts intentionally do not expose `AIKernel.Common.Result<T>` or Core runtime handles. Implementations should adapt their internal result pipeline to the DTO/interface boundary.
LINQ `SelectMany`, `Bind`, and `Map` implementations belong to `AIKernel.Common` or Core packages, not to `AIKernel.NET`.
Distillation planning may run in the load pipeline, but distillation execution must be offloaded through `IDynamicSlmDistillationJobScheduler` or `IDynamicSlmBackgroundDistillationService`. Pipelines should continue through teacher, remote, or cached fallback metadata instead of blocking on training work.
SeedSLM discipline, delegation, thought-artifact, and memory-placement contracts are also DTO/interface-only. Core should adapt them to ResultStep/ReplayLog/SemanticDelta pipelines and must not embed runtime behavior in contract packages.
`DynamicSlmModelAbi`, `DynamicSlmPipelineContext`, and `DynamicSlmPipelineMetadata` include SeedSLM extension fields while retaining constructor compatibility for callers that do not provide SeedSLM state; missing SeedSLM fields are interpreted as absent contract metadata, not as runtime failure.
HATL cryptographic operations are also contract-only in `AIKernel.NET`. Bind `IHatlCryptographicOperator` to an AIKernel.RH-backed operator, hardware provider, or audited module in Core/host code.
DTO timestamp properties no longer inject `DateTime.UtcNow` by default. Core/provider implementations should assign deterministic timestamps through their clock or semantic-state materialization boundary.
Governance admission records are DTO/enum-only. Core semantic compilers should attach `AdmissibilityReplayRecord` values to their own ResultStep/ReplayLog pipeline and use `SemanticIrSlot` only as shared G/T/C/B vocabulary, not as a runtime graph executor.
Semantic Compilation DTOs are also contract-only. Prototype-space search, semantic distance evaluation, admissibility functions, deterministic synthesis, and graph execution remain Core/runtime responsibilities.

### 15.7 Verification Commands
Run:

```powershell
dotnet build src\AIKernel.NET.slnx -c Release
dotnet test src\AIKernel.NET.slnx -c Release --no-build
```

Confirm:

```text
AIKernel.Abstractions exports interfaces only.
AIKernel.Contracts exports interfaces only.
AIKernel.Dtos exports no enums.
AIKernel.Enums owns shared enums.
CYCLE CHECK: OK
```
---

# Changelog
- v0.0.0 / v0.0.0.0: Initial draft
- v0.0.1 (2026-05-06): Version upgrade aligned with documentation guidelines
- v0.0.2 (2026-05-09): Added Issue #4 Vfs capability contract migration steps, Issue #7 Vfs naming normalization, provider/security capability contract guidance, Issue #8 contract purity migration, Issue #9 provider capability migration, Issue #10 security/policy separation migration, and Issue #11 sandbox/validator isolation migration
- v0.0.3 (2026-06-02): Added dependency-layer migration for Vfs contract ownership, `AIKernel.Vfs` type-forwarding compatibility, package-reference guidance, and cycle-verification steps
- v0.0.4 (2026-06-04): Added DSL pipeline, DSL ROM, History ROM, Kernel clock contract extraction, ROM store contracts, ambiguous-interface rename guidance, AIKernel.Vfs package removal steps, and interface-only contract package migration for AIKernel.Core adapter migration
- v0.0.5 (2026-06-05): Removed remaining Abstractions-local DTO/exception implementations, duplicate DTO enums, and legacy ambiguous ChatChain interfaces; added external Capability module contracts, DynamicSLM Model ABI, SeedSLM discipline, distillation offload, HATL external cryptographic operator, governance admissibility gate/trajectory, and Semantic Compilation DTO vocabulary contract preparation
