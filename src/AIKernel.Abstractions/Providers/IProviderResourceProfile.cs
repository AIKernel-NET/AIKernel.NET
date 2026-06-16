namespace AIKernel.Abstractions.Providers;

/// <summary>
/// EN: UC-05/UC-19/UC-23/UC-26/UC-27 に基づく IProviderResourceProfile の契約を定義します。
/// [EN] Documents this public package API member. [JA] IProviderResourceProfile の公開契約を定義します。
/// </summary>
/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.Providers.IProviderResourceProfile']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.Providers.IProviderResourceProfile']" />
public interface IProviderResourceProfile
{
    /// <summary>EN: Gets the ProviderId value exposed by the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで公開される ProviderId 値を取得します。</summary>
    string ProviderId { get; }
    /// <summary>EN: Gets the CreditInfo value exposed by the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで公開される CreditInfo 値を取得します。</summary>
    IProviderCreditInfo CreditInfo { get; }
    /// <summary>EN: Gets the CostProfile value exposed by the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで公開される CostProfile 値を取得します。</summary>
    IProviderCostProfile CostProfile { get; }
    /// <summary>EN: Gets the UsageStats value exposed by the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで公開される UsageStats 値を取得します。</summary>
    IProviderUsageStats UsageStats { get; }
    /// <summary>EN: Gets the BillingInfo value exposed by the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで公開される BillingInfo 値を取得します。</summary>
    IProviderBillingInfo BillingInfo { get; }
    /// <summary>EN: Gets the HealthScore value exposed by the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで公開される HealthScore 値を取得します。</summary>
    double HealthScore { get; }
    /// <summary>EN: Gets the UpdatedAtUtc value exposed by the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで公開される UpdatedAtUtc 値を取得します。</summary>
    DateTimeOffset UpdatedAtUtc { get; }
}




