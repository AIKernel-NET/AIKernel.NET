namespace AIKernel.Dtos.Rom;

/// <summary>EN: Documentation for public API. JA: RomSignatureSnapshot を表します。</summary>
/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Dtos.Rom.RomSignatureSnapshot']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Dtos.Rom.RomSignatureSnapshot']" />
public sealed record RomSignatureSnapshot(
    string Algorithm,
    string ExpectedHash,
    string ActualHash,
    bool IsVerified);