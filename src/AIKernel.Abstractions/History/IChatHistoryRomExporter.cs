namespace AIKernel.Abstractions.History;

using AIKernel.Dtos.History;

/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.History.IChatHistoryRomExporter']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.History.IChatHistoryRomExporter']" />
public interface IChatHistoryRomExporter
{
    /// <summary>Executes the ToRomMarkdownAsync operation on the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで ToRomMarkdownAsync 操作を実行します。</summary>
    Task<string> ToRomMarkdownAsync(
        IReadOnlyList<ChatHistoryRomRecord> records,
        ChatHistoryRomOptions options,
        CancellationToken cancellationToken = default);
}
