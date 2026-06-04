namespace AIKernel.Abstractions.Dsl;

using AIKernel.Dtos.Dsl;
using AIKernel.Vfs;

public interface IDslRomStore
{
    Task<DslRomMetadata> SaveDslAsRomAsync(
        IVfsSession session,
        string @namespace,
        string name,
        string jsonDsl,
        DateTimeOffset createdAtUtc,
        string? expectedRomHash = null,
        CancellationToken cancellationToken = default);

    Task<DslRomMetadata> LoadDslRomAsync(
        IVfsSession session,
        string @namespace,
        string name,
        DateTimeOffset createdAtUtc,
        string expectedRomHash,
        CancellationToken cancellationToken = default);
}
