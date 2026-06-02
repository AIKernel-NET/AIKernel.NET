# Zenodo Metadata Draft

## Basic information

- Resource type: Publication
- Publication type: Technical note
- Title: Provider–Observer–Operator: A Role-Based Abstraction Discipline for Interface-Led Architecture
- Publication date: 2026-05-21
- Version: v1.0.0
- Language: English
- Additional language: Japanese
- Access right: Open Access
- License: Creative Commons Attribution 4.0 International (CC BY 4.0)
- DOI: 10.5281/zenodo.20322690
- Creator: Sogawa, Takuya
- ORCID: 0009-0009-7499-2595
- Copyright: Copyright © 2026 Takuya Sogawa

## Description

This technical note defines Provider–Observer–Operator as a role-based abstraction discipline for applying Interface-Led Architecture (ILA) to concrete software design and refactoring.

The paper classifies interface-bearing components into Provider, Observer, and Operator roles. It defines Units as governed compositions of roles and connects Units through Pipelines operating under Core Contracts. It also clarifies that exceptions are not roles, but failure states or transition results that occur when a Pipeline can no longer proceed under its Core Contract.

The paper supplements the existing Interface-Led Architecture methodology by defining how interfaces are extracted from software systems. Semantic IR, Composite Distance, Governed Circuits, and ReplayLog are treated not as general ILA concepts, but as AIKernel-specific specializations.

The English manuscript is the canonical version. The Japanese manuscript is included as a companion translation.

## Keywords

AIKernel; Interface-Led Architecture; ILA; Provider; Observer; Operator; Unit; Pipeline; Core Contract; Role-Based Abstraction; Software Architecture; Contract-First Design; Fail-Closed; Capability-Based Design

## Related identifiers

- Cites: https://doi.org/10.5281/zenodo.20290614
- Is supplemented by: https://github.com/AIKernel-NET/AIKernel.NET
- Is supplemented by: https://aikernel.net/

## References

1. Sogawa, Takuya. "Interface-Led Architecture (ILA): A Software Development Methodology for the AI Era, Validated by the AIKernel Execution Model." Zenodo, 2026. DOI: 10.5281/zenodo.20290614.
2. Gamma, Erich, Richard Helm, Ralph Johnson, and John Vlissides. *Design Patterns: Elements of Reusable Object-Oriented Software*. Addison-Wesley, 1994.
3. Bonér, Jonas, Dave Farley, Roland Kuhn, and Martin Thompson. "The Reactive Manifesto." 2014. Available at: https://www.reactivemanifesto.org/.
