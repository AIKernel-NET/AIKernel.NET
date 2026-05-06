using AIKernel.Dtos.Context;
using AIKernel.Abstractions.Models;

namespace AIKernel.Abstractions.Execution;

/// <summary>
/// UC-02/UC-04/UC-09/UC-20/UC-22 に基づく契約です。
/// 思考プロセスのインターフェース。
/// Orchestration コンテキストから生のロジック（中間表現）を生成します。
/// これは Two‑Phase 実行の第 1 ステップです。
/// </summary>
public interface IThoughtProcess
{
    /// <summary>
    /// このThoughtProcessが要求するモデル能力ベクトル。
    /// 通常は ReasoningDepth が高いベクトルが要求されます。
    /// </summary>
    ModelCapacityVector RequiredCapacity { get; }

    /// <summary>
    /// Orchestration コンテキストからロジックを構築します。
    /// </summary>
    /// <param name="orchestrationContext">制御・指示コンテキスト</param>
    /// <param name="ct">キャンセルトークン</param>
    /// <returns>生のロジック（推論結果の中間表現）</returns>
    Task<RawLogic> BuildLogicAsync(IContextCollection orchestrationContext, CancellationToken ct = default);
}


