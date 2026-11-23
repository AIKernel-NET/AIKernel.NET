# AIKernel embedding contracts

`IEmbeddingRequestProvider` accepts an ordered batch of typed inputs. Ask the provider's capability descriptor for the available modalities, models, limits and output formats. The result uses zero-based input indices and reports the resolved model and options.

The original 0.1.4 text embedding interfaces remain available. `IMultimodalEmbeddingProvider` composes the old interfaces, the request interface and placement metadata. Capability declarations describe what a particular registered model can do.
