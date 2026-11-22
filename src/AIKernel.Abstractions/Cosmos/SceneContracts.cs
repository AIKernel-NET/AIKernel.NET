using System.Security.Claims;
using AIKernel.Abstractions.Capabilities;

namespace AIKernel.Providers.Cosmos;

/// <summary>Creates caller-bound scene sessions and reports backend readiness.</summary>
public interface ISceneService : IAsyncDisposable
{
    ISceneSession OpenSession(ClaimsPrincipal authenticatedCaller);
    ValueTask<SceneReadiness> ProbeAsync(CancellationToken cancellationToken = default);
    void RevokeRequestAuthorization(string callerId, string requestId);
    void ConfirmBackendQuiescent();
}

public interface ISceneSession : ICapabilityModuleInvoker
{
    Task<SceneMediaReceipt> RegisterMediaAsync(SceneMediaRegistration registration, Stream data,
        CancellationToken cancellationToken = default);
}

public interface ISceneAuthorizer
{
    SceneGrant Authorize(ClaimsPrincipal authenticatedCaller);
}

public interface ISceneReasonerBackend
{
    SceneBackendIdentity Identity { get; }
    ValueTask<SceneReadiness> ProbeAsync(CancellationToken cancellationToken);
    Task<SceneBackendReply> AnalyzeAsync(SceneBackendInput input, CancellationToken cancellationToken);
    // Return "unsupported", "requested", or "confirmed". A request/HTTP abort
    // is not proof that GPU work has stopped; AnalyzeAsync must settle as well.
    ValueTask<string> RequestCancellationAsync(string requestId, CancellationToken cancellationToken);
}

public interface ISceneDeploymentEvidenceSource
{
    ValueTask<SceneDeploymentEvidence> ReadAsync(CancellationToken cancellationToken);
}
