namespace AIKernel.Abstractions;

using AIKernel.Abstractions.Context;
using AIKernel.Abstractions.Models;

/// <summary>
/// 目的と制約から必要なモデル能力ベクトルを推定するインターフェースです。
/// RAGとの連携を通じてタスク要求を分析し、最適なモデル選定をサポートします。
/// </summary>
public interface ITaskVectorEstimator
{
    /// <summary>
    /// 目的と制約から、どの程度の能力が必要かを自動推定します。
    /// </summary>
    /// <param name="purpose">タスクの目的</param>
    /// <param name="constraints">制約条件のリスト（RAGコンテキストなど）</param>
    /// <param name="cancellationToken">キャンセルトークン</param>
    /// <returns>推定された要求ベクトル</returns>
    /// <exception cref="ArgumentNullException">purpose または constraints が null の場合</exception>
    Task<ModelCapacityVector> EstimateAsync(
        Purpose purpose,
        IEnumerable<ContextFragment> constraints,
        CancellationToken cancellationToken = default);
}
