# LocalLlm host composition

This .NET 10 host project consumes the two frozen 0.3.0 packages. The existing contract solution builds independently of the candidate feed.

```csharp
await using var registration = await LocalLlmRegistration.RegisterAsync(settings, registry, cancellationToken);
var descriptor = await registry.ResolveAsync(request.CapabilityId, cancellationToken);
if (descriptor is not null && registration.ResolveInvoker(descriptor.CapabilityId) is { } target)
{
    var result = await target.InvokeAsync(request, cancellationToken);
    // Consume the shared CapabilityInvocationResult here.
}
```

The host owns the registration and registry. Keep the registry scoped to that host. Stop admitting new requests before disposal. Use the provider's `Succeeded` and `ErrorCode` for each request. A registered descriptor advertises an operation even if a particular model is unavailable.

## Verify the frozen feed

Provide the original `AIKernel.Kernel.0.3.0.nupkg` and `AIKernel.Providers.LocalLlm.0.3.0.nupkg` in one local directory. From the repository root with Python 3.11+ and the .NET SDK specified by `global.json`, run:

```sh
python src/integrations/LocalLlm/verify_frozen.py --feed /path/to/frozen-feed --results /path/to/new-results --model /models/Bonsai-1.7B-Q1_0.gguf
```

The runner hashes the archives before restore, restores into an empty cache with the checked-in lock files, verifies the package sources and versions, compares the consumer's managed and native files against the frozen archives, and saves the test results in TRX and JSON. The full run requires every test to pass. Omit `--model` for the contract-only run, which skips the two real-model cases. `--results` must identify a new directory. Without this argument the runner creates a temporary directory and prints its location.

The manual GitHub Actions workflow `LocalLlm frozen package acceptance` runs the contract-only check. Supply the ID of a run in this repository that has an artifact named `local-llm-030-frozen` containing both original packages at its root. The workflow applies the same pinned hashes and publishes the TRX and JSON as evidence.

[Migration guide (English)](../../../docs/migration/local-llm-0.3.0.md) · [移行ガイド（日本語）](../../../docs/migration/local-llm-0.3.0-jp.md)
