using AIKernel.Contracts;

namespace AIKernel.Abstractions.Tests;

public sealed class ContractPurityTests
{
    [Fact]
    public void MaterialContractExposesOnlyImmutableViewMembers()
    {
        var methodNames = typeof(IMaterialContract)
            .GetMethods()
            .Select(method => method.Name)
            .ToArray();

        Assert.DoesNotContain("Normalize", methodNames);
        Assert.DoesNotContain("Structurize", methodNames);
        Assert.DoesNotContain("ExtractEssentialContent", methodNames);
        Assert.DoesNotContain("ValidateQuarantine", methodNames);
    }

    [Fact]
    public void ContextContractsDoNotOwnValidationOrAnalysisProcessing()
    {
        var unifiedMethodNames = typeof(IUnifiedContextContract).GetMethods().Select(method => method.Name).ToArray();
        var orchestrationMethodNames = typeof(IOrchestrationContract).GetMethods().Select(method => method.Name).ToArray();
        var expressionMethodNames = typeof(IExpressionContract).GetMethods().Select(method => method.Name).ToArray();

        Assert.DoesNotContain("ValidateAll", unifiedMethodNames);
        Assert.DoesNotContain("ValidateLayerSeparation", unifiedMethodNames);
        Assert.DoesNotContain("DetectPollution", unifiedMethodNames);
        Assert.DoesNotContain("CalculateSignalToNoiseRatio", unifiedMethodNames);
        Assert.DoesNotContain("Validate", orchestrationMethodNames);
        Assert.DoesNotContain("CalculateSignalToNoiseRatio", orchestrationMethodNames);
        Assert.DoesNotContain("ValidateIsolation", expressionMethodNames);
        Assert.DoesNotContain("CanApplyAfterInference", expressionMethodNames);
    }

    [Fact]
    public void MaterialTransformationsAreExternalizedAsServices()
    {
        Assert.True(typeof(IMaterialNormalizer).IsInterface);
        Assert.True(typeof(IMaterialStructurizer).IsInterface);
        Assert.True(typeof(IMaterialCanonicalizer).IsInterface);
        Assert.True(typeof(IMaterialHashProvider).IsInterface);
        Assert.True(typeof(IEssentialMaterialExtractor).IsInterface);
        Assert.True(typeof(IMaterialQuarantineValidator).IsInterface);
    }

    [Fact]
    public void SignalToNoiseRatioCalculatorSupportsUnifiedAndOrchestrationContracts()
    {
        var signatures = typeof(ISignalToNoiseRatioCalculator)
            .GetMethods()
            .Where(method => method.Name == "CalculateSignalToNoiseRatio")
            .Select(method => method.GetParameters().Single().ParameterType)
            .ToArray();

        Assert.Contains(typeof(IUnifiedContextContract), signatures);
        Assert.Contains(typeof(IOrchestrationContract), signatures);
    }
}
