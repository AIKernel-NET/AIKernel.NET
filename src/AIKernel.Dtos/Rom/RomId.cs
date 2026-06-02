namespace AIKernel.Dtos.Rom;

using System.Collections.Immutable;

public sealed record RomId(string Value)
{
    public static RomId Parse(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            throw new ArgumentException("rom_id is required.", nameof(value));
        }

        return new RomId(value.Trim());
    }

    public override string ToString() => Value;
}