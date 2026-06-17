namespace AIKernel.Abstractions.Hatl;

using AIKernel.Dtos.Hatl;

/// <summary>[EN] Documents this public package API member. [JA] IHatlAnchorPublisher contract を定義します。</summary>
/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.Hatl.IHatlAnchorPublisher']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.Hatl.IHatlAnchorPublisher']" />
public interface IHatlAnchorPublisher
{
    /// <summary>EN: Executes the PublishAsync operation on the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで PublishAsync 操作を実行します。</summary>
    ValueTask<HatlPublicAnchorReceipt> PublishAsync(
        HatlAnchorDocument anchor,
        CancellationToken cancellationToken = default);
}
