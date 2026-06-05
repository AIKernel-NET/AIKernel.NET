namespace AIKernel.Abstractions.DynamicSlm;

using AIKernel.Dtos.DynamicSlm;
using AIKernel.Enums;

public interface IDynamicSlmPipelineStep<TInput, TOutput>
{
    DynamicSlmPipelineStage Stage { get; }

    DynamicSlmPipelineResult<TOutput> Execute(TInput input);
}
