using AIKernel.Enums;

namespace AIKernel.Dtos.Context;

/// <summary>
/// ExpressionContext のデータを表現する DTO です。
/// 推論が完全に終了した後にのみ適用される、出力表現層の情報を含みます。
/// 
/// 参照: 2.CONTEXT_ISOLATION_SPEC.jp.md
/// JA: ExpressionContextDto の公開契約を定義します。
/// </summary>
/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Dtos.Context.ExpressionContextDto']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Dtos.Context.ExpressionContextDto']" />
public sealed class ExpressionContextDto
{
    /// <summary>
    /// 出力の文体を取得または設定します。
    /// JA: Style を取得します。
    /// </summary>
    /// <include file="docs.en.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Context.ExpressionContextDto.Style']" />
    /// <include file="docs.ja.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Context.ExpressionContextDto.Style']" />
    public string? Style { get; init; }

    /// <summary>
    /// 説明用の例を取得または設定します。
    /// 注意: これらの例は推論には混入しません。
    /// JA: Examples を取得します。
    /// </summary>
    /// <include file="docs.en.xml" path="doc/members/member[@name='M:AIKernel.Dtos.Context.ExpressionContextDto.new']" />
    /// <include file="docs.ja.xml" path="doc/members/member[@name='M:AIKernel.Dtos.Context.ExpressionContextDto.new']" />
    public List<string> Examples { get; init; } = new();

    /// <summary>
    /// 説明テンプレートを取得または設定します。
    /// JA: DescriptionTemplate を取得します。
    /// </summary>
    /// <include file="docs.en.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Context.ExpressionContextDto.DescriptionTemplate']" />
    /// <include file="docs.ja.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Context.ExpressionContextDto.DescriptionTemplate']" />
    public string? DescriptionTemplate { get; init; }

    /// <summary>
    /// 比喩・類推を取得または設定します。
    /// JA: Analogies を取得します。
    /// </summary>
    /// <include file="docs.en.xml" path="doc/members/member[@name='M:AIKernel.Dtos.Context.ExpressionContextDto.new']" />
    /// <include file="docs.ja.xml" path="doc/members/member[@name='M:AIKernel.Dtos.Context.ExpressionContextDto.new']" />
    public List<string> Analogies { get; init; } = new();

    /// <summary>
    /// フォーマット指示を取得または設定します。
    /// JA: FormatDirectives を取得します。
    /// </summary>
    /// <include file="docs.en.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Context.ExpressionContextDto.string']" />
    /// <include file="docs.ja.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Context.ExpressionContextDto.string']" />
    public Dictionary<string, string>? FormatDirectives { get; init; }

    /// <summary>
    /// 作成日時を取得または設定します。
    /// JA: CreatedAt を取得します。
    /// </summary>
    /// <include file="docs.en.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Context.ExpressionContextDto.CreatedAt']" />
    /// <include file="docs.ja.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Context.ExpressionContextDto.CreatedAt']" />
    public DateTime CreatedAt { get; init; }
}


