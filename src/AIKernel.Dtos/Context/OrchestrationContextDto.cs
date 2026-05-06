using AIKernel.Enums;

namespace AIKernel.Dtos.Context;

/// <summary>
/// OrchestrationContext のデータを表現する DTO です。
/// 推論に必要な情報のみを含みます。
/// 
/// 参照: 2.CONTEXT_ISOLATION_SPEC.jp.md
/// </summary>
public sealed class OrchestrationContextDto
{
    /// <summary>
    /// 目的を取得または設定します。
    /// </summary>
    public required string Purpose { get; init; }

    /// <summary>
    /// 制約条件を取得または設定します。
    /// </summary>
    public List<string> Constraints { get; init; } = new();

    /// <summary>
    /// 抽象構造を取得または設定します。
    /// </summary>
    public required string Structure { get; init; }

    /// <summary>
    /// 思考パターンを取得または設定します。
    /// </summary>
    public string? ReasoningPattern { get; init; }

    /// <summary>
    /// 追加パラメータを取得または設定します。
    /// </summary>
    public Dictionary<string, object>? Parameters { get; init; }

    /// <summary>
    /// 作成日時を取得または設定します。
    /// </summary>
    public DateTime CreatedAt { get; init; } = DateTime.UtcNow;
}


