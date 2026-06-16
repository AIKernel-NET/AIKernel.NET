using AIKernel.Enums;

namespace AIKernel.Dtos.Hatl;

/// <summary>[EN] Documents this public package API member. [JA] HatlDigitalDeed を表します。</summary>
/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Dtos.Hatl.HatlDigitalDeed']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Dtos.Hatl.HatlDigitalDeed']" />
public sealed record HatlDigitalDeed(
    string DeedId,
    string SubjectId,
    HatlDeedStatus Status,
    string Issuer,
    string AnchorHash,
    DateTimeOffset EffectiveAt,
    DateTimeOffset? ExpiresAt,
    IReadOnlyDictionary<string, string> Metadata);
