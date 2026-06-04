---
title: "移行ガイド（Migration Guide）"
updated: 2026-06-04
published: 2026-05-16
version: "0.0.4"
edition: "Draft"
status: "Refactor"
issuer: ai-kernel@aikernel.net
maintainer: "拓也（AIKernel プロジェクト メンテナー）"
---

# 移行ガイド（Migration Guide）

本ガイドは、初期コンセプト版（v0.0.0）から、正典化されたアーキテクチャ（v0.0.1、v0.0.2、v0.0.3）、および v0.0.4 の DSL / History ROM contract 抽出へ移行するための手順を定義します。

## 1. 根本的な変更点
v0.0.1 では、`決定論（Determinism）` と `非推論型ガバナンス` を軸に、全体設計が再編されました。

- `Namespace の厳格化`:
  `AIKernel.Models` は廃止され、`Routing` / `Rom` / `Rules` へ責務分割されました。
- `DTO の純粋化`:
  DTO 層からロジックとカスタム例外を排除し、データ契約に限定しました。
- `信頼チェーンの導入`:
  ROM 処理は、`IRomCanonicalizer` を経由してから `ISemanticHasher` で検証する流れへ統一されました。

## 2. インターフェースの代替マッピング
旧語彙から新語彙への置換ルールです。

| 旧インターフェース (v0.0.0) | 新インターフェース (v0.0.1) | 移行ポイント |
|---|---|---|
| `IPromptSigner` | `ISemanticHasher` + `IPromptSignatureProvider` | 署名のみの発想から、正準化 + 意味ハッシュ + 署名検証の連鎖へ移行。 |
| `IContextSerializer` | （廃止） | `IKernelContext` と `IContextSnapshot` に責務を再配置。 |
| `IRoutingDecisionEngine` | `IModelVectorRouter` | モデル名中心の選択から、能力ベクトル中心の決定へ移行。 |
| `IPromptRuleSet` | `IPolicy` / `IRuleEngine` | ルール集合の曖昧運用を廃止し、決定論的ポリシー評価へ移行。 |

## 3. 推奨移行ステップ
1. `Namespace の修正`:
   物理ディレクトリ構造に合わせて `using` を更新します。
2. `例外処理の移動`:
   DTO 層の例外前提実装を廃止し、Provider/Kernel 実行層で Fail-Closed を実装します。
3. `ROM 処理の修正`:
   ハッシュ計算の前に必ず `IRomCanonicalizer.Canonicalize()` を呼び出します。
4. `テストの再整備`:
   Use-Case 駆動テストを、`UC-xx` と対応 Interface に再マッピングします。

## 4. 検証チェックリスト
- `Abstractions` が外部 SDK 型をシグネチャに露出していない。
- `Dtos` がロジックや例外型に依存していない。
- `IRomDocument -> IRomCanonicalizer -> ISemanticHasher` の順序が守られている。
- `IPdp` 判定経路に LLM 推論を含めず、`Indeterminate => Deny` を保証している。

## 5. v0.0.2 への移行: Vfs 命名規約の統一
v0.0.2 では、.NET Framework Design Guidelines に合わせて、3 文字以上の頭字語を単語として扱います。これにより、`VFS` は identifier 上では `Vfs` に統一されます。

この変更は、namespace、project/package 名、docs 上の公開表記に影響する破壊的変更です。

### 5.1 置換マッピング
| 旧表記 | 新表記 | 備考 |
|---|---|---|
| `AIKernel.VFS` | `AIKernel.Vfs` | Namespace / project / NuGet package 名を統一。 |
| `AIKernel.VFS.csproj` | `AIKernel.Vfs.csproj` | ProjectReference と solution entry を更新。 |
| `VFS` | `Vfs` | コード上の identifier と package/docs の正規表記。 |
| `ProviderID` | `ProviderId` | `Id` は 2 文字語として `Id` に統一。 |
| `IROMCanonicalizer` | `IRomCanonicalizer` | 3 文字 acronym を PascalCase の単語として扱う。 |

既存の `IVfsProvider`, `IVfsSession`, `VfsProviderHealth`, `VfsEntry` など、すでに `Vfs` 表記になっている型名はそのまま維持します。

### 5.2 移行手順
1. `using AIKernel.VFS;` を `using AIKernel.Vfs;` に変更します。
2. `.csproj` / `.slnx` の参照を `AIKernel.Vfs/AIKernel.Vfs.csproj` に変更します。
3. NuGet package 参照がある場合は、`AIKernel.VFS` から `AIKernel.Vfs` へ変更します。
4. README、設計ドキュメント、運用ドキュメントに残る `VFS` 表記を `Vfs` に統一します。
5. 移行例を除き、case-sensitive 検索で `VFS`, `AIKernel.VFS`, `ProviderID`, `IROMCanonicalizer` が残っていないことを確認します。

## 6. v0.0.2 への移行: Vfs Capability Contract
本節は Issue #4 `[RFC] Interface Segregation for VFS: Transitioning to Capability-Based Abstractions` に対応します。

v0.0.2 では、Vfs の権限を monolithic contract ではなく capability interface として表現します。

### 6.1 新規 capability interface
| Capability | 用途 |
|---|---|
| `IVfsEntryInfo` | Vfs entry に共通する識別情報と metadata。 |
| `IReadableVfsFile` | ファイル内容の読み取り。 |
| `IWritableVfsFile` | file-level mutation が成立する場合の書き込み。 |
| `INavigableVfsDirectory` | ディレクトリの列挙と階層移動。 |
| `IReadableVfsSession` | session 経由の読み取りと存在確認。 |
| `IWritableVfsSession` | session 経由の書き込み。 |
| `IDeletableVfsSession` | session 経由の削除。 |
| `INavigableVfsSession` | session 経由のディレクトリ取得。 |
| `IQueryableVfsSession` | provider 定義 query の実行。 |

### 6.2 互換 contract
既存の `IVfsFile`, `IVfsDirectory`, `IVfsSession` は互換合成 contract として残ります。

- `IVfsFile` は `IReadableVfsFile` を継承します。
- `IVfsDirectory` は `INavigableVfsDirectory` を継承し、従来の `IVfsFile` / `IVfsDirectory` 戻り値を維持します。
- `IVfsSession` は readable / writable / deletable / navigable / queryable / async-disposable capability を合成します。

このため、既存の `IVfsSession` 前提の実装はすぐに全置換する必要はありません。ただし、新規実装や標準 provider では、必要最小限の capability interface へ依存を縮小することを推奨します。

### 6.3 実装側の移行指針
- 読み取り専用 provider は `IReadableVfsSession` のみを実装し、`IWritableVfsSession` や `IDeletableVfsSession` を実装しません。
- 書き込み不能な provider に placeholder の `WriteFileAsync` を実装して `NotSupportedException` を投げる設計は避けます。
- 呼び出し側は操作前に必要な capability interface を確認し、不足している場合は副作用を開始する前に拒否します。

```csharp
if (session is not IWritableVfsSession writable)
{
    // Deny before side effects begin.
    return;
}

await writable.WriteFileAsync(path, content);
```

## 7. v0.0.2 への移行: Provider / Security Capability Contract
Issue #4 以降、capability-based contract は Vfs だけでなく、単一インターフェースが複数の権限面を抱えていた provider / security abstraction にも適用します。

### 7.1 Provider Lifecycle Contract
`IProvider` は互換合成 contract として残しつつ、provider identity、capability metadata、availability、lifecycle、health を個別に表現できるようにします。

| Capability | 用途 |
|---|---|
| `IProviderIdentity` | Provider Id、表示名、version。 |
| `IProviderCapabilitySource` | 静的または動的な provider capability metadata。 |
| `IProviderAvailabilityProbe` | 可用性確認。 |
| `IProviderLifecycle` | 初期化と終了処理。 |
| `IProviderHealthProbe` | health check の報告。 |

### 7.2 Provider Router Contract
`IProviderRouter` は互換合成 contract として残しつつ、retrieval、cache、registry の責務を分離します。

| Capability | 用途 |
|---|---|
| `IProviderMaterialRetriever` | 単一または複数 source から Material Context を取得。 |
| `IMaterialCacheReader` | cache から Material Context を読み取り。 |
| `IMaterialCacheWriter` | cache へ Material Context を書き込み。 |
| `IProviderRegistry` | provider の登録、解除、列挙。 |

読み取り専用 cache adapter は `IMaterialCacheReader` のみを実装し、cache write や provider registry capability を公開しません。

### 7.3 Tool Access Validation
`IToolAccessValidator` は互換合成 contract として残しつつ、権限チェックを capability interface に分割します。

| Capability | 用途 |
|---|---|
| `IToolExecutionAccessValidator` | ツール実行の検証。 |
| `IFileReadAccessValidator` | ファイル読み取りの検証。 |
| `IFileWriteAccessValidator` | ファイル書き込みの検証。 |
| `INetworkAccessValidator` | ネットワークアクセスの検証。 |
| `IEnvironmentAccessValidator` | 環境変数アクセスの検証。 |
| `ISystemCommandAccessValidator` | システムコマンド実行の検証。 |
| `IPermissionLifecycleValidator` | 権限の有効期限・ライフサイクル検証。 |
| `IPermissionConstraintValidator` | 実行時制約の検証。 |

呼び出し側は、対象操作に必要な最小の validator capability に依存します。必要な capability が存在しない場合は、実行開始前に deny として扱います。

### 7.4 Event Bus Contract
`IEventBus` は `IProvider`、event publishing、broadcast、subscription registry capability を合成する互換 contract として残ります。

| Capability | 用途 |
|---|---|
| `IEventPublisher` | event の publish。 |
| `IEventBroadcaster` | すべての subscriber への broadcast。 |
| `IEventSubscriptionRegistry` | subscribe、unsubscribe、subscriber count の確認。 |

購読専用 adapter は `IEventSubscriptionRegistry` のみを実装し、publish / broadcast capability を公開しません。

### 7.5 Task / Scheduler Contract
`ITaskManager` と `IScheduler` は互換合成 contract として残しつつ、実行、制御、結果参照、schedule 権限を分離します。

| Capability | 用途 |
|---|---|
| `IPipelineRegistrar` | pipeline の登録。 |
| `IPipelineExecutor` | 登録済み pipeline の実行。 |
| `ITaskExecutor` | 個別 task の実行。 |
| `IPipelineExecutionController` | pipeline execution の pause、resume、cancel。 |
| `IPipelineExecutionResultReader` | pipeline execution result の参照。 |
| `IScheduledJobReader` | scheduled job の参照と列挙。 |
| `IJobScheduler` | job の schedule。 |
| `IScheduledJobCanceller` | scheduled job の cancel。 |
| `IScheduledExecutionResultReader` | scheduled job execution result の参照。 |

観測専用 component は result-reader や job-reader capability に依存し、execution や cancellation 権限を受け取らないようにします。

### 7.6 Tokenizer Contract
`ITokenizer` は互換合成 contract として残しつつ、tokenization、counting、decoding、statistics、model support、NPU cardinality の責務を分離します。

| Capability | 用途 |
|---|---|
| `ITokenizerIdentity` | tokenizer profile Id と name。 |
| `ITextTokenizer` | text から token への変換。 |
| `ITokenCounter` | token materialization を公開しない token count。 |
| `ITokenDecoder` | token から text への decode。 |
| `ITokenizerStatisticsProvider` | tokenizer statistics の参照。 |
| `ITokenizerModelSupport` | model support の確認。 |
| `IPhysicalCardinalityAdvisor` | logical token count から physical cardinality への変換。 |
| `IPaddingInfoProvider` | padding information の参照。 |

Budget estimator は通常 `ITokenCounter` に依存し、hardware alignment が必要な場合のみ `IPhysicalCardinalityAdvisor` を併用します。

### 7.7 Signature Trust Store Contract
`ISignatureTrustStore` は互換合成 contract として残しつつ、trust resolution、revocation、expiry、chain verification、trusted-anchor lookup、health probing を分離します。

| Capability | 用途 |
|---|---|
| `ISignerTrustResolver` | signer trust score の解決。 |
| `IKeyRevocationChecker` | key revocation の確認。 |
| `IKeyExpiryReader` | key expiry の参照。 |
| `ICertificateChainVerifier` | certificate chain の検証。 |
| `ITrustedAnchorReader` | trusted anchor の参照。 |
| `ITrustStoreHealthProbe` | trust store 到達性の確認。 |

health check 専用の処理は `ITrustStoreHealthProbe` に依存し、trust resolution や revocation 権限を受け取らないようにします。

### 7.8 Kernel Facade Contract
`IKernel` は最上位 facade の互換合成 contract として残しつつ、execution、analysis、preprocessing、provider routing、governance access を個別に表現できるようにします。

| Capability | 用途 |
|---|---|
| `IKernelVersionProvider` | kernel version の参照。 |
| `IKernelContextExecutor` | unified context contract の実行。 |
| `IKernelAttentionAnalyzer` | orchestration attention pollution の解析。 |
| `IKernelMaterialPreprocessor` | Material Context の正規化・構造化。 |
| `IKernelExpressionPreparer` | Expression Context の準備。 |
| `IKernelProviderRouterAccessor` | Provider Router へのアクセス。 |
| `IKernelGuardAccessor` | Guard へのアクセス。 |
| `IKernelPdpAccessor` | PDP へのアクセス。 |

Application code は必要な kernel capability のみに依存します。`IKernel` は composition root や facade-level orchestration に限定して使います。

### 7.9 RAG Provider Contract
`IRagProvider` は `IProvider`、検索、index mutation capability を合成する互換 contract として残ります。

| Capability | 用途 |
|---|---|
| `IRagSearchProvider` | RAG material の検索。 |
| `IRagIndexWriter` | index document の追加・更新。 |
| `IRagIndexDeleter` | index document の削除。 |
| `IRagIndexManager` | clear など index 全体の管理操作。 |

読み取り専用 RAG provider は `IRagSearchProvider` のみを実装し、provider lifecycle metadata が必要な場合に `IProvider` を併用します。書き込み・削除・clear capability を実装して `NotSupportedException` を投げる設計は避けます。

## 8. v0.0.2 検証チェックリスト
- `using AIKernel.VFS;` が残っていない。
- ProjectReference / solution entry が `AIKernel.Vfs/AIKernel.Vfs.csproj` を参照している。
- 移行例を除き、公開 docs / README / csproj metadata に `VFS`, `ProviderID`, `IROMCanonicalizer` 表記が残っていない。
- 読み取り専用 Vfs 実装が mutation capability を公開していない。
- 未対応 capability が `NotSupportedException` ではなく、実行前の deny として扱われている。
- 読み取り専用 RAG provider が index mutation capability を公開せず、`IRagSearchProvider` に限定されている。
- Provider/router の依存先が、可能な限り identity、lifecycle、retrieval、cache、registry capability に縮小されている。
- Event の依存先が、可能な限り publisher、broadcaster、subscription registry capability に縮小されている。
- Task / scheduler の依存先が、可能な限り execution、control、result reader、job reader、scheduler、canceller capability に縮小されている。
- Tokenizer の依存先が、可能な限り counter、tokenizer、decoder、statistics、model support、cardinality、padding capability に縮小されている。
- Signature trust の依存先が、可能な限り trust resolver、revocation checker、expiry reader、chain verifier、anchor reader、health probe capability に縮小されている。
- Kernel の依存先が、可能な限り execution、analysis、preprocessing、provider-router access、guard access、PDP access capability に縮小されている。
- Tool access validation の依存先が、可能な限り必要最小の capability interface に縮小されている。

## 9. v0.0.2 への移行: Contract Purity
本節は Issue #8 `Contract Purity` に対応します。

Contract は immutable view / descriptor のみを表現します。mutation、validation、transformation、canonicalization、hashing、extraction、analysis の責務は、明示的な service interface へ移動します。

### 9.1 Contract object から削除された member
| Contract | 削除 member | 代替 service interface |
|---|---|---|
| `IMaterialContract` | `Normalize`, `Structurize`, `ExtractEssentialContent`, `ValidateQuarantine` | `IMaterialNormalizer`, `IMaterialStructurizer`, `IEssentialMaterialExtractor`, `IMaterialQuarantineValidator` |
| `IUnifiedContextContract` | `ValidateAll`, `ValidateLayerSeparation`, `DetectPollution`, `CalculateSignalToNoiseRatio` | `IUnifiedContextContractValidator`, `ILayerSeparationValidator`, `IAttentionPollutionDetector`, `ISignalToNoiseRatioCalculator` |
| `IOrchestrationContract` | `Validate`, `CalculateSignalToNoiseRatio` | `IOrchestrationContractValidator`, `ISignalToNoiseRatioCalculator` |
| `IExpressionContract` | `ValidateIsolation`, `CanApplyAfterInference` | `IExpressionIsolationValidator`, `IExpressionApplicationGate` |

### 9.2 新規 Material processing service
| Service | 用途 |
|---|---|
| `IMaterialNormalizer` | material を新しい `MaterialContextDto` として正規化。 |
| `IMaterialStructurizer` | contract を変更せず structured material data を生成。 |
| `IMaterialCanonicalizer` | canonical material text を生成。 |
| `IMaterialHashProvider` | material hash を計算。 |
| `IEssentialMaterialExtractor` | orchestration-safe な essential content を抽出。 |
| `IMaterialQuarantineValidator` | material quarantine state を検証。 |

Contract 実装は自分自身を変更しません。変換は新しい DTO/value または派生表現を返します。

## 10. v0.0.2 への移行: Capability-Driven Providers
本節は Issue #9 `Capability-Driven Providers` に対応します。

Provider contract は optional operation を明示的な capability interface として公開します。既存の広い interface は互換合成 contract として残ります。

### 10.1 Model Provider Capability
| Capability | 用途 |
|---|---|
| `ITextGenerationProvider` | `GenerateAsync` による text generation。 |
| `IStreamingGenerationProvider` | `StreamGenerateAsync` による streaming text generation。 |
| `IQuestionAnsweringProvider` | `AnswerAsync` による直接 question answering。 |
| `IModelProvider` | すべての model capability と `IProvider` を合成する互換 contract。 |

text-only provider は `ITextGenerationProvider` のみを実装し、streaming や question answering を実装しているように見せません。

### 10.2 Embedding Provider Capability
| Capability | 用途 |
|---|---|
| `ITextEmbeddingProvider` | 単一 text embedding。 |
| `IBatchEmbeddingProvider` | batch embedding。 |
| `IEmbeddingDimensionProvider` | embedding dimension metadata。 |
| `IEmbeddingProvider` | すべての embedding capability と `IProvider` を合成する互換 contract。 |

### 10.3 Provider Capability Metadata
| Capability | 用途 |
|---|---|
| `IProviderOperationCapabilities` | 静的な operation / data-type support。 |
| `IProviderConnectionCapabilities` | concurrency / rate-limit metadata。 |
| `IProviderCapacityVectorSource` | 静的 capacity vector。 |
| `IDynamicProviderCapacitySource` | constraint-dependent dynamic capacities。 |
| `IProviderProfileSource` | capability profile metadata。 |
| `IQuantizationSupport` | quantization support check。 |
| `IProviderCapabilities` | すべての provider capability metadata を合成する互換 contract。 |

Router は、実際に必要な capability interface によって provider を選択します。

## 11. v0.0.2 への移行: Security and Policy Separation
本節は Issue #10 `Security & Policy Separation` に対応します。

Security contract は、decision、enforcement、registry、validation、failure handling、audit category の責務を分離します。必要な権限が存在しない、または indeterminate の場合、呼び出し側境界で fail closed として扱います。

### 11.1 Guard Capability
| Capability | 用途 |
|---|---|
| `IGuardEvaluator` | execution / context-access check。 |
| `IResourceAccessGuard` | read/write resource check。 |
| `IGuardEnforcer` | guard decision を強制し fail-closed action を返す。 |
| `IGuardFailureHandler` | failure-mode handling と fail-closed action。 |
| `IGuard` | 互換合成 contract。 |

### 11.2 PDP Capability
| Capability | 用途 |
|---|---|
| `IPolicyDecisionPoint` | 決定論的 access decision evaluation。 |
| `IPolicyRegistry` | policy registry の add/remove operation。 |
| `IPolicySource` | registered policy の参照。 |
| `IPolicyDecisionEvaluator` | unified context に対する policy evaluation。 |
| `IPdp` | 互換合成 contract。 |

### 11.3 Rules Engine Capability
| Capability | 用途 |
|---|---|
| `IRuleRegistry` | prompt rule の register / read / delete / list。 |
| `IRuleEvaluator` | rule evaluation。 |
| `IPreExecutionRuleValidator` | pre-prompt context validation。 |
| `IPostExecutionRuleValidator` | post-prompt context validation。 |
| `IRulesEngine` | 互換合成 contract。 |

### 11.4 Audit Capability
| Capability | 用途 |
|---|---|
| `IAuditEventWriter` | generic audit event logging。 |
| `IExecutionAuditLogger` | execution event logging。 |
| `IGuardAuditLogger` | guard event logging。 |
| `IPipelineAuditLogger` | pipeline event logging。 |
| `IProviderAuditLogger` | provider event logging。 |
| `ITransferTraceLogger` | transfer trace logging。 |
| `IAuditLogger` | 互換合成 contract。 |

## 12. v0.0.2 への移行: Sandbox and Validator Isolation
本節は Issue #11 `Sandbox & Validator Isolation` に対応します。

Execution、file transfer、cleanup、observation、validation、store mutation、context-buffer access を capability interface として分離します。既存の広い interface は互換合成 contract として残ります。

### 12.1 Tool Sandbox Capability
| Capability | 用途 |
|---|---|
| `IToolSandboxIdentity` | sandbox identity。 |
| `IToolExecutor` | sandbox 内での tool execution。 |
| `IToolFileUploadSink` | sandbox への file upload。 |
| `IToolFileDownloadSource` | sandbox からの file download。 |
| `IToolSandboxCleanup` | sandbox state の cleanup。 |
| `IToolResourceUsageSource` | sandbox resource usage の参照。 |
| `IToolSandbox` | 互換合成 contract。 |

### 12.2 ROM Validator Capability
| Capability | 用途 |
|---|---|
| `IRomSchemaValidator` | ROM schema validation。 |
| `IRomLinkageValidator` | ROM linkage validation。 |
| `IRomTypeConsistencyValidator` | ROM type consistency validation。 |
| `IRomCircularReferenceValidator` | ROM circular reference detection。 |
| `IRomValidator` | 互換合成 contract。 |

### 12.3 Store / Collection / Compute Capability
| Capability | 用途 |
|---|---|
| `IConversationSnapshotWriter` | conversation snapshot の保存。 |
| `IConversationSnapshotReader` | conversation snapshot の参照。 |
| `IConversationBranchLister` | conversation branch の列挙。 |
| `IConversationSnapshotDeleter` | conversation snapshot の削除。 |
| `IContextFragmentCollection` | context fragment の参照。 |
| `IPhaseBufferCollection` | phase buffer の参照。 |
| `IComputeCardinalityAdvisor` | cardinality advice。 |
| `IComputePaddingAdvisor` | padding strategy / overhead advice。 |
| `IQuantizationAdvisor` | quantization advice。 |
| `IComputeShapeOptimizer` | constraint-based shape optimization。 |

Read-only store や schema-only validator は、実際にサポートする capability のみを実装します。

## 13. v0.0.2 から v0.0.3 への移行: 依存レイヤ修正
v0.0.3 では、Vfs contract 周辺の package 依存グラフを修正します。

> v0.0.4 では、この互換 facade は置き換え済みです。v0.0.4 以降へ直接移行する場合は、14.6 に従い、個別の `AIKernel.Vfs` package/project を削除してください。

主な変更は、Vfs interface contract の所有元が `AIKernel.Abstractions` になったことです。`AIKernel.Vfs` package は type forwarding による互換 facade として残りますが、contract 定義そのものの所有元ではなくなります。

### 13.1 目標レイヤ構造
Phase-1 の期待される依存方向は次の通りです。

```text
AIKernel.Enums -> (none)
AIKernel.Dtos -> AIKernel.Enums
AIKernel.Contracts -> AIKernel.Enums, AIKernel.Dtos
AIKernel.Abstractions -> AIKernel.Dtos, AIKernel.Enums
AIKernel.Vfs -> AIKernel.Abstractions
```

禁止される依存方向は次の通りです。

```text
AIKernel.Abstractions -> AIKernel.Vfs
AIKernel.Abstractions -> AIKernel.Core
AIKernel.Abstractions -> Providers
```

### 13.2 移動された Vfs Contract
以下の contract は `AIKernel.Vfs` project から `AIKernel.Abstractions` project へ移動しました。

| Contract | 新しい所有元 | 互換性 |
|---|---|---|
| `IVfsProvider` | `AIKernel.Abstractions` | `AIKernel.Vfs` が type-forwarding。 |
| `IVfsSession` | `AIKernel.Abstractions` | `AIKernel.Vfs` が type-forwarding。 |
| `IReadableVfsSession` | `AIKernel.Abstractions` | `AIKernel.Vfs` が type-forwarding。 |
| `IWritableVfsSession` | `AIKernel.Abstractions` | `AIKernel.Vfs` が type-forwarding。 |
| `IDeletableVfsSession` | `AIKernel.Abstractions` | `AIKernel.Vfs` が type-forwarding。 |
| `INavigableVfsSession` | `AIKernel.Abstractions` | `AIKernel.Vfs` が type-forwarding。 |
| `IQueryableVfsSession` | `AIKernel.Abstractions` | `AIKernel.Vfs` が type-forwarding。 |
| `IVfsCredentials` | `AIKernel.Abstractions` | `AIKernel.Vfs` が type-forwarding。 |
| `IVfsFile`, `IVfsDirectory` | `AIKernel.Abstractions` | `AIKernel.Vfs` が type-forwarding。 |
| `IReadableVfsFile`, `IWritableVfsFile` | `AIKernel.Abstractions` | `AIKernel.Vfs` が type-forwarding。 |
| `INavigableVfsDirectory` | `AIKernel.Abstractions` | `AIKernel.Vfs` が type-forwarding。 |
| `IVfsEntryInfo` | `AIKernel.Abstractions` | `AIKernel.Vfs` が type-forwarding。 |
| `IVfsQuery`, `IVfsQueryResult` | `AIKernel.Abstractions` | `AIKernel.Vfs` が type-forwarding。 |
| `VfsAuthenticationFailedException` | `AIKernel.Abstractions` | `AIKernel.Vfs` が type-forwarding。 |

公開 namespace は互換性のため `AIKernel.Vfs` のままです。変更されたのは assembly/package レイヤでの所有関係です。

### 13.3 ProjectReference の更新
ProjectReference は次のように更新します。

```diff
AIKernel.Abstractions.csproj
- <ProjectReference Include="..\AIKernel.Vfs\AIKernel.Vfs.csproj" />

AIKernel.Vfs.csproj
- <ProjectReference Include="..\AIKernel.Dtos\AIKernel.Dtos.csproj" />
+ <ProjectReference Include="..\AIKernel.Abstractions\AIKernel.Abstractions.csproj" />
```

Vfs contract だけを利用する application project は、`AIKernel.Abstractions` を直接参照できます。互換 facade が必要な project は、引き続き `AIKernel.Vfs` を参照できます。

### 13.4 NuGet Package の更新
package reference を更新する場合は、次のように揃えます。

```xml
<PackageReference Include="AIKernel.Abstractions" Version="0.0.3" />
<PackageReference Include="AIKernel.Vfs" Version="0.0.3" />
```

`AIKernel.Abstractions` `0.0.3` と `AIKernel.Vfs` `0.0.2` を混在させないでください。互換 facade は、Vfs contract 型が `0.0.3` の Abstractions assembly から提供されることを前提にします。

### 13.5 Source Migration 手順
1. 互換 facade を意図的に外す場合を除き、既存の `using AIKernel.Vfs;` は維持します。
2. `AIKernel.Abstractions -> AIKernel.Vfs` の直接 ProjectReference を削除します。
3. contract のみを定義する library は、`AIKernel.Vfs` ではなく `AIKernel.Abstractions` への依存を優先します。
4. runtime/provider package が Vfs contract を実装し、既存コードとの互換性も必要とする場合は、package 境界に応じて `AIKernel.Vfs` または `AIKernel.Abstractions` を参照します。
5. type-forwarding metadata が一貫して出力されるよう、すべての package を再ビルドします。

### 13.6 検証コマンド
次を実行します。

```powershell
dotnet build src\AIKernel.NET.slnx
dotnet test src\tests\AIKernel.Abstractions.Tests\AIKernel.Abstractions.Tests.csproj --no-build
```

ProjectReference graph が次の形であることを確認します。

```text
AIKernel.Abstractions -> AIKernel.Dtos, AIKernel.Enums
AIKernel.Vfs -> AIKernel.Abstractions
CYCLE CHECK: OK (no ProjectReference cycles)
```

加えて、`AIKernel.Abstractions.csproj` に `AIKernel.Vfs` への参照が残っていないことを確認します。

## 14. v0.0.3 から v0.0.4 への移行: DSL / History ROM Contract 抽出
v0.0.4 では、`AIKernel.Core` 内で先行して増えていた公開境界候補を `AIKernel.NET` の contract package に昇格します。これにより、外部 Capability module、Server host、WASM client、今後の Core package が同じ interface surface を共有できます。

このリリースでは、`AIKernel.Abstractions` が `AIKernel.Core` や `AIKernel.Common` に依存しない構造を維持します。Core 実装で `Result<T>` や `ResultStep<TState,TValue>` を使っている場合は、以下の DTO contract surface へ adapter 変換してください。

### 14.1 新しい DTO 領域
| 領域 | 追加 DTO |
|---|---|
| `AIKernel.Dtos.Time` | `KernelTimestamp` |
| `AIKernel.Dtos.Dsl` | `DslDocument`, `PipelineNode`, `PipelineRootNode`, `StepNode`, `CallCapabilityNode`, `LoopNode`, `LoopUntilNode`, `SuspendNode`, `DslPipelineValue`, `DslPipelineState`, `DslPipelineExecutionContext`, `DslPipelineExecutionResult`, `DslRomMetadata`, `DslRomSnapshot` |
| `AIKernel.Dtos.History` | `ChatHistoryRomRecord`, `ChatHistoryRomOptions`, `HistoryRomMetadata`, `HistoryRomSnapshot` |

### 14.2 新しい Abstraction 領域
| 領域 | 追加 contract |
|---|---|
| `AIKernel.Abstractions.Time` | `IKernelClock` |
| `AIKernel.Abstractions.Dsl` | `IKernelPipeline`, `IDslPipelineCompiler`, `IDslCapabilityRegistry`, `IDslRomRegistry`, `IDslRomStore` |
| `AIKernel.Abstractions.History` | `IChatHistoryRomExporter`, `IHistoryRomRegistry`, `IHistoryRomStore` |

### 14.3 Core Adapter 向け破壊的移行ポイント
Core 側実装は、下流 consumer に Core 専用の DSL、History ROM、clock contract 参照を要求しない形へ移行してください。

推奨置換は次の通りです。

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

### 14.4 曖昧な Interface 名の変更
v0.0.4 では、共有 package surface として広すぎた public interface 名を整理します。

| 削除 / 改名された contract | 置換先 |
|---|---|
| `AIKernel.Abstractions.Kernel.IKernelExecutor` | `AIKernel.Abstractions.Kernel.IKernelContextExecutor` |
| `AIKernel.Abstractions.Governance.ChatChain.IResult` | `AIKernel.Abstractions.Governance.ChatChain.IChatTurnVerificationResult` |
| `AIKernel.Abstractions.Governance.ChatChain.ISemanticHasher` | `AIKernel.Abstractions.Governance.ChatChain.IChatTurnSemanticHasher` |
| `AIKernel.Abstractions.Scheduling.IExecutionResult` | `AIKernel.Abstractions.Scheduling.IScheduledExecutionResult` |

`AIKernel.Abstractions.Execution.IKernelExecutor` と `AIKernel.Abstractions.Rom.ISemanticHasher` は変更しません。改名対象は、facade / chat-chain / scheduling 専用でありながら、実行境界や ROM 概念と名前衝突していた contract です。

Core 実装が内部で `AIKernel.Common.Results.Result<T>` を使い続ける場合、package 境界では次のいずれかへ変換してください。

- 成功時は DTO 戻り値
- 失敗時は host が採用する fail-closed exception / result adapter

`AIKernel.Common` が安定 package として公開されるまで、`AIKernel.NET` の contract package は `Result<T>` を公開しません。

### 14.5 NuGet Package 更新
package set は必ず揃えてください。

```xml
<PackageReference Include="AIKernel.Abstractions" Version="0.0.4" />
<PackageReference Include="AIKernel.Dtos" Version="0.0.4" />
<PackageReference Include="AIKernel.Enums" Version="0.0.4" />
```

`AIKernel.Abstractions` `0.0.4` と `AIKernel.Dtos` `0.0.3` を混在させないでください。DSL、History ROM、time contract は v0.0.4 の DTO surface を前提にします。

### 14.6 AIKernel.Vfs package の削除
v0.0.4 では、個別の `AIKernel.Vfs` 互換 package/project を削除します。
Vfs contract は引き続き `AIKernel.Abstractions` から利用でき、公開 namespace は `AIKernel.Vfs` のままです。

移行手順:

1. application、provider、test project から `PackageReference Include="AIKernel.Vfs"` を削除します。
2. Vfs contract を利用する project では `PackageReference Include="AIKernel.Abstractions" Version="0.0.4"` を追加または維持します。
3. `using AIKernel.Vfs;` は維持して構いません。namespace は引き続き正しいです。
4. local source build では `AIKernel.Vfs/AIKernel.Vfs.csproj` への project reference を削除します。

### 14.7 検証コマンド
次を実行します。

```powershell
dotnet build src\AIKernel.NET.slnx
dotnet test src\tests\AIKernel.Abstractions.Tests\AIKernel.Abstractions.Tests.csproj --no-build
dotnet pack src\AIKernel.NET.slnx --no-build
```

ProjectReference graph が次のままであることを確認します。

```text
AIKernel.Enums -> (none)
AIKernel.Dtos -> AIKernel.Enums
AIKernel.Contracts -> AIKernel.Enums, AIKernel.Dtos
AIKernel.Abstractions -> AIKernel.Dtos, AIKernel.Enums
CYCLE CHECK: OK
```
---

# 変更履歴
- v0.0.0 / v0.0.0.0: 初期ドラフト
- v0.0.1 (2026-05-06): ドキュメント規約に基づくバージョン更新
- v0.0.2 (2026-05-09): Issue #4 の Vfs capability contract 移行手順、Issue #7 の Vfs 命名規約統一、provider/security capability contract 指針、Issue #8 の contract purity 移行、Issue #9 の provider capability 移行、Issue #10 の security/policy separation 移行、Issue #11 の sandbox/validator isolation 移行を追加
- v0.0.3 (2026-06-02): Vfs contract 所有元の Abstractions への移動、`AIKernel.Vfs` type-forwarding 互換、package reference 指針、循環依存検証手順を追加
- v0.0.4 (2026-06-04): AIKernel.Core adapter 移行に向け、DSL pipeline、DSL ROM、History ROM、Kernel clock contract 抽出、ROM store contract、曖昧な interface 改名ガイド、AIKernel.Vfs package 削除手順を追加
