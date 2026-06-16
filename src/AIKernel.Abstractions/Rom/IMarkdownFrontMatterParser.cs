namespace AIKernel.Abstractions.Rom;

using AIKernel.Dtos.Rom;

/// <summary>EN: Documentation for public API. JA: IMarkdownFrontMatterParser contract を定義します。</summary>
/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.Rom.IMarkdownFrontMatterParser']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.Rom.IMarkdownFrontMatterParser']" />
public interface IMarkdownFrontMatterParser
{
    /// <summary>EN: Executes the Parse operation on the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで Parse 操作を実行します。</summary>
    MarkdownFrontMatterDocument Parse(
        string markdown,
        string sourcePath);
}
