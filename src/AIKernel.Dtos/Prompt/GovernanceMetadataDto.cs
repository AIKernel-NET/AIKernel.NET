namespace AIKernel.Dtos.Prompt;

/// <summary>
/// GovernanceMetadataDto の契約を定義します。
/// JA: GovernanceMetadataDto の公開契約を定義します。
/// </summary>
/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Dtos.Prompt.GovernanceMetadataDto']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Dtos.Prompt.GovernanceMetadataDto']" />
public sealed record GovernanceMetadataDto
{
    /// <include file="docs.en.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Prompt.GovernanceMetadataDto.Issuer']" />
    /// <include file="docs.ja.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Prompt.GovernanceMetadataDto.Issuer']" />
    public required string Issuer { get; init; }
    /// <include file="docs.en.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Prompt.GovernanceMetadataDto.SignerId']" />
    /// <include file="docs.ja.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Prompt.GovernanceMetadataDto.SignerId']" />
    public required string SignerId { get; init; }
    /// <include file="docs.en.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Prompt.GovernanceMetadataDto.HashAlgorithm']" />
    /// <include file="docs.ja.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Prompt.GovernanceMetadataDto.HashAlgorithm']" />
    public string HashAlgorithm { get; init; } = "SHA256";
    /// <include file="docs.en.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Prompt.GovernanceMetadataDto.Hash']" />
    /// <include file="docs.ja.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Prompt.GovernanceMetadataDto.Hash']" />
    public required string Hash { get; init; }
    /// <include file="docs.en.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Prompt.GovernanceMetadataDto.Signature']" />
    /// <include file="docs.ja.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Prompt.GovernanceMetadataDto.Signature']" />
    public required string Signature { get; init; }
    /// <include file="docs.en.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Prompt.GovernanceMetadataDto.SignedAt']" />
    /// <include file="docs.ja.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Prompt.GovernanceMetadataDto.SignedAt']" />
    public DateTime SignedAt { get; init; }
}



