namespace AIKernel.Contracts.Images;

/// <summary>Returns textual tags describing the visible contents of a local image.</summary>
public interface IImageTaggingProvider
{
    /// <summary>Analyzes a PNG or JPEG and returns one or more model-generated tags.</summary>
    /// <param name="image">Encoded bytes kept unchanged through completion.</param>
    /// <param name="cancellationToken">Signals cancellation of the operation.</param>
    /// <returns>Tags describing objects, colors, and the setting where visible.</returns>
    /// <exception cref="InvalidDataException">The image is invalid or exceeds the input limits.</exception>
    /// <exception cref="OperationCanceledException">The operation was canceled.</exception>
    ValueTask<IReadOnlyList<string>> TagAsync(
        ReadOnlyMemory<byte> image, CancellationToken cancellationToken = default);
}
