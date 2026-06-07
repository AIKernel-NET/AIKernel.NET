namespace AIKernel.Abstractions.Security;

/// <summary>
/// Represents options that require secure secret resolution before runtime use.
/// </summary>
/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.Security.ISecureOptions']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.Security.ISecureOptions']" />
public interface ISecureOptions
{
    /// <summary>
    /// Gets the key name used to resolve the secret from environment variables,
    /// UserSecrets, configuration, or a custom vault.
    /// </summary>
    string? SecretKeyName { get; }

    /// <summary>
    /// Gets or sets the resolved secret value.
    /// This property is intentionally mutable to allow Hosting to inject
    /// the resolved secret during startup validation.
    /// </summary>
    string? ApiKey { get; set; }
}