namespace AIKernel.Dtos.Rom;

/// <summary>
/// EntityTypeSchema の契約を定義します。
/// JA: EntityTypeSchema の公開契約を定義します。
/// </summary>
/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Dtos.Rom.EntityTypeSchema']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Dtos.Rom.EntityTypeSchema']" />
public sealed record EntityTypeSchema
{
    /// <include file="docs.en.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Rom.EntityTypeSchema.TypeName']" />
    /// <include file="docs.ja.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Rom.EntityTypeSchema.TypeName']" />
    public required string TypeName { get; init; }
    /// <include file="docs.en.xml" path="doc/members/member[@name='M:AIKernel.Dtos.Rom.EntityTypeSchema.List&lt;string&gt;']" />
    /// <include file="docs.ja.xml" path="doc/members/member[@name='M:AIKernel.Dtos.Rom.EntityTypeSchema.List&lt;string&gt;']" />
    public IReadOnlyList<string> RequiredProperties { get; init; } = new List<string>();
    /// <summary>Gets the AllowedProperties value exposed by the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで公開される AllowedProperties 値を取得します。</summary>
    public IReadOnlyList<string> AllowedProperties { get; init; } = new List<string>();
    /// <include file="docs.en.xml" path="doc/members/member[@name='M:AIKernel.Dtos.Rom.EntityTypeSchema.string&gt;']" />
    /// <include file="docs.ja.xml" path="doc/members/member[@name='M:AIKernel.Dtos.Rom.EntityTypeSchema.string&gt;']" />
    public IReadOnlyDictionary<string, string> PropertyTypes { get; init; } = new Dictionary<string, string>();
}




