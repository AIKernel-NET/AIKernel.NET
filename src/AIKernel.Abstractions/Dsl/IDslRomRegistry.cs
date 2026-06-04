namespace AIKernel.Abstractions.Dsl;

using AIKernel.Dtos.Dsl;

public interface IDslRomRegistry
{
    Task<DslRomMetadata> RegisterAsync(
        DslRomSnapshot snapshot,
        CancellationToken cancellationToken = default);

    bool Contains(string capabilityName);

    Task<DslRomSnapshot> ResolveAsync(
        string capabilityName,
        CancellationToken cancellationToken = default);
}
