namespace AIKernel.Enums;

/// <summary>
/// AIKernel の 3 層コンテキスト隔離モデルにおけるコンテキストタイプを定義します。
/// 
/// 参照: 2.CONTEXT_ISOLATION_SPEC.jp.md
/// </summary>
public enum ContextType
{
    /// <summary>
    /// OrchestrationContext - 推論用コンテキスト
    /// 推論に必要な情報のみを含む（目的、制約、抽象構造、思考パターン）
    /// 例・文体・RAG は絶対に入れない。
    /// </summary>
    Orchestration = 1,

    /// <summary>
    /// ExpressionContext - 表現用コンテキスト
    /// 推論が完全に終了した後にのみ適用される。
    /// 文体、例、説明、比喩を含む。
    /// </summary>
    Expression = 2,

    /// <summary>
    /// MaterialContext - 素材用コンテキスト
    /// RAG の断片や外部情報を含む。
    /// 生データのまま OrchestrationContext に渡してはならない。
    /// 必ず正規化・構造化してから転写される。
    /// </summary>
    Material = 3
}

