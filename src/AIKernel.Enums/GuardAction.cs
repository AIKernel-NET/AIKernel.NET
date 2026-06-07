namespace AIKernel.Enums;

/// <summary>
/// GuardAction の契約を定義します。
/// </summary>
/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Enums.GuardAction']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Enums.GuardAction']" />
public enum GuardAction
{
    /// <summary>Gets the Continue value exposed by the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで公開される Continue 値を取得します。</summary>
    Continue = 1,
    /// <summary>Gets the Warn value exposed by the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで公開される Warn 値を取得します。</summary>
    Warn = 2,
    /// <summary>Gets the Block value exposed by the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで公開される Block 値を取得します。</summary>
    Block = 3,
    /// <summary>Gets the FallBack value exposed by the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで公開される FallBack 値を取得します。</summary>
    FallBack = 4
}



