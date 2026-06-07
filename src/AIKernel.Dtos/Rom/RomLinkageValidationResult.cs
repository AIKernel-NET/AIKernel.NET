namespace AIKernel.Dtos.Rom;

/// <summary>
/// RomLinkageValidationResult の契約を定義します。
/// </summary>
/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Dtos.Rom.RomLinkageValidationResult']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Dtos.Rom.RomLinkageValidationResult']" />
public sealed record RomLinkageValidationResult
{
    /// <include file="docs.en.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Rom.RomLinkageValidationResult.AllLinksResolvable']" />
    /// <include file="docs.ja.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Rom.RomLinkageValidationResult.AllLinksResolvable']" />
    public required bool AllLinksResolvable { get; init; }
    /// <include file="docs.en.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Rom.RomLinkageValidationResult.Message']" />
    /// <include file="docs.ja.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Rom.RomLinkageValidationResult.Message']" />
    public required string Message { get; init; }
    /// <include file="docs.en.xml" path="doc/members/member[@name='M:AIKernel.Dtos.Rom.RomLinkageValidationResult.List&lt;string&gt;']" />
    /// <include file="docs.ja.xml" path="doc/members/member[@name='M:AIKernel.Dtos.Rom.RomLinkageValidationResult.List&lt;string&gt;']" />
    public IReadOnlyList<string> UnresolvedLinks { get; init; } = new List<string>();
}




