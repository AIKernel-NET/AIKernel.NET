---
title: "Creating Tools"
lang: ja
description: "Tool package を追加するときの source layout、commands、tests、Reference 更新を説明します。"
tags: [AIKernel, AIKernel.NET, v0.1.3]
category: docs
source: "generated-from-repository-inventory"
generated: true
release: "0.1.3"
updated: "2026-06-17"
---
# Creating Tools

## 概要

Creating Tools は 0.1.3 の repository metadata、package metadata、既存 docs を根拠に説明します。

## 背景

この guide page は explanatory material と generated Reference を分離し、低品質な API dump page になることを避けます。

## 使い方

package table で実装または wrapper package を探し、正確な API member は Reference で確認します。

## 例

### Related packages

| Package | Kind | Version | Description | Source |
|---|---|---|---|---|
| [`AIKernel.Tools.Capability.RomStorage`](/reference/aikernel-tools/aikernel-tools-capability-romstorage/) | nuget | `0.1.3` | AIKernel.Tools.Capability.RomStorage package metadata is defined in AIKernel.Tools/src/AIKernel.Tools.Capability.RomStorage/AIKernel.Tools.Capability.RomStor... | `AIKernel.Tools/src/AIKernel.Tools.Capability.RomStorage/AIKernel.Tools.Capability.RomStorage.csproj` |
| [`AIKernel.Tools.CLI`](/reference/aikernel-tools/aikernel-tools-cli/) | nuget | `0.1.3` | AIKernel.Tools.CLI package metadata is defined in AIKernel.Tools/src/AIKernel.CLI/AIKernel.CLI.csproj. | `AIKernel.Tools/src/AIKernel.CLI/AIKernel.CLI.csproj` |
| [`AIKernel.Tools.Inspectors.ChatHistoryScraper`](/reference/aikernel-tools/aikernel-tools-inspectors-chathistoryscraper/) | nuget | `0.1.3` | AIKernel.Tools.Inspectors.ChatHistoryScraper package metadata is defined in AIKernel.Tools/src/AIKernel.Tools.Inspectors.ChatHistoryScraper/AIKernel.Tools.In... | `AIKernel.Tools/src/AIKernel.Tools.Inspectors.ChatHistoryScraper/AIKernel.Tools.Inspectors.ChatHistoryScraper.csproj` |
| [`AIKernel.Tools.Inspectors.KernelClock`](/reference/aikernel-tools/aikernel-tools-inspectors-kernelclock/) | nuget | `0.1.3` | AIKernel.Tools.Inspectors.KernelClock package metadata is defined in AIKernel.Tools/src/AIKernel.Tools.Inspectors.KernelClock/AIKernel.Tools.Inspectors.Kerne... | `AIKernel.Tools/src/AIKernel.Tools.Inspectors.KernelClock/AIKernel.Tools.Inspectors.KernelClock.csproj` |
| [`AIKernel.Tools.Inspectors.Vfs`](/reference/aikernel-tools/aikernel-tools-inspectors-vfs/) | nuget | `0.1.3` | AIKernel.Tools.Inspectors.Vfs package metadata is defined in AIKernel.Tools/src/AIKernel.Tools.Inspectors.Vfs/AIKernel.Tools.Inspectors.Vfs.csproj. | `AIKernel.Tools/src/AIKernel.Tools.Inspectors.Vfs/AIKernel.Tools.Inspectors.Vfs.csproj` |
| [`AIKernel.Tools.Instrumentation`](/reference/aikernel-tools/aikernel-tools-instrumentation/) | nuget | `0.1.3` | AIKernel.Tools.Instrumentation package metadata is defined in AIKernel.Tools/src/AIKernel.Tools.Instrumentation/AIKernel.Tools.Instrumentation.csproj. | `AIKernel.Tools/src/AIKernel.Tools.Instrumentation/AIKernel.Tools.Instrumentation.csproj` |
| [`aikernel-tools`](/reference/aikernel-tools/python/aikernel-tools/) | python | `0.1.3` | Python wrapper for AIKernel.Tools v0.1.3 instrumentation contracts with bundled managed assemblies and pythonnet loading. | `AIKernel.Tools/python/pyproject.toml` |

## 補足

- Examples are limited to package and command shapes confirmed in repository metadata.
- For behavior details, inspect the linked source path and tests.
- If a runtime asset is hosted outside the source repository, the page treats it as deployment configuration rather than source behavior.

## 関連ページ

- [Architecture](../architecture/index.md)
- [Reference](/reference/)
- [Generation Report](../docs-generation-report.md)
