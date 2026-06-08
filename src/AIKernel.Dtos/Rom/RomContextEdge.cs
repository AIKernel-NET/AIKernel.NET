namespace AIKernel.Dtos.Rom;

/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Dtos.Rom.RomContextEdge']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Dtos.Rom.RomContextEdge']" />
public sealed record RomContextEdge(
    RomId SourceRomId,
    RomId TargetRomId,
    string Kind);
