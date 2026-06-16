namespace AIKernel.Abstractions.DynamicSlm;

using AIKernel.Dtos.DynamicSlm;
using AIKernel.Dtos.Rules;

/// <summary>[EN] Documents this public package API member. [JA] IDynamicSlmCapabilityGraphResolver contract を定義します。</summary>
/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.DynamicSlm.IDynamicSlmCapabilityGraphResolver']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.DynamicSlm.IDynamicSlmCapabilityGraphResolver']" />
public interface IDynamicSlmCapabilityGraphResolver
{
    /// <summary>EN: Executes the ResolveSubgraphAsync operation on the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで ResolveSubgraphAsync 操作を実行します。</summary>
    ValueTask<DynamicSlmResolvedSubgraph> ResolveSubgraphAsync(
        DynamicSlmModelAbi modelAbi,
        IReadOnlyList<string> requiredCapabilityIds,
        RuleEvaluationContext? governanceContext = null,
        CancellationToken cancellationToken = default);
}
