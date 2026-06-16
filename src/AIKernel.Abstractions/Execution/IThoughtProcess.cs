using AIKernel.Dtos.Context;
using AIKernel.Abstractions.Models;

namespace AIKernel.Abstractions.Execution;

/// <summary>
/// UC-02/UC-04/UC-09/UC-20/UC-22 に基づく契約です。
/// 思考プロセスのインターフェース。
/// Orchestration コンテキストから生のロジック（中間表現）を生成します。
/// EN: これは Two‑Phase 実行の第 1 ステップです。
/// [EN] Documents this public package API member. [JA] IThoughtProcess の公開契約を定義します。
/// </summary>
/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.Execution.IThoughtProcess']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.Execution.IThoughtProcess']" />
public interface IThoughtProcess
{
    /// <summary>
    /// このThoughtProcessが要求するモデル能力ベクトル。
    /// EN: 通常は ReasoningDepth が高いベクトルが要求されます。
    /// [EN] Documents this public package API member. [JA] BuildLogicAsync 操作を実行します。
    /// </summary>
    ModelCapacityVector RequiredCapacity { get; }

    /// <summary>
    /// EN: Orchestration コンテキストからロジックを構築します。
    /// [EN] Documents this public package API member. [JA] BuildLogicAsync 操作を実行します。
    /// </summary>
    /// <param name="orchestrationContext">[EN] Documents this public package API member. [JA] 制御・指示コンテキスト orchestrationContext パラメーターです。</param>
    /// <param name="ct">[EN] Documents this public package API member. [JA] キャンセルトークン ct パラメーターです。</param>
    /// <returns>[EN] Documents this public package API member. [JA] 生のロジック（推論結果の中間表現） 結果を返します。</returns>
    Task<RawLogic> BuildLogicAsync(IContextCollection orchestrationContext, CancellationToken ct = default);
}


