namespace AIKernel.Abstractions.Governance.ChatChain;

/// <summary>
/// Computes the deterministic hash for a chat turn from canonical content and the previous turn hash.
/// </summary>
public interface IChatTurnSemanticHasher
{
    string ComputeHash(string canonicalContent, string previousHash);
}
