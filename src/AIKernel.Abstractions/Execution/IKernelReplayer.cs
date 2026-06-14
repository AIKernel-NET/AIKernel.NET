namespace AIKernel.Abstractions.Execution;

/// <summary>
/// UC-20（決定論的リプレイと監査証跡）に基づき、Replay Dump から再実行を行う契約を定義します。
/// JA: IKernelReplayer の公開契約を定義します。
/// </summary>
/// <remarks>
/// 同一の ReplayDump と実行条件に対して、常に同一の再実行結果へ収束する決定論的挙動を保証する必要があります。
/// 副作用を伴う外部依存は、再現性を損なわない形で隔離してください。
/// </remarks>
/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.Execution.IKernelReplayer']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.Execution.IKernelReplayer']" />
public interface IKernelReplayer
{
    /// <summary>
    /// 指定された Replay Dump を再実行します。
    /// JA: ReplayAsync 操作を実行します。
    /// </summary>
    /// <param name="replayDump">再実行対象のダンプ JA: replayDump パラメーターです。</param>
    /// <param name="traceContext">トレース情報 JA: traceContext パラメーターです。</param>
    /// <param name="cancellationToken">キャンセルトークン JA: キャンセル通知を監視するトークンです。</param>
    /// <returns>再実行結果 JA: 結果を返します。</returns>
    ValueTask<ExecutionResult> ReplayAsync(
        ReplayDump replayDump,
        TraceContext traceContext,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// 指定された Replay Dump が再実行可能かを判定します。
    /// JA: CanReplay 操作を実行します。
    /// </summary>
    /// <param name="replayDump">判定対象のダンプ JA: replayDump パラメーターです。</param>
    /// <returns>再実行可能な場合は <see langword="true"/>、それ以外は <see langword="false"/>。 JA: 結果を返します。</returns>
    bool CanReplay(ReplayDump replayDump);
}


