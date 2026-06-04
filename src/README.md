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
  - `AIKernel.Abstractions.Dsl`
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
  - `AIKernel.Abstractions.Time`
  - `AIKernel.Abstractions.Tooling`
  - `AIKernel.Vfs` (Vfs contracts, owned by the Abstractions assembly)
- Project references: `AIKernel.Dtos`, `AIKernel.Enums`

### AIKernel.Contracts
- Purpose: Cross-boundary contract interfaces for orchestration/context projections.
- Main namespace: `AIKernel.Contracts`
- Project references: `AIKernel.Dtos`, `AIKernel.Enums`

### AIKernel.Dtos
- Purpose: POCO/record data carriers and wire metadata key constants only (no business logic).
- Main namespaces:
  - `AIKernel.Dtos.Context`
  - `AIKernel.Dtos.Core`
  - `AIKernel.Dtos.Dsl`
  - `AIKernel.Dtos.Events`
  - `AIKernel.Dtos.Execution`
  - `AIKernel.Dtos.Governance`
  - `AIKernel.Dtos.Kernel`
  - `AIKernel.Dtos.KernelContext`
  - `AIKernel.Dtos.History`
  - `AIKernel.Dtos.Material`
  - `AIKernel.Dtos.Prompt`
  - `AIKernel.Dtos.Rom`
  - `AIKernel.Dtos.Routing`
  - `AIKernel.Dtos.Rules`
  - `AIKernel.Dtos.Sandbox`
  - `AIKernel.Dtos.Security`
  - `AIKernel.Dtos.Tokenization`
  - `AIKernel.Dtos.Time`
  - `AIKernel.Dtos.Vfs`
- Project references: `AIKernel.Enums`

DTO packages may expose stable metadata key constants for wire formats such as DSL ROM and History ROM.
Those constants are part of the serialized contract surface; parsing, validation, and runtime behavior still belong to Core/Common or host implementations.

### AIKernel.Enums
- Purpose: Shared enum primitives used across the specification layer.
- Main namespace: `AIKernel.Enums`
- Project references: none

## Dependency Rules (Normative)

- `AIKernel.Abstractions` -> `AIKernel.Dtos`, `AIKernel.Enums`
- `AIKernel.Contracts` -> `AIKernel.Dtos`, `AIKernel.Enums`
- `AIKernel.Dtos` -> `AIKernel.Enums`
- `AIKernel.Enums` -> (none)

Prohibited examples:
- `Abstractions` -> `Contracts`
- `Contracts` -> `Abstractions`
- `Abstractions` -> separate Vfs package/project

`AIKernel.Vfs` is a public namespace inside `AIKernel.Abstractions`; the separate `AIKernel.Vfs` compatibility project was removed in v0.0.4.

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
