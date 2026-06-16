namespace AIKernel.Dtos.Rom;

/// <summary>
/// EN: RomLinkageValidationResult の契約を定義します。
/// EN: Documentation for public API. JA: RomLinkageValidationResult の公開契約を定義します。
/// </summary>
/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Dtos.Rom.RomLinkageValidationResult']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Dtos.Rom.RomLinkageValidationResult']" />
public sealed record RomLinkageValidationResult
{
    /// <summary>EN: Documentation for public API. JA: AllLinksResolvable を取得します。</summary>
    /// <include file="docs.en.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Rom.RomLinkageValidationResult.AllLinksResolvable']" />
    /// <include file="docs.ja.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Rom.RomLinkageValidationResult.AllLinksResolvable']" />
    public required bool AllLinksResolvable { get; init; }
    /// <summary>EN: Documentation for public API. JA: Message を取得します。</summary>
    /// <include file="docs.en.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Rom.RomLinkageValidationResult.Message']" />
    /// <include file="docs.ja.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Rom.RomLinkageValidationResult.Message']" />
    public required string Message { get; init; }
    /// <summary>EN: Documentation for public API. JA: UnresolvedLinks を実行します。</summary>
    /// <include file="docs.en.xml" path="doc/members/member[@name='M:AIKernel.Dtos.Rom.RomLinkageValidationResult.List&lt;string&gt;']" />
    /// <include file="docs.ja.xml" path="doc/members/member[@name='M:AIKernel.Dtos.Rom.RomLinkageValidationResult.List&lt;string&gt;']" />
    public IReadOnlyList<string> UnresolvedLinks { get; init; } = new List<string>();
}




