namespace AIKernel.Abstractions.Providers;

/// <summary>
/// UC-05/UC-19/UC-23/UC-26/UC-27 に基づく契約です。
/// EN: テキスト生成を実行する capability interface です。
/// [EN] Documents this public package API member. [JA] ITextGenerationProvider の公開契約を定義します。
/// </summary>
/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.Providers.ITextGenerationProvider']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.Providers.ITextGenerationProvider']" />
public interface ITextGenerationProvider
{
    /// <summary>
    /// EN: テキスト生成を実行します。
    /// [EN] Documents this public package API member. [JA] GenerateAsync 操作を実行します。
    /// </summary>
    /// <param name="messages">[EN] Documents this public package API member. [JA] 入力メッセージシーケンス messages パラメーターです。</param>
    /// <param name="cancellationToken">[EN] Documents this public package API member. [JA] キャンセルトークン キャンセル通知を監視するトークンです。</param>
    /// <returns>[EN] Documents this public package API member. [JA] 生成されたテキスト 結果を返します。</returns>
    Task<string> GenerateAsync(IReadOnlyList<IModelMessage> messages, CancellationToken cancellationToken = default);
}

/// <summary>
/// UC-05/UC-19/UC-23/UC-26/UC-27 に基づく契約です。
/// EN: ストリーミング生成を実行する capability interface です。
/// [EN] Documents this public package API member. [JA] IStreamingGenerationProvider の公開契約を定義します。
/// </summary>
/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.Providers.IStreamingGenerationProvider']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.Providers.IStreamingGenerationProvider']" />
public interface IStreamingGenerationProvider
{
    /// <summary>
    /// EN: ストリーミングでテキスト生成を実行します。
    /// [EN] Documents this public package API member. [JA] StreamGenerateAsync 操作を実行します。
    /// </summary>
    /// <param name="messages">[EN] Documents this public package API member. [JA] 入力メッセージシーケンス messages パラメーターです。</param>
    /// <param name="onChunk">[EN] Documents this public package API member. [JA] チャンク受信時のコールバック onChunk パラメーターです。</param>
    /// <param name="cancellationToken">[EN] Documents this public package API member. [JA] キャンセルトークン キャンセル通知を監視するトークンです。</param>
    Task StreamGenerateAsync(IReadOnlyList<IModelMessage> messages, Func<string, Task> onChunk, CancellationToken cancellationToken = default);
}

/// <summary>
/// UC-05/UC-19/UC-23/UC-26/UC-27 に基づく契約です。
/// EN: 質問応答を実行する capability interface です。
/// [EN] Documents this public package API member. [JA] IQuestionAnsweringProvider の公開契約を定義します。
/// </summary>
/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.Providers.IQuestionAnsweringProvider']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.Providers.IQuestionAnsweringProvider']" />
public interface IQuestionAnsweringProvider
{
    /// <summary>
    /// EN: 単一の質問に対して回答を生成します。
    /// [EN] Documents this public package API member. [JA] AnswerAsync 操作を実行します。
    /// </summary>
    /// <param name="question">[EN] Documents this public package API member. [JA] 質問テキスト question パラメーターです。</param>
    /// <param name="context">[EN] Documents this public package API member. [JA] オプショナルなコンテキスト context パラメーターです。</param>
    /// <param name="cancellationToken">[EN] Documents this public package API member. [JA] キャンセルトークン キャンセル通知を監視するトークンです。</param>
    /// <returns>[EN] Documents this public package API member. [JA] 回答テキスト 結果を返します。</returns>
    Task<string> AnswerAsync(string question, string? context = null, CancellationToken cancellationToken = default);
}

/// <summary>
/// UC-05/UC-19/UC-23/UC-26/UC-27 に基づく契約です。
/// LLMモデル推論プロバイダーを定義する互換合成インターフェースです。
/// EN: チャット、テキスト生成、推論など、LLMベースの推論機能を提供します。
/// [EN] Documents this public package API member. [JA] IModelProvider の公開契約を定義します。
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
