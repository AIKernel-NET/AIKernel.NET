using AIKernel.Enums;

namespace AIKernel.Dtos.Context;

/// <summary>
/// OrchestrationContext のデータを表現する DTO です。
/// 推論に必要な情報のみを含みます。
/// 
/// EN: 参照: 2.CONTEXT_ISOLATION_SPEC.jp.md
/// EN: Documentation for public API. JA: OrchestrationContextDto の公開契約を定義します。
/// </summary>
/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Dtos.Context.OrchestrationContextDto']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Dtos.Context.OrchestrationContextDto']" />
public sealed class OrchestrationContextDto
{
    /// <summary>
    /// EN: 目的を取得または設定します。
    /// EN: Documentation for public API. JA: Purpose を取得します。
    /// </summary>
    /// <include file="docs.en.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Context.OrchestrationContextDto.Purpose']" />
    /// <include file="docs.ja.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Context.OrchestrationContextDto.Purpose']" />
    public required string Purpose { get; init; }

    /// <summary>
    /// EN: 制約条件を取得または設定します。
    /// EN: Documentation for public API. JA: Constraints を取得します。
    /// </summary>
    /// <include file="docs.en.xml" path="doc/members/member[@name='M:AIKernel.Dtos.Context.OrchestrationContextDto.new']" />
    /// <include file="docs.ja.xml" path="doc/members/member[@name='M:AIKernel.Dtos.Context.OrchestrationContextDto.new']" />
    public List<string> Constraints { get; init; } = new();

    /// <summary>
    /// EN: 抽象構造を取得または設定します。
    /// EN: Documentation for public API. JA: Structure を取得します。
    /// </summary>
    /// <include file="docs.en.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Context.OrchestrationContextDto.Structure']" />
    /// <include file="docs.ja.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Context.OrchestrationContextDto.Structure']" />
    public required string Structure { get; init; }

    /// <summary>
    /// EN: 思考パターンを取得または設定します。
    /// EN: Documentation for public API. JA: ReasoningPattern を取得します。
    /// </summary>
    /// <include file="docs.en.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Context.OrchestrationContextDto.ReasoningPattern']" />
    /// <include file="docs.ja.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Context.OrchestrationContextDto.ReasoningPattern']" />
    public string? ReasoningPattern { get; init; }

    /// <summary>
    /// EN: 追加パラメータを取得または設定します。
    /// EN: Documentation for public API. JA: Parameters を取得します。
    /// </summary>
    /// <include file="docs.en.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Context.OrchestrationContextDto.object']" />
    /// <include file="docs.ja.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Context.OrchestrationContextDto.object']" />
    public Dictionary<string, object>? Parameters { get; init; }

    /// <summary>
    /// EN: 作成日時を取得または設定します。
    /// EN: Documentation for public API. JA: CreatedAt を取得します。
    /// </summary>
    /// <include file="docs.en.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Context.OrchestrationContextDto.CreatedAt']" />
    /// <include file="docs.ja.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Context.OrchestrationContextDto.CreatedAt']" />
    public DateTime CreatedAt { get; init; }
}


