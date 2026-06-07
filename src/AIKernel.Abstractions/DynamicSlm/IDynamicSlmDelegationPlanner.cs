namespace AIKernel.Abstractions.DynamicSlm;

using AIKernel.Dtos.DynamicSlm;

/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.DynamicSlm.IDynamicSlmDelegationPlanner']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.DynamicSlm.IDynamicSlmDelegationPlanner']" />
public interface IDynamicSlmDelegationPlanner
{
    /// <summary>Executes the PlanDelegationAsync operation on the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで PlanDelegationAsync 操作を実行します。</summary>
    ValueTask<DynamicSlmDelegationRequest> PlanDelegationAsync(
        DynamicSlmCapabilityGap gap,
        DynamicSlmPipelineContext context,
        CancellationToken cancellationToken = default);
}
