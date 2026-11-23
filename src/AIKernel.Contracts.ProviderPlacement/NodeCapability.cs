namespace AIKernel.Dtos.Providers;

/// <summary>[EN] A node capability and load observation. [JA] ノードの能力と負荷の観測。</summary>
public sealed record NodeCapabilityDescriptor
{
    /// <summary>[EN] Descriptor schema version. [JA] 記述子のスキーマ版。</summary>
    public required int SchemaVersion { get; init; }
    /// <summary>[EN] Stable node ID. [JA] 固定のノード ID。</summary>
    public required string NodeId { get; init; }
    /// <summary>[EN] CPU information. [JA] CPU の情報。</summary>
    public required NodeCpuInfo Cpu { get; init; }
    /// <summary>[EN] Physical and allocatable RAM. [JA] 物理 RAM 容量と割り当て可能量。</summary>
    public required NodeMemoryInfo Memory { get; init; }
    /// <summary>[EN] Observed GPU devices. [JA] 観測された GPU。</summary>
    public IReadOnlyList<NodeGpuInfo> Gpus { get; init; } = [];
    /// <summary>[EN] Available tiers of AIKernel memory. [JA] 利用できる AIKernel メモリの階層。</summary>
    public required IReadOnlyList<NodeMemoryTierInfo> MemoryTiers { get; init; }
    /// <summary>[EN] Observed job load. [JA] 現在のジョブ負荷。</summary>
    public required NodeLoadInfo Load { get; init; }
    /// <summary>[EN] UTC observation time. [JA] UTC の観測時刻。</summary>
    public required DateTimeOffset ObservedAtUtc { get; init; }
}

/// <summary>[EN] Process architecture and usable instruction extensions. [JA] プロセスのアーキテクチャと利用可能な命令拡張。</summary>
public sealed record NodeCpuInfo
{
    /// <summary>[EN] Process architecture. [JA] プロセスのアーキテクチャ。</summary>
    public required string Architecture { get; init; }
    /// <summary>[EN] Usable ISA extension names. [JA] 利用可能な ISA 拡張名。</summary>
    public IReadOnlyList<string> IsaExtensions { get; init; } = [];
    /// <summary>[EN] Logical cores available to the process. [JA] プロセスが利用可能な論理コア数。</summary>
    public required int LogicalCores { get; init; }
}

/// <summary>[EN] Installed and available RAM in bytes. [JA] RAM の容量と利用可能量（バイト）。</summary>
public sealed record NodeMemoryInfo
{
    /// <summary>[EN] RAM capacity in bytes. [JA] RAM 容量（バイト）。</summary>
    public required long RamTotalBytes { get; init; }
    /// <summary>[EN] Allocatable RAM in bytes. [JA] 割り当て可能な RAM（バイト）。</summary>
    public required long RamAvailableBytes { get; init; }
}

/// <summary>[EN] Internal GPU capability and capacity observation. [JA] 内部で使う GPU の能力と容量の観測。</summary>
public sealed record NodeGpuInfo
{
    /// <summary>[EN] Stable internal device ID. [JA] 内部向けの固定デバイス ID。</summary>
    public required string DeviceId { get; init; }
    /// <summary>[EN] Device name. [JA] デバイス名。</summary>
    public required string Name { get; init; }
    /// <summary>[EN] VRAM capacity. [JA] VRAM 容量。</summary>
    public required long VramTotalBytes { get; init; }
    /// <summary>[EN] Available VRAM. [JA] 利用可能な VRAM。</summary>
    public required long VramAvailableBytes { get; init; }
    /// <summary>[EN] CUDA compute capability, if supported. [JA] 対応時の CUDA コンピュート機能。</summary>
    public string? CudaComputeCapability { get; init; }
}

/// <summary>[EN] AIKernel memory tier and allocatable bytes. [JA] AIKernel のメモリ階層と割り当て可能量。</summary>
public sealed record NodeMemoryTierInfo
{
    /// <summary>[EN] AIKernel memory tier name. [JA] AIKernel のメモリ階層名。</summary>
    public required string Tier { get; init; }
    /// <summary>[EN] Optional physical storage medium. [JA] 物理媒体の種別。</summary>
    public string? Medium { get; init; }
    /// <summary>[EN] Known capacity in bytes. [JA] 既知の場合の容量（バイト）。</summary>
    public long? CapacityBytes { get; init; }
    /// <summary>[EN] Known available bytes. [JA] 既知の場合の利用可能量（バイト）。</summary>
    public long? AvailableBytes { get; init; }
}

/// <summary>[EN] Running and queued provider jobs. [JA] 実行中および待機中の Provider ジョブ。</summary>
public sealed record NodeLoadInfo
{
    /// <summary>[EN] Running jobs. [JA] 実行中のジョブ数。</summary>
    public required int ActiveJobs { get; init; }
    /// <summary>[EN] Waiting jobs. [JA] 待機中のジョブ数。</summary>
    public required int QueuedJobs { get; init; }
}

/// <summary>[EN] Registry view captured independently on a node. [JA] ノードの能力とは独立した登録状態の観測。</summary>
public sealed record NodeProviderRegistrationSnapshot
{
    /// <summary>[EN] UTC observation time. [JA] UTC の観測時刻。</summary>
    public required DateTimeOffset ObservedAtUtc { get; init; }
    /// <summary>[EN] Providers registered at observation time. [JA] 観測時点で登録済みの Provider。</summary>
    public required IReadOnlyList<RegisteredProvider> Providers { get; init; }
}

/// <summary>[EN] Registered provider and currently resident model IDs. [JA] 登録 Provider と常駐済みモデル ID。</summary>
public sealed record RegisteredProvider
{
    /// <summary>[EN] Registered provider capabilities. [JA] 登録された Provider の機能。</summary>
    public required ProviderCapabilityDescriptor Descriptor { get; init; }
    /// <summary>[EN] IDs of models already loaded on this node. [JA] このノードに常駐済みのモデル ID。</summary>
    public IReadOnlyList<string> ResidentModelIds { get; init; } = [];
}
