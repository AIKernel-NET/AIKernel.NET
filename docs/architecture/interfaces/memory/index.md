---
title: "Memory Contracts"
layer: "AIKernel.Abstractions.Memory"
status: "v0.1.0"
---

# Memory Contracts

`AIKernel.Abstractions.Memory` defines the OS-independent contract surface for
memory mapped regions used by Native Capability modules.

The contract package owns only the stable boundary:

- `IMemoryRegion`
- `IMemoryMapper`
- `AIKernel.Dtos.Memory.MemoryRegionInfo`
- `AIKernel.Enums.MemoryAccessMode`

Runtime behavior belongs to implementation packages. Core/Common may adapt this
surface to `Result<T>` pipelines, and Kernel may provide Win32 or POSIX mapping
implementations. AIKernel.NET does not implement `mmap`, `CreateFileMapping`,
native paging, or fail-closed result composition.

This keeps GPU, Native ABI, and OS-specific memory behavior outside the shared
contract repository while giving Capability authors a stable ABI-adjacent
interface to target.
