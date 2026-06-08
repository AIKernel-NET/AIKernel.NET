namespace AIKernel.Abstractions.Context;

using AIKernel.Dtos.Context;
using AIKernel.Dtos.Rom;

/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.Context.IContextAssemblyGovernancePolicy']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.Context.IContextAssemblyGovernancePolicy']" />
public interface IContextAssemblyGovernancePolicy
{
    /// <summary>Executes the EvaluateAsync operation on the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで EvaluateAsync 操作を実行します。</summary>
    ValueTask<ContextAssemblyDecision> EvaluateAsync(
        RomSnapshot rom,
        ContextAssemblyScope scope,
        CancellationToken cancellationToken = default);
}
