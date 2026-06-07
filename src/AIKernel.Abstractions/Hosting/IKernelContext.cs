namespace AIKernel.Abstractions.Hosting;

/// <summary>
/// UC-14 に基づく IKernelContext の契約を定義します。
/// </summary>
/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.Hosting.IKernelContext']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.Hosting.IKernelContext']" />
public interface IKernelContext
{
    /// <summary>Gets the ContextId value exposed by the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで公開される ContextId 値を取得します。</summary>
    string ContextId { get; }
    /// <summary>Gets the Contract value exposed by the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで公開される Contract 値を取得します。</summary>
    UnifiedContextDto? Contract { get; }
    /// <summary>Gets the CreatedAtUtc value exposed by the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで公開される CreatedAtUtc 値を取得します。</summary>
    DateTimeOffset CreatedAtUtc { get; }
    /// <summary>Gets the Attributes value exposed by the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで公開される Attributes 値を取得します。</summary>
    IReadOnlyDictionary<string, string> Attributes { get; }
    /// <summary>Gets the TraceContext value exposed by the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで公開される TraceContext 値を取得します。</summary>
    TraceContext? TraceContext { get; }
    /// <summary>Gets the Identity value exposed by the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで公開される Identity 値を取得します。</summary>
    Identity? Identity { get; }
    /// <summary>Gets the Permissions value exposed by the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで公開される Permissions 値を取得します。</summary>
    IReadOnlyList<Permission> Permissions { get; }
    /// <summary>Gets the Budget value exposed by the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで公開される Budget 値を取得します。</summary>
    Budget? Budget { get; }
    /// <summary>Gets the DataClassification value exposed by the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで公開される DataClassification 値を取得します。</summary>
    DataClassification? DataClassification { get; }
    /// <summary>Gets the TrustContext value exposed by the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで公開される TrustContext 値を取得します。</summary>
    TrustContext? TrustContext { get; }
}



