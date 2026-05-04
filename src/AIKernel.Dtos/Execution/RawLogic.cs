namespace AIKernel.Dtos.Execution;

/// <summary>
/// 推論の中間表現（生のロジック）を表現します。
/// IThoughtProcess が返し、IOutputPolisher が入力として受け取ります。
/// </summary>
public sealed record RawLogic(string SerializedRepresentation)
{
    /// <summary>
    /// ロジックが空でないかどうかを確認します。
    /// </summary>
    public bool IsEmpty => string.IsNullOrWhiteSpace(SerializedRepresentation);
}

