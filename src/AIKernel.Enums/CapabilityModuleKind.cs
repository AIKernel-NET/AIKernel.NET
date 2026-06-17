namespace AIKernel.Enums;

/// <summary>
/// EN: Declares how an external capability module is packaged or invoked.
/// [EN] Documents this public package API member. [JA] CapabilityModuleKind の公開契約を定義します。
/// </summary>
/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Enums.CapabilityModuleKind']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Enums.CapabilityModuleKind']" />
public enum CapabilityModuleKind
{
    /// <summary>EN: Gets the Unknown value exposed by the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで公開される Unknown 値を取得します。</summary>
    Unknown = 0,
    /// <summary>EN: Gets the CliExecutable value exposed by the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで公開される CliExecutable 値を取得します。</summary>
    CliExecutable = 1,
    /// <summary>EN: Gets the ManagedAssembly value exposed by the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで公開される ManagedAssembly 値を取得します。</summary>
    ManagedAssembly = 2,
    /// <summary>EN: Gets the NativeLibrary value exposed by the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで公開される NativeLibrary 値を取得します。</summary>
    NativeLibrary = 3,
    /// <summary>EN: Gets the DslRom value exposed by the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで公開される DslRom 値を取得します。</summary>
    DslRom = 4,
    /// <summary>EN: Gets the RemoteEndpoint value exposed by the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで公開される RemoteEndpoint 値を取得します。</summary>
    RemoteEndpoint = 5
}
