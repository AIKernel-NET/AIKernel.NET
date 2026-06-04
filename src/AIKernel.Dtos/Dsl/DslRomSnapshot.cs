namespace AIKernel.Dtos.Dsl;

public sealed record DslRomSnapshot(
    DslRomMetadata Metadata,
    string JsonDsl);
