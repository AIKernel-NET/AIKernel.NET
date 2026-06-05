using AIKernel.Enums;

namespace AIKernel.Dtos.DynamicSlm;

public sealed record SeedSlmOutputDisciplinePolicy(
    DynamicSlmStrictOutputMode Mode,
    bool RequireThoughtArtifactBeforeFinalOutput,
    bool RejectNaturalLanguageSlop,
    bool FailClosedOnSchemaDrift,
    string OutputSchemaHash,
    IReadOnlyDictionary<string, string> Metadata);
