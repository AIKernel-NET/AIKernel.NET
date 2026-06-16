namespace AIKernel.Abstractions.Governance;

using AIKernel.Dtos.Governance;

/// <summary>EN: Documentation for public API. JA: ICriticalOperationGate contract を定義します。</summary>
/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.Governance.ICriticalOperationGate']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.Governance.ICriticalOperationGate']" />
public interface ICriticalOperationGate
{
    /// <summary>EN: Executes the EvaluateAsync operation on the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで EvaluateAsync 操作を実行します。</summary>
    ValueTask<CriticalOperationGateResult> EvaluateAsync(
        CriticalOperationProfile profile,
        CancellationToken cancellationToken = default);
}
