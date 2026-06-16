namespace AIKernel.Enums;

/// <summary>
/// AIKernel の 3 層コンテキスト隔離モデルにおけるコンテキストタイプを定義します。
/// 
/// EN: 参照: 2.CONTEXT_ISOLATION_SPEC.jp.md
/// EN: Documentation for public API. JA: ContextType の公開契約を定義します。
/// </summary>
/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Enums.ContextType']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Enums.ContextType']" />
public enum ContextType
{
    /// <summary>
    /// OrchestrationContext - 推論用コンテキスト
    /// 推論に必要な情報のみを含む（目的、制約、抽象構造、思考パターン）
    /// EN: 例・文体・RAG は絶対に入れない。
    /// EN: Documentation for public API. JA: Orchestration 値を表します。
    /// </summary>
    Orchestration = 1,

    /// <summary>
    /// ExpressionContext - 表現用コンテキスト
    /// 推論が完全に終了した後にのみ適用される。
    /// EN: 文体、例、説明、比喩を含む。
    /// EN: Documentation for public API. JA: Expression 値を表します。
    /// </summary>
    Expression = 2,

    /// <summary>
    /// MaterialContext - 素材用コンテキスト
    /// RAG の断片や外部情報を含む。
    /// 生データのまま OrchestrationContext に渡してはならない。
    /// EN: 必ず正規化・構造化してから転写される。
    /// EN: Documentation for public API. JA: Material 値を表します。
    /// </summary>
    Material = 3
}

