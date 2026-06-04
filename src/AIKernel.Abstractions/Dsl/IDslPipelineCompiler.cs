namespace AIKernel.Abstractions.Dsl;

using AIKernel.Dtos.Dsl;

public interface IDslPipelineCompiler
{
    Task<IKernelPipeline> CompileAsync(
        DslDocument document,
        CancellationToken cancellationToken = default);
}
