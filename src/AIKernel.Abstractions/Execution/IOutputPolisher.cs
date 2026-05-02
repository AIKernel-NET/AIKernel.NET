using AIKernel.Abstractions.Context;
using AIKernel.Abstractions.Models;

namespace AIKernel.Abstractions.Execution;

/// <summary>
/// 出力整形の文脈情報を保持する構造体。
/// Expression コンテキストに基づいて、スタイルやトーンを指定します。
/// </summary>
public readonly struct ExpressionContext
{
    /// <summary>
    /// Expression バッファを取得します。
    /// </summary>
    public ExpressionBuffer ExpressionBuffer { get; }

    /// <summary>
    /// ExpressionContext を初期化します。
    /// </summary>
    /// <param name="expressionBuffer">Expression バッファ</param>
    public ExpressionContext(ExpressionBuffer expressionBuffer)
    {
        ExpressionBuffer = expressionBuffer;
    }
}

/// <summary>
/// 出力整形インターフェース。
/// 生のロジックと Expression コンテキストから最終出力を生成します。
/// これは Two‑Phase 実行の第 2 ステップです。
/// </summary>
public interface IOutputPolisher
{
    /// <summary>
    /// このOutputPolisherが要求するモデル能力ベクトル。
    /// 通常は LinguisticFluidity と StructuralIntegrity が高いベクトルが要求されます。
    /// </summary>
    ModelCapacityVector RequiredCapacity { get; }

    /// <summary>
    /// 生のロジックを Expression コンテキストに基づいて整形・レンダリングします。
    /// </summary>
    /// <param name="logic">推論結果の中間表現</param>
    /// <param name="expressionContext">表現・整形の文脈</param>
    /// <param name="ct">キャンセルトークン</param>
    /// <returns>最終出力（整形済みテキスト）</returns>
    Task<string> RenderAsync(RawLogic logic, ExpressionContext expressionContext, CancellationToken ct = default);
}
