namespace AIKernel.Dtos.Rom;

/// <summary>EN: Documentation for public API. JA: RomContextEdge を表します。</summary>
/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Dtos.Rom.RomContextEdge']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Dtos.Rom.RomContextEdge']" />
public sealed record RomContextEdge(
    RomId SourceRomId,
    RomId TargetRomId,
    string Kind);
