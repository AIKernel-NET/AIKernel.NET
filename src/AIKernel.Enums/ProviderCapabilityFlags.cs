namespace AIKernel.Enums;

/// <summary>
/// Describes coarse-grained provider capabilities for discovery and routing.
/// JA: ProviderCapabilityFlags の公開契約を定義します。
/// </summary>
[Flags]
public enum ProviderCapabilityFlags
{
    /// <summary>No capability is declared. JA: None 値を表します。</summary>
    None = 0,

    /// <summary>Runtime lifecycle capability. JA: RuntimeLifecycle 値を表します。</summary>
    RuntimeLifecycle = 1 << 0,

    /// <summary>Runtime status capability. JA: RuntimeStatus 値を表します。</summary>
    RuntimeStatus = 1 << 1,

    /// <summary>Runtime asset resolution capability. JA: RuntimeAssetResolution 値を表します。</summary>
    RuntimeAssetResolution = 1 << 2,

    /// <summary>Memory-backed asset mount capability. JA: MemoryAssetMount 値を表します。</summary>
    MemoryAssetMount = 1 << 3,

    /// <summary>Frame source capability. JA: FrameSource 値を表します。</summary>
    FrameSource = 1 << 4,

    /// <summary>Frame surface binding capability. JA: FrameSurface 値を表します。</summary>
    FrameSurface = 1 << 5,

    /// <summary>Frame perception capability. JA: FramePerception 値を表します。</summary>
    FramePerception = 1 << 6,

    /// <summary>Observation capability. JA: Observation 値を表します。</summary>
    Observation = 1 << 7,

    /// <summary>Phase routing capability. JA: PhaseRouting 値を表します。</summary>
    PhaseRouting = 1 << 8,

    /// <summary>Action proposal capability. JA: ActionProposal 値を表します。</summary>
    ActionProposal = 1 << 9,

    /// <summary>Action arbitration capability. JA: ActionArbitration 値を表します。</summary>
    ActionArbitration = 1 << 10,

    /// <summary>Virtual input capability. JA: VirtualInput 値を表します。</summary>
    VirtualInput = 1 << 11,

    /// <summary>Telemetry capability. JA: Telemetry 値を表します。</summary>
    Telemetry = 1 << 12,

    /// <summary>Evidence capture capability. JA: EvidenceCapture 値を表します。</summary>
    EvidenceCapture = 1 << 13,

    /// <summary>Replay evidence capability. JA: ReplayEvidence 値を表します。</summary>
    ReplayEvidence = 1 << 14,

    /// <summary>Contract validation capability. JA: ContractValidation 値を表します。</summary>
    ContractValidation = 1 << 15,

    /// <summary>Signature capability. JA: Signature 値を表します。</summary>
    Signature = 1 << 16,

    /// <summary>Contract migration capability. JA: Migration 値を表します。</summary>
    Migration = 1 << 17
}
