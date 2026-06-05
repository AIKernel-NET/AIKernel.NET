namespace AIKernel.Abstractions.DynamicSlm;

using AIKernel.Dtos.DynamicSlm;
using AIKernel.Dtos.Rules;

public interface IDynamicSlmCapabilityGraphResolver
{
    ValueTask<DynamicSlmResolvedSubgraph> ResolveSubgraphAsync(
        DynamicSlmModelAbi modelAbi,
        IReadOnlyList<string> requiredCapabilityIds,
        RuleEvaluationContext? governanceContext = null,
        CancellationToken cancellationToken = default);
}
