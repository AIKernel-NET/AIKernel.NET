using AIKernel.Enums;

namespace AIKernel.Dtos.DynamicSlm;

/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Dtos.DynamicSlm.DynamicSlmPayloadDescriptor']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Dtos.DynamicSlm.DynamicSlmPayloadDescriptor']" />
public sealed record DynamicSlmPayloadDescriptor(
    string PayloadId,
    DynamicSlmPayloadKind Kind,
    string Uri,
    string Sha256,
    long SizeBytes,
    string Quantization,
    IReadOnlyDictionary<string, string> Metadata);
