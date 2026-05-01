namespace AIKernel.Abstractions.Exceptions;

/// <summary>
/// 素材の検疫に失敗したことを示す例外。
/// 入力データが正規化できない、または安全でないと判定された場合に投げられます。
/// </summary>
public class QuarantineFailedException : Exception
{
    /// <summary>
    /// QuarantineFailedException を初期化します。
    /// </summary>
    /// <param name="message">エラーメッセージ</param>
    public QuarantineFailedException(string message) : base(message)
    {
    }

    /// <summary>
    /// QuarantineFailedException を初期化します。
    /// </summary>
    /// <param name="message">エラーメッセージ</param>
    /// <param name="innerException">内部例外</param>
    public QuarantineFailedException(string message, Exception innerException)
        : base(message, innerException)
    {
    }

    /// <summary>
    /// QuarantineFailedException を初期化します。
    /// </summary>
    /// <param name="message">エラーメッセージ</param>
    /// <param name="fragmentId">検疫に失敗したフラグメント ID</param>
    /// <param name="reason">失敗の理由</param>
    public QuarantineFailedException(string message, string? fragmentId, string? reason)
        : base(message)
    {
        FragmentId = fragmentId;
        Reason = reason;
    }

    /// <summary>
    /// 検疫に失敗したフラグメント ID を取得します。
    /// </summary>
    public string? FragmentId { get; }

    /// <summary>
    /// 失敗の理由を取得します。
    /// </summary>
    public string? Reason { get; }
}
