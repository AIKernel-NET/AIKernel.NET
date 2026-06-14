namespace AIKernel.Abstractions.Models;

/// <summary>
/// UC-22 に基づく契約です。
/// 動的次元を持つモデル能力ベクトルを表現するインターフェースです。
/// 従来の固定プロパティベースの ModelCapacityVector とは異なり、
/// 実行制約に応じて次元数や各軸の値が動的に変わります。
/// JA: IDynamicCapacityVector の公開契約を定義します。
/// </summary>
/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.Models.IDynamicCapacityVector']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.Models.IDynamicCapacityVector']" />
public interface IDynamicCapacityVector
{
    /// <summary>
    /// このベクトルの一意識別子を取得します。
    /// JA: GetRegisteredAxes 操作を実行します。
    /// </summary>
    string VectorId { get; }

    /// <summary>
    /// 現在登録されているすべての評価軸を取得します。
    /// JA: GetRegisteredAxes 操作を実行します。
    /// </summary>
    /// <returns>評価軸の列挙 JA: 結果を返します。</returns>
    IEnumerable<IDynamicCapacityAxis> GetRegisteredAxes();

    /// <summary>
    /// 指定された制約下での具体的な能力ベクトルを解決します。
    /// 結果は IDictionary&lt;string, float&gt; で、AxisId をキーとして値をマッピングします。
    /// JA: ResolveCapacities 操作を実行します。
    /// </summary>
    /// <param name="constraints">実行制約条件 JA: constraints パラメーターです。</param>
    /// <returns>制約下での能力マップ JA: 結果を返します。</returns>
    IDictionary<string, float> ResolveCapacities(IExecutionConstraints constraints);

    /// <summary>
    /// 指定された評価軸の値を取得します。
    /// JA: GetAxisValue 操作を実行します。
    /// </summary>
    /// <param name="constraints">実行制約条件 JA: constraints パラメーターです。</param>
    /// <param name="axisId">評価軸ID JA: axisId パラメーターです。</param>
    /// <returns>軸の値（0.0 ~ 1.0） JA: 結果を返します。</returns>
    float GetAxisValue(IExecutionConstraints constraints, string axisId);

    /// <summary>
    /// このベクトルに評価軸を登録します。
    /// JA: RegisterAxis 操作を実行します。
    /// </summary>
    /// <param name="axis">登録する評価軸 JA: axis パラメーターです。</param>
    void RegisterAxis(IDynamicCapacityAxis axis);

    /// <summary>
    /// 指定された基数（Cardinality）での能力ベクトルを取得します。
    /// 便宜メソッド。
    /// JA: GetCapacitiesForCardinality 操作を実行します。
    /// </summary>
    /// <param name="cardinality">基数 JA: cardinality パラメーターです。</param>
    /// <param name="quantizationLevel">量子化レベル JA: quantizationLevel パラメーターです。</param>
    /// <returns>能力マップ JA: 結果を返します。</returns>
    IDictionary<string, float> GetCapacitiesForCardinality(int cardinality, string quantizationLevel);
}

