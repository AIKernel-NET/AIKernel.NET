# AIKernel image contracts

`IImageEditProvider` applies illustration styles and removes backgrounds. `IImageTaggingProvider` returns text tags about visible content. Both accept encoded PNG or JPEG bytes. The caller owns loading, saving, and job orchestration.

This interface-only package can be installed alongside the AIKernel 0.1.4 contracts. Applications obtain implementations from `AIKernel.Providers.Image` or provide their own.

`IImagePromptEditProvider` accepts an RGB24 reference, a text editing instruction, and a seed. Its output is RGB24 at the reference dimensions. A host can choose an implementation independently of the original image processing provider.
