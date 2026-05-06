namespace AIKernel.Contracts;

/// <summary>
/// トークナイザープロファイル契約を定義します。
/// トークナイザーの設定とメタデータを管理します。
/// UC-30（トークン・ベクトル推定）
/// </summary>
public interface ITokenizerProfile
{
    /// <summary>
    /// プロファイルの一意識別子を取得します。
    /// </summary>
    string ProfileId { get; }

    /// <summary>
    /// プロファイルの名前を取得します。
    /// </summary>
    string Name { get; }

    /// <summary>
    /// サポートされているモデルを取得します。
    /// </summary>
    IReadOnlyList<string> SupportedModels { get; }

    /// <summary>
    /// 語彙サイズを取得します。
    /// </summary>
    int VocabularySize { get; }

    /// <summary>
    /// 特殊トークンの定義を取得します。
    /// </summary>
    IReadOnlyDictionary<string, int>? SpecialTokens { get; }

    /// <summary>
    /// デコード時に特殊なトリートメントを必要とするかどうかを取得します。
    /// </summary>
    bool RequiresSpecialHandling { get; }
}

