# Zenodo Metadata

## Basic Information

- Resource type: Publication
- Publication type: Technical note
- Title: Prompt-State Machines: Applying Interface-Led Architecture to Structure LLM Reasoning
- Publication date: 2026-05-21
- Version: v1.0.0
- Language: English
- Additional language: Japanese
- Access right: Open Access
- License: Creative Commons Attribution 4.0 International (CC BY 4.0)
- DOI: 10.5281/zenodo.20323512
- Publisher: Zenodo
- Copyright: Copyright © 2026 Takuya Sogawa

## Creator

- Sogawa, Takuya
- ORCID: 0009-0009-7499-2595

## Description

This technical note defines Prompt-State Machines as a prompt-level application of Interface-Led Architecture (ILA) and the Provider-Observer-Operator abstraction discipline. It structures LLM reasoning as a sequence of Provider, Observer, Operator, Clarify, and FailClosed states.

The paper argues that structured Markdown or ROM-like prompts can act as practical state-boundary representations for LLMs. A Prompt-State Machine does not make LLM inference deterministic, but it can guide and constrain the model's output process by assigning explicit responsibilities and failure transitions. It also includes a Skill-Set Provider pattern as a practical example for declaring available reasoning capabilities in the Provider state.

This paper supplements the ILA methodology and the Provider-Observer-Operator abstraction discipline by applying them to prompt space. It also relates the model to AIKernel's SGP Pipeline and Semantic Runtime Theory while clarifying that Prompt-State Machines are prompt-level governance protocols, not runtime-enforced Governed Circuits.

The English manuscript is the canonical version. The Japanese manuscript is included as a companion translation.

## Keywords

AIKernel; Interface-Led Architecture; ILA; Prompt-State Machine; Provider; Observer; Operator; LLM Reasoning; Prompt Engineering; Markdown; ROM; Fail-Closed; Clarify; Governed Reasoning; Semantic Runtime

## Related Identifiers

- Cites: https://doi.org/10.5281/zenodo.20290614
- Cites: https://doi.org/10.5281/zenodo.20322690
- Cites: https://doi.org/10.5281/zenodo.20312092
- Is supplemented by: https://github.com/AIKernel-NET/AIKernel.NET
- Is supplemented by: https://aikernel.net/

## References

1. Sogawa, Takuya. "Interface-Led Architecture (ILA): A Software Development Methodology for the AI Era, Validated by the AIKernel Execution Model." Zenodo, 2026. DOI: 10.5281/zenodo.20290614.
2. Sogawa, Takuya. "Provider-Observer-Operator: A Role-Based Abstraction Discipline for Interface-Led Architecture." Zenodo, 2026. DOI: 10.5281/zenodo.20322690.
3. Sogawa, Takuya. "AIKernel Phase-2 Theory: Semantic Compilation Architecture." Zenodo, 2026. DOI: 10.5281/zenodo.20312092.
4. Harel, David. "Statecharts: A Visual Formalism for Complex Systems." Science of Computer Programming, vol. 8, no. 3, 1987, pp. 231-274. DOI: 10.1016/0167-6423(87)90035-9.
5. Wei, Jason, Xuezhi Wang, Dale Schuurmans, Maarten Bosma, Brian Ichter, Fei Xia, Ed Chi, Quoc Le, and Denny Zhou. "Chain-of-Thought Prompting Elicits Reasoning in Large Language Models." arXiv:2201.11903, 2022.
6. Yao, Shunyu, Jeffrey Zhao, Dian Yu, Nan Du, Izhak Shafran, Karthik Narasimhan, and Yuan Cao. "ReAct: Synergizing Reasoning and Acting in Language Models." International Conference on Learning Representations (ICLR), 2023.
7. CommonMark. "CommonMark: A Strongly Defined, Highly Compatible Specification of Markdown." CommonMark Specification. Available at: https://commonmark.org/.
