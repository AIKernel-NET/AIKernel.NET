namespace AIKernel.Abstractions.History;

/// <summary>
/// 履歴をどのように扱うかを指定するポリシー。
/// </summary>
public enum HistoryPolicy
{
    /// <summary>
    /// 履歴を素材として扱う（正規化され、重み付けされた Material として投影）
    /// </summary>
    AsMaterial = 0,

    /// <summary>
    /// 履歴をコンテキストとして扱う（制御情報として投影）
    /// </summary>
    AsContext = 1,

    /// <summary>
    /// 履歴を破棄する
    /// </summary>
    Discard = 2
}
