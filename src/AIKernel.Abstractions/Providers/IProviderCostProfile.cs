namespace AIKernel.Abstractions.Providers;

/// <summary>
/// EN: UC-05/UC-19/UC-23/UC-26/UC-27 に基づく IProviderCostProfile の契約を定義します。
/// [EN] Documents this public package API member. [JA] IProviderCostProfile の公開契約を定義します。
/// </summary>
/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.Providers.IProviderCostProfile']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.Providers.IProviderCostProfile']" />
public interface IProviderCostProfile
{
    /// <summary>EN: Gets the ProviderId value exposed by the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで公開される ProviderId 値を取得します。</summary>
    string ProviderId { get; }
    /// <summary>EN: Gets the ModelClass value exposed by the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで公開される ModelClass 値を取得します。</summary>
    string ModelClass { get; }
    /// <summary>EN: Gets the InputTokenUnitCost value exposed by the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで公開される InputTokenUnitCost 値を取得します。</summary>
    decimal InputTokenUnitCost { get; }
    /// <summary>EN: Gets the OutputTokenUnitCost value exposed by the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで公開される OutputTokenUnitCost 値を取得します。</summary>
    decimal OutputTokenUnitCost { get; }
    /// <summary>EN: Gets the ComputeMinuteCost value exposed by the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで公開される ComputeMinuteCost 値を取得します。</summary>
    decimal ComputeMinuteCost { get; }
    /// <summary>EN: Gets the StorageUnitCost value exposed by the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで公開される StorageUnitCost 値を取得します。</summary>
    decimal StorageUnitCost { get; }
    /// <summary>EN: Gets the EffectiveFromUtc value exposed by the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで公開される EffectiveFromUtc 値を取得します。</summary>
    DateTimeOffset EffectiveFromUtc { get; }
}




