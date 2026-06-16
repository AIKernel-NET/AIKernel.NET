namespace AIKernel.Dtos.Hatl;

/// <summary>[EN] Documents this public package API member. [JA] HatlBlockMacRequest を表します。</summary>
/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Dtos.Hatl.HatlBlockMacRequest']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Dtos.Hatl.HatlBlockMacRequest']" />
public sealed record HatlBlockMacRequest(
    string LedgerId,
    long SequenceNumber,
    string PreviousEntryHash,
    string PayloadHash,
    IReadOnlyDictionary<string, string> AssociatedData);
