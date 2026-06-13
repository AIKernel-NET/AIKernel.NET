namespace AIKernel.Dtos.Hbs;

/// <summary>
/// Carries a signature result for hash-bound signing services.
/// </summary>
public sealed record SignatureResult
{
    /// <summary>Gets whether signing succeeded.</summary>
    public bool Succeeded { get; init; }

    /// <summary>Gets the signature value.</summary>
    public string? Signature { get; init; }

    /// <summary>Gets the signature algorithm.</summary>
    public string? Algorithm { get; init; }

    /// <summary>Gets the signature counter value.</summary>
    public long? CounterValue { get; init; }

    /// <summary>Gets optional signature metadata.</summary>
    public IReadOnlyDictionary<string, string> Metadata { get; init; } = new Dictionary<string, string>();
}

/// <summary>
/// Carries a verification result for hash-bound signatures.
/// </summary>
public sealed record VerifyResult
{
    /// <summary>Gets whether verification succeeded.</summary>
    public bool Succeeded { get; init; }

    /// <summary>Gets a stable verification code.</summary>
    public string? Code { get; init; }

    /// <summary>Gets a human-readable verification message.</summary>
    public string? Message { get; init; }

    /// <summary>Gets optional verification metadata.</summary>
    public IReadOnlyDictionary<string, string> Metadata { get; init; } = new Dictionary<string, string>();
}

/// <summary>
/// Carries signature counter state.
/// </summary>
public sealed record SignatureCounter
{
    /// <summary>Gets the counter identifier.</summary>
    public required string CounterId { get; init; }

    /// <summary>Gets the counter value.</summary>
    public long Value { get; init; }

    /// <summary>Gets optional counter metadata.</summary>
    public IReadOnlyDictionary<string, string> Metadata { get; init; } = new Dictionary<string, string>();
}
