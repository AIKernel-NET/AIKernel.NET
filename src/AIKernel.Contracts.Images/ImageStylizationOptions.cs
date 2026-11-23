namespace AIKernel.Contracts.Images;

/// <summary>Controls the amount of the chosen illustration effect in the output.</summary>
public sealed record ImageStylizationOptions
{
    /// <summary>Creates options with a strength between zero and one, inclusive.</summary>
    /// <param name="strength">Zero preserves the input pixels and one applies the full effect.</param>
    public ImageStylizationOptions(double strength = 1d)
    {
        if (!(strength >= 0d && strength <= 1d))
            throw new ArgumentOutOfRangeException(nameof(strength), strength, "Strength must be between zero and one.");

        Strength = strength;
    }

    /// <summary>The amount of the illustration effect. Defaults to one.</summary>
    public double Strength { get; }
}
