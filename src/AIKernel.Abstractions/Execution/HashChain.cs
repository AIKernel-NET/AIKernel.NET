namespace AIKernel.Abstractions.Execution;

public sealed record HashChain
{
    public required string StructureHash { get; init; }
    public required string GenerationHash { get; init; }
    public required string GenerationParentHash { get; init; }
    public required string PolishHash { get; init; }
    public required string PolishParentHash { get; init; }
    public string HashAlgorithm { get; init; } = "SHA256";

    public bool IsChainValid()
    {
        return !string.IsNullOrEmpty(StructureHash)
            && !string.IsNullOrEmpty(GenerationHash)
            && !string.IsNullOrEmpty(GenerationParentHash)
            && !string.IsNullOrEmpty(PolishHash)
            && !string.IsNullOrEmpty(PolishParentHash)
            && GenerationParentHash == StructureHash;
    }
}
