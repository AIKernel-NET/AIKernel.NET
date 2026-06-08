namespace AIKernel.Dtos.Hatl;

/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Dtos.Hatl.HatlPublicAnchorReceipt']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Dtos.Hatl.HatlPublicAnchorReceipt']" />
public sealed record HatlPublicAnchorReceipt(
    string AnchorId,
    string PublicationUri,
    string PublishedHash,
    DateTimeOffset PublishedAt,
    IReadOnlyDictionary<string, string> Metadata);
