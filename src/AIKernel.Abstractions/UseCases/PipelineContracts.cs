namespace AIKernel.Abstractions.UseCases;

public interface IPipelineStep
{
    string StepId { get; }
    IReadOnlyList<string> DependsOn { get; }
    Task<AIKernel.Dtos.Execution.ExecutionResult> ExecuteAsync(IKernelContext context, CancellationToken ct = default);
}

public interface IPipelineOrchestrator
{
    string Name { get; }
    Task<AIKernel.Dtos.Execution.ExecutionResult> RunAsync(IEnumerable<IPipelineStep> steps, IKernelContext context, CancellationToken ct = default);
    void Validate(IEnumerable<IPipelineStep> steps);
}

public interface IStructurePlanner
{
    string Name { get; }
    Task<IReadOnlyList<string>> PlanAsync(Context.IContextCollection orchestrationContext, CancellationToken ct = default);
    double EstimateComplexity(Context.IContextCollection orchestrationContext);
}
