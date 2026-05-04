using AIKernel.Abstractions.Rom;

namespace AIKernel.Abstractions.Tests.Execution;

public sealed class RomCoreSpecAlignmentTests
{
    [Fact]
    public async Task RCS_001_002_004_RomContract_Covers_Mandatory_Fields_References_And_Hash()
    {
        // RCS-001: entity.id / entity.type 必須
        // RCS-002: [[id]] 参照解決対象を保持
        // RCS-004: Semantic Hash 算出可能
        IRomDocument rom = new StubRomDocument();

        Assert.Equal("entity.1", rom.EntityId);
        Assert.Equal("execution.contract", rom.EntityType);
        Assert.Contains("[[provider.reasoning_model]]", rom.RelationReferences);
        var hash = await rom.GetSemanticHashAsync();
        Assert.StartsWith("sha256:", hash, StringComparison.Ordinal);
    }

    [Fact]
    public async Task RCS_F002_RCS_F005_FailClosed_Result_Type_Is_Safe()
    {
        // RCS-F002: 未解決リンクを拒否
        // RCS-F005: 循環参照を検知したら停止
        var validator = new StubRomValidator();
        var resolver = new StubResolver();
        var rom = new StubRomDocument();

        var linkage = await validator.ValidateLinkageAsync(rom, resolver);
        var cyclic = await validator.DetectCircularReferencesAsync(rom, resolver);

        Assert.False(linkage.AllLinksResolvable);
        Assert.True(cyclic.MayTriggerInferenceLoop);
    }

    private sealed class StubRomDocument : IRomDocument
    {
        public string EntityId => "entity.1";
        public string EntityType => "execution.contract";
        public string Version => "1.0.0";
        public string Body => "* [author]: [[provider.reasoning_model]]";
        public IReadOnlyDictionary<string, object> Metadata => new Dictionary<string, object>();
        public IReadOnlyList<string> RelationReferences => new[] { "[[provider.reasoning_model]]" };
        public Task<string> GetSemanticHashAsync() => Task.FromResult("sha256:abc");
        public Task<CanonicalizedRomDocument> CanonicalizeAsync() => Task.FromResult(new CanonicalizedRomDocument
        {
            NormalizedEntityId = "entity.1",
            NormalizedMetadata = new Dictionary<string, string>(),
            NormalizedBody = Body,
            CanonicalizedAt = DateTime.UtcNow
        });
    }

    private sealed class StubRomValidator : IRomValidator
    {
        public Task<RomSchemaValidationResult> ValidateSchemaAsync(IRomDocument document, CancellationToken cancellationToken = default) =>
            Task.FromResult(new RomSchemaValidationResult { IsValid = true, Message = "ok" });

        public Task<RomLinkageValidationResult> ValidateLinkageAsync(IRomDocument document, IRelationResolver relationResolver, CancellationToken cancellationToken = default) =>
            Task.FromResult(new RomLinkageValidationResult { AllLinksResolvable = false, Message = "RCS-F002", UnresolvedLinks = new[] { "x" } });

        public Task<RomTypeConsistencyResult> ValidateTypeConsistencyAsync(IRomDocument document, EntityTypeSchema typeSchema, CancellationToken cancellationToken = default) =>
            Task.FromResult(new RomTypeConsistencyResult { IsConsistent = true, Message = "ok" });

        public Task<CircularReferenceDetectionResult> DetectCircularReferencesAsync(IRomDocument document, IRelationResolver relationResolver, int maxDepth = 10, CancellationToken cancellationToken = default) =>
            Task.FromResult(new CircularReferenceDetectionResult { CircularReferencesDetected = true, Message = "RCS-F005", MayTriggerInferenceLoop = true });
    }

    private sealed class StubResolver : IRelationResolver
    {
        public Task<ResolvableEntity?> ResolveAsync(string referenceId, CancellationToken cancellationToken = default) =>
            Task.FromResult<ResolvableEntity?>(null);

        public Task<bool> CanResolveAsync(string referenceId, CancellationToken cancellationToken = default) =>
            Task.FromResult(false);
    }
}
