namespace AIKernel.Dtos.Hatl;

public sealed record HatlPublicAnchorReceipt(
    string AnchorId,
    string PublicationUri,
    string PublishedHash,
    DateTimeOffset PublishedAt,
    IReadOnlyDictionary<string, string> Metadata);
