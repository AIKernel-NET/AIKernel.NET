namespace AIKernel.Abstractions.DynamicSlm;

using AIKernel.Dtos.DynamicSlm;
using AIKernel.Dtos.Rules;

public interface IDynamicSlmCompatibilityVerifier
{
    ValueTask<DynamicSlmCompatibilityResult> VerifyCompatibilityAsync(
        DynamicSlmModelAbi modelAbi,
        DynamicSlmResolvedSubgraph subgraph,
        RuleEvaluationContext? governanceContext = null,
        CancellationToken cancellationToken = default);
}
