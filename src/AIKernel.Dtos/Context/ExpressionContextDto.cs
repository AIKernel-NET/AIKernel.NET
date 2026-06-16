using AIKernel.Enums;

namespace AIKernel.Dtos.Context;

/// <summary>
/// ExpressionContext のデータを表現する DTO です。
/// 推論が完全に終了した後にのみ適用される、出力表現層の情報を含みます。
/// 
/// EN: 参照: 2.CONTEXT_ISOLATION_SPEC.jp.md
/// [EN] Documents this public package API member. [JA] ExpressionContextDto の公開契約を定義します。
/// </summary>
/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Dtos.Context.ExpressionContextDto']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Dtos.Context.ExpressionContextDto']" />
public sealed class ExpressionContextDto
{
    /// <summary>
    /// EN: 出力の文体を取得または設定します。
    /// [EN] Documents this public package API member. [JA] Style を取得します。
    /// </summary>
    /// <include file="docs.en.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Context.ExpressionContextDto.Style']" />
    /// <include file="docs.ja.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Context.ExpressionContextDto.Style']" />
    public string? Style { get; init; }

    /// <summary>
    /// 説明用の例を取得または設定します。
    /// EN: 注意: これらの例は推論には混入しません。
    /// [EN] Documents this public package API member. [JA] Examples を取得します。
    /// </summary>
    /// <include file="docs.en.xml" path="doc/members/member[@name='M:AIKernel.Dtos.Context.ExpressionContextDto.new']" />
    /// <include file="docs.ja.xml" path="doc/members/member[@name='M:AIKernel.Dtos.Context.ExpressionContextDto.new']" />
    public List<string> Examples { get; init; } = new();

    /// <summary>
    /// EN: 説明テンプレートを取得または設定します。
    /// [EN] Documents this public package API member. [JA] DescriptionTemplate を取得します。
    /// </summary>
    /// <include file="docs.en.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Context.ExpressionContextDto.DescriptionTemplate']" />
    /// <include file="docs.ja.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Context.ExpressionContextDto.DescriptionTemplate']" />
    public string? DescriptionTemplate { get; init; }

    /// <summary>
    /// EN: 比喩・類推を取得または設定します。
    /// [EN] Documents this public package API member. [JA] Analogies を取得します。
    /// </summary>
    /// <include file="docs.en.xml" path="doc/members/member[@name='M:AIKernel.Dtos.Context.ExpressionContextDto.new']" />
    /// <include file="docs.ja.xml" path="doc/members/member[@name='M:AIKernel.Dtos.Context.ExpressionContextDto.new']" />
    public List<string> Analogies { get; init; } = new();

    /// <summary>
    /// EN: フォーマット指示を取得または設定します。
    /// [EN] Documents this public package API member. [JA] FormatDirectives を取得します。
    /// </summary>
    /// <include file="docs.en.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Context.ExpressionContextDto.string']" />
    /// <include file="docs.ja.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Context.ExpressionContextDto.string']" />
    public Dictionary<string, string>? FormatDirectives { get; init; }

    /// <summary>
    /// EN: 作成日時を取得または設定します。
    /// [EN] Documents this public package API member. [JA] CreatedAt を取得します。
    /// </summary>
    /// <include file="docs.en.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Context.ExpressionContextDto.CreatedAt']" />
    /// <include file="docs.ja.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Context.ExpressionContextDto.CreatedAt']" />
    public DateTime CreatedAt { get; init; }
}


