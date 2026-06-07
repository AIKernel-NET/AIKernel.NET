using AIKernel.Dtos.Context;

namespace AIKernel.Abstractions.Material;

/// <summary>
/// UC-21（マテリアル検疫とポリシー実行）に基づき、スキャン済み素材を検疫・正規化する契約を定義します。
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
    /// コンテキストフラグメントを検疫します。
    /// </summary>
    /// <param name="rawFragment">検疫対象のフラグメント</param>
    /// <param name="ct">キャンセルトークン</param>
    /// <returns>正規化されたコンテンツを含む IStructuredMaterial</returns>
    Task<IStructuredMaterial> QuarantineAsync(ContextFragment rawFragment, CancellationToken ct = default);
}


