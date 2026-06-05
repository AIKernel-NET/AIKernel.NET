namespace AIKernel.Dtos.Hatl;

public sealed record HatlBlockMacRequest(
    string LedgerId,
    long SequenceNumber,
    string PreviousEntryHash,
    string PayloadHash,
    IReadOnlyDictionary<string, string> AssociatedData);
