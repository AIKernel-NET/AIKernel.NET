namespace AIKernel.Abstractions.Routing;

using AIKernel.Abstractions.Models;

/// <summary>
/// UC-03/UC-22 に基づく IModelVectorRouter の契約を定義します。
/// </summary>
public interface IModelVectorRouter
{
    Task<ModelRoutingDecision> RouteAsync(
        ModelCapacityVector requiredCapacity,
        RuleEvaluationContext ruleEvaluationContext,
        IExecutionConstraints executionConstraints,
        CancellationToken cancellationToken = default);

    ModelType SelectOptimalModel(ModelCapacityVector requirement, IEnumerable<ModelType> candidates);

    IEnumerable<(ModelType Model, float Score)> RankModels(
        ModelCapacityVector requirement,
        IEnumerable<ModelType> candidates);

    bool VerifyDeterministicRouting(ModelRoutingDecision decision1, ModelRoutingDecision decision2);
}


