namespace AIKernel.Abstractions.DynamicSlm;

using AIKernel.Dtos.DynamicSlm;
using AIKernel.Dtos.Execution;
using AIKernel.Dtos.Rules;

public interface IDynamicSlmCapabilityGraphEvolutionPlanner
{
    ValueTask<DynamicSlmCapabilityGraphUpdatePlan> PlanGraphEvolutionAsync(
        DynamicSlmModelAbi modelAbi,
        IReadOnlyList<DynamicSlmCapabilityGap> capabilityGaps,
        IReadOnlyList<ReplayDump> verifiedReplayTraces,
        RuleEvaluationContext? governanceContext = null,
        CancellationToken cancellationToken = default);
}
