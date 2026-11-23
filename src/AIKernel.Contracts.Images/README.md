# AIKernel image contracts

`IImageEditProvider` applies illustration styles and removes backgrounds. `IImageTaggingProvider` returns text tags about visible content. Both accept encoded PNG or JPEG bytes. The caller owns loading, saving, and job orchestration.

This interface-only package can be installed alongside the AIKernel 0.1.4 contracts. Applications obtain implementations from `AIKernel.Providers.Image` or provide their own.
