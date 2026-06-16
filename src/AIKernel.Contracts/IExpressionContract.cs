using AIKernel.Dtos.Context;

namespace AIKernel.Contracts;

/// <summary>
/// 表現（Expression）契約を定義します。
/// 推論が完全に終了した後にのみ適用される、出力表現層の契約です。
/// 
/// 参照: 2.CONTEXT_ISOLATION_SPEC.jp.md
/// EN: UC-04（生成と出力整形）
/// EN: Documentation for public API. JA: IExpressionContract の公開契約を定義します。
/// </summary>
/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Contracts.IExpressionContract']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Contracts.IExpressionContract']" />
public interface IExpressionContract
{
    /// <summary>
    /// EN: 表現層のコンテキストを取得します。
    /// EN: Documentation for public API. JA: GetContext 操作を実行します。
    /// </summary>
    /// <returns>EN: Documentation for public API. JA: Expression コンテキスト 結果を返します。</returns>
    ExpressionContextDto GetContext();

    /// <summary>
    /// EN: 出力の文体を取得します。
    /// EN: Documentation for public API. JA: GetStyle 操作を実行します。
    /// </summary>
    /// <returns>EN: Documentation for public API. JA: 文体。未設定の場合は null。 結果を返します。</returns>
    string? GetStyle();

    /// <summary>
    /// 説明用の例を取得します。
    /// EN: 注意: これらは推論には混入しません。
    /// EN: Documentation for public API. JA: GetExamples 操作を実行します。
    /// </summary>
    /// <returns>EN: Documentation for public API. JA: 説明用の例一覧 結果を返します。</returns>
    IReadOnlyList<string> GetExamples();

    /// <summary>
    /// EN: 説明テンプレートを取得します。
    /// EN: Documentation for public API. JA: GetDescriptionTemplate 操作を実行します。
    /// </summary>
    /// <returns>EN: Documentation for public API. JA: 説明テンプレート。未設定の場合は null。 結果を返します。</returns>
    string? GetDescriptionTemplate();

    /// <summary>
    /// EN: 比喩・類推を取得します。
    /// EN: Documentation for public API. JA: GetAnalogies 操作を実行します。
    /// </summary>
    /// <returns>EN: Documentation for public API. JA: 比喩・類推一覧 結果を返します。</returns>
    IReadOnlyList<string> GetAnalogies();
}

