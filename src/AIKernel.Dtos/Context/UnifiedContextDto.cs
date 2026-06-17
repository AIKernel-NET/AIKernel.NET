using AIKernel.Enums;

namespace AIKernel.Dtos.Context;

/// <summary>
/// 統合されたコンテキストデータを表現する DTO です。
/// OrchestrationContext、ExpressionContext、MaterialContext を管理します。
/// 
/// EN: 参照: 2.CONTEXT_ISOLATION_SPEC.jp.md
/// [EN] Documents this public package API member. [JA] UnifiedContextDto の公開契約を定義します。
/// </summary>
/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Dtos.Context.UnifiedContextDto']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Dtos.Context.UnifiedContextDto']" />
public sealed class UnifiedContextDto
{
    /// <summary>
    /// EN: コンテキストの一意識別子を取得または設定します。
    /// [EN] Documents this public package API member. [JA] Id を取得します。
    /// </summary>
    /// <include file="docs.en.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Context.UnifiedContextDto.Id']" />
    /// <include file="docs.ja.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Context.UnifiedContextDto.Id']" />
    public required string Id { get; init; }

    /// <summary>
    /// EN: OrchestrationContext を取得または設定します。
    /// [EN] Documents this public package API member. [JA] Orchestration を取得します。
    /// </summary>
    /// <include file="docs.en.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Context.UnifiedContextDto.Orchestration']" />
    /// <include file="docs.ja.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Context.UnifiedContextDto.Orchestration']" />
    public required OrchestrationContextDto Orchestration { get; init; }

    /// <summary>
    /// EN: ExpressionContext を取得または設定します。
    /// [EN] Documents this public package API member. [JA] Expression を取得します。
    /// </summary>
    /// <include file="docs.en.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Context.UnifiedContextDto.Expression']" />
    /// <include file="docs.ja.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Context.UnifiedContextDto.Expression']" />
    public ExpressionContextDto? Expression { get; init; }

    /// <summary>
    /// EN: MaterialContext を取得または設定します。
    /// [EN] Documents this public package API member. [JA] Material を取得します。
    /// </summary>
    /// <include file="docs.en.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Context.UnifiedContextDto.Material']" />
    /// <include file="docs.ja.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Context.UnifiedContextDto.Material']" />
    public MaterialContextDto? Material { get; init; }

    /// <summary>
    /// EN: SNR（Signal-to-Noise Ratio）を取得または設定します。
    /// [EN] Documents this public package API member. [JA] SignalToNoiseRatio を取得します。
    /// </summary>
    /// <include file="docs.en.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Context.UnifiedContextDto.SignalToNoiseRatio']" />
    /// <include file="docs.ja.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Context.UnifiedContextDto.SignalToNoiseRatio']" />
    public double SignalToNoiseRatio { get; init; } = 1.0;

    /// <summary>
    /// EN: 発生した failure modes を取得または設定します。
    /// [EN] Documents this public package API member. [JA] DetectedFailureModes を取得します。
    /// </summary>
    /// <include file="docs.en.xml" path="doc/members/member[@name='M:AIKernel.Dtos.Context.UnifiedContextDto.new']" />
    /// <include file="docs.ja.xml" path="doc/members/member[@name='M:AIKernel.Dtos.Context.UnifiedContextDto.new']" />
    public List<FailureMode> DetectedFailureModes { get; init; } = new();

    /// <summary>
    /// EN: 作成日時を取得または設定します。
    /// [EN] Documents this public package API member. [JA] CreatedAt を取得します。
    /// </summary>
    /// <include file="docs.en.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Context.UnifiedContextDto.CreatedAt']" />
    /// <include file="docs.ja.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Context.UnifiedContextDto.CreatedAt']" />
    public DateTime CreatedAt { get; init; }
}


