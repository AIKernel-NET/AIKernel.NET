namespace AIKernel.Contracts.Images;

/// <summary>Optional full-resolution refinements for the predicted foreground matte.</summary>
public sealed record ImageMattingOptions
{
    /// <summary>Creates options measured in pixels in the decoded source image.</summary>
    /// <param name="maskRefineRadius">Guide radius from 0 to 32 pixels. Zero disables guided refinement.</param>
    /// <param name="maskErodePx">Contraction of the foreground by 0 to 2 pixels.</param>
    /// <param name="decontaminateEdge">Whether to remove estimated background color from partially transparent edges.</param>
    public ImageMattingOptions(int maskRefineRadius = 0, int maskErodePx = 0, bool decontaminateEdge = false)
    {
        ArgumentOutOfRangeException.ThrowIfNegative(maskRefineRadius);
        ArgumentOutOfRangeException.ThrowIfGreaterThan(maskRefineRadius, 32);
        ArgumentOutOfRangeException.ThrowIfNegative(maskErodePx);
        ArgumentOutOfRangeException.ThrowIfGreaterThan(maskErodePx, 2);
        MaskRefineRadius = maskRefineRadius;
        MaskErodePx = maskErodePx;
        DecontaminateEdge = decontaminateEdge;
    }

    /// <summary>The radius of the full-resolution image guide.</summary>
    public int MaskRefineRadius { get; }

    /// <summary>The width of the inward edge adjustment.</summary>
    public int MaskErodePx { get; }

    /// <summary>Whether to estimate and remove the old background contribution.</summary>
    public bool DecontaminateEdge { get; }
}
