namespace AIKernel.Abstractions.Security;

public interface ISecureCredentialProvider
{
    ValueTask<string> GetSecretAsync(
        string key,
        CancellationToken cancellationToken = default);
}