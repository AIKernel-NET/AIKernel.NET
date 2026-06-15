---
updated: 2026-06-15
published: 2026-06-15
version: "0.1.1.1"
edition: "Draft"
status: "Add-only implementation complete"
issuer: ai-kernel@aikernel.net
maintainer: "Takuya (AIKernel Project Maintainer)"
---

# Concept Elevation Refactoring TODO

## P0 Documentation Baseline

- [x] Add Canonical Language Dictionary.
- [x] Add Concept Elevation Refactoring Design.
- [x] Add Concept Elevation Guidelines.
- [x] Add v0.1.1.1 Migration Notes.
- [x] Add README links.
- [x] Add architecture index links if present.
- [x] Add guideline index links if present.

## P1 Canonical Language Dictionary

- [x] Define core concept vocabulary.
- [x] Define reserved vocabulary.
- [x] Include Japanese readings / furigana.
- [x] Include pronunciation hints.
- [x] Define forbidden naming examples.
- [x] Separate Core Concept and Reserved Vocabulary.

## P2 Concept Elevation Guidelines

- [x] Define Concept Elevation as more than rename.
- [x] Define allowed layers.
- [x] Define forbidden layers.
- [x] Define Concept Weight Rule.
- [x] Define CTG-ROM Safety Rule.
- [x] Define XML Documentation Rule.
- [x] Define Architecture Test Rule.

## P3 Migration Notes

- [x] Define add-only compatibility policy.
- [x] Define repository-by-repository plan.
- [x] Define CTG-ROM safety checklist.
- [x] Define migration phases.

## P4 README / Index Links

- [x] Link from README.md.
- [x] Link from docs/architecture/index.md.
- [x] Link from docs/guidelines/index.md.
- [x] Link from docs/migration/index.md if that index is later created.
- [x] Link from docs/todo/index.md if that index is later created.

## P5 Architecture Test Plan

- [x] Add architecture naming tests in AIKernel.Core.
- [x] Add architecture naming tests in AIKernel.Control.
- [x] Add architecture naming tests in AIKernel.Providers.
- [x] Add architecture naming tests in AIKernel.Wasm.
- [x] Add architecture naming tests in AIKernel.Doom.
- [x] Add architecture naming tests in AIKernel.Tools.
- [x] Ensure tests fail when philosophical prefixes appear on DTO / Request / Result / Mapper / Adapter / Serializer / Converter / HttpClient / JSInterop / NativeBridge / provider implementation classes.

## P6 Future Coding Phase

- [x] Add concept facade / wrappers in AIKernel.Core.
- [x] Add concept facade / wrappers in AIKernel.Control.
- [x] Add concept facade / wrappers in AIKernel.Providers.
- [x] Add concept facade / wrappers in AIKernel.Wasm.
- [x] Add concept facade / wrappers in AIKernel.Doom.
- [x] Add concept viewer names in AIKernel.Tools.
- [x] Add non-breaking Tools CLI aliases for `rom` / `nomos` and `clock` / `chronos` / `replay`.
- [x] Preserve old technical names as compatibility wrappers where needed.
- [x] Confirm CTG-ROM and canonical governance contracts remain unchanged before any code change.

## P7 Compatibility Review

- [x] Document Obsolete candidates without applying `[Obsolete]` attributes.
- [x] Keep compatibility exception names active in v0.1.1.1.
- [x] Record that aggressive rename/removal remains out of scope.
