using AIKernel.Abstractions.Models;

namespace AIKernel.Abstractions.Execution;

/// <summary>
/// モデル選定と能力ベクトルルーティングの契約。
/// EPS-008: 決定論的スケジューリング（Deterministic Scheduling）に従い、
/// 各フェーズ開始前にモデル再評価を行い、選定根拠を ExecutionResult メタデータへ記録する。
/// </summary>
public interface IModelVectorRouter
{
    /// <summary>
    /// 要求能力ベクトルに基づいて最適なプロバイダを選定します。
    /// EPS-008: 選定根拠を メタデータとして返すこと。
    /// </summary>
    /// <param name="requiredCapacity">要求能力ベクトル</param>
    /// <param name="executionConstraints">実行時の制約条件</param>
    /// <param name="cancellationToken">キャンセルトークン</param>
    /// <returns>選定プロバイダのメタデータを含む ルーティング決定</returns>
    Task<ModelRoutingDecision> RouteAsync(
        ModelCapacityVector requiredCapacity,
        IExecutionConstraints executionConstraints,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// 同一入力でモデル選定が再現可能であることを検証します。
    /// 決定論的スケジューリング (EPS-008) の検証用。
    /// </summary>
    /// <param name="decision1">第1回目のルーティング決定</param>
    /// <param name="decision2">第2回目のルーティング決定</param>
    /// <returns>ルーティングが一致したかどうか</returns>
    bool VerifyDeterministicRouting(ModelRoutingDecision decision1, ModelRoutingDecision decision2);
}
