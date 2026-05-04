namespace AIKernel.Dtos.Execution;

/// <summary>
/// Two‑Phase 実行の結果を表現します。
/// 推論の中間表現と最終出力の両方を保持します。
/// </summary>
public sealed class ExecutionResult
{
    /// <summary>
    /// 推論結果の中間表現（生のロジック）を取得または設定します。
    /// </summary>
    public required RawLogic Logic { get; init; }

    /// <summary>
    /// 最終出力（整形済みテキスト）を取得または設定します。
    /// </summary>
    public required string FinalOutput { get; init; }

    /// <summary>
    /// 実行の成功/失敗を示す値を取得または設定します。
    /// </summary>
    public bool IsSuccessful { get; init; } = true;

    /// <summary>
    /// 実行時に発生したエラーメッセージを取得または設定します。
    /// </summary>
    public string? ErrorMessage { get; init; }

    /// <summary>
    /// 実行に要した時間（ミリ秒）を取得または設定します。
    /// </summary>
    public long ElapsedMilliseconds { get; init; }
}

