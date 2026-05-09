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
| `IKernelExecutor` | Execute a unified context contract. |
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
---

# Changelog
- v0.0.0 / v0.0.0.0: Initial draft
- v0.0.1 (2026-05-06): Version upgrade aligned with documentation guidelines
- v0.0.2 (2026-05-09): Added Issue #4 Vfs capability contract migration steps, Issue #7 Vfs naming normalization, provider/security capability contract guidance, Issue #8 contract purity migration, Issue #9 provider capability migration, Issue #10 security/policy separation migration, and Issue #11 sandbox/validator isolation migration
