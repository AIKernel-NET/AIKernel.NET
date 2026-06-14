using AIKernel.Dtos.Frame;
using AIKernel.Dtos.Perception;
using AIKernel.Dtos.Providers;

namespace AIKernel.Abstractions.Perception;

/// <summary>
/// Provides diagnostics-bearing frame perception results.
/// JA: IDiagnosticFramePerceptionProvider の公開契約を定義します。
/// </summary>
public interface IDiagnosticFramePerceptionProvider : IFramePerceptionProvider
{
    /// <summary>
    /// Analyzes a frame snapshot with diagnostics-bearing output.
    /// JA: AnalyzeWithDiagnosticsAsync 操作を実行します。
    /// </summary>
    /// <param name="frame">The frame snapshot. JA: frame パラメーターです。</param>
    /// <param name="options">The perception options. JA: options パラメーターです。</param>
    /// <param name="context">The execution context. JA: context パラメーターです。</param>
    /// <param name="cancellationToken">The cancellation token. JA: キャンセル通知を監視するトークンです。</param>
    /// <returns>The perception result. JA: 結果を返します。</returns>
    ValueTask<FramePerceptionResult> AnalyzeWithDiagnosticsAsync(
        FrameSnapshot frame,
        FramePerceptionOptions options,
        ProviderExecutionContext context,
        CancellationToken cancellationToken);
}
