using AIKernel.Enums;

namespace AIKernel.Dtos.DynamicSlm;

public sealed record DynamicSlmLoadedPayload(
    string PayloadId,
    DynamicSlmPayloadKind Kind,
    string MaterializedHandle,
    string Sha256,
    IReadOnlyDictionary<string, string> Metadata);
