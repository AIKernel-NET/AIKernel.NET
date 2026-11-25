# Migrating to LocalLlm 0.3.0

The frozen 0.3.0 candidate generates text through `chat.local` using a host-registered model. Existing callers can continue to use the same two statements.

```csharp
using var invoker = new LocalLlmInvoker(settings);
var result = await invoker.InvokeAsync(request, cancellationToken);
```

## Applications that use embeddings

Provider 0.1.4 listed `embedding.local` and reported support even when no embedding model was registered. In 0.3.0 it is absent from the operation list and the support query returns `false`. Sending `embedding.local` directly to LocalLlm returns `provider.model_not_registered`. Register an embedding model with the dedicated Embedding Provider and call `IEmbeddingRequestProvider.GenerateEmbeddingsAsync`. Calling `chat.local` without a registered chat model also returns `provider.model_not_registered`.

## Host integration

`LocalLlmRegistration.RegisterAsync(settings, registry, cancellationToken)` copies the host settings and binds the provider and invoker to the manifest ID `local-llm`. It registers the descriptor once during initialization. Look up this ID through the shared `ICapabilityModuleRegistry`, then pass the request to the `ICapabilityModuleInvoker` selected by `ResolveInvoker(request.CapabilityId)`. Resolution returns `null` for a different ID or after shutdown starts. The host controls the model and system prompt.

Keep the registration for the lifetime of the model. Stop accepting requests before calling `await registration.DisposeAsync()`, which waits for active inference and releases the invoker. The registry entry describes capabilities. Scope the registry to the host lifetime because the shared registry has no unregister API. Distributed placement ABI v1 registration is deferred.

## Reading the compatibility results

| Consumer baseline | Result with frozen 0.3.0 |
|---|---|
| Consumer compiled against Provider 0.1.6 and Kernel 0.1.4 | 11/11 tests pass without recompilation |
| Original Provider 0.1.4 contract tests (5/5 against their original release) | The same binary passes 3/5. The two differences are the embedding operation list and support query. |

[Composition project and verification](../../src/integrations/LocalLlm/README.md)
