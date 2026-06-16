namespace AIKernel.Enums;

/// <summary>
/// EN: GuardAction の契約を定義します。
/// EN: Documentation for public API. JA: GuardAction の公開契約を定義します。
/// </summary>
/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Enums.GuardAction']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Enums.GuardAction']" />
public enum GuardAction
{
    /// <summary>EN: Gets the Continue value exposed by the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで公開される Continue 値を取得します。</summary>
    Continue = 1,
    /// <summary>EN: Gets the Warn value exposed by the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで公開される Warn 値を取得します。</summary>
    Warn = 2,
    /// <summary>EN: Gets the Block value exposed by the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで公開される Block 値を取得します。</summary>
    Block = 3,
    /// <summary>EN: Gets the FallBack value exposed by the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで公開される FallBack 値を取得します。</summary>
    FallBack = 4
}



