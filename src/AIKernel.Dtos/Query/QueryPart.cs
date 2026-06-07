namespace AIKernel.Dtos.Query;

using System.Collections.Immutable;

/// <summary>
/// Phase 1 の Query Processing によって生成される、意味的に独立した query fragment を表します。
/// </summary>
/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Dtos.Query.QueryPart']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Dtos.Query.QueryPart']" />
public sealed record QueryPart
{
    /// <summary>
    /// QueryPart の一意識別子を取得します。
    /// </summary>
    /// <include file="docs.en.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Query.QueryPart.QueryPartId']" />
    /// <include file="docs.ja.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Query.QueryPart.QueryPartId']" />
    public required string QueryPartId { get; init; }

    /// <summary>
    /// 元 query から分割または補間された query text を取得します。
    /// </summary>
    /// <include file="docs.en.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Query.QueryPart.Text']" />
    /// <include file="docs.ja.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Query.QueryPart.Text']" />
    public required string Text { get; init; }

    /// <summary>
    /// 元 query 内での安定した順序を取得します。
    /// </summary>
    /// <include file="docs.en.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Query.QueryPart.Order']" />
    /// <include file="docs.ja.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Query.QueryPart.Order']" />
    public required int Order { get; init; }

    /// <summary>
    /// 元 query 全体を識別する任意の ID を取得します。
    /// </summary>
    /// <include file="docs.en.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Query.QueryPart.ParentQueryId']" />
    /// <include file="docs.ja.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Query.QueryPart.ParentQueryId']" />
    public string? ParentQueryId { get; init; }

    /// <summary>
    /// この QueryPart の意味的な役割を取得します。
    /// </summary>
    /// <include file="docs.en.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Query.QueryPart.Role']" />
    /// <include file="docs.ja.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Query.QueryPart.Role']" />
    public string? Role { get; init; }

    /// <summary>
    /// ルーティングや監査に使う追加メタデータを取得します。
    /// </summary>
    /// <include file="docs.en.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Query.QueryPart.string']" />
    /// <include file="docs.ja.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Query.QueryPart.string']" />
    public ImmutableDictionary<string, string> Metadata { get; init; } = ImmutableDictionary<string, string>.Empty;
}
