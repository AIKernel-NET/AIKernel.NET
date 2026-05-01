using AIKernel.Abstractions.Context;

namespace AIKernel.Abstractions.Material;

/// <summary>
/// 素材を検疫（検証・正規化）するインターフェース。
/// 生データの流入を防ぎ、必ず正規化されたコンテンツを返すか例外を投げます。
/// </summary>
public interface IMaterialQuarantine
{
    /// <summary>
    /// コンテキストフラグメントを検疫します。
    /// </summary>
    /// <param name="rawFragment">検疫対象のフラグメント</param>
    /// <param name="ct">キャンセルトークン</param>
    /// <returns>正規化されたコンテンツを含む IStructuredMaterial</returns>
    /// <exception cref="Exceptions.QuarantineFailedException">検疫に失敗した場合</exception>
    Task<IStructuredMaterial> QuarantineAsync(ContextFragment rawFragment, CancellationToken ct = default);
}
