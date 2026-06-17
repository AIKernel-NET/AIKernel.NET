namespace AIKernel.Dtos.Tokenization;

/// <summary>
/// EN: TokenizerStatistics の契約を定義します。
/// [EN] Documents this public package API member. [JA] TokenizerStatistics の公開契約を定義します。
/// </summary>
/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Dtos.Tokenization.TokenizerStatistics']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Dtos.Tokenization.TokenizerStatistics']" />
public sealed class TokenizerStatistics
{
    /// <summary>[EN] Documents this public package API member. [JA] VocabularySize を取得します。</summary>
    /// <include file="docs.en.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Tokenization.TokenizerStatistics.VocabularySize']" />
    /// <include file="docs.ja.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Tokenization.TokenizerStatistics.VocabularySize']" />
    public required int VocabularySize { get; init; }
    /// <summary>[EN] Documents this public package API member. [JA] SupportedModels を実行します。</summary>
    /// <include file="docs.en.xml" path="doc/members/member[@name='M:AIKernel.Dtos.Tokenization.TokenizerStatistics.Empty&lt;string&gt;']" />
    /// <include file="docs.ja.xml" path="doc/members/member[@name='M:AIKernel.Dtos.Tokenization.TokenizerStatistics.Empty&lt;string&gt;']" />
    public IReadOnlyList<string> SupportedModels { get; init; } = Array.Empty<string>();
    /// <summary>[EN] Documents this public package API member. [JA] Version を取得します。</summary>
    /// <include file="docs.en.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Tokenization.TokenizerStatistics.Version']" />
    /// <include file="docs.ja.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Tokenization.TokenizerStatistics.Version']" />
    public string? Version { get; init; }
    /// <summary>[EN] Documents this public package API member. [JA] AverageTokenLength を取得します。</summary>
    /// <include file="docs.en.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Tokenization.TokenizerStatistics.AverageTokenLength']" />
    /// <include file="docs.ja.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Tokenization.TokenizerStatistics.AverageTokenLength']" />
    public double AverageTokenLength { get; init; }
    /// <summary>[EN] Documents this public package API member. [JA] MaxTokenLength を取得します。</summary>
    /// <include file="docs.en.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Tokenization.TokenizerStatistics.MaxTokenLength']" />
    /// <include file="docs.ja.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Tokenization.TokenizerStatistics.MaxTokenLength']" />
    public int MaxTokenLength { get; init; }
}




