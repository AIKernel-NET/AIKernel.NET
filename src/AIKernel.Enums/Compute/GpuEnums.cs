namespace AIKernel.Enums;

/// <summary>
/// [EN] Canonical GPU backend identity used by AIKernel v0.1.3 GPU providers.
/// [JA] AIKernel v0.1.3 GPU Provider が使用する canonical GPU backend 識別子です。
/// </summary>
public enum GpuBackend
{
    /// <summary>[EN] Unknown or not reported. [JA] 不明または未報告です。</summary>
    Unknown = 0,

    /// <summary>[EN] Deterministic CPU fallback path. [JA] deterministic CPU fallback path です。</summary>
    CpuFallback = 1,

    /// <summary>[EN] Browser WebGPU backend. [JA] Browser WebGPU backend です。</summary>
    WebGpu = 2,

    /// <summary>[EN] Native WebGPU backed by Dawn. [JA] Dawn による Native WebGPU backend です。</summary>
    Dawn = 3,

    /// <summary>[EN] NVIDIA CUDA backend. [JA] NVIDIA CUDA backend です。</summary>
    Cuda = 4,

    /// <summary>[EN] Vulkan backend. [JA] Vulkan backend です。</summary>
    Vulkan = 5,

    /// <summary>[EN] Direct3D 12 backend. [JA] Direct3D 12 backend です。</summary>
    Direct3D12 = 6,

    /// <summary>[EN] Metal backend. [JA] Metal backend です。</summary>
    Metal = 7
}

/// <summary>
/// [EN] Canonical GPU capability flags introduced for AIKernel v0.1.3.
/// [JA] AIKernel v0.1.3 で導入する canonical GPU capability flag です。
/// </summary>
[Flags]
public enum GpuProviderCapabilities
{
    /// <summary>[EN] No GPU capability is available. [JA] GPU capability が利用できません。</summary>
    None = 0,

    /// <summary>[EN] Provider can run compute dispatches. [JA] Provider は compute dispatch を実行できます。</summary>
    SupportsCompute = 1 << 0,

    /// <summary>[EN] Provider can composite HUD panels on GPU. [JA] Provider は GPU 上で HUD panel を合成できます。</summary>
    SupportsHudComposite = 1 << 1,

    /// <summary>[EN] Provider can run GPU Aisthesis feature extraction. [JA] Provider は GPU Aisthesis feature extraction を実行できます。</summary>
    SupportsAisthesis = 1 << 2,

    /// <summary>[EN] Provider can run spatial reasoning matrices on GPU. [JA] Provider は spatial reasoning matrix を GPU 上で処理できます。</summary>
    SupportsSpatialReasoning = 1 << 3,

    /// <summary>[EN] Provider can consume raw frame textures without CPU readback. [JA] Provider は CPU readback なしで raw frame texture を消費できます。</summary>
    SupportsZeroCopyRawTexture = 1 << 4,

    /// <summary>[EN] Provider can validate native GPU execution contracts. [JA] Provider は native GPU execution contract を検証できます。</summary>
    SupportsNativeValidation = 1 << 5,

    /// <summary>[EN] Provider can recover to a deterministic CPU path. [JA] Provider は deterministic CPU path へ復帰できます。</summary>
    SupportsCpuFallback = 1 << 6,

    /// <summary>[EN] Provider can expose frame diagnostics for each GPU path. [JA] Provider は GPU path ごとの frame diagnostics を公開できます。</summary>
    SupportsFrameDiagnostics = 1 << 7
}

/// <summary>
/// [EN] Canonical frame target kinds for GPU capture and rendering.
/// [JA] GPU capture/rendering 用の canonical frame target kind です。
/// </summary>
public enum GpuFrameTargetKind
{
    /// <summary>[EN] Unknown target. [JA] 不明な target です。</summary>
    Unknown = 0,

    /// <summary>[EN] Raw game framebuffer before HUD composition. [JA] HUD 合成前の raw game framebuffer です。</summary>
    RawFramebuffer = 1,

    /// <summary>[EN] Offscreen HUD composite framebuffer. [JA] offscreen HUD composite framebuffer です。</summary>
    HudCompositeOffscreen = 2,

    /// <summary>[EN] Browser or native display surface. [JA] browser または native display surface です。</summary>
    DisplaySurface = 3,

    /// <summary>[EN] Intermediate feature mask texture. [JA] intermediate feature mask texture です。</summary>
    FeatureMask = 4
}

/// <summary>
/// [EN] Canonical readback policy for GPU passes.
/// [JA] GPU pass 用の canonical readback policy です。
/// </summary>
public enum GpuReadbackPolicy
{
    /// <summary>[EN] No CPU readback is allowed. [JA] CPU readback を許可しません。</summary>
    None = 0,

    /// <summary>[EN] Readback is allowed for debug surfaces only. [JA] debug surface に限り readback を許可します。</summary>
    DebugOnly = 1,

    /// <summary>[EN] Readback is limited to runtime summaries and diagnostics. [JA] runtime summary と diagnostics に限定します。</summary>
    RuntimeSummary = 2,

    /// <summary>[EN] Readback is required for CPU fallback. [JA] CPU fallback のため readback が必要です。</summary>
    RequiredFallback = 3
}

/// <summary>
/// [EN] Ego-radar rendering mode for GPU HUD.
/// [JA] GPU HUD の ego-radar rendering mode です。
/// </summary>
public enum GpuEgoRadarMode
{
    /// <summary>[EN] Normal compass/radar mode. [JA] 通常の compass/radar mode です。</summary>
    Normal = 0,

    /// <summary>[EN] Suppressed mode such as wall-follow or combat survey. [JA] wall-follow や combat survey などの suppressed mode です。</summary>
    Suppressed = 1,

    /// <summary>[EN] Lost or frozen heading mode. [JA] heading を喪失または freeze した mode です。</summary>
    Lost = 2
}

/// <summary>
/// [EN] Severity for canonical GPU contract validation issues.
/// [JA] canonical GPU contract validation issue の重大度です。
/// </summary>
public enum GpuValidationSeverity
{
    /// <summary>[EN] Informational issue. [JA] 情報レベルの issue です。</summary>
    Info = 0,

    /// <summary>[EN] Warning issue; execution may continue with fallback. [JA] 警告レベルの issue です。fallback により実行継続できる可能性があります。</summary>
    Warning = 1,

    /// <summary>[EN] Error issue; the canonical GPU contract is not satisfied. [JA] error レベルの issue です。canonical GPU contract を満たしていません。</summary>
    Error = 2
}
