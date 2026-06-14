using AIKernel.Abstractions.Governance;

namespace AIKernel.Abstractions.Tests;

/// <summary>
/// Defines a test helper type. JA: テスト用の型を定義します。
/// </summary>
public sealed class SignatureTrustStoreCapabilityContractTests
{
    [Fact]
    public void CompositeSignatureTrustStoreExposesGranularTrustCapabilities()
    {
        ISignatureTrustStore trustStore = new FullSignatureTrustStore();

        Assert.IsAssignableFrom<ISignerTrustResolver>(trustStore);
        Assert.IsAssignableFrom<IKeyRevocationChecker>(trustStore);
        Assert.IsAssignableFrom<IKeyExpiryReader>(trustStore);
        Assert.IsAssignableFrom<ICertificateChainVerifier>(trustStore);
        Assert.IsAssignableFrom<ITrustedAnchorReader>(trustStore);
        Assert.IsAssignableFrom<ITrustStoreHealthProbe>(trustStore);
    }

    [Fact]
    /// <summary>
    /// Executes a test helper member. JA: テスト用のメンバーを実行します。
    /// </summary>
    public void TrustStoreHealthProbeDoesNotExposeTrustResolutionCapabilities()
    {
        ITrustStoreHealthProbe healthProbe = new HealthOnlyTrustStoreProbe();

        Assert.False(healthProbe is ISignerTrustResolver);
        Assert.False(healthProbe is IKeyRevocationChecker);
        Assert.False(healthProbe is ICertificateChainVerifier);
    }

    private sealed class HealthOnlyTrustStoreProbe : ITrustStoreHealthProbe
    {
        public Task<bool> IsHealthyAsync(CancellationToken cancellationToken = default)
        {
            return Task.FromResult(true);
        }
    }

    private sealed class FullSignatureTrustStore : ISignatureTrustStore
    {
        /// <summary>
        /// Executes a test helper member. JA: テスト用のメンバーを実行します。
        /// </summary>
        public Task<double> ResolveTrustScoreAsync(string signerId, CancellationToken cancellationToken = default)
        {
            return Task.FromResult(1.0);
        }

        public Task<bool> IsKeyRevokedAsync(string keyId, CancellationToken cancellationToken = default)
        {
            return Task.FromResult(false);
        }

        public Task<DateTime?> GetKeyExpiryAsync(string keyId, CancellationToken cancellationToken = default)
        {
            return Task.FromResult<DateTime?>(DateTime.UnixEpoch);
        }

        /// <summary>
        /// Executes a test helper member. JA: テスト用のメンバーを実行します。
        /// </summary>
        public Task<bool> VerifyCertificateChainAsync(string signerId, CancellationToken cancellationToken = default)
        {
            return Task.FromResult(true);
        }

        public Task<IReadOnlyList<string>> GetTrustedAnchorsAsync(CancellationToken cancellationToken = default)
        {
            IReadOnlyList<string> anchors = [];
            return Task.FromResult(anchors);
        }

        public Task<bool> IsHealthyAsync(CancellationToken cancellationToken = default)
        {
            return Task.FromResult(true);
        }
    }
}
