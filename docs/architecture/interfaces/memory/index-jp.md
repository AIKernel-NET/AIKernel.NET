---
title: "Memory Contracts"
layer: "AIKernel.Abstractions.Memory"
status: "v0.1.0"
---

# Memory Contracts

`AIKernel.Abstractions.Memory` は、Native Capability module が利用する
memory mapped region の OS 非依存 contract surface を定義します。

Contract package が所有するのは、安定した境界だけです。

- `IMemoryRegion`
- `IMemoryMapper`
- `AIKernel.Dtos.Memory.MemoryRegionInfo`
- `AIKernel.Enums.MemoryAccessMode`

Runtime behavior は実装 package の責務です。Core/Common はこの surface を
`Result<T>` pipeline へ adapter でき、Kernel は Win32 または POSIX mapping
実装を提供できます。AIKernel.NET は `mmap`、`CreateFileMapping`、native
paging、fail-closed result composition を実装しません。

これにより、GPU、Native ABI、OS 固有 memory behavior を共有 contract
repository の外側に保ったまま、Capability author が対象にできる安定した
ABI-adjacent interface を提供します。
