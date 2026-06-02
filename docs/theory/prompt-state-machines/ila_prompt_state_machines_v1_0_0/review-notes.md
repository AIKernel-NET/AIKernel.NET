# Review Notes

## Editorial Process

1. Japanese draft was reviewed and revised before producing the English canonical version.
2. The English manuscript was not translated mechanically. It was rewritten as a Zenodo-ready technical note consistent with the AIKernel / ILA paper series.
3. The paper was positioned as ILA Supplement 2:
   - ILA: general interface-first methodology.
   - Provider-Observer-Operator: role-based abstraction discipline.
   - Prompt-State Machines: application of that discipline to prompt space.

## Key Revisions

- Added explicit contribution statement to the Abstract.
- Strengthened Section 2 to clarify that this paper does not extend general ILA theory and does not import AIKernel runtime specializations directly into prompt space.
- Reworked the SGP / Semantic Runtime correspondence table.
- Added Chain-of-Thought and ReAct as related prompting paradigms while clarifying that Prompt-State Machines are governance-oriented rather than performance-oriented.
- Added strong Non-Claims: prompt structure does not make LLM inference deterministic and is not equivalent to kernel-level enforcement.
- Added Section 10.1, "Skill-Set Provider Example," immediately after the minimal example.
- Section 10.1 makes the practical use of the Provider state more concrete by showing how to declare prompt-level skills, required inputs, forbidden assumptions, output contracts, and fallback transitions.
- Clarified that a prompt-level skill set is not an AIKernel Core Contract; it makes assumed reasoning resources visible, inspectable, and governable at the prompt level.

## Reference Rationale

- ILA paper: primary methodological foundation.
- Provider-Observer-Operator paper: direct abstraction discipline this paper applies.
- Semantic Compilation Architecture: related AIKernel theory for semantic runtime and governed reasoning.
- Harel statecharts: classical basis for state-oriented system specification.
- Chain-of-Thought: prior work on prompting intermediate reasoning steps.
- ReAct: prior work on interleaving reasoning, acting, and observation in language models.
- CommonMark: reference for Markdown as a structured textual representation.


## Final Review Pass: Practical Example Positioning

- Added an Abstract/Introduction preview of the Skill-Set Provider pattern so the practical example is not introduced abruptly.
- Clarified that Skill-Set Provider is a specialization of the general Prompt-State Machine structure, not a new ILA primitive.
- Added a conclusion hook for future experimental evaluation across multiple models.
