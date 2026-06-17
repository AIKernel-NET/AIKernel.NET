namespace AIKernel.Abstractions.DynamicSlm;

using AIKernel.Dtos.DynamicSlm;

/// <summary>[EN] Documents this public package API member. [JA] IDynamicSlmDistillationPlanner contract を定義します。</summary>
/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.DynamicSlm.IDynamicSlmDistillationPlanner']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.DynamicSlm.IDynamicSlmDistillationPlanner']" />
public interface IDynamicSlmDistillationPlanner
{
    /// <summary>EN: Executes the PlanDistillationAsync operation on the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで PlanDistillationAsync 操作を実行します。</summary>
    ValueTask<DynamicSlmDistillationPlan> PlanDistillationAsync(
        DynamicSlmCapabilityGap gap,
        string teacherModelId,
        IReadOnlyList<string> verifiedReplayLogHashes,
        CancellationToken cancellationToken = default);
}
