namespace AIKernel.Abstractions.Execution;

/// <summary>
/// UC-02/UC-04/UC-09/UC-20/UC-22 に基づく IStructurePlanner の契約を定義します。
/// </summary>
public interface IStructurePlanner
{
    string Name { get; }
    Task<IReadOnlyList<string>> PlanAsync(Context.IContextCollection orchestrationContext, CancellationToken ct = default);
    double EstimateComplexity(Context.IContextCollection orchestrationContext);
}




