namespace AIKernel.Abstractions.DynamicSlm;

using AIKernel.Dtos.DynamicSlm;

public interface IDynamicSlmModelAbiProvider
{
    ValueTask<DynamicSlmModelAbi?> GetModelAbiAsync(
        string modelId,
        CancellationToken cancellationToken = default);
}
