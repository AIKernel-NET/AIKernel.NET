namespace AIKernel.Abstractions.DynamicSlm;

using AIKernel.Dtos.DynamicSlm;

public interface IDynamicSlmAsyncPipeline
{
    ValueTask<DynamicSlmPipelineResult<DynamicSlmPipelineContext>> ExecuteAsync(
        DynamicSlmPipelineContext context,
        CancellationToken cancellationToken = default);
}
