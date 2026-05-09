---
version: 0.0.1
issuer: ai-kernel@tkysoftware.xsrv.jp
title: "DI Guide"
description: Extension points and DI registration patterns for AIKernel.Core (for integrators)
created: 2026-01-01
tags:
  - aikernel
  - architecture
  - preprocessing
  - prompt-design
  - english
updated: 2026-05-06
---

# Purpose
This guide shows dependency injection (DI) registration patterns, lifecycle guidance, and sample code for AIKernel.Core abstractions so integrators can replace Providers easily.

# Scope
- Target: implementations referencing `AIKernel.NET` (contracts) and `AIKernel.Core` (abstractions)
- Audience: Provider implementers, service developers, operations engineers

# Terms and assumptions
- **Contracts layer (AIKernel.NET)**: contains interfaces, DTOs, Enums only
- **Core (AIKernel.Core)**: provides abstract interfaces and minimal NoOp implementations; production implementations live in separate repos

# Extension points (excerpt)
- **IModelProvider**: model inference interface. Singleton recommended.
- **IRagProvider**: retrieval (RAG) interface. Singleton recommended.
- **IEmbeddingProvider**: embedding generation. Singleton recommended.
- **IVirtualFileProvider**: Vfs abstraction (Git/S3/Blob). Singleton recommended.
- **IScheduler**: job scheduler. Singleton recommended.
- **IEventBus**: event delivery. Singleton recommended.

# Lifecycle guidance
- **Singleton**: for thread-safe implementations that hold connections or models
- **Scoped**: for request-scoped state
- **Transient**: for lightweight utilities only

# DI registration pattern (template)
```csharp
var builder = WebApplication.CreateBuilder(args);

// Register Core contracts and minimal implementations
builder.Services.AddAIKernelCoreContracts();

// Inject user-provided Providers (example)
builder.Services.AddSingleton<IModelProvider, OpenAIModelProvider>();
builder.Services.AddSingleton<IVirtualFileProvider, GitVfsProvider>();

var app = builder.Build();
app.MapControllers();
app.Run();
```

# NoOp implementations
Core provides NoOp/Stub implementations for initial startup. NoOp is for test startup only; replace with production implementations in production.

# Error handling and timeouts
- Providers must respect cancellation tokens
- Always set timeouts for network calls
- Retry policies are recommended to be controlled by the caller (Pipeline)

# Security and authentication
- Store secrets in Vault/KMS; do not embed in code or images
- Inject credentials via DI or environment providers

# Testing guidance
- Design interfaces to be mockable
- Automate integration tests using sample implementations
- Include NoOp-based minimal startup tests in CI

# Version compatibility and migration
- AIKernel.NET (contracts) prioritizes backward compatibility
 Breaking changes use major versions and migration steps documented in design/MIGRATION_GUIDE.md

# References
- AIKernel.NET/docs/design/DESIGN_INTENT.md
- AIKernel.Core/docs/NOOP_IMPLEMENTATION.md

# Changelog
- 2026-05-01 Initial version
- v0.0.1 (2026-05-06): Version upgrade aligned with documentation guidelines

