namespace AIKernel.Dtos.Context;

using AIKernel.Enums;

/// <summary>
/// EN: ContextFragment の契約を定義します。
/// [EN] Documents this public package API member. [JA] ContextFragment の公開契約を定義します。
/// </summary>
/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Dtos.Context.ContextFragment']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Dtos.Context.ContextFragment']" />
public class ContextFragment
{
    /// <summary>[EN] Documents this public package API member. [JA] FragmentId を取得します。</summary>
    /// <include file="docs.en.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Context.ContextFragment.FragmentId']" />
    /// <include file="docs.ja.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Context.ContextFragment.FragmentId']" />
    public string FragmentId { get; init; } = string.Empty;
    /// <summary>[EN] Documents this public package API member. [JA] Category を取得します。</summary>
    /// <include file="docs.en.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Context.ContextFragment.Category']" />
    /// <include file="docs.ja.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Context.ContextFragment.Category']" />
    public ContextCategory Category { get; init; }
    /// <summary>[EN] Documents this public package API member. [JA] Content を取得します。</summary>
    /// <include file="docs.en.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Context.ContextFragment.Content']" />
    /// <include file="docs.ja.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Context.ContextFragment.Content']" />
    public string Content { get; init; } = string.Empty;
    /// <summary>[EN] Documents this public package API member. [JA] Priority を取得します。</summary>
    /// <include file="docs.en.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Context.ContextFragment.Priority']" />
    /// <include file="docs.ja.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Context.ContextFragment.Priority']" />
    public double Priority { get; init; } = 0.5;
    /// <summary>[EN] Documents this public package API member. [JA] CreatedAt を取得します。</summary>
    /// <include file="docs.en.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Context.ContextFragment.CreatedAt']" />
    /// <include file="docs.ja.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Context.ContextFragment.CreatedAt']" />
    public DateTime CreatedAt { get; init; }
    /// <summary>[EN] Documents this public package API member. [JA] Metadata を取得します。</summary>
    /// <include file="docs.en.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Context.ContextFragment.string']" />
    /// <include file="docs.ja.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Context.ContextFragment.string']" />
    public IReadOnlyDictionary<string, string>? Metadata { get; init; }
}



