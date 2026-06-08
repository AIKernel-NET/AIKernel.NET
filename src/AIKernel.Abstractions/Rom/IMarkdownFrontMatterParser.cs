namespace AIKernel.Abstractions.Rom;

using AIKernel.Dtos.Rom;

/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.Rom.IMarkdownFrontMatterParser']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.Rom.IMarkdownFrontMatterParser']" />
public interface IMarkdownFrontMatterParser
{
    /// <summary>Executes the Parse operation on the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで Parse 操作を実行します。</summary>
    MarkdownFrontMatterDocument Parse(
        string markdown,
        string sourcePath);
}
