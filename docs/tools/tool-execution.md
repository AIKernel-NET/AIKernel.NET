---
title: "Inspect the runtime with tools"
lang: en
description: "Install the AIKernel CLI and inspect runtime health, system information, available capabilities, and virtual files."
category: docs
source: "maintained-guide"
generated: false
release: "0.1.3"
documentation_target: "0.1.4"
updated: "2026-11-12"
---

# Inspect the runtime with tools

AIKernel.Tools provides CLI and inspection facilities. Use them to investigate visible capabilities and resources before changing the application's implementation.

## Install the CLI

The CLI is distributed as a .NET tool, rather than a normal in-process library. These commands are documented in the 0.1.3 Demo README:

```powershell
dotnet tool install -g AIKernel.Tools.CLI --version 0.1.3
aik runtime ping
aik system info
aik capabilities list
```

Installation requires the .NET SDK and access to the package source. If a version is already installed, check `dotnet tool list -g` first. These CLI instructions were checked against source documentation; they are separate from the console run verified in Quick Start.

## Interpret the results

Use `runtime ping` for a basic response, `system info` for visible configuration, and `capabilities list` for exposed operations. The available capabilities depend on the host and registrations; a fixed capability list is not a universal success condition.

To inspect a file root explicitly:

```powershell
aik system vfs --vfs-root .
```

Here `.` is the current directory. Choose a directory relevant to your investigation and avoid exposing unrelated secrets.

## Compare execution records

When examining replay records, compare inputs, provider selection, rules, and package versions. Differences in text alone do not explain differences in execution conditions.

See the [Tools README](https://github.com/AIKernel-NET/AIKernel.Tools/blob/main/README.md) for available inspection features and the [Demo README](https://github.com/AIKernel-NET/AIKernel.Demo/blob/8c960f57bdf6f431663a1ca33de7584f5e882140/README.md) for examples. Use [troubleshooting](../runtime/index.md) to investigate failures or [Core concepts](../concepts/index.md) to understand replay terminology.
