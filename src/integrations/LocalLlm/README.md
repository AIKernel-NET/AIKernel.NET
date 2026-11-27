# LocalLlm host composition

This .NET 10 host project uses AIKernel.Kernel and AIKernel.Providers.LocalLlm 0.3.0. Its default package locks cover the coordinated candidates with all seven AIKernel packages at 0.3.0. The existing contract solution builds independently of the candidate feed.

```csharp
await using var registration = await LocalLlmRegistration.RegisterAsync(settings, registry, cancellationToken);
var descriptor = await registry.ResolveAsync(request.CapabilityId, cancellationToken);
if (descriptor is not null && registration.ResolveInvoker(descriptor.CapabilityId) is { } target)
{
    var result = await target.InvokeAsync(request, cancellationToken);
    // Consume the shared CapabilityInvocationResult here.
}
```

The coordinated host asks the shared `IProviderCapabilitySource.ToCapabilityDescriptor()` contract for the descriptor after initialization. A provider that does not supply a module descriptor returns `null`. The frozen-feed runner selects the historical concrete call when building against the archived contracts.

When consuming the new descriptor API, restore the host and provider together from the coordinated package lock. A LocalLlm binary built before the interface member was introduced still returns its descriptor through its original concrete method. With the new Abstractions assembly it returns the default `null` through the interface. Rebuild third-party providers against the new contract to expose their matching descriptor method through that interface.

The host owns the registration and registry. Keep the registry scoped to that host. Stop admitting new requests before disposal. Use the provider's `Succeeded` and `ErrorCode` for each request. A registered descriptor advertises an operation even if a particular model is unavailable.

## Test the coordinated 0.3.0 candidates

Place all seven candidate nupkgs in a local NuGet feed. Supply that feed and nuget.org (or a verified mirror for third-party dependencies) in a NuGet.Config file. From this directory, restore the test project using the exact candidate locks, then run its registration and invocation tests.

```sh
dotnet restore AIKernel.Integration.LocalLlm.Tests --locked-mode --configfile /path/to/NuGet.Config
dotnet test AIKernel.Integration.LocalLlm.Tests --no-restore -c Release
```

Set `AIKERNEL_TEST_BONSAI_GGUF` to the Bonsai 1.7B GGUF file to run the two generation tests. These locks record the candidate archives. Verify the feed artifacts and their locks again at publication.

## Reproduce the original frozen feed

Provide the original `AIKernel.Kernel.0.3.0.nupkg` and `AIKernel.Providers.LocalLlm.0.3.0.nupkg` in one local directory. From the repository root with Python 3.11+ and the .NET SDK specified by `global.json`, run:

```sh
python src/integrations/LocalLlm/verify_frozen.py --feed /path/to/frozen-feed --results /path/to/new-results --model /models/Bonsai-1.7B-Q1_0.gguf
```

The runner hashes the archives before restore, restores into an empty cache with the archived `packages.frozen.lock.json` files, verifies the package sources and versions, compares the consumer's managed and native files against the frozen archives, and saves the test results in TRX and JSON. The full run requires every test to pass. Omit `--model` for the contract-only run, which skips the two real-model cases. `--results` must identify a new directory. Without this argument the runner creates a temporary directory and prints its location.

The manual GitHub Actions workflow `LocalLlm frozen package acceptance` runs the contract-only check. Supply the ID of a run in this repository that has an artifact named `local-llm-030-frozen` containing both original packages at its root. The workflow applies the same pinned hashes and publishes the TRX and JSON as evidence.

[Migration guide (English)](../../../docs/migration/local-llm-0.3.0.md) · [移行ガイド（日本語）](../../../docs/migration/local-llm-0.3.0-jp.md)
