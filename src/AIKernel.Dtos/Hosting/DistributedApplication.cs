using System.Text.Json;

namespace AIKernel.Dtos.Hosting;

public sealed record RequestIdentity(string CredentialId, IReadOnlySet<string> Scopes);
public sealed record ApiEndpoint(string Method, string Path, string OperationId, string Scope,
    string? RequestContentType = null, string? ResponseContentType = null);
public sealed record McpOperation(string Name, string Description, JsonElement InputSchema, string OperationId, string Scope);
public sealed record ApiInvocation(Stream Body, IReadOnlyDictionary<string,string> RouteValues,
    IReadOnlyDictionary<string,string> Query, string? Range, RequestIdentity Caller);
public sealed record ApiResponse(int StatusCode, JsonElement? Json = null, Stream? Body = null,
    string? ContentType = null, bool EnableRanges = false, string? Location = null);
public sealed record ConnectionProfile(Guid ServerId, string Name, string Service, Uri ApiUrl, Uri McpUrl);
public sealed record ConnectionDescriptor(int SchemaVersion, string Service, string ServerId,
    string Name, string ApiUrl, string McpUrl, string Token)
{
    public override string ToString() => $"{Service} ({ServerId})";
}
public sealed record Heartbeat(string Service, string ServerId, string Status, DateTimeOffset Utc);
public enum ConnectionState { Unchecked, Connecting, Online, Unavailable, Unauthorized, IdentityMismatch }
public sealed record HeartbeatObservation(Guid ServerId, ConnectionState State, DateTimeOffset? CheckedAt, DateTimeOffset? LastSuccess);
