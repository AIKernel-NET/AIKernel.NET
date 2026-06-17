namespace AIKernel.Abstractions.DynamicSlm;

using AIKernel.Abstractions.Models;
using AIKernel.Dtos.DynamicSlm;

/// <summary>[EN] Documents this public package API member. [JA] IDynamicSlmScheduler contract を定義します。</summary>
/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.DynamicSlm.IDynamicSlmScheduler']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.DynamicSlm.IDynamicSlmScheduler']" />
public interface IDynamicSlmScheduler
{
    /// <summary>EN: Executes the PlanPlacementAsync operation on the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで PlanPlacementAsync 操作を実行します。</summary>
    ValueTask<DynamicSlmPlacementPlan> PlanPlacementAsync(
        DynamicSlmResolvedSubgraph subgraph,
        IExecutionConstraints executionConstraints,
        CancellationToken cancellationToken = default);
}
