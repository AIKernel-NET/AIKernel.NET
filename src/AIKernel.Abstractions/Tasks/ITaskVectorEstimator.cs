namespace AIKernel.Abstractions.Tasks;

using AIKernel.Dtos.Context;
using AIKernel.Abstractions.Models;

/// <summary>
/// UC-29 に基づく契約です。
/// 目的と制約から必要なモデル能力ベクトルを推定するインターフェースです。
/// RAGとの連携を通じてタスク要求を分析し、最適なモデル選定をサポートします。
/// JA: ITaskVectorEstimator の公開契約を定義します。
/// </summary>
/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.Tasks.ITaskVectorEstimator']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.Tasks.ITaskVectorEstimator']" />
public interface ITaskVectorEstimator
{
    /// <summary>
    /// 目的と制約から、どの程度の能力が必要かを自動推定します。
    /// JA: EstimateAsync 操作を実行します。
    /// </summary>
    /// <param name="purpose">タスクの目的 JA: purpose パラメーターです。</param>
    /// <param name="constraints">制約条件のリスト（RAGコンテキストなど） JA: constraints パラメーターです。</param>
    /// <param name="cancellationToken">キャンセルトークン JA: キャンセル通知を監視するトークンです。</param>
    /// <returns>推定された要求ベクトル JA: 結果を返します。</returns>
    Task<ModelCapacityVector> EstimateAsync(
        Purpose purpose,
        IEnumerable<ContextFragment> constraints,
        CancellationToken cancellationToken = default);
}


