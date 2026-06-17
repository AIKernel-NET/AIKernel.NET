namespace AIKernel.Dtos.Hatl;

/// <summary>[EN] Documents this public package API member. [JA] HatlPublicAnchorReceipt を表します。</summary>
/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Dtos.Hatl.HatlPublicAnchorReceipt']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Dtos.Hatl.HatlPublicAnchorReceipt']" />
public sealed record HatlPublicAnchorReceipt(
    string AnchorId,
    string PublicationUri,
    string PublishedHash,
    DateTimeOffset PublishedAt,
    IReadOnlyDictionary<string, string> Metadata);
