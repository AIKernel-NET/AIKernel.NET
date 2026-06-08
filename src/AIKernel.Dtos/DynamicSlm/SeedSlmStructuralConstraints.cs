using AIKernel.Enums;

namespace AIKernel.Dtos.DynamicSlm;

/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Dtos.DynamicSlm.SeedSlmStructuralConstraints']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Dtos.DynamicSlm.SeedSlmStructuralConstraints']" />
public sealed record SeedSlmStructuralConstraints(
    bool RequiresStructuralAdherence,
    bool RequiresContractFidelity,
    bool RequiresFailClosed,
    bool RequiresZeroSlop,
    DynamicSlmStrictOutputMode StrictOutputMode,
    DynamicSlmReasoningTraceFormat RequiredTraceFormat,
    IReadOnlyDictionary<string, string> Metadata);
