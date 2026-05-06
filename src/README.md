# AIKernel.NET

AIKernel.NET is a specification-first repository for Semantic Context OS contracts.
The `src` tree contains the canonical specification projects that define interfaces, DTOs, enums, and external boundary contracts.

---

## Projects

### AIKernel.Abstractions
- Purpose: Interface layer (no concrete business logic).
- Main namespaces:
  - `AIKernel.Abstractions.Context`
  - `AIKernel.Abstractions.Conversation`
  - `AIKernel.Abstractions.Events`
  - `AIKernel.Abstractions.Execution`
  - `AIKernel.Abstractions.Governance`
  - `AIKernel.Abstractions.History`
  - `AIKernel.Abstractions.Hosting`
  - `AIKernel.Abstractions.Kernel`
  - `AIKernel.Abstractions.Material`
  - `AIKernel.Abstractions.Models`
  - `AIKernel.Abstractions.Prompt`
  - `AIKernel.Abstractions.Providers`
  - `AIKernel.Abstractions.Rom`
  - `AIKernel.Abstractions.Routing`
  - `AIKernel.Abstractions.Scheduling`
  - `AIKernel.Abstractions.Security`
  - `AIKernel.Abstractions.Tasks`
  - `AIKernel.Abstractions.Tooling`
- Project references: `AIKernel.Dtos`, `AIKernel.Enums`

### AIKernel.Contracts
- Purpose: Cross-boundary contract interfaces for orchestration/context projections.
- Main namespace: `AIKernel.Contracts`
- Project references: `AIKernel.Dtos`, `AIKernel.Enums`

### AIKernel.Dtos
- Purpose: POCO/record data carriers only (no business logic).
- Main namespaces:
  - `AIKernel.Dtos.Context`
  - `AIKernel.Dtos.Core`
  - `AIKernel.Dtos.Events`
  - `AIKernel.Dtos.Execution`
  - `AIKernel.Dtos.Governance`
  - `AIKernel.Dtos.Kernel`
  - `AIKernel.Dtos.KernelContext`
  - `AIKernel.Dtos.Material`
  - `AIKernel.Dtos.Prompt`
  - `AIKernel.Dtos.Rom`
  - `AIKernel.Dtos.Routing`
  - `AIKernel.Dtos.Rules`
  - `AIKernel.Dtos.Sandbox`
  - `AIKernel.Dtos.Security`
  - `AIKernel.Dtos.Tokenization`
  - `AIKernel.Dtos.Vfs`
- Project references: `AIKernel.Enums`

### AIKernel.Enums
- Purpose: Shared enum primitives used across the specification layer.
- Main namespace: `AIKernel.Enums`
- Project references: none

### AIKernel.VFS
- Purpose: Provider-agnostic Virtual File System contracts.
- Main namespace: `AIKernel.VFS`
- Project references: `AIKernel.Dtos`

---

## Dependency Rules (Normative)

- `AIKernel.Abstractions` -> `AIKernel.Dtos`, `AIKernel.Enums`
- `AIKernel.Contracts` -> `AIKernel.Dtos`, `AIKernel.Enums`
- `AIKernel.Dtos` -> `AIKernel.Enums`
- `AIKernel.Enums` -> (none)
- `AIKernel.VFS` -> `AIKernel.Dtos`

Prohibited examples:
- `Abstractions` -> `Contracts`
- `Contracts` -> `Abstractions`
- `VFS` -> `Abstractions`

---

## Notes on Decomposition

- `AIKernel.KernelContext` project has been decomposed and moved into `AIKernel.Dtos.KernelContext` (models) and `AIKernel.Abstractions` (contracts).
- `AIKernel.Events` project has been decomposed and moved into `AIKernel.Dtos.Events` (models) and `AIKernel.Abstractions.Events` (contracts).
- Concrete runtime implementations are out of this repository scope and belong to `AIKernel.Core`.

---

## Testing

- `src/tests/AIKernel.Abstractions.Tests`: spec-alignment and interface-composition tests.

---

## License

MIT License  
Copyright © 2026 Takuya Sogawa
