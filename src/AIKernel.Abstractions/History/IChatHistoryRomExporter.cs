namespace AIKernel.Abstractions.History;

using AIKernel.Dtos.History;

/// <summary>[EN] Documents this public package API member. [JA] IChatHistoryRomExporter contract を定義します。</summary>
/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.History.IChatHistoryRomExporter']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.History.IChatHistoryRomExporter']" />
public interface IChatHistoryRomExporter
{
    /// <summary>EN: Executes the ToRomMarkdownAsync operation on the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで ToRomMarkdownAsync 操作を実行します。</summary>
    Task<string> ToRomMarkdownAsync(
        IReadOnlyList<ChatHistoryRomRecord> records,
        ChatHistoryRomOptions options,
        CancellationToken cancellationToken = default);
}
