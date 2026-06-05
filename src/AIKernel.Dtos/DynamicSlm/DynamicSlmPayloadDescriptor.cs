using AIKernel.Enums;

namespace AIKernel.Dtos.DynamicSlm;

public sealed record DynamicSlmPayloadDescriptor(
    string PayloadId,
    DynamicSlmPayloadKind Kind,
    string Uri,
    string Sha256,
    long SizeBytes,
    string Quantization,
    IReadOnlyDictionary<string, string> Metadata);
