using AIKernel.Abstractions.Providers;
using Xunit;

namespace AIKernel.Abstractions.Tests;

public sealed class ProviderDescriptorTests
{
    [Fact]
    public void SourceWithoutModuleSupportReportsNoRegistrationDescriptor()
    {
        IProviderCapabilitySource source = new SourceWithoutModule();
        Assert.Null(source.ToCapabilityDescriptor());
    }

    private sealed class SourceWithoutModule : IProviderCapabilitySource
    {
        public IProviderCapabilities GetCapabilities() => throw new NotSupportedException();
    }
}
