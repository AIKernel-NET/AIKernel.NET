namespace AIKernel.Dtos.Providers;

/// <summary>[EN] Provider category. [JA] Provider の種別。</summary>
public enum ProviderKind
{
    /// <summary>[EN] Embedding models. [JA] 埋め込みモデル。</summary>
    Embedding,
    /// <summary>[EN] Reranking models. [JA] 再順位付けモデル。</summary>
    Reranker,
    /// <summary>[EN] Speech recognition models. [JA] 音声認識モデル。</summary>
    SpeechRecognition,
    /// <summary>[EN] Classification models (reserved). [JA] 分類モデル（予約）。</summary>
    Classification,
    /// <summary>[EN] Scoring models (reserved). [JA] スコアリングモデル（予約）。</summary>
    Scoring,
    /// <summary>[EN] Chat generation. [JA] チャット生成。</summary>
    ChatGeneration = 5
}

/// <summary>[EN] Input or output modality. [JA] 入出力のモダリティ。</summary>
public enum ProviderModality
{
    /// <summary>[EN] Text. [JA] テキスト。</summary>
    Text,
    /// <summary>[EN] Still image. [JA] 静止画。</summary>
    Image,
    /// <summary>[EN] Audio. [JA] 音声。</summary>
    Audio
}

/// <summary>[EN] Execution backend. [JA] 実行バックエンド。</summary>
public enum ExecutionTarget
{
    /// <summary>[EN] CPU. [JA] CPU。</summary>
    Cpu,
    /// <summary>[EN] CUDA GPU. [JA] CUDA GPU。</summary>
    Cuda,
    /// <summary>[EN] Vulkan compute. [JA] Vulkan コンピュート。</summary>
    Vulkan = 2
}

/// <summary>[EN] Supported request forms. [JA] 対応する呼び出し形態。</summary>
[Flags]
public enum ExecutionMode
{
    /// <summary>[EN] No supported mode. [JA] 対応モードなし。</summary>
    None = 0,
    /// <summary>[EN] One input at a time. [JA] 1件ずつ処理。</summary>
    Single = 1,
    /// <summary>[EN] Multiple inputs per request. [JA] 複数件を一括処理。</summary>
    Batch = 2,
    /// <summary>[EN] Incremental input or output. [JA] 逐次入力または出力。</summary>
    Streaming = 4
}

/// <summary>[EN] Capabilities advertised by a provider. [JA] Provider が申告する機能。</summary>
public sealed record ProviderCapabilityDescriptor
{
    /// <summary>[EN] Descriptor schema version. [JA] 記述子のスキーマ版。</summary>
    public required int SchemaVersion { get; init; }
    /// <summary>[EN] Stable provider ID. [JA] 固定の Provider ID。</summary>
    public required string ProviderId { get; init; }
    /// <summary>[EN] Provider category. [JA] Provider の種別。</summary>
    public required ProviderKind Kind { get; init; }
    /// <summary>[EN] Registered model IDs. [JA] 登録済みモデルの ID。</summary>
    public IReadOnlyList<string> ModelIds { get; init; } = [];
    /// <summary>[EN] Accepted input modalities. [JA] 受け付ける入力モダリティ。</summary>
    public required IReadOnlyList<ProviderModality> InputModalities { get; init; }
    /// <summary>[EN] Supported execution backends. [JA] 対応バックエンド。</summary>
    public required IReadOnlyList<ExecutionTarget> ExecutionTargets { get; init; }
    /// <summary>[EN] Supported execution modes. [JA] 対応する呼び出し形態。</summary>
    public required ExecutionMode Modes { get; init; }
    /// <summary>[EN] Supported precision names. [JA] 対応する演算精度名。</summary>
    public IReadOnlyList<string> Precisions { get; init; } = [];
    /// <summary>[EN] Minimum logical working set. [JA] 最低限必要な論理作業領域。</summary>
    public required ProviderMemoryRequirement Memory { get; init; }
    /// <summary>[EN] Advertised input limits. [JA] 申告された入力上限。</summary>
    public ProviderInputLimits Limits { get; init; } = new();
    /// <summary>[EN] Kind-specific capabilities. [JA] 種別固有の機能。</summary>
    public ProviderCapabilityExtension? Extension { get; init; }
    /// <summary>[EN] Deterministic public metadata. Supply neither credentials nor paths. [JA] 決定的な公開メタデータ。資格情報とパスは格納しません。</summary>
    public IReadOnlyDictionary<string, string> Metadata { get; init; } =
        new System.Collections.ObjectModel.ReadOnlyDictionary<string, string>(
            new Dictionary<string, string>(StringComparer.Ordinal));
}

/// <summary>[EN] Kind-specific capabilities and their placement names. [JA] 種別固有の機能と配置判定用の名前。</summary>
public abstract record ProviderCapabilityExtension
{
    /// <summary>[EN] Kind this extension belongs to. [JA] この拡張が対応する種別。</summary>
    public abstract ProviderKind Kind { get; }
    /// <summary>[EN] Named features used during placement. [JA] 配置判断に使う機能名。</summary>
    public virtual IReadOnlyList<string> Features => [];
}

/// <summary>[EN] Logical working set across memory tiers. [JA] メモリ階層全体で必要な論理作業領域。</summary>
public sealed record ProviderMemoryRequirement
{
    /// <summary>[EN] Required logical bytes. [JA] 必要な論理バイト数。</summary>
    public required long WorkingSetBytes { get; init; }
    /// <summary>[EN] Use measured or estimated. [JA] 実測の measured または見積もりの estimated。</summary>
    public required string Basis { get; init; }
}

/// <summary>[EN] Provider-declared input limits. [JA] Provider が申告する入力上限。</summary>
public sealed record ProviderInputLimits
{
    /// <summary>[EN] Optional maximum items per request. [JA] 1リクエストあたりの最大件数。</summary>
    public int? MaxItemsPerRequest { get; init; }
    /// <summary>[EN] Optional maximum length per item. [JA] 1件あたりの最大長。</summary>
    public long? MaxItemLength { get; init; }
    /// <summary>[EN] Unit of the item length limit. [JA] 最大長の単位。</summary>
    public string? MaxItemLengthUnit { get; init; }
    /// <summary>[EN] Optional byte limit per request. [JA] 1リクエストあたりの最大バイト数。</summary>
    public long? MaxRequestBytes { get; init; }
}
