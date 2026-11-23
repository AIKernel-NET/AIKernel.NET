# AIKernel image contracts

`IImageEditProvider` applies illustration styles and removes backgrounds. `IImageTaggingProvider` returns text tags about visible content. Both accept encoded PNG or JPEG bytes. The caller owns loading, saving, and job orchestration.

`ImageStylizationOptions` sets the effect strength from zero to one. Zero preserves the source pixels, and one matches the original overload. Use the overload that accepts options and a cancellation token for an explicit strength. An older provider implementation rejects strengths other than one.

This interface-only package can be installed alongside the AIKernel 0.1.4 contracts. Applications obtain implementations from `AIKernel.Providers.Image` or provide their own.

`IImagePromptEditProvider` accepts an RGB24 reference, a text editing instruction, and a seed. Its output is RGB24 at the reference dimensions. A host can choose an implementation independently of the original image processing provider.
