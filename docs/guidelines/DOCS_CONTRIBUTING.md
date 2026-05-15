---
updated: 2026-05-16
published: 2026-05-16
version: "0.0.2"
edition: "Draft"
status: "Refactor"
issuer: ai-kernel@aikernel.net
maintainer: "Takuya (AIKernel Project Maintainer)"
---

# Purpose
This guide defines procedures and quality checks for creating and updating AIKernel project documentation.

# Required Front Matter
Each document must include the following front matter:
- title
- description
- lang
- last_updated
- owners

# PR Rules
- All documentation changes must be made via PR.
- At least one approval from an `owners` member is required.
- For significant design changes, obtain additional architect approval.

# CI Checks (on PR)
- Markdown lint (style)
- Link checks (internal/external)
- Static site build (Docusaurus/MkDocs, etc.)
- Translation status check (pages requiring both English and Japanese should be flagged if untranslated)

# Template (recommended headings)
1. Purpose (Why)
2. Scope
3. Specification / Procedure (What / How)
4. References
5. Changelog
6. Owners

# Translation Operations
- Important pages should have both English and Japanese versions.
- Manage translations in a separate branch and record translation status in `AIKernel.Docs/translations_status.md`.

# Author Checklist (for PR creators)
- [ ] Front matter is correct
- [ ] Purpose and scope are clearly written
- [ ] Code examples are minimal and runnable
- [ ] Internal and external links are valid
- [ ] Images have alt text and license info
- [ ] Assigned reviewers to obtain `owners` approval

# Changelog
- 2026-05-01 Initial version
- v0.0.1 (2026-05-06): Version upgrade aligned with documentation guidelines

