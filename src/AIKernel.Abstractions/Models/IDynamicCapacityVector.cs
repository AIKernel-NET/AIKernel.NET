namespace AIKernel.Abstractions.Models;

/// <summary>
/// UC-22 に基づく契約です。
/// 動的次元を持つモデル能力ベクトルを表現するインターフェースです。
/// 従来の固定プロパティベースの ModelCapacityVector とは異なり、
/// 実行制約に応じて次元数や各軸の値が動的に変わります。
/// </summary>
public interface IDynamicCapacityVector
{
    /// <summary>
    /// このベクトルの一意識別子を取得します。
    /// </summary>
    string VectorId { get; }

    /// <summary>
    /// 現在登録されているすべての評価軸を取得します。
    /// </summary>
    /// <returns>評価軸の列挙</returns>
    IEnumerable<IDynamicCapacityAxis> GetRegisteredAxes();

    /// <summary>
    /// 指定された制約下での具体的な能力ベクトルを解決します。
    /// 結果は IDictionary&lt;string, float&gt; で、AxisId をキーとして値をマッピングします。
    /// </summary>
    /// <param name="constraints">実行制約条件</param>
    /// <returns>制約下での能力マップ</returns>
    IDictionary<string, float> ResolveCapacities(IExecutionConstraints constraints);

    /// <summary>
    /// 指定された評価軸の値を取得します。
    /// </summary>
    /// <param name="constraints">実行制約条件</param>
    /// <param name="axisId">評価軸ID</param>
    /// <returns>軸の値（0.0 ~ 1.0）</returns>
    /// <exception cref="ArgumentException">AxisId が登録されていない場合</exception>
    float GetAxisValue(IExecutionConstraints constraints, string axisId);

    /// <summary>
    /// このベクトルに評価軸を登録します。
    /// </summary>
    /// <param name="axis">登録する評価軸</param>
    void RegisterAxis(IDynamicCapacityAxis axis);

    /// <summary>
    /// 指定された基数（Cardinality）での能力ベクトルを取得します。
    /// 便宜メソッド。
    /// </summary>
    /// <param name="cardinality">基数</param>
    /// <param name="quantizationLevel">量子化レベル</param>
    /// <returns>能力マップ</returns>
    IDictionary<string, float> GetCapacitiesForCardinality(int cardinality, string quantizationLevel);
}

