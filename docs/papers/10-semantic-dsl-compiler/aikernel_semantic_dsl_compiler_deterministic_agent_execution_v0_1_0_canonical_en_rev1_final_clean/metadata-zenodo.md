
# Zenodo Metadata

## Title

AIKernel Semantic DSL Compiler and Deterministic Agent Execution Architecture

## Subtitle

Compiling AI-Generated Plans into Governed Pipelines with Semantic IR, ReplayLogs, and Fail-Closed Control

## DOI

https://doi.org/10.5281/zenodo.20534341

## Version

v0.1.0-rev1

## Publication Date

2026-06-04

## Resource Type

Publication

## Publication Type

Technical note

## Creators

- Sogawa, Takuya  
  ORCID: 0009-0009-7499-2595  
  Affiliation: AIKernel Project

## Language

English

## Additional Language

Japanese

## License

Creative Commons Attribution 4.0 International (CC BY 4.0)

## Description

This technical note introduces the AIKernel Semantic DSL Compiler, an OS-level mechanism for governing probabilistic LLM-generated plans through deterministic compilation rather than direct execution. The compilation path is Semantic IR -> Admissibility Checking -> Governed Pipeline -> ResultStep / SemanticDelta -> hash-linked ReplayLog. The model treats an LLM-generated plan as structured intent rather than executable source code, and it explicitly defines non-Turing-complete DSL semantics, formal admissibility conditions, bounded loop and suspend/resume behavior, and validation cases for deterministic replay.

The English manuscript is the canonical version. The Japanese manuscript is included as a companion translation.

## Keywords

AIKernel; Semantic DSL; Semantic IR; Deterministic Agent Execution; Governed Pipeline; ReplayLog; Fail-Closed Governance; Capability Resolution; Semantic Compiler; C#; LINQ; Result Monad; Autonomous AI Agents; Phase-2.5

## Files

- paper-en.pdf
- paper-ja.pdf
- paper-en.md
- paper-ja.md
- metadata-zenodo.md
- review-notes.md
- CITATION.cff
- .zenodo.json
- CHECKSUMS.txt
