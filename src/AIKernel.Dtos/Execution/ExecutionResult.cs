namespace AIKernel.Dtos.Execution;

/// <summary>
/// Two‑Phase 実行の結果を表現します。
/// 推論の中間表現と最終出力の両方を保持します。
/// </summary>
/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Dtos.Execution.ExecutionResult']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Dtos.Execution.ExecutionResult']" />
public sealed class ExecutionResult
{
    /// <summary>
    /// 推論結果の中間表現（生のロジック）を取得または設定します。
    /// </summary>
    /// <include file="docs.en.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Execution.ExecutionResult.Logic']" />
    /// <include file="docs.ja.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Execution.ExecutionResult.Logic']" />
    public required RawLogic Logic { get; init; }

    /// <summary>
    /// 最終出力（整形済みテキスト）を取得または設定します。
    /// </summary>
    /// <include file="docs.en.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Execution.ExecutionResult.FinalOutput']" />
    /// <include file="docs.ja.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Execution.ExecutionResult.FinalOutput']" />
    public required string FinalOutput { get; init; }

    /// <summary>
    /// 実行の成功/失敗を示す値を取得または設定します。
    /// </summary>
    /// <include file="docs.en.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Execution.ExecutionResult.IsSuccessful']" />
    /// <include file="docs.ja.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Execution.ExecutionResult.IsSuccessful']" />
    public bool IsSuccessful { get; init; } = true;

    /// <summary>
    /// 実行時に発生したエラーメッセージを取得または設定します。
    /// </summary>
    /// <include file="docs.en.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Execution.ExecutionResult.ErrorMessage']" />
    /// <include file="docs.ja.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Execution.ExecutionResult.ErrorMessage']" />
    public string? ErrorMessage { get; init; }

    /// <summary>
    /// 実行に要した時間（ミリ秒）を取得または設定します。
    /// </summary>
    /// <include file="docs.en.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Execution.ExecutionResult.ElapsedMilliseconds']" />
    /// <include file="docs.ja.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Execution.ExecutionResult.ElapsedMilliseconds']" />
    public long ElapsedMilliseconds { get; init; }
}


