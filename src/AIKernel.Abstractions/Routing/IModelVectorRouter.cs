namespace AIKernel.Abstractions.Routing;

using AIKernel.Abstractions.Models;

/// <summary>
/// EN: UC-03/UC-22 に基づく IModelVectorRouter の契約を定義します。
/// [EN] Documents this public package API member. [JA] IModelVectorRouter の公開契約を定義します。
/// </summary>
/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.Routing.IModelVectorRouter']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.Routing.IModelVectorRouter']" />
public interface IModelVectorRouter
{
    /// <summary>EN: Executes the RouteAsync operation on the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで RouteAsync 操作を実行します。</summary>
    Task<ModelRoutingDecision> RouteAsync(
        ModelCapacityVector requiredCapacity,
        RuleEvaluationContext ruleEvaluationContext,
        IExecutionConstraints executionConstraints,
        CancellationToken cancellationToken = default);

    /// <summary>EN: Executes the SelectOptimalModel operation on the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで SelectOptimalModel 操作を実行します。</summary>
    ModelType SelectOptimalModel(ModelCapacityVector requirement, IEnumerable<ModelType> candidates);

    /// <summary>EN: Executes the RankModels operation on the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで RankModels 操作を実行します。</summary>
    IEnumerable<(ModelType Model, float Score)> RankModels(
        ModelCapacityVector requirement,
        IEnumerable<ModelType> candidates);

    /// <summary>EN: Executes the VerifyDeterministicRouting operation on the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで VerifyDeterministicRouting 操作を実行します。</summary>
    bool VerifyDeterministicRouting(ModelRoutingDecision decision1, ModelRoutingDecision decision2);
}


