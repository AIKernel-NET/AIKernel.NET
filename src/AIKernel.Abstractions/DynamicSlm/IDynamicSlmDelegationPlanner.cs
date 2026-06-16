namespace AIKernel.Abstractions.DynamicSlm;

using AIKernel.Dtos.DynamicSlm;

/// <summary>EN: Documentation for public API. JA: IDynamicSlmDelegationPlanner contract を定義します。</summary>
/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.DynamicSlm.IDynamicSlmDelegationPlanner']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.DynamicSlm.IDynamicSlmDelegationPlanner']" />
public interface IDynamicSlmDelegationPlanner
{
    /// <summary>EN: Executes the PlanDelegationAsync operation on the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで PlanDelegationAsync 操作を実行します。</summary>
    ValueTask<DynamicSlmDelegationRequest> PlanDelegationAsync(
        DynamicSlmCapabilityGap gap,
        DynamicSlmPipelineContext context,
        CancellationToken cancellationToken = default);
}
