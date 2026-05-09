using AIKernel.Dtos.Context;

namespace AIKernel.Contracts;

/// <summary>
/// 表現（Expression）契約を定義します。
/// 推論が完全に終了した後にのみ適用される、出力表現層の契約です。
/// 
/// 参照: 2.CONTEXT_ISOLATION_SPEC.jp.md
/// UC-04（生成と出力整形）
/// </summary>
public interface IExpressionContract
{
    /// <summary>
    /// 表現層のコンテキストを取得します。
    /// </summary>
    /// <returns>Expression コンテキスト</returns>
    ExpressionContextDto GetContext();

    /// <summary>
    /// 出力の文体を取得します。
    /// </summary>
    /// <returns>文体。未設定の場合は null。</returns>
    string? GetStyle();

    /// <summary>
    /// 説明用の例を取得します。
    /// 注意: これらは推論には混入しません。
    /// </summary>
    /// <returns>説明用の例一覧</returns>
    IReadOnlyList<string> GetExamples();

    /// <summary>
    /// 説明テンプレートを取得します。
    /// </summary>
    /// <returns>説明テンプレート。未設定の場合は null。</returns>
    string? GetDescriptionTemplate();

    /// <summary>
    /// 比喩・類推を取得します。
    /// </summary>
    /// <returns>比喩・類推一覧</returns>
    IReadOnlyList<string> GetAnalogies();
}

