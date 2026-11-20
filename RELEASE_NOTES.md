# AIKernel.NET Release Notes

[日本語](RELEASE_NOTES-ja.md)

## 0.1.4 (release candidate in development)

For an existing 0.1.3 application, start with the [model selection and first-reply checks](docs/overview/upgrade-0-1-4.md). For direct SDK integration, see the [Cosmos, Gemma and Bonsai CTG API examples](docs/overview/inference-api-0-1-4.md).

- Imported Cosmos 3 Edge and Nano checkpoints generate text from text, RGB images and timestamped video frames on CPU. The runtime requires neither CUDA nor LibTorch. Multi-turn generation preserves each speaker and earlier attachments.
- Monolith can register either local reasoner with a pinned SHA-256 import manifest. The bilingual website chat checks availability and accepts follow-up questions about the same image without a visitor API key.
- Cosmos registrations and the local chat launcher accept process, weight-cache and KV-cache budgets. The private host audit records weight backing reads and KV swap reads per request. Admission detects missing tokenizers and preprocessing files. Monolith reports its build version at `/health`.
- Cosmos 3 Edge and Nano ran with four CPU workers under a 7 GB model-host limit. Replies and generated token IDs matched the reference in all six text, image and video cases. Peak host RSS was 3.564 GB with the default 128 MB KV cache. Across the six requests the host wrote 84 KiB to SSD at that setting and 18.09 GB with an 8 MiB KV cache. [Development-machine comparison and test conditions (Japanese)](https://github.com/AIKernel-NET/AIKernel.Core/blob/c502bfda7017779783809507b18e3929ad5b6e52/docs/development/evidence/cosmos3-server-7gb-20261120/README.md)
- GPT-OSS-20B ran with SSD paging under the Server's 7 GB physical-memory budget. Its generated tokens matched llama.cpp on the two validation prompts.
- Gemma 4 E2B supports text generation on CPU and a resident forward pass with weights and KV on supported NVIDIA GPUs. [Supported GGUF and numerical checks (Japanese)](https://github.com/AIKernel-NET/AIKernel.Core/blob/dev/docs/gemma4-e2b-inference.md)
- Bonsai 1.7B evaluates a proposed operation separately from host observations using the governance ROM. Across 16 newly evaluated Server cases and 60 replayed cases, all 30 expected approvals and 46 expected denials matched. [Operating guide and evaluation breakdown (Japanese)](https://github.com/AIKernel-NET/AIKernel.Core/blob/dev/docs/development/bonsai-ctg-operations-jp.md)
- Cosmos prefill reuses weight pages across tiles of up to 32 input tokens when the weights exceed the cache. The private host audit reports model load, prefill and decode time separately. [Memory settings and diagnostics (Japanese)](https://github.com/AIKernel-NET/AIKernel.Core/blob/dev/docs/cosmos3-inference.md)
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
