namespace AIKernel.Dtos.Core;

/// <summary>
/// 目的を表現します。
/// 処理の意図と目標を定義します。
/// </summary>
public sealed class Purpose
{
    public required string PurposeId { get; init; }
    public required string Description { get; init; }
    public int Priority { get; init; } = 5;
    public List<string> Tags { get; init; } = new();
    public string? SuccessCriteria { get; init; }
    public DateTime CreatedAt { get; init; } = DateTime.UtcNow;
}


