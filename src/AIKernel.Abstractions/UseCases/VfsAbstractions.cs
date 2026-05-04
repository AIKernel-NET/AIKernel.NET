namespace AIKernel.Abstractions.UseCases;

public interface IVfsCredentials
{
    string CredentialType { get; }
    IReadOnlyDictionary<string, string> Values { get; }
}

public interface IVfsSession : IAsyncDisposable
{
    string SessionId { get; }
    DateTimeOffset CreatedAtUtc { get; }
}

public interface IVfsProvider
{
    string ProviderId { get; }
    string Name { get; }
    Task<IVfsSession> OpenSessionAsync(IVfsCredentials credentials);
    Task<bool> IsAvailableAsync();
    Task<VfsProviderHealth> GetHealthAsync();
}
