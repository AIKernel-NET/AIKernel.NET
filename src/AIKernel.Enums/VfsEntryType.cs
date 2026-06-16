namespace AIKernel.Enums;

/// <summary>
/// EN: VfsEntryType の契約を定義します。
/// EN: Documentation for public API. JA: VfsEntryType の公開契約を定義します。
/// </summary>
/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Enums.VfsEntryType']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Enums.VfsEntryType']" />
public enum VfsEntryType
{
    /// <summary>EN: Gets the File value exposed by the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで公開される File 値を取得します。</summary>
    File = 1,
    /// <summary>EN: Gets the Directory value exposed by the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで公開される Directory 値を取得します。</summary>
    Directory = 2,
    /// <summary>EN: Gets the Link value exposed by the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで公開される Link 値を取得します。</summary>
    Link = 3
}



