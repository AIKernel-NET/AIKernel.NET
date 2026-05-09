---
title: "移行ガイド（Migration Guide）"
status: "Planned"
version: 0.0.2
updated: 2026-05-09
---

# 移行ガイド（Migration Guide）

本ガイドは、初期コンセプト版（v0.0.0）から、正典化されたアーキテクチャ（v0.0.1）、および v0.0.2 の命名規約・Vfs capability contract へ移行するための手順を定義します。

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

### 7.4 RAG Provider Contract
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
- Tool access validation の依存先が、可能な限り必要最小の capability interface に縮小されている。
---

# 変更履歴
- v0.0.0 / v0.0.0.0: 初期ドラフト
- v0.0.1 (2026-05-06): ドキュメント規約に基づくバージョン更新
- v0.0.2 (2026-05-09): Issue #4 の Vfs capability contract 移行手順、Issue #7 の Vfs 命名規約統一、provider/security capability contract 指針を追加
