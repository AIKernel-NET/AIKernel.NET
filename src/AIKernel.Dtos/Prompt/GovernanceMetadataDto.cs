namespace AIKernel.Dtos.Prompt;

/// <summary>
/// EN: GovernanceMetadataDto の契約を定義します。
/// [EN] Documents this public package API member. [JA] GovernanceMetadataDto の公開契約を定義します。
/// </summary>
/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Dtos.Prompt.GovernanceMetadataDto']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Dtos.Prompt.GovernanceMetadataDto']" />
public sealed record GovernanceMetadataDto
{
    /// <summary>[EN] Documents this public package API member. [JA] Issuer を取得します。</summary>
    /// <include file="docs.en.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Prompt.GovernanceMetadataDto.Issuer']" />
    /// <include file="docs.ja.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Prompt.GovernanceMetadataDto.Issuer']" />
    public required string Issuer { get; init; }
    /// <summary>[EN] Documents this public package API member. [JA] SignerId を取得します。</summary>
    /// <include file="docs.en.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Prompt.GovernanceMetadataDto.SignerId']" />
    /// <include file="docs.ja.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Prompt.GovernanceMetadataDto.SignerId']" />
    public required string SignerId { get; init; }
    /// <summary>[EN] Documents this public package API member. [JA] HashAlgorithm を取得します。</summary>
    /// <include file="docs.en.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Prompt.GovernanceMetadataDto.HashAlgorithm']" />
    /// <include file="docs.ja.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Prompt.GovernanceMetadataDto.HashAlgorithm']" />
    public string HashAlgorithm { get; init; } = "SHA256";
    /// <summary>[EN] Documents this public package API member. [JA] Hash を取得します。</summary>
    /// <include file="docs.en.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Prompt.GovernanceMetadataDto.Hash']" />
    /// <include file="docs.ja.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Prompt.GovernanceMetadataDto.Hash']" />
    public required string Hash { get; init; }
    /// <summary>[EN] Documents this public package API member. [JA] Signature を取得します。</summary>
    /// <include file="docs.en.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Prompt.GovernanceMetadataDto.Signature']" />
    /// <include file="docs.ja.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Prompt.GovernanceMetadataDto.Signature']" />
    public required string Signature { get; init; }
    /// <summary>[EN] Documents this public package API member. [JA] SignedAt を取得します。</summary>
    /// <include file="docs.en.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Prompt.GovernanceMetadataDto.SignedAt']" />
    /// <include file="docs.ja.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Prompt.GovernanceMetadataDto.SignedAt']" />
    public DateTime SignedAt { get; init; }
}



