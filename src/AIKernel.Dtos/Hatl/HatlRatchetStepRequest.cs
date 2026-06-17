namespace AIKernel.Dtos.Hatl;

/// <summary>[EN] Documents this public package API member. [JA] HatlRatchetStepRequest を表します。</summary>
/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Dtos.Hatl.HatlRatchetStepRequest']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Dtos.Hatl.HatlRatchetStepRequest']" />
public sealed record HatlRatchetStepRequest(
    string LedgerId,
    long SequenceNumber,
    string CurrentKeyCommitment,
    string ContextHash,
    IReadOnlyDictionary<string, string> Metadata);
