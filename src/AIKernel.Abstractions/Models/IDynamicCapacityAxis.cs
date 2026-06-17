namespace AIKernel.Abstractions.Models;

/// <summary>
/// UC-22 に基づく契約です。
/// 実行制約に応じて動的に値が変わる評価軸を表現するインターフェースです。
/// NPU環境では、基数やメモリ制約によって各軸の値が非線形に変化するため、
/// EN: 静的な ICapacityAxis では不十分です。
/// [EN] Documents this public package API member. [JA] IDynamicCapacityAxis の公開契約を定義します。
/// </summary>
/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.Models.IDynamicCapacityAxis']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.Models.IDynamicCapacityAxis']" />
public interface IDynamicCapacityAxis : ICapacityAxis
{
    /// <summary>
    /// EN: 指定された実行制約の下で、この評価軸の値を動的に算出します。
    /// [EN] Documents this public package API member. [JA] ResolveValue 操作を実行します。
    /// </summary>
    /// <param name="constraints">[EN] Documents this public package API member. [JA] 実行制約条件 constraints パラメーターです。</param>
    /// <returns>[EN] Documents this public package API member. [JA] 制約下での評価軸の値（0.0 ~ 1.0） 結果を返します。</returns>
    float ResolveValue(IExecutionConstraints constraints);

    /// <summary>
    /// この評価軸が与えられた制約下で意味のある値を持つか判定します。
    /// 例：「INT8量子化忠実性」は、QuantizationLevel が "INT8" でない場合は
    /// EN: 意味を持たないため false を返す。
    /// [EN] Documents this public package API member. [JA] IsApplicable 操作を実行します。
    /// </summary>
    /// <param name="constraints">[EN] Documents this public package API member. [JA] 実行制約条件 constraints パラメーターです。</param>
    /// <returns>[EN] Documents this public package API member. [JA] この軸が制約下で有効な場合は true 結果を返します。</returns>
    bool IsApplicable(IExecutionConstraints constraints);
}

