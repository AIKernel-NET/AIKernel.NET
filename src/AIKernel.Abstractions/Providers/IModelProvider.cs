namespace AIKernel.Abstractions.Providers;

/// <summary>
/// UC-05/UC-19/UC-23/UC-26/UC-27 に基づく契約です。
/// テキスト生成を実行する capability interface です。
/// JA: ITextGenerationProvider の公開契約を定義します。
/// </summary>
/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.Providers.ITextGenerationProvider']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.Providers.ITextGenerationProvider']" />
public interface ITextGenerationProvider
{
    /// <summary>
    /// テキスト生成を実行します。
    /// JA: GenerateAsync 操作を実行します。
    /// </summary>
    /// <param name="messages">入力メッセージシーケンス JA: messages パラメーターです。</param>
    /// <param name="cancellationToken">キャンセルトークン JA: キャンセル通知を監視するトークンです。</param>
    /// <returns>生成されたテキスト JA: 結果を返します。</returns>
    Task<string> GenerateAsync(IReadOnlyList<IModelMessage> messages, CancellationToken cancellationToken = default);
}

/// <summary>
/// UC-05/UC-19/UC-23/UC-26/UC-27 に基づく契約です。
/// ストリーミング生成を実行する capability interface です。
/// JA: IStreamingGenerationProvider の公開契約を定義します。
/// </summary>
/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.Providers.IStreamingGenerationProvider']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.Providers.IStreamingGenerationProvider']" />
public interface IStreamingGenerationProvider
{
    /// <summary>
    /// ストリーミングでテキスト生成を実行します。
    /// JA: StreamGenerateAsync 操作を実行します。
    /// </summary>
    /// <param name="messages">入力メッセージシーケンス JA: messages パラメーターです。</param>
    /// <param name="onChunk">チャンク受信時のコールバック JA: onChunk パラメーターです。</param>
    /// <param name="cancellationToken">キャンセルトークン JA: キャンセル通知を監視するトークンです。</param>
    Task StreamGenerateAsync(IReadOnlyList<IModelMessage> messages, Func<string, Task> onChunk, CancellationToken cancellationToken = default);
}

/// <summary>
/// UC-05/UC-19/UC-23/UC-26/UC-27 に基づく契約です。
/// 質問応答を実行する capability interface です。
/// JA: IQuestionAnsweringProvider の公開契約を定義します。
/// </summary>
/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.Providers.IQuestionAnsweringProvider']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.Providers.IQuestionAnsweringProvider']" />
public interface IQuestionAnsweringProvider
{
    /// <summary>
    /// 単一の質問に対して回答を生成します。
    /// JA: AnswerAsync 操作を実行します。
    /// </summary>
    /// <param name="question">質問テキスト JA: question パラメーターです。</param>
    /// <param name="context">オプショナルなコンテキスト JA: context パラメーターです。</param>
    /// <param name="cancellationToken">キャンセルトークン JA: キャンセル通知を監視するトークンです。</param>
    /// <returns>回答テキスト JA: 結果を返します。</returns>
    Task<string> AnswerAsync(string question, string? context = null, CancellationToken cancellationToken = default);
}

/// <summary>
/// UC-05/UC-19/UC-23/UC-26/UC-27 に基づく契約です。
/// LLMモデル推論プロバイダーを定義する互換合成インターフェースです。
/// チャット、テキスト生成、推論など、LLMベースの推論機能を提供します。
/// JA: IModelProvider の公開契約を定義します。
/// </summary>
/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.Providers.IModelProvider']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.Providers.IModelProvider']" />
public interface IModelProvider :
    IProvider,
    ITextGenerationProvider,
    IStreamingGenerationProvider,
    IQuestionAnsweringProvider
{
}
