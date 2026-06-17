namespace AIKernel.Enums;

/// <summary>
/// EN: Identifies the four slots of AIKernel Semantic IR without prescribing runtime behavior.
/// [EN] Documents this public package API member. [JA] SemanticIrSlot の公開契約を定義します。
/// </summary>
/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Enums.SemanticIrSlot']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Enums.SemanticIrSlot']" />
public enum SemanticIrSlot
{
    /// <summary>EN: Gets the Unknown value exposed by the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで公開される Unknown 値を取得します。</summary>
    Unknown = 0,
    /// <summary>EN: Gets the G value exposed by the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで公開される G 値を取得します。</summary>
    G = 1,
    /// <summary>EN: Gets the T value exposed by the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで公開される T 値を取得します。</summary>
    T = 2,
    /// <summary>EN: Gets the C value exposed by the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで公開される C 値を取得します。</summary>
    C = 3,
    /// <summary>EN: Gets the B value exposed by the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで公開される B 値を取得します。</summary>
    B = 4
}
