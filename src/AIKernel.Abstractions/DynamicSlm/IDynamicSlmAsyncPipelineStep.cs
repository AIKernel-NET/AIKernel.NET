namespace AIKernel.Abstractions.DynamicSlm;

using AIKernel.Dtos.DynamicSlm;
using AIKernel.Enums;

public interface IDynamicSlmAsyncPipelineStep<TInput, TOutput>
{
    DynamicSlmPipelineStage Stage { get; }

    ValueTask<DynamicSlmPipelineResult<TOutput>> ExecuteAsync(
        TInput input,
        CancellationToken cancellationToken = default);
}
