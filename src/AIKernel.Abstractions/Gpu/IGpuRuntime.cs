using AIKernel.Dtos.Gpu;
using AIKernel.Enums;

namespace AIKernel.Abstractions.Gpu;

/// <summary>
/// [EN] Provider-level options for canonical GPU context creation.
/// [JA] canonical GPU context 作成用の provider-level option です。
/// </summary>
public sealed record GpuProviderOptions
{
    /// <summary>[EN] Preferred backend. [JA] preferred backend です。</summary>
    public GpuBackend PreferredBackend { get; init; } = GpuBackend.Unknown;

    /// <summary>[EN] Forces CPU fallback and skips GPU initialization. [JA] CPU fallback を強制し GPU 初期化を skip します。</summary>
    public bool ForceCpuFallback { get; init; }

    /// <summary>[EN] Requests zero-copy raw texture paths when available. [JA] 利用可能な場合 zero-copy raw texture path を要求します。</summary>
    public bool PreferZeroCopyRawTexture { get; init; } = true;

    /// <summary>[EN] Optional provider metadata. [JA] 任意の provider metadata です。</summary>
    public IReadOnlyDictionary<string, string> Metadata { get; init; } = new Dictionary<string, string>();

    /// <summary>[EN] Requests native validation layers when the backend supports them, such as Dawn. [JA] Dawn など backend が対応する場合に native validation layer を要求します。</summary>
    public bool EnableNativeValidation { get; init; }
}

/// <summary>
/// [EN] Canonical GPU provider boundary introduced for AIKernel v0.1.3.
/// [JA] AIKernel v0.1.3 で導入する canonical GPU provider boundary です。
/// </summary>
public interface IGpuProvider
{
    /// <summary>[EN] Provider identifier. [JA] provider 識別子です。</summary>
    string ProviderId { get; }

    /// <summary>[EN] Active or preferred backend. [JA] active または preferred backend です。</summary>
    GpuBackend Backend { get; }

    /// <summary>[EN] Provider capabilities. [JA] provider capability です。</summary>
    GpuProviderCapabilities Capabilities { get; }

    /// <summary>[EN] Creates a GPU context or deterministic CPU fallback context. [JA] GPU context または deterministic CPU fallback context を作成します。</summary>
    ValueTask<IGpuContext> CreateContextAsync(GpuProviderOptions options, CancellationToken cancellationToken = default);
}

/// <summary>
/// [EN] Canonical GPU context that owns frame targets, diagnostics, and pass processors.
/// [JA] frame target、diagnostics、pass processor を所有する canonical GPU context です。
/// </summary>
public interface IGpuContext : IAsyncDisposable
{
    /// <summary>[EN] Context identifier. [JA] context 識別子です。</summary>
    string ContextId { get; }

    /// <summary>[EN] Active backend. [JA] active backend です。</summary>
    GpuBackend Backend { get; }

    /// <summary>[EN] Active capabilities. [JA] active capability です。</summary>
    GpuProviderCapabilities Capabilities { get; }

    /// <summary>[EN] True when CPU fallback is active. [JA] CPU fallback が有効な場合 true です。</summary>
    bool UsingCpuFallback { get; }

    /// <summary>[EN] Returns current frame diagnostics. [JA] 現在の frame diagnostics を返します。</summary>
    GpuFrameDiagnostics Diagnostics { get; }

    /// <summary>[EN] Creates a deterministic frame token for pass synchronization. [JA] pass synchronization 用の deterministic frame token を作成します。</summary>
    GpuFrameToken CreateFrameToken(GpuFrameTarget rawTarget, GpuFrameTarget? hudTarget = null);
}

/// <summary>
/// [EN] Canonical GPU diagnostics boundary for the four execution paths: game, Bonsai, HUD, and sensor/Aisthesis.
/// [JA] game、Bonsai、HUD、sensor/Aisthesis の四経路用 canonical GPU diagnostics 境界です。
/// </summary>
public interface IGpuDiagnostics
{
    /// <summary>
    /// [EN] Captures diagnostics for the current or specified deterministic frame.
    /// [JA] 現在または指定された deterministic frame の diagnostics を取得します。
    /// </summary>
    ValueTask<GpuFrameDiagnostics> CaptureFrameDiagnosticsAsync(
        GpuFrameToken? frame = null,
        CancellationToken cancellationToken = default);
}

/// <summary>
/// [EN] GPU Aisthesis processor. Implementations must consume raw framebuffer targets, not HUD-composited targets.
/// [JA] GPU Aisthesis processor です。実装は HUD 合成済み target ではなく raw framebuffer target を消費する必要があります。
/// </summary>
public interface IGpuAisthesisProcessor
{
    /// <summary>[EN] Runs feature extraction. [JA] feature extraction を実行します。</summary>
    ValueTask<GpuAisthesisOutput> ProcessAsync(GpuAisthesisInput input, CancellationToken cancellationToken = default);
}

/// <summary>
/// [EN] GPU spatial reasoning processor for Topos, Route, Threat, and Zoe matrices.
/// [JA] Topos、Route、Threat、Zoe matrix 用の GPU spatial reasoning processor です。
/// </summary>
public interface IGpuSpatialReasoner
{
    /// <summary>[EN] Runs spatial reasoning. [JA] spatial reasoning を実行します。</summary>
    ValueTask<GpuSpatialReasoningOutput> ReasonAsync(GpuSpatialReasoningInput input, CancellationToken cancellationToken = default);
}

/// <summary>
/// [EN] GPU HUD composer. Shader implementations are pure views over already-smoothed runtime values.
/// [JA] GPU HUD composer です。shader 実装は runtime 側で smoothing 済みの値をそのまま描画する pure view です。
/// </summary>
public interface IGpuHudComposer
{
    /// <summary>[EN] Composites the HUD into an offscreen target. [JA] HUD を offscreen target へ合成します。</summary>
    ValueTask<GpuFrameTarget> ComposeAsync(GpuHudInput input, CancellationToken cancellationToken = default);
}

/// <summary>
/// [EN] Optional GPU resource lifetime boundary.
/// [JA] 任意の GPU resource lifetime boundary です。
/// </summary>
public interface IGpuResource : IAsyncDisposable
{
    /// <summary>[EN] Resource identifier. [JA] resource 識別子です。</summary>
    string ResourceId { get; }

    /// <summary>[EN] Backend that owns the resource. [JA] resource を所有する backend です。</summary>
    GpuBackend Backend { get; }
}

/// <summary>
/// [EN] Typed GPU buffer resource.
/// [JA] 型付き GPU buffer resource です。
/// </summary>
public interface IGpuBuffer : IGpuResource
{
    /// <summary>[EN] Buffer layout. [JA] buffer layout です。</summary>
    GpuFlatBufferLayout Layout { get; }
}

/// <summary>
/// [EN] Typed GPU texture resource.
/// [JA] 型付き GPU texture resource です。
/// </summary>
public interface IGpuTexture : IGpuResource
{
    /// <summary>[EN] Texture frame target descriptor. [JA] texture frame target descriptor です。</summary>
    GpuFrameTarget Target { get; }
}
