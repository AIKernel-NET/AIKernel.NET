namespace AIKernel.Dtos.Hatl;

public sealed record HatlRatchetStepResult(
    string DerivationAlgorithm,
    string NextKeyCommitment,
    IReadOnlyDictionary<string, string> Metadata);
