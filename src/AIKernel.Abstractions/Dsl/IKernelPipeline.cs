namespace AIKernel.Abstractions.Dsl;

using AIKernel.Dtos.Dsl;

public interface IKernelPipeline
{
    Task<DslPipelineExecutionResult> ExecuteAsync(
        DslPipelineExecutionContext context,
        CancellationToken cancellationToken = default);
}
