---
name: aikernel-development
description: Build, extend, or troubleshoot applications and Providers with AIKernel. Use for package selection, inference, HTTP or MCP hosting, capability registration, governed execution, replay, and compatibility checks.
---

# Develop with AIKernel

1. Read the application's project files, lock files, and local instructions. Match the installed AIKernel version and target framework. The published baseline in [developer-kit.json](developer-kit.json) is 0.1.4. Confirm availability before suggesting newer packages.
2. Select the narrowest verified starting point in the kit. Run the dependency-free example first when setting up a new environment. Use the matching source and package versions to investigate API signatures.
3. Make the change at the owning layer. AIKernel.NET owns shared interfaces, DTOs, and enums. Core owns execution and routing. Providers own external protocols, clients, and runtime-specific settings. The application owns user workflows, authorization, and deployment configuration. Keep application dependencies out of the shared contracts.
4. Verify the normal entry point. For a Provider, register its descriptor, discover the capability, invoke it through the shared contract, and check the output and cancellation. Test with a double first and verify the actual engine separately when available. Report the package, backend, platform, and limits used.

## Pick the relevant guide

- **Install or migrate:** Use the installation guide and run the first sample. Follow the upgrade guide for 0.1.3 applications.
- **Inference:** Use the versioned inference guide. Check the exact model family, weight format, target backend and memory budget, then test expected output. Record the selected backend and include token counts when comparing performance.
- **External service or Provider:** Read the Provider model and module map. Keep endpoints and credentials in trusted host configuration. Validate output at the adapter and preserve distinct failures. Reuse the capability envelope when it fits.
- **HTTP or MCP:** Follow the distributed-application sample for the installed version. Apply authentication and authorization to each operation and test both transports independently. Keep model credentials on the host.
- **Governance and replay:** Use the repository's `rom/governance` files for executable policy. Keep proposed actions distinct from observed evidence and check both unsafe approvals and undue rejections. Use the replay specification for evidence fields. Replay claims should identify the exact input, runtime settings, and version.

Use [the developer kit](developer-kit.json) for canonical guides, package entry points, and source repositories. Keep the user's secrets, private inputs, and unreviewed generated content out of published files and test logs.
