using AIKernel.Enums;

namespace AIKernel.Dtos.Context;

/// <summary>
/// MaterialContext のデータを表現する DTO です。
/// RAG の断片や外部情報を含み、必ず正規化・構造化して使用します。
/// 
/// 参照: 2.CONTEXT_ISOLATION_SPEC.jp.md
/// </summary>
/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Dtos.Context.MaterialContextDto']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Dtos.Context.MaterialContextDto']" />
public sealed class MaterialContextDto
{
    /// <summary>
    /// 取得元ソースを取得または設定します。
    /// </summary>
    /// <include file="docs.en.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Context.MaterialContextDto.Source']" />
    /// <include file="docs.ja.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Context.MaterialContextDto.Source']" />
    public required string Source { get; init; }

    /// <summary>
    /// 生の素材データを取得または設定します。
    /// </summary>
    /// <include file="docs.en.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Context.MaterialContextDto.RawData']" />
    /// <include file="docs.ja.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Context.MaterialContextDto.RawData']" />
    public required string RawData { get; init; }

    /// <summary>
    /// 正規化されたデータを取得または設定します。
    /// 不要情報が除去されたバージョン。
    /// </summary>
    /// <include file="docs.en.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Context.MaterialContextDto.NormalizedData']" />
    /// <include file="docs.ja.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Context.MaterialContextDto.NormalizedData']" />
    public string? NormalizedData { get; init; }

    /// <summary>
    /// 構造化されたデータを取得または設定します。
    /// 要素分解・抽象化・意味単位化されたバージョン。
    /// </summary>
    /// <include file="docs.en.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Context.MaterialContextDto.object']" />
    /// <include file="docs.ja.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Context.MaterialContextDto.object']" />
    public Dictionary<string, object>? StructuredData { get; init; }

    /// <summary>
    /// 関連性スコアを取得または設定します（0.0 ～ 1.0）。
    /// </summary>
    /// <include file="docs.en.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Context.MaterialContextDto.RelevanceScore']" />
    /// <include file="docs.ja.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Context.MaterialContextDto.RelevanceScore']" />
    public double RelevanceScore { get; init; } = 1.0;

    /// <summary>
    /// メタデータを取得または設定します。
    /// </summary>
    /// <include file="docs.en.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Context.MaterialContextDto.object']" />
    /// <include file="docs.ja.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Context.MaterialContextDto.object']" />
    public Dictionary<string, object>? Metadata { get; init; }

    /// <summary>
    /// 取得日時を取得または設定します。
    /// </summary>
    /// <include file="docs.en.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Context.MaterialContextDto.RetrievedAt']" />
    /// <include file="docs.ja.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Context.MaterialContextDto.RetrievedAt']" />
    public DateTime RetrievedAt { get; init; }
}


