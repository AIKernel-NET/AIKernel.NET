namespace AIKernel.Abstractions.Execution;

/// <summary>
/// 実行フェーズの成果物を統一的に表現する基底インターフェースです。
/// ExecutionResult, RawLogic, その他の出力型を統一的に扱えます。
/// </summary>
public interface IExecutionOutput
{
    /// <summary>
    /// この実行出力の一意識別子を取得します。
    /// </summary>
    string OutputId { get; }

    /// <summary>
    /// この実行出力のタイプを取得します。
    /// </summary>
    string OutputType { get; }

    /// <summary>
    /// この実行出力が生成された時刻を取得します。
    /// </summary>
    DateTime GeneratedAt { get; }

    /// <summary>
    /// この実行出力の成功状態を取得します。
    /// </summary>
    bool IsSuccessful { get; }

    /// <summary>
    /// この実行出力に関連するエラーメッセージを取得します（失敗時）。
    /// </summary>
    string? ErrorMessage { get; }

    /// <summary>
    /// 出力内容のシリアル化された表現を取得します。
    /// </summary>
    string GetSerializedRepresentation();

    /// <summary>
    /// この出力を別の出力型に変換します。
    /// </summary>
    /// <typeparam name="TOutput">変換先の出力型</typeparam>
    /// <returns>変換後の出力オブジェクト</returns>
    /// <exception cref="InvalidOperationException">変換が不可能な場合</exception>
    TOutput ConvertTo<TOutput>() where TOutput : class, IExecutionOutput;
}

/// <summary>
/// フェーズハンドオーバーのための検証インターフェースです。
/// 異なるフェーズ間での出力検証を統一的に行います。
/// </summary>
public interface IPhaseHandover
{
    /// <summary>
    /// 前フェーズの出力が次フェーズに適したものかを検証します。
    /// </summary>
    /// <param name="output">検証対象の出力</param>
    /// <param name="nextPhase">次のフェーズ名</param>
    /// <param name="cancellationToken">キャンセルトークン</param>
    /// <returns>検証結果</returns>
    Task<PhaseHandoverResult> ValidateHandoverAsync(
        IExecutionOutput output,
        string nextPhase,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// 出力をレストアアップする（次フェーズの入力形式に変換）します。
    /// </summary>
    /// <param name="output">変換対象の出力</param>
    /// <param name="nextPhase">次のフェーズ名</param>
    /// <param name="cancellationToken">キャンセルトークン</param>
    /// <returns>レストアアップ後の出力</returns>
    Task<IExecutionOutput> RestageForNextPhaseAsync(
        IExecutionOutput output,
        string nextPhase,
        CancellationToken cancellationToken = default);
}
