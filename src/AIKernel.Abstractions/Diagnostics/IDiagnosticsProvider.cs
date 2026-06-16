using AIKernel.Dtos.Diagnostics;

namespace AIKernel.Abstractions.Diagnostics;

/// <summary>
/// EN: Provides diagnostics snapshot, query, clear, and catalog operations.
/// [EN] Documents this public package API member. [JA] IDiagnosticsProvider の公開契約を定義します。
/// </summary>
public interface IDiagnosticsProvider
{
    /// <summary>
    /// EN: Captures a diagnostic snapshot.
    /// [EN] Documents this public package API member. [JA] SnapshotAsync 操作を実行します。
    /// </summary>
    /// <param name="request">EN: The snapshot request. JA: request パラメーターです。</param>
    /// <param name="cancellationToken">EN: The cancellation token. JA: キャンセル通知を監視するトークンです。</param>
    /// <returns>EN: The diagnostic snapshot. JA: 結果を返します。</returns>
    ValueTask<DiagnosticSnapshot> SnapshotAsync(
        DiagnosticSnapshotRequest request,
        CancellationToken cancellationToken);

    /// <summary>
    /// EN: Queries diagnostic entries.
    /// [EN] Documents this public package API member. [JA] QueryAsync 操作を実行します。
    /// </summary>
    /// <param name="request">EN: The diagnostic query. JA: request パラメーターです。</param>
    /// <param name="cancellationToken">EN: The cancellation token. JA: キャンセル通知を監視するトークンです。</param>
    /// <returns>EN: The diagnostic entries. JA: 結果を返します。</returns>
    IAsyncEnumerable<DiagnosticEntry> QueryAsync(
        DiagnosticQuery request,
        CancellationToken cancellationToken);

    /// <summary>
    /// EN: Clears diagnostic entries.
    /// [EN] Documents this public package API member. [JA] ClearAsync 操作を実行します。
    /// </summary>
    /// <param name="request">EN: The clear request. JA: request パラメーターです。</param>
    /// <param name="cancellationToken">EN: The cancellation token. JA: キャンセル通知を監視するトークンです。</param>
    /// <returns>EN: The clear result. JA: 結果を返します。</returns>
    ValueTask<DiagnosticClearResult> ClearAsync(
        DiagnosticClearRequest request,
        CancellationToken cancellationToken);

    /// <summary>
    /// EN: Describes known diagnostic keys.
    /// [EN] Documents this public package API member. [JA] DescribeKeysAsync 操作を実行します。
    /// </summary>
    /// <param name="request">EN: The key description request. JA: request パラメーターです。</param>
    /// <param name="cancellationToken">EN: The cancellation token. JA: キャンセル通知を監視するトークンです。</param>
    /// <returns>EN: The diagnostic key catalog. JA: 結果を返します。</returns>
    ValueTask<DiagnosticKeyCatalog> DescribeKeysAsync(
        DiagnosticKeyDescribeRequest request,
        CancellationToken cancellationToken);
}
