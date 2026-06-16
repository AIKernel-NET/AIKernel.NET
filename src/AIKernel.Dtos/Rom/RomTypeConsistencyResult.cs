namespace AIKernel.Dtos.Rom;

/// <summary>
/// EN: RomTypeConsistencyResult の契約を定義します。
/// [EN] Documents this public package API member. [JA] RomTypeConsistencyResult の公開契約を定義します。
/// </summary>
/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Dtos.Rom.RomTypeConsistencyResult']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Dtos.Rom.RomTypeConsistencyResult']" />
public sealed record RomTypeConsistencyResult
{
    /// <summary>[EN] Documents this public package API member. [JA] IsConsistent を取得します。</summary>
    /// <include file="docs.en.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Rom.RomTypeConsistencyResult.IsConsistent']" />
    /// <include file="docs.ja.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Rom.RomTypeConsistencyResult.IsConsistent']" />
    public required bool IsConsistent { get; init; }
    /// <summary>[EN] Documents this public package API member. [JA] Message を取得します。</summary>
    /// <include file="docs.en.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Rom.RomTypeConsistencyResult.Message']" />
    /// <include file="docs.ja.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Rom.RomTypeConsistencyResult.Message']" />
    public required string Message { get; init; }
    /// <summary>[EN] Documents this public package API member. [JA] Inconsistencies を実行します。</summary>
    /// <include file="docs.en.xml" path="doc/members/member[@name='M:AIKernel.Dtos.Rom.RomTypeConsistencyResult.List&lt;string&gt;']" />
    /// <include file="docs.ja.xml" path="doc/members/member[@name='M:AIKernel.Dtos.Rom.RomTypeConsistencyResult.List&lt;string&gt;']" />
    public IReadOnlyList<string> Inconsistencies { get; init; } = new List<string>();
    /// <summary>EN: Gets the MissingProperties value exposed by the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで公開される MissingProperties 値を取得します。</summary>
    public IReadOnlyList<string> MissingProperties { get; init; } = new List<string>();
}




