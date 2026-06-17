namespace AIKernel.Abstractions.Models;

/// <summary>
/// UC-22 に基づく契約です。
/// 動的次元を持つモデル能力ベクトルを表現するインターフェースです。
/// 従来の固定プロパティベースの ModelCapacityVector とは異なり、
/// EN: 実行制約に応じて次元数や各軸の値が動的に変わります。
/// [EN] Documents this public package API member. [JA] IDynamicCapacityVector の公開契約を定義します。
/// </summary>
/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.Models.IDynamicCapacityVector']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.Models.IDynamicCapacityVector']" />
public interface IDynamicCapacityVector
{
    /// <summary>
    /// EN: このベクトルの一意識別子を取得します。
    /// [EN] Documents this public package API member. [JA] GetRegisteredAxes 操作を実行します。
    /// </summary>
    string VectorId { get; }

    /// <summary>
    /// EN: 現在登録されているすべての評価軸を取得します。
    /// [EN] Documents this public package API member. [JA] GetRegisteredAxes 操作を実行します。
    /// </summary>
    /// <returns>[EN] Documents this public package API member. [JA] 評価軸の列挙 結果を返します。</returns>
    IEnumerable<IDynamicCapacityAxis> GetRegisteredAxes();

    /// <summary>
    /// 指定された制約下での具体的な能力ベクトルを解決します。
    /// EN: 結果は IDictionary&lt;string, float&gt; で、AxisId をキーとして値をマッピングします。
    /// [EN] Documents this public package API member. [JA] ResolveCapacities 操作を実行します。
    /// </summary>
    /// <param name="constraints">[EN] Documents this public package API member. [JA] 実行制約条件 constraints パラメーターです。</param>
    /// <returns>[EN] Documents this public package API member. [JA] 制約下での能力マップ 結果を返します。</returns>
    IDictionary<string, float> ResolveCapacities(IExecutionConstraints constraints);

    /// <summary>
    /// EN: 指定された評価軸の値を取得します。
    /// [EN] Documents this public package API member. [JA] GetAxisValue 操作を実行します。
    /// </summary>
    /// <param name="constraints">[EN] Documents this public package API member. [JA] 実行制約条件 constraints パラメーターです。</param>
    /// <param name="axisId">[EN] Documents this public package API member. [JA] 評価軸ID axisId パラメーターです。</param>
    /// <returns>[EN] Documents this public package API member. [JA] 軸の値（0.0 ~ 1.0） 結果を返します。</returns>
    float GetAxisValue(IExecutionConstraints constraints, string axisId);

    /// <summary>
    /// EN: このベクトルに評価軸を登録します。
    /// [EN] Documents this public package API member. [JA] RegisterAxis 操作を実行します。
    /// </summary>
    /// <param name="axis">[EN] Documents this public package API member. [JA] 登録する評価軸 axis パラメーターです。</param>
    void RegisterAxis(IDynamicCapacityAxis axis);

    /// <summary>
    /// 指定された基数（Cardinality）での能力ベクトルを取得します。
    /// EN: 便宜メソッド。
    /// [EN] Documents this public package API member. [JA] GetCapacitiesForCardinality 操作を実行します。
    /// </summary>
    /// <param name="cardinality">[EN] Documents this public package API member. [JA] 基数 cardinality パラメーターです。</param>
    /// <param name="quantizationLevel">[EN] Documents this public package API member. [JA] 量子化レベル quantizationLevel パラメーターです。</param>
    /// <returns>[EN] Documents this public package API member. [JA] 能力マップ 結果を返します。</returns>
    IDictionary<string, float> GetCapacitiesForCardinality(int cardinality, string quantizationLevel);
}

