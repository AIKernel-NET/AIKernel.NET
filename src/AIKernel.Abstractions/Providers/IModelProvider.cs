namespace AIKernel.Abstractions.Providers;

/// <summary>
/// UC-05/UC-19/UC-23/UC-26/UC-27 に基づく契約です。
/// テキスト生成を実行する capability interface です。
/// </summary>
public interface ITextGenerationProvider
{
    /// <summary>
    /// テキスト生成を実行します。
    /// </summary>
    /// <param name="messages">入力メッセージシーケンス</param>
    /// <param name="cancellationToken">キャンセルトークン</param>
    /// <returns>生成されたテキスト</returns>
    Task<string> GenerateAsync(IReadOnlyList<IModelMessage> messages, CancellationToken cancellationToken = default);
}

/// <summary>
/// UC-05/UC-19/UC-23/UC-26/UC-27 に基づく契約です。
/// ストリーミング生成を実行する capability interface です。
/// </summary>
public interface IStreamingGenerationProvider
{
    /// <summary>
    /// ストリーミングでテキスト生成を実行します。
    /// </summary>
    /// <param name="messages">入力メッセージシーケンス</param>
    /// <param name="onChunk">チャンク受信時のコールバック</param>
    /// <param name="cancellationToken">キャンセルトークン</param>
    Task StreamGenerateAsync(IReadOnlyList<IModelMessage> messages, Func<string, Task> onChunk, CancellationToken cancellationToken = default);
}

/// <summary>
/// UC-05/UC-19/UC-23/UC-26/UC-27 に基づく契約です。
/// 質問応答を実行する capability interface です。
/// </summary>
public interface IQuestionAnsweringProvider
{
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
/// UC-05/UC-19/UC-23/UC-26/UC-27 に基づく契約です。
/// LLMモデル推論プロバイダーを定義する互換合成インターフェースです。
/// チャット、テキスト生成、推論など、LLMベースの推論機能を提供します。
/// </summary>
public interface IModelProvider :
    IProvider,
    ITextGenerationProvider,
    IStreamingGenerationProvider,
    IQuestionAnsweringProvider
{
}
