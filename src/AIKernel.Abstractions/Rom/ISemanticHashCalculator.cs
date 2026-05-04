namespace AIKernel.Abstractions.Rom;

/// <summary>
/// セマンティックハッシュ計算の契約。
/// RCS-004: 正規化後の Semantic Hash を算出できなければならない（MUST）。
/// RCS-F003: ハッシュ不整合時は署名検証失敗とする。
/// </summary>
public interface ISemanticHashCalculator
{
    /// <summary>
    /// ハッシュアルゴリズム（"SHA256", "SHA512" など）。
    /// </summary>
    string Algorithm { get; }

    /// <summary>
    /// ROM ドキュメントのセマンティックハッシュを計算します。
    /// RCS-004: Canonicalization を適用した後、ハッシュを計算する。
    /// </summary>
    /// <param name="document">対象の ROM ドキュメント</param>
    /// <param name="cancellationToken">キャンセルトークン</param>
    /// <returns>ハッシュ値（例: "sha256:a1b2c3d4..."）</returns>
    Task<string> ComputeHashAsync(IRomDocument document, CancellationToken cancellationToken = default);

    /// <summary>
    /// 正規化済みドキュメントのセマンティックハッシュを計算します。
    /// </summary>
    /// <param name="canonicalized">正規化された ROM ドキュメント</param>
    /// <returns>ハッシュ値</returns>
    string ComputeHash(AIKernel.Dtos.Rom.CanonicalizedRomDocument canonicalized);

    /// <summary>
    /// ドキュメント本文と期待ハッシュの一致を検証します。
    /// RCS-F003: ハッシュ不整合時は署名検証失敗とする。
    /// </summary>
    /// <param name="document">対象の ROM ドキュメント</param>
    /// <param name="expectedHash">期待されるハッシュ値</param>
    /// <param name="cancellationToken">キャンセルトークン</param>
    /// <returns>ハッシュが一致したかどうか</returns>
    Task<bool> VerifyHashAsync(IRomDocument document, string expectedHash, CancellationToken cancellationToken = default);

    /// <summary>
    /// Linguistic Normalization を適用します。
    /// RCS-004: 全角/半角、大文字/小文字、冗長な助詞表現を正規化。
    /// </summary>
    /// <param name="text">正規化対象のテキスト</param>
    /// <returns>正規化済みテキスト</returns>
    string NormalizeLinguistic(string text);

    /// <summary>
    /// Structural Sorting を適用します。
    /// RCS-004: 同一見出しレベル内の bullet 集合を文字列ソート。
    /// </summary>
    /// <param name="items">ソート対象のアイテムリスト</param>
    /// <returns>ソート済みアイテムリスト</returns>
    IReadOnlyList<string> SortStructurally(IEnumerable<string> items);

    /// <summary>
    /// Reference Anchoring を適用します。
    /// RCS-004: [[entity.id]] を完全修飾 ID へ置換。
    /// </summary>
    /// <param name="referenceId">参照 ID（例: "user.tky"）</param>
    /// <param name="relationResolver">関係解決サービス</param>
    /// <param name="cancellationToken">キャンセルトークン</param>
    /// <returns>完全修飾 ID（例: "namespace.project.user.tky"）</returns>
    Task<string> ResolveReferenceAsync(
        string referenceId,
        IRelationResolver relationResolver,
        CancellationToken cancellationToken = default);
}
