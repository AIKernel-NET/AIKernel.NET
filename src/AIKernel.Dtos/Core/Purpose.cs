namespace AIKernel.Dtos.Core;

/// <summary>
/// 目的を表現します。
/// EN: 処理の意図と目標を定義します。
/// [EN] Documents this public package API member. [JA] Purpose の公開契約を定義します。
/// </summary>
/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Dtos.Core.Purpose']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Dtos.Core.Purpose']" />
public sealed class Purpose
{
    /// <summary>[EN] Documents this public package API member. [JA] PurposeId を取得します。</summary>
    /// <include file="docs.en.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Core.Purpose.PurposeId']" />
    /// <include file="docs.ja.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Core.Purpose.PurposeId']" />
    public required string PurposeId { get; init; }
    /// <summary>[EN] Documents this public package API member. [JA] Description を取得します。</summary>
    /// <include file="docs.en.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Core.Purpose.Description']" />
    /// <include file="docs.ja.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Core.Purpose.Description']" />
    public required string Description { get; init; }
    /// <summary>[EN] Documents this public package API member. [JA] Priority を取得します。</summary>
    /// <include file="docs.en.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Core.Purpose.Priority']" />
    /// <include file="docs.ja.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Core.Purpose.Priority']" />
    public int Priority { get; init; } = 5;
    /// <summary>[EN] Documents this public package API member. [JA] Tags を実行します。</summary>
    /// <include file="docs.en.xml" path="doc/members/member[@name='M:AIKernel.Dtos.Core.Purpose.new']" />
    /// <include file="docs.ja.xml" path="doc/members/member[@name='M:AIKernel.Dtos.Core.Purpose.new']" />
    public List<string> Tags { get; init; } = new();
    /// <summary>[EN] Documents this public package API member. [JA] SuccessCriteria を取得します。</summary>
    /// <include file="docs.en.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Core.Purpose.SuccessCriteria']" />
    /// <include file="docs.ja.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Core.Purpose.SuccessCriteria']" />
    public string? SuccessCriteria { get; init; }
    /// <summary>[EN] Documents this public package API member. [JA] CreatedAt を取得します。</summary>
    /// <include file="docs.en.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Core.Purpose.CreatedAt']" />
    /// <include file="docs.ja.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Core.Purpose.CreatedAt']" />
    public DateTime CreatedAt { get; init; }
}


