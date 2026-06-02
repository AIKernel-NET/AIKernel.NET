# Review Notes

## Scope and positioning

This package revises the provided English and Japanese drafts of Paper 02, "VFS Architecture and Semantic Storage Model", into the same publication style used for Paper 01.

## Main revisions

- Adopted English as the canonical manuscript and Japanese as the companion translation.
- Integrated the AIKernel standard YAML header.
- Reflected the reserved DOI: 10.5281/zenodo.20307891.
- Aligned title, metadata, version, license, ORCID, and series position with Paper 01.
- Removed duplicated assistant-style text from the Japanese draft.
- Reframed overly strong claims such as "mathematically guarantees" into narrower architectural guarantees.
- Clarified the distinction between prohibited operations and non-routable operations.
- Added limitations around provider honesty, distributed consistency, and semantic path design.
- Reworked references for Paper 02 scope: capability systems, protection, OS design, ABAC/XACML, event sourcing, virtualization/replay, ILA, and Paper 01.
- Generated PDFs with section numbering controlled by the Markdown source only, avoiding duplicated numbering.
- Render-checked the PDFs for clipped titles, tables, formulas, and long code fragments.

## Reference and Scope Refinement

Updated after secondary review:

- Added DOI `10.1145/365230.365252` to Dennis and Van Horn.
- Added NIST SP 800-162 and OASIS XACML 3.0 as explicit references for PDP/PEP-layer access-control policy context.
- Preserved the boundary that VFS enforces coarse-grained type-level capability contracts, while fine-grained ABAC/XACML-style policy evaluation remains the responsibility of the higher-level governance layer.
- Updated Limitations to prevent the interpretation that VFS itself implements full dynamic attribute-based authorization.
