namespace AIKernel.Abstractions.DynamicSlm;

using AIKernel.Dtos.DynamicSlm;
using AIKernel.Dtos.Execution;
using AIKernel.Dtos.Rules;

/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.DynamicSlm.IDynamicSlmCapabilityGraphEvolutionPlanner']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.DynamicSlm.IDynamicSlmCapabilityGraphEvolutionPlanner']" />
public interface IDynamicSlmCapabilityGraphEvolutionPlanner
{
    /// <summary>Executes the PlanGraphEvolutionAsync operation on the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで PlanGraphEvolutionAsync 操作を実行します。</summary>
    ValueTask<DynamicSlmCapabilityGraphUpdatePlan> PlanGraphEvolutionAsync(
        DynamicSlmModelAbi modelAbi,
        IReadOnlyList<DynamicSlmCapabilityGap> capabilityGaps,
        IReadOnlyList<ReplayDump> verifiedReplayTraces,
        RuleEvaluationContext? governanceContext = null,
        CancellationToken cancellationToken = default);
}
