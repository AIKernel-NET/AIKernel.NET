namespace AIKernel.Abstractions.Models;

/// <summary>
/// UC-22 に基づく契約です。
/// 実行制約に応じて動的に値が変わる評価軸を表現するインターフェースです。
/// NPU環境では、基数やメモリ制約によって各軸の値が非線形に変化するため、
/// 静的な ICapacityAxis では不十分です。
/// JA: IDynamicCapacityAxis の公開契約を定義します。
/// </summary>
/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.Models.IDynamicCapacityAxis']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.Models.IDynamicCapacityAxis']" />
public interface IDynamicCapacityAxis : ICapacityAxis
{
    /// <summary>
    /// 指定された実行制約の下で、この評価軸の値を動的に算出します。
    /// JA: ResolveValue 操作を実行します。
    /// </summary>
    /// <param name="constraints">実行制約条件 JA: constraints パラメーターです。</param>
    /// <returns>制約下での評価軸の値（0.0 ~ 1.0） JA: 結果を返します。</returns>
    float ResolveValue(IExecutionConstraints constraints);

    /// <summary>
    /// この評価軸が与えられた制約下で意味のある値を持つか判定します。
    /// 例：「INT8量子化忠実性」は、QuantizationLevel が "INT8" でない場合は
    /// 意味を持たないため false を返す。
    /// JA: IsApplicable 操作を実行します。
    /// </summary>
    /// <param name="constraints">実行制約条件 JA: constraints パラメーターです。</param>
    /// <returns>この軸が制約下で有効な場合は true JA: 結果を返します。</returns>
    bool IsApplicable(IExecutionConstraints constraints);
}

