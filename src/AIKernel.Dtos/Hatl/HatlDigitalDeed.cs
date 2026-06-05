using AIKernel.Enums;

namespace AIKernel.Dtos.Hatl;

public sealed record HatlDigitalDeed(
    string DeedId,
    string SubjectId,
    HatlDeedStatus Status,
    string Issuer,
    string AnchorHash,
    DateTimeOffset EffectiveAt,
    DateTimeOffset? ExpiresAt,
    IReadOnlyDictionary<string, string> Metadata);
