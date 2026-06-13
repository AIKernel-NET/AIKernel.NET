namespace AIKernel.Abstractions.Rom;

/// <summary>
/// UC-01/UC-12 に基づく契約です。
/// ROM schema validation capability です。
/// JA: IRomSchemaValidator の公開契約を定義します。
/// </summary>
/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.Rom.IRomSchemaValidator']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.Rom.IRomSchemaValidator']" />
public interface IRomSchemaValidator
{
    /// <summary>
    /// ROM ドキュメントのスキーマを検証します。
    /// RCS-001: 必須項目 (entity.id, entity.type, version) の存在確認。
    /// RCS-F001: 必須 ID 欠落時は ROM 無効。
    /// JA: ValidateSchemaAsync 操作を実行します。
    /// </summary>
    Task<AIKernel.Dtos.Rom.RomSchemaValidationResult> ValidateSchemaAsync(
        IRomDocument document,
        CancellationToken cancellationToken = default);
}

/// <summary>
/// UC-01/UC-12 に基づく契約です。
/// ROM linkage validation capability です。
/// JA: IRomLinkageValidator の公開契約を定義します。
/// </summary>
/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.Rom.IRomLinkageValidator']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.Rom.IRomLinkageValidator']" />
public interface IRomLinkageValidator
{
    /// <summary>
    /// ROM ドキュメント内の関係参照（[[id]]）がすべて解決可能であることを検証します。
    /// RCS-002: [[id]] は解決可能な参照でなければならない（MUST）。
    /// RCS-F002: リンク未解決時は推論入力を拒否。
    /// JA: ValidateLinkageAsync 操作を実行します。
    /// </summary>
    Task<AIKernel.Dtos.Rom.RomLinkageValidationResult> ValidateLinkageAsync(
        IRomDocument document,
        IRelationResolver relationResolver,
        CancellationToken cancellationToken = default);
}

/// <summary>
/// UC-01/UC-12 に基づく契約です。
/// ROM type consistency validation capability です。
/// JA: IRomTypeConsistencyValidator の公開契約を定義します。
/// </summary>
/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.Rom.IRomTypeConsistencyValidator']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.Rom.IRomTypeConsistencyValidator']" />
public interface IRomTypeConsistencyValidator
{
    /// <summary>
    /// Type Consistency を検証します。
    /// RCS-F004: entity.type とプロパティ定義が矛盾する場合、入力を拒否。
    /// 必須プロパティ欠落も含む。
    /// JA: ValidateTypeConsistencyAsync 操作を実行します。
    /// </summary>
    Task<AIKernel.Dtos.Rom.RomTypeConsistencyResult> ValidateTypeConsistencyAsync(
        IRomDocument document,
        AIKernel.Dtos.Rom.EntityTypeSchema typeSchema,
        CancellationToken cancellationToken = default);
}

/// <summary>
/// UC-01/UC-12 に基づく契約です。
/// ROM circular reference detection capability です。
/// JA: IRomCircularReferenceValidator の公開契約を定義します。
/// </summary>
/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.Rom.IRomCircularReferenceValidator']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.Rom.IRomCircularReferenceValidator']" />
public interface IRomCircularReferenceValidator
{
    /// <summary>
    /// 循環参照を検出します。
    /// RCS-F005: Circular Reference Guard - 循環参照が推論ループを誘発する場合、停止しなければならない。
    /// JA: DetectCircularReferencesAsync 操作を実行します。
    /// </summary>
    Task<AIKernel.Dtos.Rom.CircularReferenceDetectionResult> DetectCircularReferencesAsync(
        IRomDocument document,
        IRelationResolver relationResolver,
        int maxDepth = 10,
        CancellationToken cancellationToken = default);
}

/// <summary>
/// UC-01/UC-12 に基づく契約です。
/// ROM バリデーターの互換合成 contract。
/// RCS-F002: リンク未解決時は推論入力を拒否。
/// RCS-F004: Type Consistency の検証。
/// RCS-F005: Circular Reference Guard。
/// JA: IRomValidator の公開契約を定義します。
/// </summary>
/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.Rom.IRomValidator']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.Rom.IRomValidator']" />
public interface IRomValidator :
    IRomSchemaValidator,
    IRomLinkageValidator,
    IRomTypeConsistencyValidator,
    IRomCircularReferenceValidator
{
}
