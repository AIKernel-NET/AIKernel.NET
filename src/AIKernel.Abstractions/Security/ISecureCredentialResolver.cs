namespace AIKernel.Abstractions.Security;

/// <summary>Resolves configured secrets before using an application's provider options.</summary>
public interface ISecureCredentialResolver<TOptions> where TOptions : class, ISecureOptions
{
    ValueTask<TOptions> ResolveAsync(CancellationToken cancellationToken = default);
}
