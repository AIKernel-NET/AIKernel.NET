namespace AIKernel.Dtos.Material;

/// <summary>
/// EN: 素材の出典情報を表現します。
/// EN: Documentation for public API. JA: SourceInfo の公開契約を定義します。
/// </summary>
/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Dtos.Material.SourceInfo']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Dtos.Material.SourceInfo']" />
public sealed class SourceInfo
{
    /// <summary>
    /// EN: 出典の一意識別子を取得または設定します。
    /// EN: Documentation for public API. JA: SourceId を取得します。
    /// </summary>
    /// <include file="docs.en.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Material.SourceInfo.SourceId']" />
    /// <include file="docs.ja.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Material.SourceInfo.SourceId']" />
    public required string SourceId { get; init; }

    /// <summary>
    /// EN: 出典の型（例: "database", "api", "file", "user_input"）を取得または設定します。
    /// EN: Documentation for public API. JA: SourceType を取得します。
    /// </summary>
    /// <include file="docs.en.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Material.SourceInfo.SourceType']" />
    /// <include file="docs.ja.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Material.SourceInfo.SourceType']" />
    public required string SourceType { get; init; }

    /// <summary>
    /// EN: 素材が収集された日時を取得または設定します。
    /// EN: Documentation for public API. JA: CollectedAt を取得します。
    /// </summary>
    /// <include file="docs.en.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Material.SourceInfo.CollectedAt']" />
    /// <include file="docs.ja.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Material.SourceInfo.CollectedAt']" />
    public required DateTimeOffset CollectedAt { get; init; }

    /// <summary>
    /// EN: 出典に関する追加のメタデータを取得または設定します。
    /// EN: Documentation for public API. JA: Metadata を取得します。
    /// </summary>
    /// <include file="docs.en.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Material.SourceInfo.string']" />
    /// <include file="docs.ja.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Material.SourceInfo.string']" />
    public IReadOnlyDictionary<string, string>? Metadata { get; init; }
}


