using System.Text.Json;
using AIKernel.Dtos.Hosting;

namespace AIKernel.Abstractions.Hosting;

public interface IApiEndpointProvider
{
    IEnumerable<ApiEndpoint> Endpoints { get; }
    ValueTask<ApiResponse> InvokeAsync(string operationId, ApiInvocation request, CancellationToken cancellationToken);
}

public interface IMcpToolProvider
{
    IEnumerable<McpOperation> Tools { get; }
    ValueTask<JsonElement> CallAsync(string operationId, JsonElement input, RequestIdentity caller, CancellationToken cancellationToken);
}

public interface IRequestTokenValidator
{
    ValueTask<RequestIdentity?> ValidateAsync(string bearer, CancellationToken cancellationToken);
}

/// <summary>Persistent server identity and the credential issued to clients during export.</summary>
public interface IApplicationIdentity
{
    string ServerId { get; }
    ValueTask<string> GetClientTokenAsync(CancellationToken cancellationToken);
}

public interface IConnectionDescriptorProvider
{
    ConnectionProfile Validate(ConnectionDescriptor descriptor);
    ConnectionDescriptor Read(Stream input);
    void Export(string path, ConnectionDescriptor descriptor);
}

public interface IConnectionProfileStore
{
    Guid? Selected { get; }
    IReadOnlyList<ConnectionProfile> List();
    void Import(Stream descriptor);
    void Select(Guid serverId);
    event Action? Changed;
}

public interface IConnectionClient
{
    Task<HttpResponseMessage> SendAsync(Guid serverId, HttpMethod method, string relativePath,
        HttpContent? body = null, string? range = null, CancellationToken cancellationToken = default);
    /// <summary>Relay an API-relative request, preserving negotiated media, byte ranges and protocol headers.</summary>
    Task<HttpResponseMessage> SendRequestAsync(Guid serverId, HttpRequestMessage request, CancellationToken cancellationToken = default);
}

public interface IHeartbeatProvider
{
    HeartbeatObservation Get(Guid serverId);
    event Action<HeartbeatObservation>? Changed;
    Task MonitorAsync(CancellationToken cancellationToken);
}

public interface IDistributedApplicationHost : IAsyncDisposable
{
    Uri? ListeningAddress { get; }
    Task ExportConnectionAsync(CancellationToken cancellationToken = default);
    Task StartAsync(CancellationToken cancellationToken = default);
    Task StopAsync(CancellationToken cancellationToken = default);
}
