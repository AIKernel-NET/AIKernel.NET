namespace AIKernel.Abstractions.Exceptions;

/// <summary>
/// Attention が汚染された（不要な注意が向けられた）ことを示す例外。
/// 推論結果が無関係な情報に影響を受けた場合に投げられます。
/// </summary>
public class AttentionPollutionException : Exception
{
    /// <summary>
    /// AttentionPollutionException を初期化します。
    /// </summary>
    /// <param name="message">エラーメッセージ</param>
    public AttentionPollutionException(string message) : base(message)
    {
    }

    /// <summary>
    /// AttentionPollutionException を初期化します。
    /// </summary>
    /// <param name="message">エラーメッセージ</param>
    /// <param name="innerException">内部例外</param>
    public AttentionPollutionException(string message, Exception innerException)
        : base(message, innerException)
    {
    }
}
