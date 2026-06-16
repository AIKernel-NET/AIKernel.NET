namespace AIKernel.Abstractions.Providers;

/// <summary>
/// EN: UC-05/UC-19/UC-23/UC-26/UC-27 に基づく IProviderUsageStats の契約を定義します。
/// EN: Documentation for public API. JA: IProviderUsageStats の公開契約を定義します。
/// </summary>
/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.Providers.IProviderUsageStats']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.Providers.IProviderUsageStats']" />
public interface IProviderUsageStats
{
    /// <summary>EN: Gets the ProviderId value exposed by the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで公開される ProviderId 値を取得します。</summary>
    string ProviderId { get; }
    /// <summary>EN: Gets the WindowStartUtc value exposed by the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで公開される WindowStartUtc 値を取得します。</summary>
    DateTimeOffset WindowStartUtc { get; }
    /// <summary>EN: Gets the WindowEndUtc value exposed by the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで公開される WindowEndUtc 値を取得します。</summary>
    DateTimeOffset WindowEndUtc { get; }
    /// <summary>EN: Gets the RequestsCount value exposed by the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで公開される RequestsCount 値を取得します。</summary>
    long RequestsCount { get; }
    /// <summary>EN: Gets the InputTokens value exposed by the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで公開される InputTokens 値を取得します。</summary>
    long InputTokens { get; }
    /// <summary>EN: Gets the OutputTokens value exposed by the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで公開される OutputTokens 値を取得します。</summary>
    long OutputTokens { get; }
    /// <summary>EN: Gets the AvgLatencyMs value exposed by the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで公開される AvgLatencyMs 値を取得します。</summary>
    double AvgLatencyMs { get; }
    /// <summary>EN: Gets the RateLimitUtilization value exposed by the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで公開される RateLimitUtilization 値を取得します。</summary>
    double RateLimitUtilization { get; }
}




