namespace AIKernel.Contracts;

/// <summary>
/// トークナイザープロファイル契約を定義します。
/// トークナイザーの設定とメタデータを管理します。
/// EN: UC-30（トークン・ベクトル推定）
/// [EN] Documents this public package API member. [JA] ITokenizerProfile の公開契約を定義します。
/// </summary>
/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Contracts.ITokenizerProfile']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Contracts.ITokenizerProfile']" />
public interface ITokenizerProfile
{
    /// <summary>
    /// EN: プロファイルの一意識別子を取得します。
    /// [EN] Documents this public package API member. [JA] このメンバー の公開契約を定義します。
    /// </summary>
    string ProfileId { get; }

    /// <summary>
    /// EN: プロファイルの名前を取得します。
    /// [EN] Documents this public package API member. [JA] このメンバー の公開契約を定義します。
    /// </summary>
    string Name { get; }

    /// <summary>
    /// EN: サポートされているモデルを取得します。
    /// [EN] Documents this public package API member. [JA] このメンバー の公開契約を定義します。
    /// </summary>
    IReadOnlyList<string> SupportedModels { get; }

    /// <summary>
    /// EN: 語彙サイズを取得します。
    /// [EN] Documents this public package API member. [JA] このメンバー の公開契約を定義します。
    /// </summary>
    int VocabularySize { get; }

    /// <summary>
    /// EN: 特殊トークンの定義を取得します。
    /// [EN] Documents this public package API member. [JA] このメンバー の公開契約を定義します。
    /// </summary>
    IReadOnlyDictionary<string, int>? SpecialTokens { get; }

    /// <summary>
    /// EN: デコード時に特殊なトリートメントを必要とするかどうかを取得します。
    /// [EN] Documents this public package API member. [JA] このメンバー の公開契約を定義します。
    /// </summary>
    bool RequiresSpecialHandling { get; }
}

