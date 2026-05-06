namespace AIKernel.Abstractions.Execution;

/// <summary>
/// UC-02/UC-04/UC-09/UC-20/UC-22 に基づく契約です。
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


