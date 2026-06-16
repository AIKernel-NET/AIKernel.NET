---
id: contributing
title: "AIKernel Contributing Guide"
scope:
  - repo: AIKernel.NET
createdAt: 2026-04-28T00:00:00Z
updated: 2026-06-14
published: 2026-05-16
version: "0.1.1.1"
edition: "Draft"
status: "Refactor"
issuer: ai-kernel@aikernel.net
maintainer: "Takuya (AIKernel Project Maintainer)"
signature: ""
---

# CONTRIBUTING

---

## Introduction
AIKernel.NET is a **Contract-Driven AI Runtime** and aims to be a production-grade AI OS. This repository targets **.NET 10 / C# 14**. This CONTRIBUTING guide explains repository structure, PR rules, CI expectations, and best practices for contributors.

The canonical contributor-facing development discipline is defined in
[`guidelines/AIKERNEL_DEVELOPMENT_GUIDELINES.md`](guidelines/AIKERNEL_DEVELOPMENT_GUIDELINES.md)
and
[`guidelines/AIKERNEL_DEVELOPMENT_GUIDELINES-jp.md`](guidelines/AIKERNEL_DEVELOPMENT_GUIDELINES-jp.md).
That guideline is normative for Interface Led Architecture, Provider-Observer-Operator
responsibility boundaries, DAG execution, fail-closed monads, versioning, testing,
documentation, and governance. This CONTRIBUTING guide is the short operational
entry point; the detailed guideline takes precedence when reviewing architecture
or implementation choices.

---

## Environment
- **Runtime**: .NET 10
- **Language**: C# 14
- **Repository layout**: `src/`, `tests/`, `samples/`, `docs/`, `tools/`
CI runs build and tests to ensure baseline quality.

---

## Pull Request Guidelines

### 1. One logical change per PR
- Keep PRs focused on a single logical change.
- Avoid mixing unrelated changes in one PR.

### 2. Contract/interface/DTO changes require an Issue
- Changes to public contracts must be tracked with an Issue.
- Breaking changes must be documented and accompanied by migration guidance.

### 3. Use of AI tools in authoring PRs
- Using AI tools (ChatGPT, Copilot, Claude) to draft text is allowed.
- When AI is used, ensure human review and correctness.
- Do not rely on AI to replace domain expertise; reviewers must validate AI-generated content.

### 4. PR size guidance
- Prefer PRs under ~200 lines when practical.
- Large changes should be split into smaller PRs.

### 5. XML documentation
- Public APIs must include bilingual XML docs (`/// <summary>`, parameter descriptions, type parameter descriptions, and return descriptions).
- Inline XML docs use explicit `EN:` and `JA:` text. Existing external docs must use paired `docs.en.xml` and `docs.ja.xml` includes.
- Follow [`operations/XML_DOCUMENTATION_POLICY-v0.1.1.1.md`](operations/XML_DOCUMENTATION_POLICY-v0.1.1.1.md).
- Run `py tools\check_bilingual_xml_docs.py src` before opening a release PR.
- Keep docs up to date and reflect in `docs/` and README.

### 6. Mark breaking changes
- Prefix PR titles with **[Breaking]** when applicable.
- Example: `[Breaking] Modify RetrievalQuery structure`
- Create an Issue to explain the breaking change and migration plan.

### 7. CTG contract changes
- CTG changes must remain contract-only: interfaces, DTO records, and enums.
- Follow [`operations/CTG_DEVELOPER_GUIDE-v0.1.1.1.md`](operations/CTG_DEVELOPER_GUIDE-v0.1.1.1.md).
- Do not add canon rule bodies or runtime behavior to AIKernel.NET.

### 8. APM and package management
- AIKernel.NET uses an APM (Agent Package Manager) for skills, prompts, agents, hooks, MCP servers.
- Add new artifacts via Issue and follow repository packaging conventions.

### 9. Link Issues and PRs
- Link PRs to the related Issue when applicable.
- Avoid closing Issues without explicit resolution.

---

## Repository layout and branch strategy

### Key directories
- `src/` — source projects
- `tests/` — test projects
- `samples/` — sample apps and integration examples
- `docs/` — documentation and guidelines
- `tools/` — developer tools

### Branch naming
- Use `feature/<name>`, `fix/<name>`, `chore/<name>`
- Keep branches focused and CI-friendly

### CI expectations
- CI runs `dotnet test`
- Ensure tests pass before merging
- Include integration tests for critical changes

### Tooling
- Use EditorConfig
- Use Roslyn analyzers
- Use `dotnet format` in CI to enforce formatting

---

## PR checklist
- Keep PRs focused
- Create Issues for contract/interface/DTO changes
- Mark breaking changes with `[Breaking]`
- Provide XML docs for public APIs
- Confirm bilingual XML documentation for public APIs
- Run the bilingual XML documentation checker
- Confirm semantic interface naming and avoid mechanical expansion suffixes
- Confirm enum `Unknown = 0` and fail-closed handling guidance when adding enums
- Confirm CTG changes follow `operations/CTG_DEVELOPER_GUIDE-v0.1.1.1.md` when applicable
- Confirm compliance with `guidelines/AIKERNEL_DEVELOPMENT_GUIDELINES.md`
  or `guidelines/AIKERNEL_DEVELOPMENT_GUIDELINES-jp.md`
- Ensure CI passes
- If AI was used to generate content, note it and ensure human validation

---

## Review culture
- Provide constructive, respectful reviews
- Aim for clarity and maintainability
- Encourage contributors and help them improve submissions

---

## Release process
- Follow semantic versioning for packages
- Document breaking changes and migration steps
- Maintain compatibility where possible

---

## Closing
AIKernel targets **.NET 10 / C# 14** and aims to be a production-grade contract-driven AI runtime. Follow these guidelines to contribute effectively.
---

# Changelog
- v0.0.0 / v0.0.0.0: Initial draft
- v0.0.1 (2026-05-06): Version upgrade aligned with documentation guidelines
- v0.1.1.1 (2026-06-14): Added bilingual XML documentation, semantic interface naming, enum handling policy, and CTG developer guide references
