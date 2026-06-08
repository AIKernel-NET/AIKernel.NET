namespace AIKernel.Abstractions.Routing;

/// <summary>
/// UC-03/UC-22 に基づく ICapabilityRegistry の契約を定義します。
/// </summary>
/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.Routing.ICapabilityRegistry']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.Routing.ICapabilityRegistry']" />
public interface ICapabilityRegistry
{
    /// <summary>Executes the RegisterCapabilityAsync operation on the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで RegisterCapabilityAsync 操作を実行します。</summary>
    ValueTask RegisterCapabilityAsync(
        string providerId,
        ModelCapacityVector capacityVector,
        CancellationToken cancellationToken = default);

    /// <summary>Executes the GetCapabilityAsync operation on the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで GetCapabilityAsync 操作を実行します。</summary>
    ValueTask<ModelCapacityVector?> GetCapabilityAsync(
        string providerId,
        CancellationToken cancellationToken = default);

    /// <summary>Executes the ResolveCandidatesAsync operation on the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで ResolveCandidatesAsync 操作を実行します。</summary>
    ValueTask<IReadOnlyList<string>> ResolveCandidatesAsync(
        RuleEvaluationContext context,
        CancellationToken cancellationToken = default);
}


