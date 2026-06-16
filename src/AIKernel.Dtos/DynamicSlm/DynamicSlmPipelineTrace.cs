using AIKernel.Enums;

namespace AIKernel.Dtos.DynamicSlm;

/// <summary>EN: Documentation for public API. JA: DynamicSlmPipelineTrace を表します。</summary>
/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Dtos.DynamicSlm.DynamicSlmPipelineTrace']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Dtos.DynamicSlm.DynamicSlmPipelineTrace']" />
public sealed record DynamicSlmPipelineTrace(
    DynamicSlmPipelineStage Stage,
    string StepId,
    string? ParentStepId,
    string? ReplayLogHash,
    IReadOnlyDictionary<string, string> Metadata);
