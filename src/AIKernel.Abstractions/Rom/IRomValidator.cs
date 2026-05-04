namespace AIKernel.Abstractions.Rom;

/// <summary>
/// ROM バリデーターの契約。
/// RCS-F002: リンク未解決時は推論入力を拒否。
/// RCS-F004: Type Consistency の検証。
/// RCS-F005: Circular Reference Guard。
/// </summary>
public interface IRomValidator
{
    /// <summary>
    /// ROM ドキュメントのスキーマを検証します。
    /// RCS-001: 必須項目 (entity.id, entity.type, version) の存在確認。
    /// RCS-F001: 必須 ID 欠落時は ROM 無効。
    /// </summary>
    /// <param name="document">検証対象の ROM ドキュメント</param>
    /// <param name="cancellationToken">キャンセルトークン</param>
    /// <returns>スキーマ検証結果</returns>
    Task<RomSchemaValidationResult> ValidateSchemaAsync(
        IRomDocument document,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// ROM ドキュメント内の関係参照（[[id]]）がすべて解決可能であることを検証します。
    /// RCS-002: [[id]] は解決可能な参照でなければならない（MUST）。
    /// RCS-F002: リンク未解決時は推論入力を拒否。
    /// </summary>
    /// <param name="document">検証対象の ROM ドキュメント</param>
    /// <param name="relationResolver">関係解決サービス</param>
    /// <param name="cancellationToken">キャンセルトークン</param>
    /// <returns>リンク検証結果</returns>
    Task<RomLinkageValidationResult> ValidateLinkageAsync(
        IRomDocument document,
        IRelationResolver relationResolver,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Type Consistency を検証します。
    /// RCS-F004: entity.type とプロパティ定義が矛盾する場合、入力を拒否。
    /// 必須プロパティ欠落も含む。
    /// </summary>
    /// <param name="document">検証対象の ROM ドキュメント</param>
    /// <param name="typeSchema">型スキーマ定義</param>
    /// <param name="cancellationToken">キャンセルトークン</param>
    /// <returns>型一貫性検証結果</returns>
    Task<RomTypeConsistencyResult> ValidateTypeConsistencyAsync(
        IRomDocument document,
        EntityTypeSchema typeSchema,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// 循環参照を検出します。
    /// RCS-F005: Circular Reference Guard - 循環参照が推論ループを誘発する場合、停止しなければならない。
    /// </summary>
    /// <param name="document">検証対象の ROM ドキュメント</param>
    /// <param name="relationResolver">関係解決サービス</param>
    /// <param name="maxDepth">探索の最大深度（無限ループ防止）</param>
    /// <param name="cancellationToken">キャンセルトークン</param>
    /// <returns>循環参照検出結果</returns>
    Task<CircularReferenceDetectionResult> DetectCircularReferencesAsync(
        IRomDocument document,
        IRelationResolver relationResolver,
        int maxDepth = 10,
        CancellationToken cancellationToken = default);
}

/// <summary>
/// 関係参照を解決するサービスの契約。
/// RCS-002, RCS-F002 で使用。
/// </summary>
public interface IRelationResolver
{
    /// <summary>
    /// 参照 ID を解決して実際のエンティティを取得します。
    /// </summary>
    /// <param name="referenceId">参照 ID（例: "user.tky"）</param>
    /// <param name="cancellationToken">キャンセルトークン</param>
    /// <returns>解決されたエンティティ、存在しない場合は null</returns>
    Task<ResolvableEntity?> ResolveAsync(string referenceId, CancellationToken cancellationToken = default);

    /// <summary>
    /// 参照が解決可能であるかだけを確認します（軽量チェック）。
    /// </summary>
    /// <param name="referenceId">参照 ID</param>
    /// <param name="cancellationToken">キャンセルトークン</param>
    /// <returns>解決可能かどうか</returns>
    Task<bool> CanResolveAsync(string referenceId, CancellationToken cancellationToken = default);
}
