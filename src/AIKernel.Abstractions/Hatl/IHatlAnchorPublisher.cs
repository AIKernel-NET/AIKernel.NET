namespace AIKernel.Abstractions.Hatl;

using AIKernel.Dtos.Hatl;

public interface IHatlAnchorPublisher
{
    ValueTask<HatlPublicAnchorReceipt> PublishAsync(
        HatlAnchorDocument anchor,
        CancellationToken cancellationToken = default);
}
