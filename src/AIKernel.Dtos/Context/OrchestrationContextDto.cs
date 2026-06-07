using AIKernel.Enums;

namespace AIKernel.Dtos.Context;

/// <summary>
/// OrchestrationContext のデータを表現する DTO です。
/// 推論に必要な情報のみを含みます。
/// 
/// 参照: 2.CONTEXT_ISOLATION_SPEC.jp.md
/// </summary>
/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Dtos.Context.OrchestrationContextDto']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Dtos.Context.OrchestrationContextDto']" />
public sealed class OrchestrationContextDto
{
    /// <summary>
    /// 目的を取得または設定します。
    /// </summary>
    /// <include file="docs.en.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Context.OrchestrationContextDto.Purpose']" />
    /// <include file="docs.ja.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Context.OrchestrationContextDto.Purpose']" />
    public required string Purpose { get; init; }

    /// <summary>
    /// 制約条件を取得または設定します。
    /// </summary>
    /// <include file="docs.en.xml" path="doc/members/member[@name='M:AIKernel.Dtos.Context.OrchestrationContextDto.new']" />
    /// <include file="docs.ja.xml" path="doc/members/member[@name='M:AIKernel.Dtos.Context.OrchestrationContextDto.new']" />
    public List<string> Constraints { get; init; } = new();

    /// <summary>
    /// 抽象構造を取得または設定します。
    /// </summary>
    /// <include file="docs.en.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Context.OrchestrationContextDto.Structure']" />
    /// <include file="docs.ja.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Context.OrchestrationContextDto.Structure']" />
    public required string Structure { get; init; }

    /// <summary>
    /// 思考パターンを取得または設定します。
    /// </summary>
    /// <include file="docs.en.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Context.OrchestrationContextDto.ReasoningPattern']" />
    /// <include file="docs.ja.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Context.OrchestrationContextDto.ReasoningPattern']" />
    public string? ReasoningPattern { get; init; }

    /// <summary>
    /// 追加パラメータを取得または設定します。
    /// </summary>
    /// <include file="docs.en.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Context.OrchestrationContextDto.object']" />
    /// <include file="docs.ja.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Context.OrchestrationContextDto.object']" />
    public Dictionary<string, object>? Parameters { get; init; }

    /// <summary>
    /// 作成日時を取得または設定します。
    /// </summary>
    /// <include file="docs.en.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Context.OrchestrationContextDto.CreatedAt']" />
    /// <include file="docs.ja.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Context.OrchestrationContextDto.CreatedAt']" />
    public DateTime CreatedAt { get; init; }
}


