using AIKernel.Enums;

namespace AIKernel.Dtos.DynamicSlm;

/// <summary>EN: Documentation for public API. JA: DynamicSlmThoughtArtifact を表します。</summary>
/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Dtos.DynamicSlm.DynamicSlmThoughtArtifact']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Dtos.DynamicSlm.DynamicSlmThoughtArtifact']" />
public sealed record DynamicSlmThoughtArtifact(
    string ArtifactId,
    DynamicSlmReasoningTraceFormat Format,
    string Intent,
    IReadOnlyList<string> IntermediateSteps,
    IReadOnlyList<string> Decisions,
    string? OutputHash,
    string? ReplayLogHash,
    IReadOnlyDictionary<string, string> Metadata);
