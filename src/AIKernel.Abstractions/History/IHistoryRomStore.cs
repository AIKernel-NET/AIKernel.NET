namespace AIKernel.Abstractions.History;

using AIKernel.Dtos.History;
using AIKernel.Vfs;

/// <summary>EN: Documentation for public API. JA: IHistoryRomStore contract を定義します。</summary>
/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.History.IHistoryRomStore']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.History.IHistoryRomStore']" />
public interface IHistoryRomStore
{
    /// <summary>EN: Executes the SaveHistoryAsRomAsync operation on the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで SaveHistoryAsRomAsync 操作を実行します。</summary>
    Task<HistoryRomMetadata> SaveHistoryAsRomAsync(
        IVfsSession session,
        string @namespace,
        string name,
        IReadOnlyList<ChatHistoryRomRecord> records,
        DateTimeOffset generatedAtUtc,
        string entityType = "conversation",
        string version = "1",
        IReadOnlyList<string>? securityTags = null,
        CancellationToken cancellationToken = default);

    /// <summary>EN: Executes the SaveMarkdownAsRomAsync operation on the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで SaveMarkdownAsRomAsync 操作を実行します。</summary>
    Task<HistoryRomMetadata> SaveMarkdownAsRomAsync(
        IVfsSession session,
        string @namespace,
        string name,
        string markdown,
        DateTimeOffset createdAtUtc,
        CancellationToken cancellationToken = default);

    /// <summary>EN: Executes the LoadHistoryRomAsync operation on the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで LoadHistoryRomAsync 操作を実行します。</summary>
    Task<HistoryRomMetadata> LoadHistoryRomAsync(
        IVfsSession session,
        string @namespace,
        string name,
        DateTimeOffset createdAtUtc,
        string? expectedRomHash = null,
        CancellationToken cancellationToken = default);
}
