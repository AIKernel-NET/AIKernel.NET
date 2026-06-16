namespace AIKernel.Abstractions.Hosting;

/// <summary>
/// EN: UC-14 に基づく IKernelContext の契約を定義します。
/// [EN] Documents this public package API member. [JA] IKernelContext の公開契約を定義します。
/// </summary>
/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.Hosting.IKernelContext']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.Hosting.IKernelContext']" />
public interface IKernelContext
{
    /// <summary>EN: Gets the ContextId value exposed by the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで公開される ContextId 値を取得します。</summary>
    string ContextId { get; }
    /// <summary>EN: Gets the Contract value exposed by the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで公開される Contract 値を取得します。</summary>
    UnifiedContextDto? Contract { get; }
    /// <summary>EN: Gets the CreatedAtUtc value exposed by the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで公開される CreatedAtUtc 値を取得します。</summary>
    DateTimeOffset CreatedAtUtc { get; }
    /// <summary>EN: Gets the Attributes value exposed by the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで公開される Attributes 値を取得します。</summary>
    IReadOnlyDictionary<string, string> Attributes { get; }
    /// <summary>EN: Gets the TraceContext value exposed by the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで公開される TraceContext 値を取得します。</summary>
    TraceContext? TraceContext { get; }
    /// <summary>EN: Gets the Identity value exposed by the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで公開される Identity 値を取得します。</summary>
    Identity? Identity { get; }
    /// <summary>EN: Gets the Permissions value exposed by the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで公開される Permissions 値を取得します。</summary>
    IReadOnlyList<Permission> Permissions { get; }
    /// <summary>EN: Gets the Budget value exposed by the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで公開される Budget 値を取得します。</summary>
    Budget? Budget { get; }
    /// <summary>EN: Gets the DataClassification value exposed by the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで公開される DataClassification 値を取得します。</summary>
    DataClassification? DataClassification { get; }
    /// <summary>EN: Gets the TrustContext value exposed by the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで公開される TrustContext 値を取得します。</summary>
    TrustContext? TrustContext { get; }
}



