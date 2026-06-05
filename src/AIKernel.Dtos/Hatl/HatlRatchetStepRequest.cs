namespace AIKernel.Dtos.Hatl;

public sealed record HatlRatchetStepRequest(
    string LedgerId,
    long SequenceNumber,
    string CurrentKeyCommitment,
    string ContextHash,
    IReadOnlyDictionary<string, string> Metadata);
