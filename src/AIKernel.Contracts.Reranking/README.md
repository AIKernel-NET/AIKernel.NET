# AIKernel reranking contracts

`IRerankProvider.RerankAsync` takes one query and an ordered list of text candidates. Each scored item refers to the candidate's original zero-based index and has a null label. The result contains no input text. All candidates are scored before applying `TopK`, and ties follow input order.

`IRerankerProvider` adds provider lifecycle and placement metadata. Read the capability descriptor for model IDs, execution targets, input limits and the meaning of scores. This package shares the score types and error codes from `AIKernel.Contracts.ProviderPlacement`.
