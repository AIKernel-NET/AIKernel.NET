namespace AIKernel.Dtos.Tokenization;

/// <summary>
/// EN: Token の契約を定義します。
/// EN: Documentation for public API. JA: Token の公開契約を定義します。
/// </summary>
/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Dtos.Tokenization.Token']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Dtos.Tokenization.Token']" />
public sealed class Token
{
    /// <summary>EN: Documentation for public API. JA: Value を取得します。</summary>
    /// <include file="docs.en.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Tokenization.Token.Value']" />
    /// <include file="docs.ja.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Tokenization.Token.Value']" />
    public required string Value { get; init; }
    /// <summary>EN: Documentation for public API. JA: TokenId を取得します。</summary>
    /// <include file="docs.en.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Tokenization.Token.TokenId']" />
    /// <include file="docs.ja.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Tokenization.Token.TokenId']" />
    public required int TokenId { get; init; }
    /// <summary>EN: Documentation for public API. JA: StartPosition を取得します。</summary>
    /// <include file="docs.en.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Tokenization.Token.StartPosition']" />
    /// <include file="docs.ja.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Tokenization.Token.StartPosition']" />
    public int StartPosition { get; init; }
    /// <summary>EN: Documentation for public API. JA: EndPosition を取得します。</summary>
    /// <include file="docs.en.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Tokenization.Token.EndPosition']" />
    /// <include file="docs.ja.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Tokenization.Token.EndPosition']" />
    public int EndPosition { get; init; }
    /// <summary>EN: Documentation for public API. JA: TokenType を取得します。</summary>
    /// <include file="docs.en.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Tokenization.Token.TokenType']" />
    /// <include file="docs.ja.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Tokenization.Token.TokenType']" />
    public string? TokenType { get; init; }
}




