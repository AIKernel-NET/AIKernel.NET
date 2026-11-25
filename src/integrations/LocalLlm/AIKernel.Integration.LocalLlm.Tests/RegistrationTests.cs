using AIKernel.Abstractions.Capabilities;
using AIKernel.Core.Capabilities;
using AIKernel.Dtos.Capabilities;
using AIKernel.Providers.LocalLlm;
using Xunit;

namespace AIKernel.Integration.LocalLlm.Tests;

public sealed class RegistrationTests : IAsyncDisposable
{
    private readonly ICapabilityModuleRegistry _registry = new InMemoryCapabilityModuleRegistry();
    private LocalLlmRegistration? _registration;
    private static CancellationToken Token => TestContext.Current.CancellationToken;

    private async Task BindAsync(LocalLlmSettings settings) =>
        _registration = await LocalLlmRegistration.RegisterAsync(settings, _registry, Token);

    public ValueTask DisposeAsync() => _registration?.DisposeAsync() ?? ValueTask.CompletedTask;

    private ICapabilityModuleInvoker Target(string id) =>
        Assert.IsAssignableFrom<ICapabilityModuleInvoker>(_registration!.ResolveInvoker(id));

    private Task<CapabilityModuleDescriptor?> FindDescriptorAsync() =>
        _registry.ResolveAsync(LocalLlmRegistration.CapabilityId, Token).AsTask();

    [Fact]
    public async Task RegistersPackagedDescriptorAndBindsOnlyItsId()
    {
        var settings = new RegisteredLocalLlmSettings { ProviderId = "original", Runtime = "test-runtime" };
        await BindAsync(settings);
        Assert.Equal("original", settings.ProviderId);
        await CheckRegisteredIdentityAsync();
        await CheckShutdownAsync();
    }

    private async Task CheckRegisteredIdentityAsync()
    {
        var descriptor = await FindDescriptorAsync();
        Assert.NotNull(descriptor);
        CheckPackagedDescriptor(descriptor);
        Assert.IsType<LocalLlmInvoker>(Target(descriptor.CapabilityId));
        Assert.Null(_registration!.ResolveInvoker("original"));
    }

    private static void CheckPackagedDescriptor(CapabilityModuleDescriptor descriptor)
    {
        Assert.Equal("local-llm", descriptor.CapabilityId);
        Assert.Equal("0.3.0", descriptor.Version);
        Assert.Equal("test-runtime", descriptor.EntryPoint);
        Assert.Equal(["chat.local"], descriptor.ProvidedOperations);
        Assert.Equal(["llm.local", "local.process"], descriptor.RequiredPermissions.Order());
        Assert.Equal(typeof(CapabilityModuleDescriptor),
            typeof(LocalLlmProvider).GetMethod(nameof(LocalLlmProvider.ToCapabilityDescriptor))!.ReturnType);
    }

    private async Task CheckShutdownAsync()
    {
        await DisposeAsync();
        Assert.Null(_registration!.ResolveInvoker("local-llm"));
    }

    [Theory]
    [InlineData("chat.local", "provider.model_not_registered")]
    [InlineData("embedding.local", "provider.model_not_registered")]
    [InlineData("unknown", "LOCAL_LLM_OPERATION_NOT_SUPPORTED")]
    public async Task SharedInvokerPreservesFrozenFailures(string operation, string expectedCode)
    {
        await BindAsync(new());
        var request = Request(operation, "Hello");
        var result = await Target(request.CapabilityId).InvokeAsync(request, Token);
        CheckFailure(result, expectedCode);
    }

    private static void CheckFailure(CapabilityInvocationResult result, string code)
    {
        Assert.False(result.Succeeded);
        Assert.Equal(code, result.ErrorCode);
        Assert.Null(result.OutputHash);
        Assert.Equal("replay", result.ReplayLogHash);
    }

    [Fact]
    public async Task CancelledRegistrationDoesNotPublishADescriptor()
    {
        await Assert.ThrowsAnyAsync<OperationCanceledException>(RegisterCancelledAsync);
        Assert.Null(await FindDescriptorAsync());
    }

    private Task RegisterCancelledAsync() =>
        LocalLlmRegistration.RegisterAsync(new(), _registry, new CancellationToken(true));

    public static bool HasModel => File.Exists(Environment.GetEnvironmentVariable("AIKERNEL_TEST_BONSAI_GGUF"));

    [Theory(SkipUnless = nameof(HasModel), Skip = "Requires the Bonsai 1.7B Q1_0 fixture.")]
    [InlineData("Follow the user's formatting request.", "Reply with exactly the word BLUE.",
        "24a866f4940f1b00083a71ba4df7323bac1486f28dc81d500bbc4bb02c6e0e16")]
    [InlineData("You are a helpful assistant. Answer in the user's language.", "「こんにちは」とだけ答えてください。",
        "439e44a82b28f76c2661e4e65537f0f3963df49beaed16276f0938471f86a7d2")]
    public async Task GeneratesAcceptedReplyAndDrainsOnShutdown(string system, string prompt, string hash)
    {
        await BindAsync(ModelSettings(system));
        var request = Request("chat.local", prompt);
        await CheckCancellationAsync(request);
        await CheckActiveReplyAsync(request, hash);
    }

    private static LocalLlmSettings ModelSettings(string system) => new()
    {
        BonsaiModelPath = Environment.GetEnvironmentVariable("AIKERNEL_TEST_BONSAI_GGUF"),
        CpuThreads = 2, ContextTokens = 256, MaxNewTokens = 16, SystemPrompt = system
    };

    private Task CheckCancellationAsync(CapabilityInvocationRequest request) =>
        Assert.ThrowsAnyAsync<OperationCanceledException>(() =>
            Target(request.CapabilityId).InvokeAsync(request, new CancellationToken(true)).AsTask());

    private async Task CheckActiveReplyAsync(CapabilityInvocationRequest request, string hash)
    {
        var pending = Target(request.CapabilityId).InvokeAsync(request, Token).AsTask();
        Assert.False(pending.IsCompleted, "The shutdown check requires an active generation.");
        await CheckShutdownAsync();
        CheckReply(await pending, hash);
    }

    private static void CheckReply(CapabilityInvocationResult reply, string hash)
    {
        Assert.True(reply.Succeeded, reply.ErrorMessage);
        Assert.Equal("sha256:" + hash, reply.OutputHash);
    }

    private static CapabilityInvocationRequest Request(string operation, string prompt) =>
        new("consumer", "local-llm", operation, new Dictionary<string, string> { ["prompt"] = prompt },
            null, "replay", new Dictionary<string, string>());
}
