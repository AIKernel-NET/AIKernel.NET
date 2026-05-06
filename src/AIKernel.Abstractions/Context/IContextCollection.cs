namespace AIKernel.Abstractions.Context;

/// <summary>
/// UC-06/UC-08 に基づく契約です。
/// コンテキスト断片の集合を管理するインターフェースです。
/// カテゴリ別アクセスと各フェーズ向けバッファ取得を提供します。
/// </summary>
public interface IContextCollection
{
    /// <summary>
    /// すべてのコンテキストフラグメントを取得します。
    /// </summary>
    /// <returns>コンテキストフラグメント一覧</returns>
    IEnumerable<ContextFragment> GetAll();

    /// <summary>
    /// 指定カテゴリに属するコンテキストフラグメントを取得します。
    /// </summary>
    /// <param name="category">対象カテゴリ</param>
    /// <returns>カテゴリに一致するコンテキストフラグメント一覧</returns>
    IEnumerable<ContextFragment> GetByCategory(ContextCategory category);

    /// <summary>
    /// Orchestration フェーズ向けバッファを取得します。
    /// </summary>
    /// <returns>Orchestration バッファ</returns>
    OrchestrationBuffer GetOrchestrationBuffer();

    /// <summary>
    /// Expression フェーズ向けバッファを取得します。
    /// </summary>
    /// <returns>Expression バッファ</returns>
    ExpressionBuffer GetExpressionBuffer();

    /// <summary>
    /// Material フェーズ向けバッファを取得します。
    /// </summary>
    /// <returns>Material バッファ</returns>
    MaterialBuffer GetMaterialBuffer();

    /// <summary>
    /// History フェーズ向けバッファを取得します。
    /// </summary>
    /// <returns>History バッファ</returns>
    HistoryBuffer GetHistoryBuffer();
}

