# AIKernel.NET Release Notes

[日本語](RELEASE_NOTES-ja.md)

## 0.1.4 (release candidate in development)

- Imported Cosmos 3 Edge and Nano checkpoints generate text from text, RGB images and timestamped video frames on CPU. The runtime requires neither CUDA nor LibTorch. Multi-turn generation preserves each speaker and earlier attachments.
- Monolith can register either local reasoner with a pinned SHA-256 import manifest. The bilingual website chat checks availability and accepts follow-up questions about the same image without a visitor API key.
- GPT-OSS-20B ran with SSD paging under the Server's 7 GB physical-memory budget. Its generated tokens matched llama.cpp on the two validation prompts. Cosmos has separate model and input memory requirements.
- CTG evaluation with Bonsai 1.7B separates a proposal from the observations supporting it and applies the governance ROM. Its acceptance results cover the evaluated cases.
- CPU is the standard distribution. Supported GPUs can use the optional CUDA Driver path. The legacy LibTorch add-on stays at 0.1.3.

## 0.1.3

- Publish the GPU vocabulary through the contract packages: provider and pass interfaces, frame/target DTOs, capability flags, canonical diagnostics, and shared validation. The contract packages do not include a GPU runtime.
- Keep raw framebuffer input separate from HUD and display targets. Validate layouts, capabilities, and diagnostics at the provider/bridge boundary.
- See the [GPU migration guide](docs/migration/v0.1.3-gpu-canonical-migration.md) and the [release alignment guide](docs/development/package-release-alignment-v0.1.3.md) for migration and local verification.

## 0.1.2

**June 16th, 2026 - Canonical interface line.**

AIKernel.NET 0.1.2 is the canonical contract package line for the AIKernel Semantic OS family.

- Publish the synchronized contract packages: `AIKernel.Abstractions`, `AIKernel.Contracts`, `AIKernel.Dtos`, and `AIKernel.Enums`.
- Align public documentation, package installation guidance, and migration notes with the 0.1.2 package family.
- Keep historical CTG and v0.1.1.1 documents available as migration references while making 0.1.2 the active public line.
- Support downstream Core, Control, Providers, CUDA, Wasm, and Tools packages through the 0.1.2 dependency chain.
