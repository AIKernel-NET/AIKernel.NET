using AIKernel.Enums;

namespace AIKernel.Dtos.DynamicSlm;

/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Dtos.DynamicSlm.DynamicSlmLoadedPayload']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Dtos.DynamicSlm.DynamicSlmLoadedPayload']" />
public sealed record DynamicSlmLoadedPayload(
    string PayloadId,
    DynamicSlmPayloadKind Kind,
    string MaterializedHandle,
    string Sha256,
    IReadOnlyDictionary<string, string> Metadata);
