using AIKernel.Enums;

namespace AIKernel.Dtos.Hatl;

/// <summary>EN: Documentation for public API. JA: HatlVerificationResult を表します。</summary>
/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Dtos.Hatl.HatlVerificationResult']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Dtos.Hatl.HatlVerificationResult']" />
public sealed record HatlVerificationResult(
    HatlVerificationStatus Status,
    string? AnchorId,
    string? VerifiedHash,
    string? FailureCode,
    IReadOnlyDictionary<string, string> Metadata);
