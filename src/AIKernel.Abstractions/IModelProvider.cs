namespace AIKernel.Abstractions;

/// <summary>
/// LLMモデル推論プロバイダーを定義します。
/// チャット、テキスト生成、推論など、LLMベースの推論機能を提供します。
/// </summary>
public interface IModelProvider : IProvider
{
    /// <summary>
    /// テキスト生成を実行します。
    /// </summary>
    /// <param name="messages">入力メッセージシーケンス</param>
    /// <param name="cancellationToken">キャンセルトークン</param>
    /// <returns>生成されたテキスト</returns>
    Task<string> GenerateAsync(IReadOnlyList<IModelMessage> messages, CancellationToken cancellationToken = default);

    /// <summary>
    /// ストリーミングでテキスト生成を実行します。
    /// </summary>
    /// <param name="messages">入力メッセージシーケンス</param>
    /// <param name="onChunk">チャンク受信時のコールバック</param>
    /// <param name="cancellationToken">キャンセルトークン</param>
    Task StreamGenerateAsync(IReadOnlyList<IModelMessage> messages, Func<string, Task> onChunk, CancellationToken cancellationToken = default);

    /// <summary>
    /// 単一の質問に対して回答を生成します。
    /// </summary>
    /// <param name="question">質問テキスト</param>
    /// <param name="context">オプショナルなコンテキスト</param>
    /// <param name="cancellationToken">キャンセルトークン</param>
    /// <returns>回答テキスト</returns>
    Task<string> AnswerAsync(string question, string? context = null, CancellationToken cancellationToken = default);
}

/// <summary>
/// LLMプロバイダーが処理するメッセージを定義します。
/// </summary>
public interface IModelMessage
{
    /// <summary>
    /// メッセージロール（user/assistant/system）を取得します。
    /// </summary>
    string Role { get; }

    /// <summary>
    /// メッセージコンテンツを取得します。
    /// </summary>
    string Content { get; }
}
