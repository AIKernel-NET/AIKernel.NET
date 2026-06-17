namespace AIKernel.Enums;

/// <summary>
/// LLM に渡す情報のカテゴリを定義します。
/// これらのカテゴリは絶対に混在させてはなりません。
/// 
/// EN: 参照: 1.CATEGORY_SEPARATION_PRINCIPLES.jp.md
/// [EN] Documents this public package API member. [JA] InformationCategory の公開契約を定義します。
/// </summary>
/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Enums.InformationCategory']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Enums.InformationCategory']" />
public enum InformationCategory
{
    /// <summary>
    /// EN: 目的 - タスクの本質と達成目標
    /// [EN] Documents this public package API member. [JA] Purpose 値を表します。
    /// </summary>
    Purpose = 1,

    /// <summary>
    /// EN: 制約 - 実行時に守るべき制限条件
    /// [EN] Documents this public package API member. [JA] Constraints 値を表します。
    /// </summary>
    Constraints = 2,

    /// <summary>
    /// EN: 抽象構造 - 推論の骨格となる構造
    /// [EN] Documents this public package API member. [JA] Structure 値を表します。
    /// </summary>
    Structure = 3,

    /// <summary>
    /// EN: 履歴 - 過去の状態・操作・結果
    /// [EN] Documents this public package API member. [JA] History 値を表します。
    /// </summary>
    History = 4,

    /// <summary>
    /// EN: 背景 - 文脈となる背景情報
    /// [EN] Documents this public package API member. [JA] Context 値を表します。
    /// </summary>
    Context = 5,

    /// <summary>
    /// EN: RAG素材 - 取得した外部素材
    /// [EN] Documents this public package API member. [JA] RagMaterial 値を表します。
    /// </summary>
    RagMaterial = 6,

    /// <summary>
    /// EN: 表現整形 - 出力の文体・例・比喩
    /// [EN] Documents this public package API member. [JA] Expression 値を表します。
    /// </summary>
    Expression = 7,

    /// <summary>
    /// EN: メタ情報 - 分類・タイプ・タグなどのメタデータ
    /// [EN] Documents this public package API member. [JA] Metadata 値を表します。
    /// </summary>
    Metadata = 8
}

