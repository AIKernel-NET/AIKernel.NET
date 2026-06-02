namespace AIKernel.Abstractions.Rom;

using AIKernel.Dtos.Rom;

public interface IMarkdownFrontMatterParser
{
    MarkdownFrontMatterDocument Parse(
        string markdown,
        string sourcePath);
}