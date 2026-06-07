namespace AIKernel.Dtos.Context;

using AIKernel.Enums;

/// <summary>
/// ExpressionFragment の契約を定義します。
/// </summary>
/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Dtos.Context.ExpressionFragment']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Dtos.Context.ExpressionFragment']" />
public sealed class ExpressionFragment : ContextFragment
{
    /// <include file="docs.en.xml" path="doc/members/member[@name='M:AIKernel.Dtos.Context.ExpressionFragment.Empty&lt;string&gt;']" />
    /// <include file="docs.ja.xml" path="doc/members/member[@name='M:AIKernel.Dtos.Context.ExpressionFragment.Empty&lt;string&gt;']" />
    public IReadOnlyList<string> Examples { get; init; } = Array.Empty<string>();
    /// <include file="docs.en.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Context.ExpressionFragment.StyleHints']" />
    /// <include file="docs.ja.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Context.ExpressionFragment.StyleHints']" />
    public string StyleHints { get; init; } = string.Empty;
    /// <include file="docs.en.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Context.ExpressionFragment.Tone']" />
    /// <include file="docs.ja.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Context.ExpressionFragment.Tone']" />
    public string Tone { get; init; } = string.Empty;
    /// <include file="docs.en.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Context.ExpressionFragment.LanguageTag']" />
    /// <include file="docs.ja.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Context.ExpressionFragment.LanguageTag']" />
    public string LanguageTag { get; init; } = "ja-JP";

    /// <include file="docs.en.xml" path="doc/members/member[@name='M:AIKernel.Dtos.Context.ExpressionFragment.#ctor']" />
    /// <include file="docs.ja.xml" path="doc/members/member[@name='M:AIKernel.Dtos.Context.ExpressionFragment.#ctor']" />
    public ExpressionFragment()
    {
        Category = ContextCategory.Expression;
    }
}



