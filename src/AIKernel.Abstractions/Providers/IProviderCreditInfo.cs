namespace AIKernel.Abstractions.Providers;

/// <summary>
/// EN: UC-05/UC-19/UC-23/UC-26/UC-27 に基づく IProviderCreditInfo の契約を定義します。
/// EN: Documentation for public API. JA: IProviderCreditInfo の公開契約を定義します。
/// </summary>
/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.Providers.IProviderCreditInfo']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.Providers.IProviderCreditInfo']" />
public interface IProviderCreditInfo
{
    /// <summary>EN: Gets the ProviderId value exposed by the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで公開される ProviderId 値を取得します。</summary>
    string ProviderId { get; }
    /// <summary>EN: Gets the CurrencyCode value exposed by the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで公開される CurrencyCode 値を取得します。</summary>
    string CurrencyCode { get; }
    /// <summary>EN: Gets the CurrentBalance value exposed by the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで公開される CurrentBalance 値を取得します。</summary>
    decimal CurrentBalance { get; }
    /// <summary>EN: Gets the ReservedBalance value exposed by the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで公開される ReservedBalance 値を取得します。</summary>
    decimal ReservedBalance { get; }
    /// <summary>EN: Gets the HardLimit value exposed by the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで公開される HardLimit 値を取得します。</summary>
    decimal HardLimit { get; }
    /// <summary>EN: Gets the SoftLimit value exposed by the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで公開される SoftLimit 値を取得します。</summary>
    decimal SoftLimit { get; }
    /// <summary>EN: Gets the LastUpdatedUtc value exposed by the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで公開される LastUpdatedUtc 値を取得します。</summary>
    DateTimeOffset LastUpdatedUtc { get; }
}




