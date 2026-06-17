using AIKernel.Enums;

namespace AIKernel.Dtos.Context;

/// <summary>
/// MaterialContext のデータを表現する DTO です。
/// RAG の断片や外部情報を含み、必ず正規化・構造化して使用します。
/// 
/// EN: 参照: 2.CONTEXT_ISOLATION_SPEC.jp.md
/// [EN] Documents this public package API member. [JA] MaterialContextDto の公開契約を定義します。
/// </summary>
/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Dtos.Context.MaterialContextDto']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Dtos.Context.MaterialContextDto']" />
public sealed class MaterialContextDto
{
    /// <summary>
    /// EN: 取得元ソースを取得または設定します。
    /// [EN] Documents this public package API member. [JA] Source を取得します。
    /// </summary>
    /// <include file="docs.en.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Context.MaterialContextDto.Source']" />
    /// <include file="docs.ja.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Context.MaterialContextDto.Source']" />
    public required string Source { get; init; }

    /// <summary>
    /// EN: 生の素材データを取得または設定します。
    /// [EN] Documents this public package API member. [JA] RawData を取得します。
    /// </summary>
    /// <include file="docs.en.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Context.MaterialContextDto.RawData']" />
    /// <include file="docs.ja.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Context.MaterialContextDto.RawData']" />
    public required string RawData { get; init; }

    /// <summary>
    /// 正規化されたデータを取得または設定します。
    /// EN: 不要情報が除去されたバージョン。
    /// [EN] Documents this public package API member. [JA] NormalizedData を取得します。
    /// </summary>
    /// <include file="docs.en.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Context.MaterialContextDto.NormalizedData']" />
    /// <include file="docs.ja.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Context.MaterialContextDto.NormalizedData']" />
    public string? NormalizedData { get; init; }

    /// <summary>
    /// 構造化されたデータを取得または設定します。
    /// EN: 要素分解・抽象化・意味単位化されたバージョン。
    /// [EN] Documents this public package API member. [JA] StructuredData を取得します。
    /// </summary>
    /// <include file="docs.en.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Context.MaterialContextDto.object']" />
    /// <include file="docs.ja.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Context.MaterialContextDto.object']" />
    public Dictionary<string, object>? StructuredData { get; init; }

    /// <summary>
    /// EN: 関連性スコアを取得または設定します（0.0 ～ 1.0）。
    /// [EN] Documents this public package API member. [JA] RelevanceScore を取得します。
    /// </summary>
    /// <include file="docs.en.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Context.MaterialContextDto.RelevanceScore']" />
    /// <include file="docs.ja.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Context.MaterialContextDto.RelevanceScore']" />
    public double RelevanceScore { get; init; } = 1.0;

    /// <summary>
    /// EN: メタデータを取得または設定します。
    /// [EN] Documents this public package API member. [JA] Metadata を取得します。
    /// </summary>
    /// <include file="docs.en.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Context.MaterialContextDto.object']" />
    /// <include file="docs.ja.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Context.MaterialContextDto.object']" />
    public Dictionary<string, object>? Metadata { get; init; }

    /// <summary>
    /// EN: 取得日時を取得または設定します。
    /// [EN] Documents this public package API member. [JA] RetrievedAt を取得します。
    /// </summary>
    /// <include file="docs.en.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Context.MaterialContextDto.RetrievedAt']" />
    /// <include file="docs.ja.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Context.MaterialContextDto.RetrievedAt']" />
    public DateTime RetrievedAt { get; init; }
}


