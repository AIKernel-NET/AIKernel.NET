using AIKernel.Dtos.Context;

namespace AIKernel.Abstractions.Material;

/// <summary>
/// EN: UC-21（マテリアル検疫とポリシー実行）に基づき、スキャン済み素材を検疫・正規化する契約を定義します。
/// EN: Documentation for public API. JA: IMaterialQuarantine の公開契約を定義します。
/// </summary>
/// <remarks>
/// IMaterialScanner が実施する物理スキャンと責務を分離し、
/// 本インターフェースは検疫ロジック適用後の IStructuredMaterial への昇格のみを担います。
/// </remarks>
/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.Material.IMaterialQuarantine']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.Material.IMaterialQuarantine']" />
public interface IMaterialQuarantine
{
    /// <summary>
    /// EN: コンテキストフラグメントを検疫します。
    /// EN: Documentation for public API. JA: QuarantineAsync 操作を実行します。
    /// </summary>
    /// <param name="rawFragment">EN: Documentation for public API. JA: 検疫対象のフラグメント rawFragment パラメーターです。</param>
    /// <param name="ct">EN: Documentation for public API. JA: キャンセルトークン ct パラメーターです。</param>
    /// <returns>EN: Documentation for public API. JA: 正規化されたコンテンツを含む IStructuredMaterial 結果を返します。</returns>
    Task<IStructuredMaterial> QuarantineAsync(ContextFragment rawFragment, CancellationToken ct = default);
}


