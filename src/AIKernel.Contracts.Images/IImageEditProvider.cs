namespace AIKernel.Contracts.Images;

/// <summary>Converts a locally supplied PNG or JPEG into a PNG with the same pixel dimensions.</summary>
/// <remarks>
/// Input bytes must remain unchanged until the operation completes. Unsupported or invalid images
/// raise <see cref="InvalidDataException"/>. Awaiting a canceled operation raises
/// <see cref="OperationCanceledException"/>.
/// </remarks>
public interface IImageEditProvider
{
    /// <summary>Applies an illustration style to a photo and preserves source transparency.</summary>
    /// <param name="image">Encoded PNG or JPEG.</param>
    /// <param name="style">One of <c>illustration</c>, <c>pencil</c>, or <c>detail</c>.</param>
    /// <param name="cancellationToken">Signals cancellation of the operation.</param>
    /// <returns>The edited PNG bytes.</returns>
    /// <exception cref="NotSupportedException">The requested style is unavailable.</exception>
    ValueTask<ReadOnlyMemory<byte>> StylizeAsync(
        ReadOnlyMemory<byte> image, string style, CancellationToken cancellationToken = default);

    /// <summary>Applies a selected amount of the illustration effect and preserves source transparency.</summary>
    /// <param name="image">Encoded PNG or JPEG.</param>
    /// <param name="style">One of <c>illustration</c>, <c>pencil</c>, or <c>detail</c>.</param>
    /// <param name="options">Strength options. Pass <see langword="null"/> for the full effect.</param>
    /// <param name="cancellationToken">Signals cancellation of the operation.</param>
    /// <returns>The edited PNG bytes.</returns>
    /// <exception cref="NotSupportedException">The style or requested strength is unavailable.</exception>
    ValueTask<ReadOnlyMemory<byte>> StylizeAsync(
        ReadOnlyMemory<byte> image, string style, ImageStylizationOptions? options, CancellationToken cancellationToken)
    {
        cancellationToken.ThrowIfCancellationRequested();
        if (options is { Strength: not 1d })
            throw new NotSupportedException("This image provider does not support adjustable stylization strength.");

        return StylizeAsync(image, style, cancellationToken);
    }

    /// <summary>Removes the background and returns a PNG with a soft alpha channel.</summary>
    /// <param name="image">Encoded PNG or JPEG.</param>
    /// <param name="cancellationToken">Signals cancellation of the operation.</param>
    /// <returns>The PNG bytes with foreground alpha multiplied by any existing source alpha.</returns>
    /// <exception cref="InvalidOperationException">No background removal model is registered.</exception>
    ValueTask<ReadOnlyMemory<byte>> RemoveBackgroundAsync(
        ReadOnlyMemory<byte> image, CancellationToken cancellationToken = default);

    /// <summary>Removes the background with optional full-resolution edge refinement.</summary>
    /// <param name="image">Encoded input image.</param>
    /// <param name="options">Refinement parameters. Null or default values preserve the original behavior.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    ValueTask<ReadOnlyMemory<byte>> RemoveBackgroundAsync(
        ReadOnlyMemory<byte> image, ImageMattingOptions? options, CancellationToken cancellationToken)
    {
        cancellationToken.ThrowIfCancellationRequested();
        if (options is { MaskRefineRadius: > 0 } or { MaskErodePx: > 0 } or { DecontaminateEdge: true })
            throw new NotSupportedException("This provider does not support matte edge refinement.");
        return RemoveBackgroundAsync(image, cancellationToken);
    }
}
