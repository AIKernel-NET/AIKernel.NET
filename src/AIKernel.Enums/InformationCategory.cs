namespace AIKernel.Enums;

/// <summary>
/// LLM に渡す情報のカテゴリを定義します。
/// これらのカテゴリは絶対に混在させてはなりません。
/// 
/// 参照: 1.CATEGORY_SEPARATION_PRINCIPLES.jp.md
/// </summary>
public enum InformationCategory
{
    /// <summary>
    /// 目的 - タスクの本質と達成目標
    /// </summary>
    Purpose = 1,

    /// <summary>
    /// 制約 - 実行時に守るべき制限条件
    /// </summary>
    Constraints = 2,

    /// <summary>
    /// 抽象構造 - 推論の骨格となる構造
    /// </summary>
    Structure = 3,

    /// <summary>
    /// 履歴 - 過去の状態・操作・結果
    /// </summary>
    History = 4,

    /// <summary>
    /// 背景 - 文脈となる背景情報
    /// </summary>
    Context = 5,

    /// <summary>
    /// RAG素材 - 取得した外部素材
    /// </summary>
    RagMaterial = 6,

    /// <summary>
    /// 表現整形 - 出力の文体・例・比喩
    /// </summary>
    Expression = 7,

    /// <summary>
    /// メタ情報 - 分類・タイプ・タグなどのメタデータ
    /// </summary>
    Metadata = 8
}
