namespace AIKernel.Abstractions.Context;

/// <summary>
/// Orchestration（制御・指示）フェーズ用バッファ。
/// 推論前の制御情報を提供します。
/// </summary>
public readonly struct OrchestrationBuffer
{
    /// <summary>
    /// バッファ内のフラグメント一覧を取得します。
    /// </summary>
    public IReadOnlyList<ContextFragment> Fragments { get; }

    /// <summary>
    /// OrchestrationBuffer を初期化します。
    /// </summary>
    /// <param name="fragments">フラグメント一覧</param>
    public OrchestrationBuffer(IEnumerable<ContextFragment> fragments)
    {
        var list = fragments?.ToList() ?? new List<ContextFragment>();
        Fragments = list.AsReadOnly();
    }
}

/// <summary>
/// Expression（表現・整形）フェーズ用バッファ。
/// 推論後の整形に必要な情報を提供します。
/// </summary>
public readonly struct ExpressionBuffer
{
    /// <summary>
    /// バッファ内のフラグメント一覧を取得します。
    /// </summary>
    public IReadOnlyList<ExpressionFragment> Fragments { get; }

    /// <summary>
    /// ExpressionBuffer を初期化します。
    /// </summary>
    /// <param name="fragments">フラグメント一覧</param>
    public ExpressionBuffer(IEnumerable<ExpressionFragment> fragments)
    {
        var list = fragments?.ToList() ?? new List<ExpressionFragment>();
        Fragments = list.AsReadOnly();
    }
}

/// <summary>
/// Material（素材）フェーズ用バッファ。
/// 入力となる素材情報を提供します。
/// </summary>
public readonly struct MaterialBuffer
{
    /// <summary>
    /// バッファ内のフラグメント一覧を取得します。
    /// </summary>
    public IReadOnlyList<ContextFragment> Fragments { get; }

    /// <summary>
    /// MaterialBuffer を初期化します。
    /// </summary>
    /// <param name="fragments">フラグメント一覧</param>
    public MaterialBuffer(IEnumerable<ContextFragment> fragments)
    {
        var list = fragments?.ToList() ?? new List<ContextFragment>();
        Fragments = list.AsReadOnly();
    }
}

/// <summary>
/// History（履歴）フェーズ用バッファ。
/// 履歴・学習記録情報を提供します。
/// </summary>
public readonly struct HistoryBuffer
{
    /// <summary>
    /// バッファ内のフラグメント一覧を取得します。
    /// </summary>
    public IReadOnlyList<ContextFragment> Fragments { get; }

    /// <summary>
    /// HistoryBuffer を初期化します。
    /// </summary>
    /// <param name="fragments">フラグメント一覧</param>
    public HistoryBuffer(IEnumerable<ContextFragment> fragments)
    {
        var list = fragments?.ToList() ?? new List<ContextFragment>();
        Fragments = list.AsReadOnly();
    }
}

/// <summary>
/// コンテキスト情報の集合を管理するインターフェース。
/// カテゴリ別の隔離と読み取り専用アクセスを保証します。
/// </summary>
public interface IContextCollection
{
    /// <summary>
    /// すべてのコンテキストフラグメントを取得します。
    /// </summary>
    /// <returns>フラグメント一覧</returns>
    IEnumerable<ContextFragment> GetAll();

    /// <summary>
    /// 指定されたカテゴリに属するフラグメントを取得します。
    /// </summary>
    /// <param name="category">カテゴリ</param>
    /// <returns>カテゴリに一致するフラグメント一覧</returns>
    IEnumerable<ContextFragment> GetByCategory(ContextCategory category);

    /// <summary>
    /// Orchestration バッファを取得します。
    /// </summary>
    /// <returns>Orchestration フェーズ用バッファ</returns>
    OrchestrationBuffer GetOrchestrationBuffer();

    /// <summary>
    /// Expression バッファを取得します。
    /// </summary>
    /// <returns>Expression フェーズ用バッファ</returns>
    ExpressionBuffer GetExpressionBuffer();

    /// <summary>
    /// Material バッファを取得します。
    /// </summary>
    /// <returns>Material フェーズ用バッファ</returns>
    MaterialBuffer GetMaterialBuffer();

    /// <summary>
    /// History バッファを取得します。
    /// </summary>
    /// <returns>History フェーズ用バッファ</returns>
    HistoryBuffer GetHistoryBuffer();
}
