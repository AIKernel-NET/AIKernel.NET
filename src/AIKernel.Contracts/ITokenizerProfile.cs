namespace AIKernel.Contracts;

/// <summary>
/// トークナイザープロファイル契約を定義します。
/// トークナイザーの設定とメタデータを管理します。
/// UC-30（トークン・ベクトル推定）
/// JA: ITokenizerProfile の公開契約を定義します。
/// </summary>
/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Contracts.ITokenizerProfile']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Contracts.ITokenizerProfile']" />
public interface ITokenizerProfile
{
    /// <summary>
    /// プロファイルの一意識別子を取得します。
    /// JA: このメンバー の公開契約を定義します。
    /// </summary>
    string ProfileId { get; }

    /// <summary>
    /// プロファイルの名前を取得します。
    /// JA: このメンバー の公開契約を定義します。
    /// </summary>
    string Name { get; }

    /// <summary>
    /// サポートされているモデルを取得します。
    /// JA: このメンバー の公開契約を定義します。
    /// </summary>
    IReadOnlyList<string> SupportedModels { get; }

    /// <summary>
    /// 語彙サイズを取得します。
    /// JA: このメンバー の公開契約を定義します。
    /// </summary>
    int VocabularySize { get; }

    /// <summary>
    /// 特殊トークンの定義を取得します。
    /// JA: このメンバー の公開契約を定義します。
    /// </summary>
    IReadOnlyDictionary<string, int>? SpecialTokens { get; }

    /// <summary>
    /// デコード時に特殊なトリートメントを必要とするかどうかを取得します。
    /// JA: このメンバー の公開契約を定義します。
    /// </summary>
    bool RequiresSpecialHandling { get; }
}

