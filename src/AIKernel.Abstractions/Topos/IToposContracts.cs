using AIKernel.Dtos.Cognition;

namespace AIKernel.Abstractions.Topos;

/// <summary>
/// EN: Evaluates the logos contribution to a Topos carrier. JA: Topos carrier への Logos 寄与を評価します。
/// </summary>
public interface ILogosVector
{
    /// <summary>
    /// EN: Evaluates a logos vector. JA: Logos ベクトルを評価します。
    /// </summary>
    /// <param name="request">EN: The Topos evaluation request. JA: Topos 評価要求です。</param>
    /// <param name="cancellationToken">EN: The cancellation token. JA: キャンセル通知を監視するトークンです。</param>
    /// <returns>EN: The logos vector. JA: Logos ベクトルを返します。</returns>
    ValueTask<IntentionVector> EvaluateAsync(ToposEvaluationRequest request, CancellationToken cancellationToken);
}

/// <summary>
/// EN: Evaluates the pathos contribution to a Topos carrier. JA: Topos carrier への Pathos 寄与を評価します。
/// </summary>
public interface IPathosVector
{
    /// <summary>
    /// EN: Evaluates a pathos vector. JA: Pathos ベクトルを評価します。
    /// </summary>
    /// <param name="request">EN: The Topos evaluation request. JA: Topos 評価要求です。</param>
    /// <param name="cancellationToken">EN: The cancellation token. JA: キャンセル通知を監視するトークンです。</param>
    /// <returns>EN: The pathos vector. JA: Pathos ベクトルを返します。</returns>
    ValueTask<IntentionVector> EvaluateAsync(ToposEvaluationRequest request, CancellationToken cancellationToken);
}

/// <summary>
/// EN: Evaluates the ethos contribution to a Topos carrier. JA: Topos carrier への Ethos 寄与を評価します。
/// </summary>
public interface IEthosVector
{
    /// <summary>
    /// EN: Evaluates an ethos vector. JA: Ethos ベクトルを評価します。
    /// </summary>
    /// <param name="request">EN: The Topos evaluation request. JA: Topos 評価要求です。</param>
    /// <param name="cancellationToken">EN: The cancellation token. JA: キャンセル通知を監視するトークンです。</param>
    /// <returns>EN: The ethos vector. JA: Ethos ベクトルを返します。</returns>
    ValueTask<IntentionVector> EvaluateAsync(ToposEvaluationRequest request, CancellationToken cancellationToken);
}

/// <summary>
/// EN: Composes a decision vector from observed triadic vectors without owning gate logic. JA: ゲートロジックを所有せず観測済み三者ベクトルから決定ベクトルを合成します。
/// </summary>
public interface IDecisionVector
{
    /// <summary>
    /// EN: Composes a decision vector. JA: 決定ベクトルを合成します。
    /// </summary>
    /// <param name="carrier">EN: The Topos carrier. JA: Topos carrier です。</param>
    /// <param name="cancellationToken">EN: The cancellation token. JA: キャンセル通知を監視するトークンです。</param>
    /// <returns>EN: The decision vector. JA: 決定ベクトルを返します。</returns>
    ValueTask<IntentionVector> ComposeAsync(ToposCarrier carrier, CancellationToken cancellationToken);
}

/// <summary>
/// EN: Evaluates a complete Topos carrier from cognition and telos context. JA: 認知と TELOS 文脈から完全な Topos carrier を評価します。
/// </summary>
public interface IToposEvaluator
{
    /// <summary>
    /// EN: Evaluates a Topos carrier. JA: Topos carrier を評価します。
    /// </summary>
    /// <param name="request">EN: The Topos evaluation request. JA: Topos 評価要求です。</param>
    /// <param name="cancellationToken">EN: The cancellation token. JA: キャンセル通知を監視するトークンです。</param>
    /// <returns>EN: The Topos carrier. JA: Topos carrier を返します。</returns>
    ValueTask<ToposCarrier> EvaluateAsync(ToposEvaluationRequest request, CancellationToken cancellationToken);
}
