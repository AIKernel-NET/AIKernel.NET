namespace AIKernel.Abstractions.Context;

/// <summary>
/// UC-06/UC-08 に基づく契約です。
/// EN: コンテキスト断片へのアクセスを提供します。
/// EN: Documentation for public API. JA: IContextFragmentCollection の公開契約を定義します。
/// </summary>
/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.Context.IContextFragmentCollection']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.Context.IContextFragmentCollection']" />
public interface IContextFragmentCollection
{
    /// <summary>
    /// EN: すべてのコンテキストフラグメントを取得します。
    /// EN: Documentation for public API. JA: GetAll 操作を実行します。
    /// </summary>
    /// <returns>EN: Documentation for public API. JA: コンテキストフラグメント一覧 結果を返します。</returns>
    IEnumerable<ContextFragment> GetAll();

    /// <summary>
    /// EN: 指定カテゴリに属するコンテキストフラグメントを取得します。
    /// EN: Documentation for public API. JA: GetByCategory 操作を実行します。
    /// </summary>
    /// <param name="category">EN: Documentation for public API. JA: 対象カテゴリ category パラメーターです。</param>
    /// <returns>EN: Documentation for public API. JA: カテゴリに一致するコンテキストフラグメント一覧 結果を返します。</returns>
    IEnumerable<ContextFragment> GetByCategory(ContextCategory category);
}

/// <summary>
/// UC-06/UC-08 に基づく契約です。
/// EN: フェーズ別 buffer へのアクセスを提供します。
/// EN: Documentation for public API. JA: IPhaseBufferCollection の公開契約を定義します。
/// </summary>
/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.Context.IPhaseBufferCollection']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.Context.IPhaseBufferCollection']" />
public interface IPhaseBufferCollection
{
    /// <summary>
    /// EN: Orchestration フェーズ向けバッファを取得します。
    /// EN: Documentation for public API. JA: GetOrchestrationBuffer 操作を実行します。
    /// </summary>
    /// <returns>EN: Documentation for public API. JA: Orchestration バッファ 結果を返します。</returns>
    OrchestrationBuffer GetOrchestrationBuffer();

    /// <summary>
    /// EN: Expression フェーズ向けバッファを取得します。
    /// EN: Documentation for public API. JA: GetExpressionBuffer 操作を実行します。
    /// </summary>
    /// <returns>EN: Documentation for public API. JA: Expression バッファ 結果を返します。</returns>
    ExpressionBuffer GetExpressionBuffer();

    /// <summary>
    /// EN: Material フェーズ向けバッファを取得します。
    /// EN: Documentation for public API. JA: GetMaterialBuffer 操作を実行します。
    /// </summary>
    /// <returns>EN: Documentation for public API. JA: Material バッファ 結果を返します。</returns>
    MaterialBuffer GetMaterialBuffer();

    /// <summary>
    /// EN: History フェーズ向けバッファを取得します。
    /// EN: Documentation for public API. JA: GetHistoryBuffer 操作を実行します。
    /// </summary>
    /// <returns>EN: Documentation for public API. JA: History バッファ 結果を返します。</returns>
    HistoryBuffer GetHistoryBuffer();
}

/// <summary>
/// UC-06/UC-08 に基づく契約です。
/// コンテキスト断片の集合を管理する互換合成インターフェースです。
/// EN: カテゴリ別アクセスと各フェーズ向けバッファ取得を提供します。
/// EN: Documentation for public API. JA: IContextCollection の公開契約を定義します。
/// </summary>
/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.Context.IContextCollection']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.Context.IContextCollection']" />
public interface IContextCollection :
    IContextFragmentCollection,
    IPhaseBufferCollection
{
}
