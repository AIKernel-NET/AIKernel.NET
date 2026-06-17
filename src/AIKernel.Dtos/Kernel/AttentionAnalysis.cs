namespace AIKernel.Dtos.Kernel;

using AIKernel.Enums;

/// <summary>
/// EN: AttentionAnalysis の契約を定義します。
/// [EN] Documents this public package API member. [JA] AttentionAnalysis の公開契約を定義します。
/// </summary>
/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Dtos.Kernel.AttentionAnalysis']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Dtos.Kernel.AttentionAnalysis']" />
public sealed class AttentionAnalysis
{
    /// <summary>[EN] Documents this public package API member. [JA] SignalToNoiseRatio を取得します。</summary>
    /// <include file="docs.en.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Kernel.AttentionAnalysis.SignalToNoiseRatio']" />
    /// <include file="docs.ja.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Kernel.AttentionAnalysis.SignalToNoiseRatio']" />
    public double SignalToNoiseRatio { get; init; }
    /// <summary>[EN] Documents this public package API member. [JA] DetectedPollution を実行します。</summary>
    /// <include file="docs.en.xml" path="doc/members/member[@name='M:AIKernel.Dtos.Kernel.AttentionAnalysis.new']" />
    /// <include file="docs.ja.xml" path="doc/members/member[@name='M:AIKernel.Dtos.Kernel.AttentionAnalysis.new']" />
    public List<FailureMode> DetectedPollution { get; init; } = new();
    /// <summary>EN: Gets the Recommendations value exposed by the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで公開される Recommendations 値を取得します。</summary>
    public List<string> Recommendations { get; init; } = new();
    /// <summary>[EN] Documents this public package API member. [JA] RiskLevel を取得します。</summary>
    /// <include file="docs.en.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Kernel.AttentionAnalysis.RiskLevel']" />
    /// <include file="docs.ja.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Kernel.AttentionAnalysis.RiskLevel']" />
    public string RiskLevel { get; init; } = "Low";
}




