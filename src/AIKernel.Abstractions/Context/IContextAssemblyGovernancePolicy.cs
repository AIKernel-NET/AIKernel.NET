namespace AIKernel.Abstractions.Context;

using AIKernel.Dtos.Context;
using AIKernel.Dtos.Rom;

public interface IContextAssemblyGovernancePolicy
{
    ValueTask<ContextAssemblyDecision> EvaluateAsync(
        RomSnapshot rom,
        ContextAssemblyScope scope,
        CancellationToken cancellationToken = default);
}
