namespace AIKernel.Contracts;

/// <summary>
/// 機能仕様契約を定義します。
/// 機能の要件と制約を定義します。
/// </summary>
public interface IFeatureSpec
{
    /// <summary>
    /// 機能の一意識別子を取得します。
    /// </summary>
    string FeatureId { get; }

    /// <summary>
    /// 機能の名前を取得します。
    /// </summary>
    string Name { get; }

    /// <summary>
    /// 機能の説明を取得します。
    /// </summary>
    string? Description { get; }

    /// <summary>
    /// 機能のバージョンを取得します。
    /// </summary>
    string Version { get; }

    /// <summary>
    /// 機能が必要とする権限を取得します。
    /// </summary>
    IReadOnlyList<string> RequiredPermissions { get; }

    /// <summary>
    /// 機能の依存関係を取得します。
    /// </summary>
    IReadOnlyList<string> Dependencies { get; }

    /// <summary>
    /// 機能がアクティブかどうかを取得します。
    /// </summary>
    bool IsActive { get; }
}
