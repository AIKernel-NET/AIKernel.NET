namespace AIKernel.Abstractions.DynamicSlm;

using AIKernel.Dtos.DynamicSlm;

public interface IDynamicSlmPipelineBuilder
{
    IDynamicSlmPipelineBuilder AddStep<TInput, TOutput>(
        IDynamicSlmAsyncPipelineStep<TInput, TOutput> step);

    IDynamicSlmAsyncPipeline Build(
        DynamicSlmPipelineMetadata metadata);
}
