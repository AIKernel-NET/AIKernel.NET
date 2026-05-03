namespace AIKernel.Abstractions;

public interface IPromptRuleSet
{
    string Version { get; }
    IReadOnlyList<string> Rules { get; }
    IReadOnlyList<string> Evaluate(string promptContent);
}

public interface IPromptHashCalculator
{
    string Algorithm { get; }
    string ComputeHash(string promptContent);
    bool Verify(string promptContent, string expectedHash);
}

public interface IPromptSigner
{
    string SignerId { get; }
    string Algorithm { get; }
    Task<string> SignAsync(string promptContent, CancellationToken ct = default);
}

public interface IPromptSignatureProvider
{
    Task<string> GetPublicKeyAsync(string keyId, CancellationToken ct = default);
    Task<IReadOnlyDictionary<string, string>> GetKeyMetadataAsync(string keyId, CancellationToken ct = default);
}

public interface IPromptVerifier
{
    bool FailClosed { get; }
    Task<bool> VerifyAsync(string promptContent, string signature, CancellationToken ct = default);
    Task<bool> VerifyWithKeyAsync(string promptContent, string signature, string keyId, CancellationToken ct = default);
}

public interface IPromptRepository
{
    Task<string?> GetAsync(string promptId, CancellationToken ct = default);
    Task PutAsync(string promptId, string content, CancellationToken ct = default);
    Task<IReadOnlyDictionary<string, string>> GetMetadataAsync(string promptId, CancellationToken ct = default);
}

public interface IPromptValidator
{
    string ValidatorVersion { get; }
    bool FailClosed { get; }
    Task<IReadOnlyList<string>> ValidateAsync(string promptContent, IPromptRuleSet rules, CancellationToken ct = default);
}
