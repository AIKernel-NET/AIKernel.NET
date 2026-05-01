namespace AIKernel.Abstractions.Context;

/// <summary>
/// コンテキストのカテゴリを定義します。
/// フェーズ別コンテキストの型保証と分類に使用されます。
/// 
/// - Orchestration: 推論前の制御・指示コンテキスト
/// - Expression: 推論後の整形・表現コンテキスト
/// - Material: 入力となる素材コンテキスト
/// - History: 履歴・学習記録コンテキスト
/// </summary>
public enum ContextCategory
{
    /// <summary>
    /// 推論前の制御・指示コンテキスト
    /// </summary>
    Orchestration = 0,

    /// <summary>
    /// 推論後の整形・表現コンテキスト
    /// </summary>
    Expression = 1,

    /// <summary>
    /// 入力となる素材コンテキスト
    /// </summary>
    Material = 2,

    /// <summary>
    /// 履歴・学習記録コンテキスト
    /// </summary>
    History = 3
}
