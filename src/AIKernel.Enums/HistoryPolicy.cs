namespace AIKernel.Enums;

/// <summary>
/// EN: HistoryPolicy の契約を定義します。
/// [EN] Documents this public package API member. [JA] HistoryPolicy の公開契約を定義します。
/// </summary>
/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Enums.HistoryPolicy']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Enums.HistoryPolicy']" />
public enum HistoryPolicy
{
    /// <summary>EN: Gets the AsMaterial value exposed by the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで公開される AsMaterial 値を取得します。</summary>
    AsMaterial = 0,
    /// <summary>EN: Gets the AsContext value exposed by the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで公開される AsContext 値を取得します。</summary>
    AsContext = 1,
    /// <summary>EN: Gets the Discard value exposed by the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで公開される Discard 値を取得します。</summary>
    Discard = 2
}



