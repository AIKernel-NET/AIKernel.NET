using AIKernel.Dtos.Frame;
using AIKernel.Dtos.Perception;
using AIKernel.Dtos.Providers;

namespace AIKernel.Abstractions.Perception;

/// <summary>
/// EN: Provides diagnostics-bearing frame perception results.
/// [EN] Documents this public package API member. [JA] IDiagnosticFramePerceptionProvider の公開契約を定義します。
/// </summary>
public interface IDiagnosticFramePerceptionProvider : IFramePerceptionProvider
{
    /// <summary>
    /// EN: Analyzes a frame snapshot with diagnostics-bearing output.
    /// [EN] Documents this public package API member. [JA] AnalyzeWithDiagnosticsAsync 操作を実行します。
    /// </summary>
    /// <param name="frame">EN: The frame snapshot. JA: frame パラメーターです。</param>
    /// <param name="options">EN: The perception options. JA: options パラメーターです。</param>
    /// <param name="context">EN: The execution context. JA: context パラメーターです。</param>
    /// <param name="cancellationToken">EN: The cancellation token. JA: キャンセル通知を監視するトークンです。</param>
    /// <returns>EN: The perception result. JA: 結果を返します。</returns>
    ValueTask<FramePerceptionResult> AnalyzeWithDiagnosticsAsync(
        FrameSnapshot frame,
        FramePerceptionOptions options,
        ProviderExecutionContext context,
        CancellationToken cancellationToken);
}
