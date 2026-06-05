namespace AIKernel.Abstractions.DynamicSlm;

using AIKernel.Dtos.DynamicSlm;

public interface IDynamicSlmPipelineContextFactory
{
    DynamicSlmPipelineContext Create(
        DynamicSlmModelAbi modelAbi,
        DynamicSlmPipelineMetadata metadata);
}
