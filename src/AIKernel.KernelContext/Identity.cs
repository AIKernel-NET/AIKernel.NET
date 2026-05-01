namespace AIKernel.KernelContext;

/// <summary>
/// 実行時の Identity（身元）情報を表現します。
/// ユーザーやシステムの識別情報を管理します。
/// </summary>
public sealed class Identity
{
    /// <summary>
    /// 身元の一意識別子を取得または設定します。
    /// </summary>
    public required string Id { get; init; }

    /// <summary>
    /// 身元の名前を取得または設定します。
    /// </summary>
    public required string Name { get; init; }

    /// <summary>
    /// 身元のタイプを取得または設定します。
    /// </summary>
    public required string Type { get; init; }

    /// <summary>
    /// メールアドレスを取得または設定します。
    /// </summary>
    public string? Email { get; init; }

    /// <summary>
    /// 所属組織を取得または設定します。
    /// </summary>
    public string? Organization { get; init; }

    /// <summary>
    /// メタデータを取得または設定します。
    /// </summary>
    public Dictionary<string, object>? Metadata { get; init; }

    /// <summary>
    /// 作成日時を取得または設定します。
    /// </summary>
    public DateTime CreatedAt { get; init; } = DateTime.UtcNow;
}
