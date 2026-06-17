using AIKernel.Dtos.Cognition;
using AIKernel.Dtos.Diagnostics;

namespace AIKernel.Dtos.Scenarios;

/// <summary>
/// EN: Carries a scenario perception request without scenario-specific vocabulary. JA: シナリオ固有語彙を持たないシナリオ知覚要求を保持します。
/// </summary>
public sealed record ScenarioPerceptionRequest
{
    /// <summary>EN: Gets the scenario identifier. JA: シナリオ識別子を取得します。</summary>
    public string ScenarioId { get; init; } = string.Empty;

    /// <summary>EN: Gets the source sensory snapshot. JA: 入力感覚スナップショットを取得します。</summary>
    public AisthesisSnapshot Aisthesis { get; init; } = new();

    /// <summary>EN: Gets request metadata. JA: 要求メタデータを取得します。</summary>
    public IReadOnlyDictionary<string, string> Metadata { get; init; } = new Dictionary<string, string>(StringComparer.Ordinal);
}

/// <summary>
/// EN: Carries scenario perception output without action decisions. JA: 行動決定を持たないシナリオ知覚出力を保持します。
/// </summary>
public sealed record ScenarioPerceptionSnapshot
{
    /// <summary>EN: Gets the snapshot identifier. JA: スナップショット識別子を取得します。</summary>
    public string SnapshotId { get; init; } = string.Empty;

    /// <summary>EN: Gets the cognition snapshot. JA: 認知スナップショットを取得します。</summary>
    public NousSnapshot Nous { get; init; } = new();

    /// <summary>EN: Gets whether perception succeeded. JA: 知覚が成功したかどうかを取得します。</summary>
    public bool? Succeeded { get; init; }

    /// <summary>EN: Gets a stable error code when perception failed. JA: 知覚に失敗した場合の安定したエラーコードを取得します。</summary>
    public string? ErrorCode { get; init; }

    /// <summary>EN: Gets a human-readable error message when perception failed. JA: 知覚に失敗した場合の可読エラーメッセージを取得します。</summary>
    public string? ErrorMessage { get; init; }

    /// <summary>EN: Gets diagnostic information. JA: 診断情報を取得します。</summary>
    public DiagnosticInfo? Diagnostics { get; init; }

    /// <summary>EN: Gets snapshot metadata. JA: スナップショットメタデータを取得します。</summary>
    public IReadOnlyDictionary<string, string> Metadata { get; init; } = new Dictionary<string, string>(StringComparer.Ordinal);
}

/// <summary>
/// EN: Carries a scenario action emission request. JA: シナリオ行動発行要求を保持します。
/// </summary>
public sealed record ScenarioActionRequest
{
    /// <summary>EN: Gets the scenario identifier. JA: シナリオ識別子を取得します。</summary>
    public string ScenarioId { get; init; } = string.Empty;

    /// <summary>EN: Gets the abstract action. JA: 抽象行動を取得します。</summary>
    public KinesisAction Action { get; init; } = new();

    /// <summary>EN: Gets request metadata. JA: 要求メタデータを取得します。</summary>
    public IReadOnlyDictionary<string, string> Metadata { get; init; } = new Dictionary<string, string>(StringComparer.Ordinal);
}

/// <summary>
/// EN: Carries a scenario action emission result. JA: シナリオ行動発行結果を保持します。
/// </summary>
public sealed record ScenarioActionResult
{
    /// <summary>EN: Gets the action identifier. JA: 行動識別子を取得します。</summary>
    public string ActionId { get; init; } = string.Empty;

    /// <summary>EN: Gets whether action emission succeeded. JA: 行動発行が成功したかどうかを取得します。</summary>
    public bool? Succeeded { get; init; }

    /// <summary>EN: Gets a stable error code when action emission failed. JA: 行動発行に失敗した場合の安定したエラーコードを取得します。</summary>
    public string? ErrorCode { get; init; }

    /// <summary>EN: Gets a human-readable error message when action emission failed. JA: 行動発行に失敗した場合の可読エラーメッセージを取得します。</summary>
    public string? ErrorMessage { get; init; }

    /// <summary>EN: Gets diagnostic information. JA: 診断情報を取得します。</summary>
    public DiagnosticInfo? Diagnostics { get; init; }

    /// <summary>EN: Gets result metadata. JA: 結果メタデータを取得します。</summary>
    public IReadOnlyDictionary<string, string> Metadata { get; init; } = new Dictionary<string, string>(StringComparer.Ordinal);
}

/// <summary>
/// EN: Carries scenario runtime status without binding to a game or host. JA: ゲームやホストに束縛されないシナリオ実行状態を保持します。
/// </summary>
public sealed record ScenarioRuntimeStatus
{
    /// <summary>EN: Gets the runtime identifier. JA: ランタイム識別子を取得します。</summary>
    public string RuntimeId { get; init; } = string.Empty;

    /// <summary>EN: Gets the status label. JA: 状態ラベルを取得します。</summary>
    public string Status { get; init; } = string.Empty;

    /// <summary>EN: Gets whether status capture succeeded. JA: 状態取得が成功したかどうかを取得します。</summary>
    public bool? Succeeded { get; init; }

    /// <summary>EN: Gets a stable error code when status capture failed. JA: 状態取得に失敗した場合の安定したエラーコードを取得します。</summary>
    public string? ErrorCode { get; init; }

    /// <summary>EN: Gets a human-readable error message when status capture failed. JA: 状態取得に失敗した場合の可読エラーメッセージを取得します。</summary>
    public string? ErrorMessage { get; init; }

    /// <summary>EN: Gets diagnostic information. JA: 診断情報を取得します。</summary>
    public DiagnosticInfo? Diagnostics { get; init; }

    /// <summary>EN: Gets status metadata. JA: 状態メタデータを取得します。</summary>
    public IReadOnlyDictionary<string, string> Metadata { get; init; } = new Dictionary<string, string>(StringComparer.Ordinal);
}

/// <summary>
/// EN: Carries scenario HUD state without drawing implementation. JA: 描画実装を持たないシナリオ HUD 状態を保持します。
/// </summary>
public sealed record ScenarioHudState
{
    /// <summary>EN: Gets the HUD state identifier. JA: HUD 状態識別子を取得します。</summary>
    public string HudStateId { get; init; } = string.Empty;

    /// <summary>EN: Gets HUD labels. JA: HUD ラベルを取得します。</summary>
    public IReadOnlyList<string> Labels { get; init; } = [];

    /// <summary>EN: Gets whether HUD state capture succeeded. JA: HUD 状態取得が成功したかどうかを取得します。</summary>
    public bool? Succeeded { get; init; }

    /// <summary>EN: Gets a stable error code when HUD state capture failed. JA: HUD 状態取得に失敗した場合の安定したエラーコードを取得します。</summary>
    public string? ErrorCode { get; init; }

    /// <summary>EN: Gets a human-readable error message when HUD state capture failed. JA: HUD 状態取得に失敗した場合の可読エラーメッセージを取得します。</summary>
    public string? ErrorMessage { get; init; }

    /// <summary>EN: Gets diagnostic information. JA: 診断情報を取得します。</summary>
    public DiagnosticInfo? Diagnostics { get; init; }

    /// <summary>EN: Gets HUD metadata. JA: HUD メタデータを取得します。</summary>
    public IReadOnlyDictionary<string, string> Metadata { get; init; } = new Dictionary<string, string>(StringComparer.Ordinal);
}
