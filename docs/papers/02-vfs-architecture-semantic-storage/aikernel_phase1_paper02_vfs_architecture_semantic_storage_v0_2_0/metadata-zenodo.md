# Zenodo Metadata Draft

## Title

AIKernel Phase-1 Paper 02: VFS Architecture and Semantic Storage Model: Virtual File System and Capability Abstraction for Deterministic AIOS Governance

## Resource Type

Publication

## Publication Type

Technical note

## Version

v0.2.0

## Publication Date

2026-05-24

## DOI

10.5281/zenodo.20307891

## Creator

Sogawa, Takuya  
ORCID: https://orcid.org/0009-0009-7499-2595

## Language

English

## Additional Language

Japanese

## License

Creative Commons Attribution 4.0 International (CC BY 4.0)

## Description

This technical note is Part I-2 of the AIKernel / AIOS Phase-1 specification series. It defines the VFS Architecture and Semantic Storage Model as the storage boundary for deterministic AI governance.

The paper introduces capability-bearing VFS interfaces, type-level truthfulness, non-routable transitions, bounded storage topology, and deterministic read-only projection for replay. Together, these mechanisms define how ROM documents, context snapshots, conversation histories, and replay artifacts are persisted and recovered without allowing storage side effects to escape governance.

The English manuscript is the canonical version. The Japanese manuscript is included as a companion translation.

## Keywords

AIKernel; AIOS; Virtual File System; VFS; Semantic Storage; Capability Contracts; Type-Level Truthfulness; Non-Routable Transition; Bounded Storage Topology; Deterministic Replay; Read-Only Projection; Audit-Grade Execution; Fail-Closed; Knowledge Substrate; AI Operating System

## Related Identifiers

- Cites: https://doi.org/10.5281/zenodo.20290614
- Cites: https://doi.org/10.5281/zenodo.20306539
- Is supplemented by: https://github.com/AIKernel-NET/AIKernel.NET
- Is supplemented by: https://aikernel.net/

## References

1. Dennis, Jack B., and Earl C. Van Horn. "Programming Semantics for Multiprogrammed Computations." Communications of the ACM, vol. 9, no. 3, 1966, pp. 143-155. DOI: 10.1145/365230.365252.
2. Lampson, Butler W. "Protection." Proceedings of the Fifth Annual Princeton Conference on Information Sciences and Systems, 1971, pp. 437-443.
3. Levy, Henry M. Capability-Based Computer Systems. Digital Press, 1984.
4. Tanenbaum, Andrew S., and Herbert Bos. Modern Operating Systems. 4th ed., Pearson, 2014.
5. Hu, Vincent C., David Ferraiolo, Rick Kuhn, Adam Schnitzer, Kenneth Sandlin, Robert Miller, and Karen Scarfone. Guide to Attribute Based Access Control (ABAC) Definition and Considerations. NIST Special Publication 800-162, 2014. DOI: 10.6028/NIST.SP.800-162.
6. OASIS. eXtensible Access Control Markup Language (XACML) Version 3.0. OASIS Standard, 22 January 2013.
7. Fowler, Martin. "Event Sourcing." martinfowler.com, 2005.
8. Chen, Peter M., and Brian D. Noble. "When Virtual Is Better Than Real." Proceedings of the 8th Workshop on Hot Topics in Operating Systems (HotOS VIII), 2001, pp. 133-138.
9. Sogawa, Takuya. "Interface-Led Architecture (ILA): A Software Development Methodology for the AI Era, Validated by the AIKernel Execution Model." Zenodo, 2026. DOI: 10.5281/zenodo.20290614.
10. Sogawa, Takuya. "AIKernel Phase-1 Paper 01: ROM Format and Knowledge Snapshot Model." Zenodo, 2026. DOI: 10.5281/zenodo.20306539.
