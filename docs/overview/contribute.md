---
title: "Contribute to AIKernel"
lang: en
description: "Report a reproducible problem, correct a guide, or propose a focused code change with evidence and the right review context."
source: "maintained-guide"
generated: false
release: "0.1.3"
documentation_target: "0.1.4"
updated: "2026-11-12"
---

# Contribute to AIKernel

You can contribute by reporting a procedure that fails, clarifying an explanation, or fixing a small defect. You do not need to begin with a new feature.

## Report a problem

Find the repository for the affected package or feature under [AIKernel-NET on GitHub](https://github.com/AIKernel-NET) and check its existing issues. If you are unsure where to report, [contact the project](/en/contact/) with the page or package name.

Include your OS, SDK and package versions, commands, expected result, actual result, and first error. Remove API keys and personal information from logs. Send security-sensitive reports by email rather than a public issue.

## Correct documentation

The site's guides are built from Markdown in the AIKernel.NET repository's `docs/` directory. Find the source corresponding to the page and explain prerequisites, steps, and expected results. Keep paired English and Japanese guides aligned.

When changing an example, record its version, verification environment, and output. Identify anything you could not verify. Follow the [documentation contribution instructions](../guidelines/DOCS_CONTRIBUTING.md).

## Propose a code change

Keep each pull request focused on one purpose. Track public interface, contract, and DTO changes in an issue, and describe compatibility effects and migration steps when necessary. Public API documentation needs English and Japanese explanations.

Follow the target repository's README and CI configuration to run the relevant build and tests. Describe the problem, the resulting behavior, and your validation in the PR. If AI assists with drafting, review the content and verify its correctness.

## Read the detailed rules

The [Contributing Guide](../CONTRIBUTING.md) covers PR and verification procedures. Consult the [detailed development guidelines](../guidelines/AIKERNEL_DEVELOPMENT_GUIDELINES.md) when changing public interfaces or execution responsibilities. Its “0.1.0” identifies the guideline edition, not the package version to install.
