namespace AIKernel.Abstractions.Context;

/// <summary>
/// UC-06/UC-08 に基づく契約です。
/// コンテキスト断片へのアクセスを提供します。
/// JA: IContextFragmentCollection の公開契約を定義します。
/// </summary>
/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.Context.IContextFragmentCollection']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.Context.IContextFragmentCollection']" />
public interface IContextFragmentCollection
{
    /// <summary>
    /// すべてのコンテキストフラグメントを取得します。
    /// JA: GetAll 操作を実行します。
    /// </summary>
    /// <returns>コンテキストフラグメント一覧 JA: 結果を返します。</returns>
    IEnumerable<ContextFragment> GetAll();

    /// <summary>
    /// 指定カテゴリに属するコンテキストフラグメントを取得します。
    /// JA: GetByCategory 操作を実行します。
    /// </summary>
    /// <param name="category">対象カテゴリ JA: category パラメーターです。</param>
    /// <returns>カテゴリに一致するコンテキストフラグメント一覧 JA: 結果を返します。</returns>
    IEnumerable<ContextFragment> GetByCategory(ContextCategory category);
}

/// <summary>
/// UC-06/UC-08 に基づく契約です。
/// フェーズ別 buffer へのアクセスを提供します。
/// JA: IPhaseBufferCollection の公開契約を定義します。
/// </summary>
/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.Context.IPhaseBufferCollection']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.Context.IPhaseBufferCollection']" />
public interface IPhaseBufferCollection
{
    /// <summary>
    /// Orchestration フェーズ向けバッファを取得します。
    /// JA: GetOrchestrationBuffer 操作を実行します。
    /// </summary>
    /// <returns>Orchestration バッファ JA: 結果を返します。</returns>
    OrchestrationBuffer GetOrchestrationBuffer();

    /// <summary>
    /// Expression フェーズ向けバッファを取得します。
    /// JA: GetExpressionBuffer 操作を実行します。
    /// </summary>
    /// <returns>Expression バッファ JA: 結果を返します。</returns>
    ExpressionBuffer GetExpressionBuffer();

    /// <summary>
    /// Material フェーズ向けバッファを取得します。
    /// JA: GetMaterialBuffer 操作を実行します。
    /// </summary>
    /// <returns>Material バッファ JA: 結果を返します。</returns>
    MaterialBuffer GetMaterialBuffer();

    /// <summary>
    /// History フェーズ向けバッファを取得します。
    /// JA: GetHistoryBuffer 操作を実行します。
    /// </summary>
    /// <returns>History バッファ JA: 結果を返します。</returns>
    HistoryBuffer GetHistoryBuffer();
}

/// <summary>
/// UC-06/UC-08 に基づく契約です。
/// コンテキスト断片の集合を管理する互換合成インターフェースです。
/// カテゴリ別アクセスと各フェーズ向けバッファ取得を提供します。
/// JA: IContextCollection の公開契約を定義します。
/// </summary>
/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.Context.IContextCollection']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.Context.IContextCollection']" />
public interface IContextCollection :
    IContextFragmentCollection,
    IPhaseBufferCollection
{
}
