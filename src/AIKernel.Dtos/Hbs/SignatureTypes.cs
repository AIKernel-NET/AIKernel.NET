namespace AIKernel.Dtos.Hbs;

/// <summary>
/// Carries a signature result for hash-bound signing services.
/// JA: SignatureResult の公開契約を定義します。
/// </summary>
public sealed record SignatureResult
{
    /// <summary>Gets whether signing succeeded. JA: Succeeded を取得します。</summary>
    public bool Succeeded { get; init; }

    /// <summary>Gets the signature value. JA: Signature を取得します。</summary>
    public string? Signature { get; init; }

    /// <summary>Gets the signature algorithm. JA: Algorithm を取得します。</summary>
    public string? Algorithm { get; init; }

    /// <summary>Gets the signature counter value. JA: CounterValue を取得します。</summary>
    public long? CounterValue { get; init; }

    /// <summary>Gets optional signature metadata. JA: Metadata を取得します。</summary>
    public IReadOnlyDictionary<string, string> Metadata { get; init; } = new Dictionary<string, string>();
}

/// <summary>
/// Carries a verification result for hash-bound signatures.
/// JA: VerifyResult の公開契約を定義します。
/// </summary>
public sealed record VerifyResult
{
    /// <summary>Gets whether verification succeeded. JA: Succeeded を取得します。</summary>
    public bool Succeeded { get; init; }

    /// <summary>Gets a stable verification code. JA: Code を取得します。</summary>
    public string? Code { get; init; }

    /// <summary>Gets a human-readable verification message. JA: Message を取得します。</summary>
    public string? Message { get; init; }

    /// <summary>Gets optional verification metadata. JA: Metadata を取得します。</summary>
    public IReadOnlyDictionary<string, string> Metadata { get; init; } = new Dictionary<string, string>();
}

/// <summary>
/// Carries signature counter state.
/// JA: SignatureCounter の公開契約を定義します。
/// </summary>
public sealed record SignatureCounter
{
    /// <summary>Gets the counter identifier. JA: CounterId を取得します。</summary>
    public required string CounterId { get; init; }

    /// <summary>Gets the counter value. JA: Value を取得します。</summary>
    public long Value { get; init; }

    /// <summary>Gets optional counter metadata. JA: Metadata を取得します。</summary>
    public IReadOnlyDictionary<string, string> Metadata { get; init; } = new Dictionary<string, string>();
}
