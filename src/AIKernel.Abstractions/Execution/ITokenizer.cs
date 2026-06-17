namespace AIKernel.Abstractions.Execution;

using AIKernel.Abstractions.Models;

/// <summary>
/// UC-02/UC-04/UC-09/UC-20/UC-22 に基づく契約です。
/// EN: トークナイザーの識別情報を公開する capability interface です。
/// [EN] Documents this public package API member. [JA] ITokenizerIdentity の公開契約を定義します。
/// </summary>
/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.Execution.ITokenizerIdentity']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.Execution.ITokenizerIdentity']" />
public interface ITokenizerIdentity
{
    /// <summary>
    /// EN: トークナイザーのプロファイルIDを取得します。
    /// [EN] Documents this public package API member. [JA] このメンバー の公開契約を定義します。
    /// </summary>
    string TokenizerProfileId { get; }

    /// <summary>
    /// EN: トークナイザーの名前を取得します。
    /// [EN] Documents this public package API member. [JA] ITextTokenizer の公開契約を定義します。
    /// </summary>
    string Name { get; }
}

/// <summary>
/// UC-02/UC-04/UC-09/UC-20/UC-22 に基づく契約です。
/// EN: テキストをトークン化する capability interface です。
/// [EN] Documents this public package API member. [JA] ITextTokenizer の公開契約を定義します。
/// </summary>
/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.Execution.ITextTokenizer']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.Execution.ITextTokenizer']" />
public interface ITextTokenizer
{
    /// <summary>
    /// EN: テキストをトークン化します。
    /// [EN] Documents this public package API member. [JA] Tokenize 操作を実行します。
    /// </summary>
    /// <param name="text">[EN] Documents this public package API member. [JA] トークン化するテキスト text パラメーターです。</param>
    /// <returns>[EN] Documents this public package API member. [JA] トークンリスト 結果を返します。</returns>
    IReadOnlyList<Token> Tokenize(string text);
}

/// <summary>
/// UC-02/UC-04/UC-09/UC-20/UC-22 に基づく契約です。
/// EN: テキストのトークン数を計算する capability interface です。
/// [EN] Documents this public package API member. [JA] ITokenCounter の公開契約を定義します。
/// </summary>
/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.Execution.ITokenCounter']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.Execution.ITokenCounter']" />
public interface ITokenCounter
{
    /// <summary>
    /// EN: テキストのトークン数を計算します。
    /// [EN] Documents this public package API member. [JA] CountTokens 操作を実行します。
    /// </summary>
    /// <param name="text">[EN] Documents this public package API member. [JA] テキスト text パラメーターです。</param>
    /// <returns>[EN] Documents this public package API member. [JA] トークン数 結果を返します。</returns>
    int CountTokens(string text);
}

/// <summary>
/// UC-02/UC-04/UC-09/UC-20/UC-22 に基づく契約です。
/// EN: トークンをテキストへデコードする capability interface です。
/// [EN] Documents this public package API member. [JA] ITokenDecoder の公開契約を定義します。
/// </summary>
/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.Execution.ITokenDecoder']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.Execution.ITokenDecoder']" />
public interface ITokenDecoder
{
    /// <summary>
    /// EN: トークンをテキストにデコードします。
    /// [EN] Documents this public package API member. [JA] Decode 操作を実行します。
    /// </summary>
    /// <param name="tokens">[EN] Documents this public package API member. [JA] トークンリスト tokens パラメーターです。</param>
    /// <returns>[EN] Documents this public package API member. [JA] デコードされたテキスト 結果を返します。</returns>
    string Decode(IReadOnlyList<Token> tokens);
}

/// <summary>
/// UC-02/UC-04/UC-09/UC-20/UC-22 に基づく契約です。
/// EN: トークナイザーの統計情報を公開する capability interface です。
/// [EN] Documents this public package API member. [JA] ITokenizerStatisticsProvider の公開契約を定義します。
/// </summary>
/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.Execution.ITokenizerStatisticsProvider']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.Execution.ITokenizerStatisticsProvider']" />
public interface ITokenizerStatisticsProvider
{
    /// <summary>
    /// EN: トークナイザーの統計情報を取得します。
    /// [EN] Documents this public package API member. [JA] GetStatistics 操作を実行します。
    /// </summary>
    /// <returns>[EN] Documents this public package API member. [JA] 統計情報 結果を返します。</returns>
    TokenizerStatistics GetStatistics();
}

/// <summary>
/// UC-02/UC-04/UC-09/UC-20/UC-22 に基づく契約です。
/// EN: モデル対応可否を判定する capability interface です。
/// [EN] Documents this public package API member. [JA] ITokenizerModelSupport の公開契約を定義します。
/// </summary>
/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.Execution.ITokenizerModelSupport']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.Execution.ITokenizerModelSupport']" />
public interface ITokenizerModelSupport
{
    /// <summary>
    /// EN: トークナイザーが特定のモデルをサポートしているかどうかを確認します。
    /// [EN] Documents this public package API member. [JA] SupportsModel 操作を実行します。
    /// </summary>
    /// <param name="modelName">[EN] Documents this public package API member. [JA] モデル名 modelName パラメーターです。</param>
    /// <returns>[EN] Documents this public package API member. [JA] サポートしている場合は true 結果を返します。</returns>
    bool SupportsModel(string modelName);
}

/// <summary>
/// UC-02/UC-04/UC-09/UC-20/UC-22 に基づく契約です。
/// EN: 物理基数を見積もる capability interface です。
/// [EN] Documents this public package API member. [JA] IPhysicalCardinalityAdvisor の公開契約を定義します。
/// </summary>
/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.Execution.IPhysicalCardinalityAdvisor']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.Execution.IPhysicalCardinalityAdvisor']" />
public interface IPhysicalCardinalityAdvisor
{
    /// <summary>
    /// 論理的なトークン数を物理基数に変換します。
    /// EN: NPU最適化のためのパディングを考慮します。
    /// [EN] Documents this public package API member. [JA] GetPhysicalCardinality 操作を実行します。
    /// </summary>
    /// <param name="logicalTokenCount">[EN] Documents this public package API member. [JA] 論理的なトークン数 logicalTokenCount パラメーターです。</param>
    /// <param name="deviceType">[EN] Documents this public package API member. [JA] デバイスタイプ（"NPU", "GPU", "CPU"等） deviceType パラメーターです。</param>
    /// <returns>[EN] Documents this public package API member. [JA] NPU最適化後の物理基数 結果を返します。</returns>
    int GetPhysicalCardinality(int logicalTokenCount, string deviceType);
}

/// <summary>
/// UC-02/UC-04/UC-09/UC-20/UC-22 に基づく契約です。
/// EN: Padding 情報を取得する capability interface です。
/// [EN] Documents this public package API member. [JA] IPaddingInfoProvider の公開契約を定義します。
/// </summary>
/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.Execution.IPaddingInfoProvider']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.Execution.IPaddingInfoProvider']" />
public interface IPaddingInfoProvider
{
    /// <summary>
    /// EN: 指定された物理基数でのパディング情報を取得します。
    /// [EN] Documents this public package API member. [JA] GetPaddingInfo 操作を実行します。
    /// </summary>
    /// <param name="logicalTokenCount">[EN] Documents this public package API member. [JA] 論理的なトークン数 logicalTokenCount パラメーターです。</param>
    /// <param name="physicalCardinality">[EN] Documents this public package API member. [JA] 物理基数 physicalCardinality パラメーターです。</param>
    /// <returns>[EN] Documents this public package API member. [JA] パディング情報 結果を返します。</returns>
    PaddingInfo GetPaddingInfo(int logicalTokenCount, int physicalCardinality);
}

/// <summary>
/// UC-02/UC-04/UC-09/UC-20/UC-22 に基づく契約です。
/// トークナイザーの互換合成インターフェースを定義します。
/// テキストトークン化と統計情報の管理を行います。
/// EN: NPU環境での物理基数（パディング）対応に対応しています。
/// [EN] Documents this public package API member. [JA] ITokenizer の公開契約を定義します。
/// </summary>
/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.Execution.ITokenizer']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.Execution.ITokenizer']" />
public interface ITokenizer :
    ITokenizerIdentity,
    ITextTokenizer,
    ITokenCounter,
    ITokenDecoder,
    ITokenizerStatisticsProvider,
    ITokenizerModelSupport,
    IPhysicalCardinalityAdvisor,
    IPaddingInfoProvider
{
}
