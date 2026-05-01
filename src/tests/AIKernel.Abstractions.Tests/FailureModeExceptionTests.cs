using AIKernel.Abstractions.Exceptions;
using Xunit;

namespace AIKernel.Abstractions.Tests;

/// <summary>
/// Failure Mode 例外のテスト
/// </summary>
public class FailureModeExceptionTests
{
    [Fact]
    public void AttentionPollutionException_ShouldBeThrowable()
    {
        // Arrange & Act
        var ex = new AttentionPollutionException("Attention pollution detected");

        // Assert
        Assert.NotNull(ex);
        Assert.IsType<AttentionPollutionException>(ex);
        Assert.Equal("Attention pollution detected", ex.Message);
    }

    [Fact]
    public void AttentionPollutionException_WithInnerException_ShouldPreserveChain()
    {
        // Arrange
        var innerEx = new InvalidOperationException("Inner error");

        // Act
        var ex = new AttentionPollutionException("Outer error", innerEx);

        // Assert
        Assert.NotNull(ex);
        Assert.NotNull(ex.InnerException);
        Assert.Equal("Outer error", ex.Message);
        Assert.Equal("Inner error", ex.InnerException.Message);
    }

    [Fact]
    public void SurfaceModeDetectedException_ShouldBeThrowable()
    {
        // Arrange & Act
        var ex = new SurfaceModeDetectedException("Surface mode detected");

        // Assert
        Assert.NotNull(ex);
        Assert.IsType<SurfaceModeDetectedException>(ex);
        Assert.Equal("Surface mode detected", ex.Message);
    }

    [Fact]
    public void SurfaceModeDetectedException_WithInnerException_ShouldPreserveChain()
    {
        // Arrange
        var innerEx = new InvalidOperationException("Inner error");

        // Act
        var ex = new SurfaceModeDetectedException("Outer error", innerEx);

        // Assert
        Assert.NotNull(ex);
        Assert.NotNull(ex.InnerException);
        Assert.Equal("Outer error", ex.Message);
    }

    [Fact]
    public void QuarantineFailedException_ShouldStoreFragmentId()
    {
        // Arrange & Act
        var ex = new QuarantineFailedException(
            "Quarantine failed",
            fragmentId: "frag-123",
            reason: "Invalid content");

        // Assert
        Assert.NotNull(ex);
        Assert.IsType<QuarantineFailedException>(ex);
        Assert.Equal("frag-123", ex.FragmentId);
        Assert.Equal("Invalid content", ex.Reason);
    }

    [Fact]
    public void QuarantineFailedException_WithSimpleMessage_ShouldWork()
    {
        // Arrange & Act
        var ex = new QuarantineFailedException("Quarantine check failed");

        // Assert
        Assert.NotNull(ex);
        Assert.Equal("Quarantine check failed", ex.Message);
        Assert.Null(ex.FragmentId);
        Assert.Null(ex.Reason);
    }

    [Fact]
    public void QuarantineFailedException_ShouldBeCatchableAsException()
    {
        // Arrange
        Exception thrownEx = new QuarantineFailedException(
            "Test quarantine failure",
            "frag-1",
            "Test reason");

        // Act & Assert
        Assert.IsType<QuarantineFailedException>(thrownEx);
        Assert.IsAssignableFrom<Exception>(thrownEx);
    }

    [Fact]
    public void Exceptions_ShouldBeSerializable()
    {
        // Test that exceptions can be caught and re-thrown
        var originalEx = new QuarantineFailedException(
            "Original message",
            "frag-123",
            "Original reason");

        Exception caughtEx = null!;
        try
        {
            throw originalEx;
        }
        catch (QuarantineFailedException ex)
        {
            caughtEx = ex;
        }

        Assert.NotNull(caughtEx);
        Assert.IsType<QuarantineFailedException>(caughtEx);
        var typedEx = (QuarantineFailedException)caughtEx;
        Assert.Equal("Original message", typedEx.Message);
        Assert.Equal("frag-123", typedEx.FragmentId);
    }
}
