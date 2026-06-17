using AIKernel.Dtos.Scenarios;

namespace AIKernel.Abstractions.Scenarios;

/// <summary>
/// EN: Extracts scenario perception into canonical cognition carriers. JA: シナリオ知覚を正典的な認知 carrier へ抽出します。
/// </summary>
public interface IScenarioPerception
{
    /// <summary>
    /// EN: Captures scenario perception. JA: シナリオ知覚を取得します。
    /// </summary>
    /// <param name="request">EN: The scenario perception request. JA: シナリオ知覚要求です。</param>
    /// <param name="cancellationToken">EN: The cancellation token. JA: キャンセル通知を監視するトークンです。</param>
    /// <returns>EN: The scenario perception snapshot. JA: シナリオ知覚スナップショットを返します。</returns>
    ValueTask<ScenarioPerceptionSnapshot> CaptureAsync(ScenarioPerceptionRequest request, CancellationToken cancellationToken);
}

/// <summary>
/// EN: Emits scenario actions through an abstract boundary. JA: 抽象境界を通じてシナリオ行動を発行します。
/// </summary>
public interface IScenarioActionEmitter
{
    /// <summary>
    /// EN: Emits a scenario action. JA: シナリオ行動を発行します。
    /// </summary>
    /// <param name="request">EN: The action request. JA: 行動要求です。</param>
    /// <param name="cancellationToken">EN: The cancellation token. JA: キャンセル通知を監視するトークンです。</param>
    /// <returns>EN: The action result. JA: 行動結果を返します。</returns>
    ValueTask<ScenarioActionResult> EmitAsync(ScenarioActionRequest request, CancellationToken cancellationToken);
}

/// <summary>
/// EN: Reads scenario runtime status without scenario-specific implementation. JA: シナリオ固有実装を持たずシナリオ実行状態を読み取ります。
/// </summary>
public interface IScenarioRuntimeStatus
{
    /// <summary>
    /// EN: Captures scenario runtime status. JA: シナリオ実行状態を取得します。
    /// </summary>
    /// <param name="cancellationToken">EN: The cancellation token. JA: キャンセル通知を監視するトークンです。</param>
    /// <returns>EN: The scenario runtime status. JA: シナリオ実行状態を返します。</returns>
    ValueTask<ScenarioRuntimeStatus> GetStatusAsync(CancellationToken cancellationToken);
}

/// <summary>
/// EN: Reads scenario HUD state without drawing implementation. JA: 描画実装を持たずシナリオ HUD 状態を読み取ります。
/// </summary>
public interface IScenarioHudState
{
    /// <summary>
    /// EN: Captures scenario HUD state. JA: シナリオ HUD 状態を取得します。
    /// </summary>
    /// <param name="cancellationToken">EN: The cancellation token. JA: キャンセル通知を監視するトークンです。</param>
    /// <returns>EN: The scenario HUD state. JA: シナリオ HUD 状態を返します。</returns>
    ValueTask<ScenarioHudState> GetHudStateAsync(CancellationToken cancellationToken);
}
