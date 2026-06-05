namespace AIKernel.Abstractions.DynamicSlm;

using AIKernel.Dtos.DynamicSlm;

public interface IDynamicSlmModuleRegistry
{
    ValueTask<DynamicSlmAdmissionResult> RegisterAsync(
        DynamicSlmModelAbi modelAbi,
        CancellationToken cancellationToken = default);

    ValueTask<DynamicSlmModelAbi?> ResolveAsync(
        string modelId,
        CancellationToken cancellationToken = default);

    ValueTask<IReadOnlyList<DynamicSlmModelAbi>> ListAsync(
        string? capabilityId = null,
        CancellationToken cancellationToken = default);
}
