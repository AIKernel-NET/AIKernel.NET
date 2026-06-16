namespace AIKernel.Abstractions.DynamicSlm;

using AIKernel.Dtos.DynamicSlm;
using AIKernel.Dtos.Rules;

/// <summary>EN: Documentation for public API. JA: IDynamicSlmCompatibilityVerifier contract を定義します。</summary>
/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.DynamicSlm.IDynamicSlmCompatibilityVerifier']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.DynamicSlm.IDynamicSlmCompatibilityVerifier']" />
public interface IDynamicSlmCompatibilityVerifier
{
    /// <summary>EN: Executes the VerifyCompatibilityAsync operation on the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで VerifyCompatibilityAsync 操作を実行します。</summary>
    ValueTask<DynamicSlmCompatibilityResult> VerifyCompatibilityAsync(
        DynamicSlmModelAbi modelAbi,
        DynamicSlmResolvedSubgraph subgraph,
        RuleEvaluationContext? governanceContext = null,
        CancellationToken cancellationToken = default);
}
