using AIKernel.Abstractions.Context;
using AIKernel.Abstractions.Material;
using AIKernel.Abstractions.Exceptions;
using Xunit;

namespace AIKernel.Abstractions.Tests;

/// <summary>
/// IMaterialQuarantine と IStructuredMaterial のテスト
/// </summary>
public class MaterialQuarantineTests
{
    /// <summary>
    /// テスト用の簡単な実装
    /// </summary>
    private class TestStructuredMaterial : IStructuredMaterial
    {
        public string RawContent { get; init; }
        public string NormalizedContent { get; init; }
        public double Weight { get; init; }
        public SourceInfo SourceInfo { get; init; }
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
                throw new QuarantineFailedException("Invalid content detected", rawFragment.FragmentId, "Content contains invalid keyword");
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
    public async Task QuarantineAsync_ShouldThrowQuarantineFailedException_WhenContentIsInvalid()
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
        var ex = await Assert.ThrowsAsync<QuarantineFailedException>(
            () => quarantine.QuarantineAsync(fragment));

        Assert.NotNull(ex);
        Assert.Equal("mat-invalid", ex.FragmentId);
        Assert.Contains("Content contains invalid keyword", ex.Reason ?? "");
    }

    [Fact]
    public async Task StructuredMaterial_ShouldPreserveSourceInfo()
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
}
