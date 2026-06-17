namespace AIKernel.Dtos.Rom;

/// <summary>[EN] Documents this public package API member. [JA] RomRelationSnapshot を表します。</summary>
/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Dtos.Rom.RomRelationSnapshot']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Dtos.Rom.RomRelationSnapshot']" />
public sealed record RomRelationSnapshot(
    string TargetRomId,
    string Kind);