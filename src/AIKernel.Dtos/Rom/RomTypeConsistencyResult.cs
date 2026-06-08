namespace AIKernel.Dtos.Rom;

/// <summary>
/// RomTypeConsistencyResult の契約を定義します。
/// </summary>
/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Dtos.Rom.RomTypeConsistencyResult']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Dtos.Rom.RomTypeConsistencyResult']" />
public sealed record RomTypeConsistencyResult
{
    /// <include file="docs.en.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Rom.RomTypeConsistencyResult.IsConsistent']" />
    /// <include file="docs.ja.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Rom.RomTypeConsistencyResult.IsConsistent']" />
    public required bool IsConsistent { get; init; }
    /// <include file="docs.en.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Rom.RomTypeConsistencyResult.Message']" />
    /// <include file="docs.ja.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Rom.RomTypeConsistencyResult.Message']" />
    public required string Message { get; init; }
    /// <include file="docs.en.xml" path="doc/members/member[@name='M:AIKernel.Dtos.Rom.RomTypeConsistencyResult.List&lt;string&gt;']" />
    /// <include file="docs.ja.xml" path="doc/members/member[@name='M:AIKernel.Dtos.Rom.RomTypeConsistencyResult.List&lt;string&gt;']" />
    public IReadOnlyList<string> Inconsistencies { get; init; } = new List<string>();
    /// <summary>Gets the MissingProperties value exposed by the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで公開される MissingProperties 値を取得します。</summary>
    public IReadOnlyList<string> MissingProperties { get; init; } = new List<string>();
}




