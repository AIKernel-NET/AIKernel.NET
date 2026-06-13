namespace AIKernel.Abstractions.Providers;

/// <summary>
/// UC-05/UC-19/UC-23/UC-26/UC-27 に基づく IProviderCreditInfo の契約を定義します。
/// JA: IProviderCreditInfo の公開契約を定義します。
/// </summary>
/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.Providers.IProviderCreditInfo']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.Providers.IProviderCreditInfo']" />
public interface IProviderCreditInfo
{
    /// <summary>Gets the ProviderId value exposed by the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで公開される ProviderId 値を取得します。</summary>
    string ProviderId { get; }
    /// <summary>Gets the CurrencyCode value exposed by the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで公開される CurrencyCode 値を取得します。</summary>
    string CurrencyCode { get; }
    /// <summary>Gets the CurrentBalance value exposed by the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで公開される CurrentBalance 値を取得します。</summary>
    decimal CurrentBalance { get; }
    /// <summary>Gets the ReservedBalance value exposed by the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで公開される ReservedBalance 値を取得します。</summary>
    decimal ReservedBalance { get; }
    /// <summary>Gets the HardLimit value exposed by the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで公開される HardLimit 値を取得します。</summary>
    decimal HardLimit { get; }
    /// <summary>Gets the SoftLimit value exposed by the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで公開される SoftLimit 値を取得します。</summary>
    decimal SoftLimit { get; }
    /// <summary>Gets the LastUpdatedUtc value exposed by the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで公開される LastUpdatedUtc 値を取得します。</summary>
    DateTimeOffset LastUpdatedUtc { get; }
}




