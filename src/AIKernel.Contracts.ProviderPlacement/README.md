# Provider Placement ABI v1

This package adds capability and placement contracts under `AIKernel.Dtos.Providers` and `AIKernel.Abstractions.Providers`. Existing AIKernel 0.1.4 provider interfaces keep their original signatures. Reference `AIKernel.Kernel.ProviderPlacement` for placement and score validation.

Register a provider and its model IDs for each node. Send the registry snapshot separately from the node's capability and load observation. Refresh both every 10 seconds. The scheduler excludes snapshots older than 30 seconds and nodes without the requested provider and model. Schema version 1 is retained for compatible additions.

The v1 worker contract pulls work and input from a central API and submits results to that API. Payload references contain a SHA-256 digest and a byte count. The receiving side validates both before accepting the payload. Worker identities, credentials and device selectors stay in the host. Claims are opaque and scoped to the worker and job.

The 0.3.0 contract adds `ProviderKind.ChatGeneration` (5) and `ExecutionTarget.Vulkan` (2). Existing wire names and numbers retain their meanings. Validate incoming enum values at the placement boundary, including values decoded from numeric JSON. A GPU name or CUDA capability alone does not establish Vulkan eligibility. The v1 scheduler can select an independently eligible CPU or CUDA device. Selecting Vulkan requires a node observation for that backend.
