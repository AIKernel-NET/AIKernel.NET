using AIKernel.Abstractions.Context;
using AIKernel.Abstractions.Material;
using AIKernel.Dtos.Governance;
using Xunit;

namespace AIKernel.Abstractions.Tests;

/// <summary>
/// IMaterialQuarantine と IStructuredMaterial のテスト
/// </summary>
public class MaterialQuarantineTests
{
    private sealed class TestMaterialScanner : IMaterialScanner
    {
        public int ScanCallCount { get; private set; }
        public int EvaluateCallCount { get; private set; }

        public ValueTask<IReadOnlyList<string>> ScanAsync(string rawMaterial, CancellationToken cancellationToken = default)
        {
            ScanCallCount++;
            if (rawMaterial.Contains("malware", StringComparison.OrdinalIgnoreCase))
            {
                return ValueTask.FromResult<IReadOnlyList<string>>(new[] { "malware.signature.detected" });
            }

            return ValueTask.FromResult<IReadOnlyList<string>>(Array.Empty<string>());
        }

        public ValueTask<TrustContext> EvaluateTrustAsync(string rawMaterial, CancellationToken cancellationToken = default)
        {
            EvaluateCallCount++;
            var trusted = !rawMaterial.Contains("untrusted", StringComparison.OrdinalIgnoreCase);
            return ValueTask.FromResult(new TrustContext
            {
                SignerId = "scanner",
                TrustScore = trusted ? 0.95 : 0.10,
                IsKeyRevoked = false,
                IsCertificateChainValid = trusted,
                IsTrustStoreHealthy = true,
                VerificationTimestamp = DateTime.UtcNow,
                IsDetermined = true
            });
        }
    }

    private sealed class StrictScanner : IMaterialScanner
    {
        public ValueTask<IReadOnlyList<string>> ScanAsync(string rawMaterial, CancellationToken cancellationToken = default)
        {
            if (rawMaterial.Contains("malware", StringComparison.OrdinalIgnoreCase))
            {
                throw new UnauthorizedAccessException("Scanner rejected material");
            }

            return ValueTask.FromResult<IReadOnlyList<string>>(Array.Empty<string>());
        }

        public ValueTask<TrustContext> EvaluateTrustAsync(string rawMaterial, CancellationToken cancellationToken = default) =>
            ValueTask.FromResult(new TrustContext
            {
                SignerId = "strict-scanner",
                TrustScore = 1.0,
                IsKeyRevoked = false,
                IsCertificateChainValid = true,
                IsTrustStoreHealthy = true,
                VerificationTimestamp = DateTime.UtcNow,
                IsDetermined = true
            });
    }

    private sealed class StrictFormatQuarantine : IMaterialQuarantine
    {
        public Task<IStructuredMaterial> QuarantineAsync(ContextFragment rawFragment, CancellationToken ct = default)
        {
            if (rawFragment.Content.Contains("bad-format", StringComparison.OrdinalIgnoreCase))
            {
                throw new FormatException("Quarantine rejected malformed content");
            }

            return Task.FromResult<IStructuredMaterial>(new TestStructuredMaterial
            {
                RawContent = rawFragment.Content,
                NormalizedContent = rawFragment.Content.Trim(),
                Weight = rawFragment.Priority,
                SourceInfo = new SourceInfo
                {
                    SourceId = $"src-{rawFragment.FragmentId}",
                    SourceType = "context_fragment",
                    CollectedAt = DateTimeOffset.UtcNow
                }
            });
        }
    }

    /// <summary>
    /// テスト用の簡単な実装
    /// </summary>
    private class TestStructuredMaterial : IStructuredMaterial
    {
        public required string RawContent { get; init; }
        public required string NormalizedContent { get; init; }
        public double Weight { get; init; }
        public required SourceInfo SourceInfo { get; init; }
    }

    /// <summary>
    /// テスト用の検疫実装（正常系）
    /// </summary>
    private class SuccessfulQuarantine : IMaterialQuarantine
    {
        public Task<IStructuredMaterial> QuarantineAsync(ContextFragment rawFragment, CancellationToken ct = default)
        {
            if (rawFragment.Content.Contains("invalid", StringComparison.OrdinalIgnoreCase))
            {
                throw new InvalidOperationException("Invalid content detected");
            }

            var normalized = rawFragment.Content.Trim().ToLowerInvariant();
            var material = new TestStructuredMaterial
            {
                RawContent = rawFragment.Content,
                NormalizedContent = normalized,
                Weight = rawFragment.Priority,
                SourceInfo = new SourceInfo
                {
                    SourceId = $"src-{rawFragment.FragmentId}",
                    SourceType = "context_fragment",
                    CollectedAt = DateTimeOffset.UtcNow
                }
            };

            return Task.FromResult((IStructuredMaterial)material);
        }
    }

    [Fact]
    public async Task QuarantineAsync_ShouldNormalizeContent()
    {
        // Arrange
        var quarantine = new SuccessfulQuarantine();
        var fragment = new ContextFragment
        {
            FragmentId = "mat-1",
            Category = ContextCategory.Material,
            Content = "  TEST CONTENT  ",
            Priority = 0.8
        };

        // Act
        var result = await quarantine.QuarantineAsync(fragment);

        // Assert
        Assert.NotNull(result);
        Assert.Equal("test content", result.NormalizedContent);
        Assert.Equal(0.8, result.Weight);
        Assert.Equal("  TEST CONTENT  ", result.RawContent);
    }

    [Fact]
    public async Task QuarantineAsync_ShouldThrowInvalidOperationException_WhenContentIsInvalid()
    {
        // Arrange
        var quarantine = new SuccessfulQuarantine();
        var fragment = new ContextFragment
        {
            FragmentId = "mat-invalid",
            Category = ContextCategory.Material,
            Content = "This contains INVALID data"
        };

        // Act & Assert
        var ex = await Assert.ThrowsAsync<InvalidOperationException>(
            () => quarantine.QuarantineAsync(fragment));

        Assert.NotNull(ex);
        Assert.Equal("Invalid content detected", ex.Message);
    }

    [Fact]
    public void StructuredMaterial_ShouldPreserveSourceInfo()
    {
        // Arrange
        var sourceInfo = new SourceInfo
        {
            SourceId = "test-source",
            SourceType = "api",
            CollectedAt = DateTimeOffset.Now
        };

        var material = new TestStructuredMaterial
        {
            RawContent = "Raw data",
            NormalizedContent = "Normalized data",
            Weight = 0.9,
            SourceInfo = sourceInfo
        };

        // Act & Assert
        Assert.Equal("test-source", material.SourceInfo.SourceId);
        Assert.Equal("api", material.SourceInfo.SourceType);
        Assert.Equal(0.9, material.Weight);
    }

    [Fact]
    public async Task QuarantineAsync_ShouldAssignCorrectWeight()
    {
        // Arrange
        var quarantine = new SuccessfulQuarantine();
        var fragment = new ContextFragment
        {
            FragmentId = "mat-weight",
            Category = ContextCategory.Material,
            Content = "Content with weight",
            Priority = 0.75
        };

        // Act
        var result = await quarantine.QuarantineAsync(fragment);

        // Assert
        Assert.Equal(0.75, result.Weight);
    }

    [Fact]
    public async Task Scanner_And_Quarantine_Should_Keep_Clear_Boundaries()
    {
        // Boundary rule:
        // Scanner は物理スキャン/信頼評価のみ、Quarantine は正規化と昇格のみ
        var scanner = new TestMaterialScanner();
        var quarantine = new SuccessfulQuarantine();
        const string rawMaterial = "  SAFE MATERIAL  ";

        var findings = await scanner.ScanAsync(rawMaterial);
        var trust = await scanner.EvaluateTrustAsync(rawMaterial);
        var promoted = await quarantine.QuarantineAsync(new ContextFragment
        {
            FragmentId = "mat-boundary",
            Category = ContextCategory.Material,
            Content = rawMaterial,
            Priority = 0.7
        });

        Assert.Empty(findings);
        Assert.True(trust.IsDetermined);
        Assert.True(trust.TrustScore > 0.9);
        Assert.Equal("safe material", promoted.NormalizedContent);
        Assert.Equal(1, scanner.ScanCallCount);
        Assert.Equal(1, scanner.EvaluateCallCount);
    }

    [Fact]
    public async Task ScannerFailure_ShouldBeRaisedByScanner_BeforeQuarantine()
    {
        // Scanner failure: セキュリティ拒否は IMaterialScanner が担当
        var scanner = new StrictScanner();
        var quarantine = new StrictFormatQuarantine();
        var fragment = new ContextFragment
        {
            FragmentId = "mat-malware",
            Category = ContextCategory.Material,
            Content = "contains malware signature",
            Priority = 1.0
        };

        await Assert.ThrowsAsync<UnauthorizedAccessException>(async () =>
        {
            await scanner.ScanAsync(fragment.Content);
            _ = await quarantine.QuarantineAsync(fragment);
        });
    }

    [Fact]
    public async Task NormalizationFailure_ShouldBeRaisedByQuarantine_AfterScan()
    {
        // Normalization failure: 形式拒否は IMaterialQuarantine が担当
        var scanner = new StrictScanner();
        var quarantine = new StrictFormatQuarantine();
        var fragment = new ContextFragment
        {
            FragmentId = "mat-bad-format",
            Category = ContextCategory.Material,
            Content = "bad-format payload",
            Priority = 0.4
        };

        var findings = await scanner.ScanAsync(fragment.Content);
        Assert.Empty(findings);
        await Assert.ThrowsAsync<FormatException>(() => quarantine.QuarantineAsync(fragment));
    }
}


