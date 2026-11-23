namespace AIKernel.Contracts.Images;

/// <summary>Edits a reference image using a text instruction and an explicit random seed.</summary>
public interface IImagePromptEditProvider
{
    /// <summary>Returns tightly packed RGB24 pixels with the same dimensions as the reference.</summary>
    /// <param name="referenceRgb24">Rows of packed red, green, and blue bytes. Keep unchanged through completion.</param>
    /// <param name="width">Reference width in pixels.</param>
    /// <param name="height">Reference height in pixels.</param>
    /// <param name="prompt">The edit to apply to the reference image.</param>
    /// <param name="seed">A non-negative seed for generation.</param>
    /// <param name="cancellationToken">Signals cancellation of the edit.</param>
    /// <returns>The edited image as RGB24.</returns>
    ValueTask<ReadOnlyMemory<byte>> EditAsync(ReadOnlyMemory<byte> referenceRgb24, int width, int height,
        string prompt, long seed, CancellationToken cancellationToken = default);
}
