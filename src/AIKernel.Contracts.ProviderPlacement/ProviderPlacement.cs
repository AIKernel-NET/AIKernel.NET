namespace AIKernel.Dtos.Providers;

/// <summary>[EN] A single placement request. [JA] 1回の配置判断への要求。</summary>
public sealed record ProviderRequirements
{
    /// <summary>[EN] Requested provider ID. [JA] 要求する Provider ID。</summary>
    public required string ProviderId { get; init; }
    /// <summary>[EN] Requested model ID. [JA] 要求するモデル ID。</summary>
    public required string ModelId { get; init; }
    /// <summary>[EN] Required input modalities. [JA] 必須の入力モダリティ。</summary>
    public required IReadOnlyList<ProviderModality> RequiredModalities { get; init; }
    /// <summary>[EN] Required execution modes. [JA] 必須の呼び出し形態。</summary>
    public required ExecutionMode RequiredMode { get; init; }
    /// <summary>[EN] Required named capabilities. [JA] 必須の機能名。</summary>
    public IReadOnlyList<string> RequiredFeatures { get; init; } = [];
    /// <summary>[EN] Optional requested precision. [JA] 演算精度の指定。</summary>
    public string? Precision { get; init; }
    /// <summary>[EN] Required logical working-set bytes. [JA] 必要な論理作業領域（バイト）。</summary>
    public required long WorkingSetBytes { get; init; }
    /// <summary>[EN] Required CPU instruction extensions. [JA] 必須の CPU 命令拡張。</summary>
    public IReadOnlyList<string> RequiredIsaExtensions { get; init; } = [];
}

/// <summary>[EN] Internal execution placement. [JA] Kernel 内部向けの実行先。</summary>
public sealed record PlacementCandidate
{
    /// <summary>[EN] Affected node ID. [JA] 対象ノードの ID。</summary>
    public required string NodeId { get; init; }
    /// <summary>[EN] Selected backend. [JA] 実行バックエンド。</summary>
    public required ExecutionTarget Target { get; init; }
    /// <summary>[EN] Internal CUDA device ID. [JA] 内部向け CUDA デバイス ID。</summary>
    public string? GpuDeviceId { get; init; }
}

/// <summary>[EN] An exclusion with a stable reason code. [JA] 固定理由コードを伴う配置除外。</summary>
public sealed record PlacementExclusion
{
    /// <summary>[EN] Affected node ID. [JA] 対象ノードの ID。</summary>
    public required string NodeId { get; init; }
    /// <summary>[EN] Stable exclusion code. [JA] 固定の除外理由コード。</summary>
    public required string ReasonCode { get; init; }
    /// <summary>[EN] Safe diagnostic message. [JA] 公開可能な診断メッセージ。</summary>
    public required string Message { get; init; }
}

/// <summary>[EN] Selected placement, ranked candidates, and exclusions. [JA] 選択結果と順位付き候補、除外理由。</summary>
public sealed record PlacementDecision
{
    /// <summary>[EN] First eligible candidate or null. [JA] 最上位の候補。候補なしの場合は null。</summary>
    public PlacementCandidate? Selected { get; init; }
    /// <summary>[EN] Eligible candidates in priority order. [JA] 優先順位順の候補。</summary>
    public required IReadOnlyList<PlacementCandidate> Candidates { get; init; }
    /// <summary>[EN] Excluded nodes and reasons. [JA] 除外したノードと理由。</summary>
    public required IReadOnlyList<PlacementExclusion> Exclusions { get; init; }
}
