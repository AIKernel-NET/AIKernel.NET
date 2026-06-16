namespace AIKernel.Enums;

/// <summary>[EN] Documents this public package API member. [JA] DynamicSlmGraphUpdateKind の値を定義します。</summary>
/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Enums.DynamicSlmGraphUpdateKind']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Enums.DynamicSlmGraphUpdateKind']" />
public enum DynamicSlmGraphUpdateKind
{
    /// <summary>EN: Gets the Unknown value exposed by the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで公開される Unknown 値を取得します。</summary>
    Unknown = 0,
    /// <summary>EN: Gets the AddCapabilityNode value exposed by the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで公開される AddCapabilityNode 値を取得します。</summary>
    AddCapabilityNode = 1,
    /// <summary>EN: Gets the AddCapabilityEdge value exposed by the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで公開される AddCapabilityEdge 値を取得します。</summary>
    AddCapabilityEdge = 2,
    /// <summary>EN: Gets the RefineCapabilityNode value exposed by the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで公開される RefineCapabilityNode 値を取得します。</summary>
    RefineCapabilityNode = 3,
    /// <summary>EN: Gets the ReplaceCapabilityPayload value exposed by the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで公開される ReplaceCapabilityPayload 値を取得します。</summary>
    ReplaceCapabilityPayload = 4
}
