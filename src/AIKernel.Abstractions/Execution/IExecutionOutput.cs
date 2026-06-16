namespace AIKernel.Abstractions.Execution;

/// <summary>
/// UC-02/UC-04/UC-09/UC-20/UC-22 に基づく契約です。
/// 実行フェーズの成果物を統一的に表現する基底インターフェースです。
/// EN: ExecutionResult, RawLogic, その他の出力型を統一的に扱えます。
/// EN: Documentation for public API. JA: IExecutionOutput の公開契約を定義します。
/// </summary>
/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.Execution.IExecutionOutput']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.Execution.IExecutionOutput']" />
public interface IExecutionOutput
{
    /// <summary>
    /// EN: この実行出力の一意識別子を取得します。
    /// EN: Documentation for public API. JA: このメンバー の公開契約を定義します。
    /// </summary>
    string OutputId { get; }

    /// <summary>
    /// EN: この実行出力のタイプを取得します。
    /// EN: Documentation for public API. JA: このメンバー の公開契約を定義します。
    /// </summary>
    string OutputType { get; }

    /// <summary>
    /// EN: この実行出力が生成された時刻を取得します。
    /// EN: Documentation for public API. JA: このメンバー の公開契約を定義します。
    /// </summary>
    DateTime GeneratedAt { get; }

    /// <summary>
    /// EN: この実行出力の成功状態を取得します。
    /// EN: Documentation for public API. JA: GetSerializedRepresentation 操作を実行します。
    /// </summary>
    bool IsSuccessful { get; }

    /// <summary>
    /// EN: この実行出力に関連するエラーメッセージを取得します（失敗時）。
    /// EN: Documentation for public API. JA: GetSerializedRepresentation 操作を実行します。
    /// </summary>
    string? ErrorMessage { get; }

    /// <summary>
    /// EN: 出力内容のシリアル化された表現を取得します。
    /// EN: Documentation for public API. JA: GetSerializedRepresentation 操作を実行します。
    /// </summary>
    string GetSerializedRepresentation();

    /// <summary>
    /// EN: この出力を別の出力型に変換します。
    /// EN: Documentation for public API. JA: このメンバー の公開契約を定義します。
    /// </summary>
    /// <typeparam name="TOutput">EN: Documentation for public API. JA: 変換先の出力型 TOutput 型パラメーターです。</typeparam>
    /// <returns>EN: Documentation for public API. JA: 変換後の出力オブジェクト 結果を返します。</returns>
    TOutput ConvertTo<TOutput>() where TOutput : class, IExecutionOutput;
}


