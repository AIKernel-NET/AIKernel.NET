using AIKernel.Abstractions.Rom;
using AIKernel.Dtos.Rom;

namespace AIKernel.Abstractions.Tests.Execution;

/// <summary>
/// RomCoreSpecAlignmentTests の契約を定義します。
/// </summary>
public sealed class RomCoreSpecAlignmentTests
{
    [Fact]
    public async Task RCS_CANON_001_003_Canonical_First_Is_Required_Before_Hashing()
    {
        // RCS-CANON-001/002/003:
        // ハッシュ計算は必ず IROMCanonicalizer の出力のみを入力にする
        IRomDocument rom = new StubRomDocument();
        var canonicalizer = new RecordingCanonicalizer();
        var hasher = new RecordingSemanticHasher();

        var canonical = await canonicalizer.CanonicalizeAsync(rom);
        var hash = await hasher.ComputeHashAsync(canonical);

        Assert.True(canonicalizer.WasCalled);
        Assert.True(hasher.WasCalled);
        Assert.Same(canonicalizer.LastCanonicalized, hasher.LastInput);
        Assert.StartsWith("sha256:", hash, StringComparison.Ordinal);
    }

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
        public IReadOnlyDictionary<string, string> Metadata => new Dictionary<string, string>();
        public IReadOnlyList<string> RelationReferences => new[] { "[[provider.reasoning_model]]" };
        public Task<string> GetSemanticHashAsync() => Task.FromResult("sha256:abc");
        public Task<CanonicalizedRomDto> CanonicalizeAsync() => Task.FromResult(new CanonicalizedRomDto
        {
            CanonicalBody = Body,
            CanonicalizationVersion = "1.0.0",
            Entities = new[]
            {
                new RomEntityMetadataDto
                {
                    EntityId = "entity.1",
                    EntityType = "execution.contract",
                    Version = "1.0.0"
                }
            }
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

    private sealed class RecordingCanonicalizer : IROMCanonicalizer
    {
        public bool WasCalled { get; private set; }
        public CanonicalizedRomDto? LastCanonicalized { get; private set; }

        public CanonicalizedRomDto Canonicalize(IRomDocument document)
        {
            WasCalled = true;
            LastCanonicalized = new CanonicalizedRomDto
            {
                CanonicalBody = document.Body,
                CanonicalizationVersion = "1.0.0",
                Entities = new[]
                {
                    new RomEntityMetadataDto
                    {
                        EntityId = document.EntityId,
                        EntityType = document.EntityType,
                        Version = document.Version
                    }
                }
            };
            return LastCanonicalized;
        }

        public Task<CanonicalizedRomDto> CanonicalizeAsync(IRomDocument document, CancellationToken cancellationToken = default) =>
            Task.FromResult(Canonicalize(document));
    }

    private sealed class RecordingSemanticHasher : ISemanticHasher
    {
        public string Algorithm => "SHA256";
        public bool WasCalled { get; private set; }
        public CanonicalizedRomDto? LastInput { get; private set; }

        public string ComputeHash(CanonicalizedRomDto canonicalized)
        {
            WasCalled = true;
            LastInput = canonicalized;
            return "sha256:canon";
        }

        public Task<string> ComputeHashAsync(CanonicalizedRomDto canonicalized, CancellationToken cancellationToken = default) =>
            Task.FromResult(ComputeHash(canonicalized));

        public bool VerifyHash(CanonicalizedRomDto canonicalized, string expectedHash) =>
            string.Equals(ComputeHash(canonicalized), expectedHash, StringComparison.Ordinal);

        public Task<bool> VerifyHashAsync(
            CanonicalizedRomDto canonicalized,
            string expectedHash,
            CancellationToken cancellationToken = default) =>
            Task.FromResult(VerifyHash(canonicalized, expectedHash));
    }
}



