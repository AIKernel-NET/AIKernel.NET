using AIKernel.Enums;

namespace AIKernel.Dtos.DynamicSlm;

/// <summary>[EN] Documents this public package API member. [JA] SeedSlmOutputDisciplinePolicy を表します。</summary>
/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Dtos.DynamicSlm.SeedSlmOutputDisciplinePolicy']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Dtos.DynamicSlm.SeedSlmOutputDisciplinePolicy']" />
public sealed record SeedSlmOutputDisciplinePolicy(
    DynamicSlmStrictOutputMode Mode,
    bool RequireThoughtArtifactBeforeFinalOutput,
    bool RejectNaturalLanguageSlop,
    bool FailClosedOnSchemaDrift,
    string OutputSchemaHash,
    IReadOnlyDictionary<string, string> Metadata);
