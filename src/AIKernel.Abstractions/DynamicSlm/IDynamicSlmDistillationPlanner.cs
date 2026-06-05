namespace AIKernel.Abstractions.DynamicSlm;

using AIKernel.Dtos.DynamicSlm;

public interface IDynamicSlmDistillationPlanner
{
    ValueTask<DynamicSlmDistillationPlan> PlanDistillationAsync(
        DynamicSlmCapabilityGap gap,
        string teacherModelId,
        IReadOnlyList<string> verifiedReplayLogHashes,
        CancellationToken cancellationToken = default);
}
