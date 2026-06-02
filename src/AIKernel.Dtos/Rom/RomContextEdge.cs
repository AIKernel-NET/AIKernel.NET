namespace AIKernel.Dtos.Rom;

public sealed record RomContextEdge(
    RomId SourceRomId,
    RomId TargetRomId,
    string Kind);
