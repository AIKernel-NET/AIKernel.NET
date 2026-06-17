namespace AIKernel.Dtos.Query;

using System.Collections.Immutable;

/// <summary>
/// EN: Phase 1 の Query Processing によって生成される、意味的に独立した query fragment を表します。
/// [EN] Documents this public package API member. [JA] QueryPart の公開契約を定義します。
/// </summary>
/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Dtos.Query.QueryPart']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Dtos.Query.QueryPart']" />
public sealed record QueryPart
{
    /// <summary>
    /// EN: QueryPart の一意識別子を取得します。
    /// [EN] Documents this public package API member. [JA] QueryPartId を取得します。
    /// </summary>
    /// <include file="docs.en.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Query.QueryPart.QueryPartId']" />
    /// <include file="docs.ja.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Query.QueryPart.QueryPartId']" />
    public required string QueryPartId { get; init; }

    /// <summary>
    /// EN: 元 query から分割または補間された query text を取得します。
    /// [EN] Documents this public package API member. [JA] Text を取得します。
    /// </summary>
    /// <include file="docs.en.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Query.QueryPart.Text']" />
    /// <include file="docs.ja.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Query.QueryPart.Text']" />
    public required string Text { get; init; }

    /// <summary>
    /// EN: 元 query 内での安定した順序を取得します。
    /// [EN] Documents this public package API member. [JA] Order を取得します。
    /// </summary>
    /// <include file="docs.en.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Query.QueryPart.Order']" />
    /// <include file="docs.ja.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Query.QueryPart.Order']" />
    public required int Order { get; init; }

    /// <summary>
    /// EN: 元 query 全体を識別する任意の ID を取得します。
    /// [EN] Documents this public package API member. [JA] ParentQueryId を取得します。
    /// </summary>
    /// <include file="docs.en.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Query.QueryPart.ParentQueryId']" />
    /// <include file="docs.ja.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Query.QueryPart.ParentQueryId']" />
    public string? ParentQueryId { get; init; }

    /// <summary>
    /// EN: この QueryPart の意味的な役割を取得します。
    /// [EN] Documents this public package API member. [JA] Role を取得します。
    /// </summary>
    /// <include file="docs.en.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Query.QueryPart.Role']" />
    /// <include file="docs.ja.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Query.QueryPart.Role']" />
    public string? Role { get; init; }

    /// <summary>
    /// EN: ルーティングや監査に使う追加メタデータを取得します。
    /// [EN] Documents this public package API member. [JA] Metadata を取得します。
    /// </summary>
    /// <include file="docs.en.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Query.QueryPart.string']" />
    /// <include file="docs.ja.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Query.QueryPart.string']" />
    public ImmutableDictionary<string, string> Metadata { get; init; } = ImmutableDictionary<string, string>.Empty;
}
