namespace AIKernel.Dtos.Routing;

/// <summary>
/// EN: ModelRoutingDecision の契約を定義します。
/// [EN] Documents this public package API member. [JA] ModelRoutingDecision の公開契約を定義します。
/// </summary>
/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Dtos.Routing.ModelRoutingDecision']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Dtos.Routing.ModelRoutingDecision']" />
public sealed record ModelRoutingDecision
{
    /// <summary>[EN] Documents this public package API member. [JA] SelectedProviderId を取得します。</summary>
    /// <include file="docs.en.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Routing.ModelRoutingDecision.SelectedProviderId']" />
    /// <include file="docs.ja.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Routing.ModelRoutingDecision.SelectedProviderId']" />
    public required string SelectedProviderId { get; init; }
    /// <summary>[EN] Documents this public package API member. [JA] SelectionRationale を取得します。</summary>
    /// <include file="docs.en.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Routing.ModelRoutingDecision.SelectionRationale']" />
    /// <include file="docs.ja.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Routing.ModelRoutingDecision.SelectionRationale']" />
    public required string SelectionRationale { get; init; }
    /// <summary>[EN] Documents this public package API member. [JA] EffectiveCapacity を取得します。</summary>
    /// <include file="docs.en.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Routing.ModelRoutingDecision.EffectiveCapacity']" />
    /// <include file="docs.ja.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Routing.ModelRoutingDecision.EffectiveCapacity']" />
    public required ModelCapacityVector EffectiveCapacity { get; init; }
    /// <summary>[EN] Documents this public package API member. [JA] FittingScore を取得します。</summary>
    /// <include file="docs.en.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Routing.ModelRoutingDecision.FittingScore']" />
    /// <include file="docs.ja.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Routing.ModelRoutingDecision.FittingScore']" />
    public required double FittingScore { get; init; }
    /// <summary>[EN] Documents this public package API member. [JA] DecisionTimestamp を取得します。</summary>
    /// <include file="docs.en.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Routing.ModelRoutingDecision.DecisionTimestamp']" />
    /// <include file="docs.ja.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Routing.ModelRoutingDecision.DecisionTimestamp']" />
    public required DateTime DecisionTimestamp { get; init; }
    /// <summary>[EN] Documents this public package API member. [JA] Metadata を実行します。</summary>
    /// <include file="docs.en.xml" path="doc/members/member[@name='M:AIKernel.Dtos.Routing.ModelRoutingDecision.string&gt;']" />
    /// <include file="docs.ja.xml" path="doc/members/member[@name='M:AIKernel.Dtos.Routing.ModelRoutingDecision.string&gt;']" />
    public IReadOnlyDictionary<string, string> Metadata { get; init; } = new Dictionary<string, string>();
}



