namespace AIKernel.Enums;

/// <summary>
/// Describes coarse-grained provider capabilities for discovery and routing.
/// </summary>
[Flags]
public enum ProviderCapabilityFlags
{
    /// <summary>No capability is declared.</summary>
    None = 0,

    /// <summary>Runtime lifecycle capability.</summary>
    RuntimeLifecycle = 1 << 0,

    /// <summary>Runtime status capability.</summary>
    RuntimeStatus = 1 << 1,

    /// <summary>Runtime asset resolution capability.</summary>
    RuntimeAssetResolution = 1 << 2,

    /// <summary>Memory-backed asset mount capability.</summary>
    MemoryAssetMount = 1 << 3,

    /// <summary>Frame source capability.</summary>
    FrameSource = 1 << 4,

    /// <summary>Frame surface binding capability.</summary>
    FrameSurface = 1 << 5,

    /// <summary>Frame perception capability.</summary>
    FramePerception = 1 << 6,

    /// <summary>Observation capability.</summary>
    Observation = 1 << 7,

    /// <summary>Phase routing capability.</summary>
    PhaseRouting = 1 << 8,

    /// <summary>Action proposal capability.</summary>
    ActionProposal = 1 << 9,

    /// <summary>Action arbitration capability.</summary>
    ActionArbitration = 1 << 10,

    /// <summary>Virtual input capability.</summary>
    VirtualInput = 1 << 11,

    /// <summary>Telemetry capability.</summary>
    Telemetry = 1 << 12,

    /// <summary>Evidence capture capability.</summary>
    EvidenceCapture = 1 << 13,

    /// <summary>Replay evidence capability.</summary>
    ReplayEvidence = 1 << 14,

    /// <summary>Contract validation capability.</summary>
    ContractValidation = 1 << 15,

    /// <summary>Signature capability.</summary>
    Signature = 1 << 16,

    /// <summary>Contract migration capability.</summary>
    Migration = 1 << 17
}
