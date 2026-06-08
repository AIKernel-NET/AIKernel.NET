namespace AIKernel.Dtos.Tokenization;

/// <summary>
/// TokenizerStatistics の契約を定義します。
/// </summary>
/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Dtos.Tokenization.TokenizerStatistics']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Dtos.Tokenization.TokenizerStatistics']" />
public sealed class TokenizerStatistics
{
    /// <include file="docs.en.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Tokenization.TokenizerStatistics.VocabularySize']" />
    /// <include file="docs.ja.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Tokenization.TokenizerStatistics.VocabularySize']" />
    public required int VocabularySize { get; init; }
    /// <include file="docs.en.xml" path="doc/members/member[@name='M:AIKernel.Dtos.Tokenization.TokenizerStatistics.Empty&lt;string&gt;']" />
    /// <include file="docs.ja.xml" path="doc/members/member[@name='M:AIKernel.Dtos.Tokenization.TokenizerStatistics.Empty&lt;string&gt;']" />
    public IReadOnlyList<string> SupportedModels { get; init; } = Array.Empty<string>();
    /// <include file="docs.en.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Tokenization.TokenizerStatistics.Version']" />
    /// <include file="docs.ja.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Tokenization.TokenizerStatistics.Version']" />
    public string? Version { get; init; }
    /// <include file="docs.en.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Tokenization.TokenizerStatistics.AverageTokenLength']" />
    /// <include file="docs.ja.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Tokenization.TokenizerStatistics.AverageTokenLength']" />
    public double AverageTokenLength { get; init; }
    /// <include file="docs.en.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Tokenization.TokenizerStatistics.MaxTokenLength']" />
    /// <include file="docs.ja.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Tokenization.TokenizerStatistics.MaxTokenLength']" />
    public int MaxTokenLength { get; init; }
}




