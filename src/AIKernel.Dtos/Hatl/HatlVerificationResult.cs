using AIKernel.Enums;

namespace AIKernel.Dtos.Hatl;

/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Dtos.Hatl.HatlVerificationResult']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Dtos.Hatl.HatlVerificationResult']" />
public sealed record HatlVerificationResult(
    HatlVerificationStatus Status,
    string? AnchorId,
    string? VerifiedHash,
    string? FailureCode,
    IReadOnlyDictionary<string, string> Metadata);
