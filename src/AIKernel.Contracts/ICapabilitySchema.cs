namespace AIKernel.Contracts;

/// <summary>
/// 能力スキーマ契約を定義します。
/// プロバイダーやコンポーネントの能力を定義します。
/// </summary>
public interface ICapabilitySchema
{
    /// <summary>
    /// 能力の一意識別子を取得します。
    /// </summary>
    string CapabilityId { get; }

    /// <summary>
    /// 能力の名前を取得します。
    /// </summary>
    string Name { get; }

    /// <summary>
    /// 能力の説明を取得します。
    /// </summary>
    string? Description { get; }

    /// <summary>
    /// 能力の入力スキーマを取得します。
    /// </summary>
    object? InputSchema { get; }

    /// <summary>
    /// 能力の出力スキーマを取得します。
    /// </summary>
    object? OutputSchema { get; }

    /// <summary>
    /// 能力がサポートする操作を取得します。
    /// </summary>
    IReadOnlyList<string> SupportedOperations { get; }

    /// <summary>
    /// 能力の制限を取得します。
    /// </summary>
    IReadOnlyDictionary<string, object>? Constraints { get; }
}
