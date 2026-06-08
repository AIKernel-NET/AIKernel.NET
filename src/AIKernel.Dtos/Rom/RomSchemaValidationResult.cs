namespace AIKernel.Dtos.Rom;

/// <summary>
/// RomSchemaValidationResult の契約を定義します。
/// </summary>
/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Dtos.Rom.RomSchemaValidationResult']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Dtos.Rom.RomSchemaValidationResult']" />
public sealed record RomSchemaValidationResult
{
    /// <include file="docs.en.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Rom.RomSchemaValidationResult.IsValid']" />
    /// <include file="docs.ja.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Rom.RomSchemaValidationResult.IsValid']" />
    public required bool IsValid { get; init; }
    /// <include file="docs.en.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Rom.RomSchemaValidationResult.Message']" />
    /// <include file="docs.ja.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Rom.RomSchemaValidationResult.Message']" />
    public required string Message { get; init; }
    /// <include file="docs.en.xml" path="doc/members/member[@name='M:AIKernel.Dtos.Rom.RomSchemaValidationResult.List&lt;string&gt;']" />
    /// <include file="docs.ja.xml" path="doc/members/member[@name='M:AIKernel.Dtos.Rom.RomSchemaValidationResult.List&lt;string&gt;']" />
    public IReadOnlyList<string> Issues { get; init; } = new List<string>();
}




