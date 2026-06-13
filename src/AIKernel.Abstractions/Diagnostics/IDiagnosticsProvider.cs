using AIKernel.Dtos.Diagnostics;

namespace AIKernel.Abstractions.Diagnostics;

/// <summary>
/// Provides diagnostics snapshot, query, clear, and catalog operations.
/// JA: IDiagnosticsProvider の公開契約を定義します。
/// </summary>
public interface IDiagnosticsProvider
{
    /// <summary>
    /// Captures a diagnostic snapshot.
    /// JA: SnapshotAsync 操作を実行します。
    /// </summary>
    /// <param name="request">The snapshot request. JA: request パラメーターです。</param>
    /// <param name="cancellationToken">The cancellation token. JA: キャンセル通知を監視するトークンです。</param>
    /// <returns>The diagnostic snapshot. JA: 結果を返します。</returns>
    ValueTask<DiagnosticSnapshot> SnapshotAsync(
        DiagnosticSnapshotRequest request,
        CancellationToken cancellationToken);

    /// <summary>
    /// Queries diagnostic entries.
    /// JA: QueryAsync 操作を実行します。
    /// </summary>
    /// <param name="request">The diagnostic query. JA: request パラメーターです。</param>
    /// <param name="cancellationToken">The cancellation token. JA: キャンセル通知を監視するトークンです。</param>
    /// <returns>The diagnostic entries. JA: 結果を返します。</returns>
    IAsyncEnumerable<DiagnosticEntry> QueryAsync(
        DiagnosticQuery request,
        CancellationToken cancellationToken);

    /// <summary>
    /// Clears diagnostic entries.
    /// JA: ClearAsync 操作を実行します。
    /// </summary>
    /// <param name="request">The clear request. JA: request パラメーターです。</param>
    /// <param name="cancellationToken">The cancellation token. JA: キャンセル通知を監視するトークンです。</param>
    /// <returns>The clear result. JA: 結果を返します。</returns>
    ValueTask<DiagnosticClearResult> ClearAsync(
        DiagnosticClearRequest request,
        CancellationToken cancellationToken);

    /// <summary>
    /// Describes known diagnostic keys.
    /// JA: DescribeKeysAsync 操作を実行します。
    /// </summary>
    /// <param name="request">The key description request. JA: request パラメーターです。</param>
    /// <param name="cancellationToken">The cancellation token. JA: キャンセル通知を監視するトークンです。</param>
    /// <returns>The diagnostic key catalog. JA: 結果を返します。</returns>
    ValueTask<DiagnosticKeyCatalog> DescribeKeysAsync(
        DiagnosticKeyDescribeRequest request,
        CancellationToken cancellationToken);
}
