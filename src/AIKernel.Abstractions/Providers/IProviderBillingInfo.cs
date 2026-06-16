namespace AIKernel.Abstractions.Providers;

/// <summary>
/// EN: UC-05/UC-19/UC-23/UC-26/UC-27 に基づく IProviderBillingInfo の契約を定義します。
/// EN: Documentation for public API. JA: IProviderBillingInfo の公開契約を定義します。
/// </summary>
/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.Providers.IProviderBillingInfo']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.Providers.IProviderBillingInfo']" />
public interface IProviderBillingInfo
{
    /// <summary>EN: Gets the ProviderId value exposed by the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで公開される ProviderId 値を取得します。</summary>
    string ProviderId { get; }
    /// <summary>EN: Gets the BillingAccountId value exposed by the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで公開される BillingAccountId 値を取得します。</summary>
    string BillingAccountId { get; }
    /// <summary>EN: Gets the BillingCycle value exposed by the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで公開される BillingCycle 値を取得します。</summary>
    string BillingCycle { get; }
    /// <summary>EN: Gets the CycleStartUtc value exposed by the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで公開される CycleStartUtc 値を取得します。</summary>
    DateTimeOffset CycleStartUtc { get; }
    /// <summary>EN: Gets the CycleEndUtc value exposed by the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで公開される CycleEndUtc 値を取得します。</summary>
    DateTimeOffset CycleEndUtc { get; }
    /// <summary>EN: Gets the AccumulatedCost value exposed by the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで公開される AccumulatedCost 値を取得します。</summary>
    decimal AccumulatedCost { get; }
    /// <summary>EN: Gets the ForecastCost value exposed by the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで公開される ForecastCost 値を取得します。</summary>
    decimal ForecastCost { get; }
    /// <summary>EN: Gets the PaymentStatus value exposed by the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで公開される PaymentStatus 値を取得します。</summary>
    string PaymentStatus { get; }
}




