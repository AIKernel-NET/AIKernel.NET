namespace AIKernel.Dtos.Rom;

/// <summary>[EN] Documents this public package API member. [JA] RomSignatureVerificationResult を表します。</summary>
/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Dtos.Rom.RomSignatureVerificationResult']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Dtos.Rom.RomSignatureVerificationResult']" />
public sealed record RomSignatureVerificationResult(
    bool IsVerified,
    string Algorithm,
    string ExpectedHash,
    string ActualHash);