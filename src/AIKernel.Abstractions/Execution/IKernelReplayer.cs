namespace AIKernel.Abstractions.Execution;

/// <summary>
/// UC-20（決定論的リプレイと監査証跡）に基づき、Replay Dump から再実行を行う契約を定義します。
/// </summary>
/// <remarks>
/// 同一の ReplayDump と実行条件に対して、常に同一の再実行結果へ収束する決定論的挙動を保証する必要があります。
/// 副作用を伴う外部依存は、再現性を損なわない形で隔離してください。
/// </remarks>
public interface IKernelReplayer
{
    /// <summary>
    /// 指定された Replay Dump を再実行します。
    /// </summary>
    /// <param name="replayDump">再実行対象のダンプ</param>
    /// <param name="traceContext">トレース情報</param>
    /// <param name="cancellationToken">キャンセルトークン</param>
    /// <returns>再実行結果</returns>
    /// <exception cref="ArgumentNullException">必須引数が null の場合にスローされます。</exception>
    /// <exception cref="InvalidOperationException">ダンプの整合性が検証に失敗した場合にスローされます。</exception>
    ValueTask<ExecutionResult> ReplayAsync(
        ReplayDump replayDump,
        TraceContext traceContext,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// 指定された Replay Dump が再実行可能かを判定します。
    /// </summary>
    /// <param name="replayDump">判定対象のダンプ</param>
    /// <returns>再実行可能な場合は <see langword="true"/>、それ以外は <see langword="false"/>。</returns>
    bool CanReplay(ReplayDump replayDump);
}


