namespace AIKernel.Abstractions.Context;

/// <summary>
/// コンテキストの基本的なフラグメント（断片）を表現します。
/// コンテキストは複数のフラグメントから構成されます。
/// </summary>
public class ContextFragment
{
    /// <summary>
    /// フラグメントの一意識別子を取得または設定します。
    /// </summary>
    public required string FragmentId { get; init; }

    /// <summary>
    /// フラグメントが属するカテゴリを取得または設定します。
    /// </summary>
    public required ContextCategory Category { get; init; }

    /// <summary>
    /// フラグメントの内容を取得または設定します。
    /// </summary>
    public required string Content { get; init; }

    /// <summary>
    /// フラグメントの重要度（0.0 ～ 1.0）を取得または設定します。
    /// </summary>
    public double Priority { get; init; } = 0.5;

    /// <summary>
    /// フラグメントが作成された日時を取得または設定します。
    /// </summary>
    public DateTime CreatedAt { get; init; } = DateTime.UtcNow;

    /// <summary>
    /// フラグメントのメタデータを取得または設定します。
    /// </summary>
    public IReadOnlyDictionary<string, string>? Metadata { get; init; }
}
