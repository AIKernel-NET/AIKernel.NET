namespace AIKernel.Dtos.Execution;

/// <summary>
/// 実行メタデータ DTO。
/// EPS-008: 決定論的スケジューリング（Deterministic Scheduling）の選定根拠を記録。
/// 各フェーズ開始前にモデル再評価を行い、選定根拠を ExecutionResult メタデータへ記録する。
/// </summary>
public sealed record ExecutionMetadataDto
{
    /// <summary>
    /// フェーズ名（"structure", "generation", "polish"）。
    /// </summary>
    public required string PhaseName { get; init; }

    /// <summary>
    /// 選定されたプロバイダ ID。
    /// EPS-008: IModelVectorRouter の決定。
    /// </summary>
    public required string SelectedProviderId { get; init; }

    /// <summary>
    /// 選定理由（ルーティング根拠）。
    /// EPS-008: 再現可能性のための詳細記録。
    /// </summary>
    public required string SelectionRationale { get; init; }

    /// <summary>
    /// フェーズ実行開始時刻。
    /// </summary>
    public required DateTime StartedAt { get; init; }

    /// <summary>
    /// フェーズ実行完了時刻。
    /// </summary>
    public required DateTime CompletedAt { get; init; }

    /// <summary>
    /// フェーズの出力ハッシュ。
    /// EPS-005: フェーズ受け渡しデータのハッシュで完全性検証。
    /// </summary>
    public required string OutputHash { get; init; }

    /// <summary>
    /// 親フェーズのハッシュ（ハッシュチェーン形成用）。
    /// EPS-007: Structure 出力ハッシュを Generation の親ハッシュとして記録し、連鎖を形成する。
    /// </summary>
    public string? ParentHash { get; init; }

    /// <summary>
    /// 追加のコンテキスト情報。
    /// </summary>
    public IReadOnlyDictionary<string, object> ContextData { get; init; } = new Dictionary<string, object>();
}
