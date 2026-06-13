using AIKernel.Dtos.Context;
using AIKernel.Abstractions.Models;

namespace AIKernel.Abstractions.Execution;

/// <summary>
/// UC-02/UC-04/UC-09/UC-20/UC-22 に基づく契約です。
/// 出力整形インターフェース。
/// 生のロジックと Expression コンテキストから最終出力を生成します。
/// これは Two‑Phase 実行の第 2 ステップです。
/// JA: IOutputPolisher の公開契約を定義します。
/// </summary>
/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.Execution.IOutputPolisher']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.Execution.IOutputPolisher']" />
public interface IOutputPolisher
{
    /// <summary>
    /// このOutputPolisherが要求するモデル能力ベクトル。
    /// 通常は LinguisticFluidity と StructuralIntegrity が高いベクトルが要求されます。
    /// JA: RenderAsync 操作を実行します。
    /// </summary>
    ModelCapacityVector RequiredCapacity { get; }

    /// <summary>
    /// 生のロジックを Expression コンテキストに基づいて整形・レンダリングします。
    /// JA: RenderAsync 操作を実行します。
    /// </summary>
    /// <param name="logic">推論結果の中間表現 JA: logic パラメーターです。</param>
    /// <param name="expressionContext">表現・整形の文脈 JA: expressionContext パラメーターです。</param>
    /// <param name="ct">キャンセルトークン JA: ct パラメーターです。</param>
    /// <returns>最終出力（整形済みテキスト） JA: 結果を返します。</returns>
    Task<string> RenderAsync(RawLogic logic, ExpressionContext expressionContext, CancellationToken ct = default);
}


