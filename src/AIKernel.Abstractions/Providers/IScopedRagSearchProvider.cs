using AIKernel.Dtos.Retrieval;

namespace AIKernel.Abstractions.Providers;

/// <summary>Opt-in scope capability. Callers requiring scope must resolve this interface.</summary>
public interface IScopedRagSearchProvider
{
    /// <summary>Search only the current eligible data. An unsupported scope fails closed.</summary>
    Task<ScopedRagResult> SearchAsync(ScopedRagRequest request, CancellationToken cancellationToken = default);
}
