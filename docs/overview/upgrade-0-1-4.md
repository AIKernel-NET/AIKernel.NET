---
title: "Moving from 0.1.3 to 0.1.4"
lang: en
description: "Choose a model and runtime for an existing application, then verify a first Cosmos reply and its audit record on a local host."
category: docs
source: "maintained-guide"
generated: false
documentation_target: "0.1.4"
updated: "2026-11-20"
---

# Moving from 0.1.3 to 0.1.4

Version 0.1.4 is in preparation. Before updating an existing application, record its 0.1.3 package versions, model, input and expected output so you can repeat the same check. New users can use the [0.1.3 walkthrough](quick-start.md) to check their .NET setup before downloading weights.

## Choose what you want to run

| Task | What to use in 0.1.4 | What to prepare |
| --- | --- | --- |
| Ask about an image or video | Cosmos 3 Edge and Nano read text, RGB images and timestamped frames and reply in text. Edge has the smaller weight set for a first run. | Imported reasoner weights and their manifest. Both models run on CPU. |
| Generate text locally | Bonsai 1.7B or 4B, or Gemma 4 E2B. Gemma also supports a full forward pass resident on an NVIDIA GPU. | A supported GGUF for your chosen model. The CUDA path needs the corresponding driver and native library. |
| Use a model larger than available RAM | The GPT-OSS-20B CPU host uses AIKernel virtual memory to read weights from SSD on demand. | Compatible weights, SSD space and a host memory budget. |
| Decide whether to execute an operation | Bonsai 1.7B evaluates the proposed operation separately from the observations the host collected. | Host authorization and the three hash-pinned rules from `rom/governance`.  Ordinary chat uses the registration votes. For a council assessment per operation, see the [host integration](inference-api-0-1-4.md#bonsaictgcouncilevaluator). |

When the release is available, update the contracts and Core to the same release line in a test project first. If your application uses the legacy LibTorch add-on, keep its 0.1.3 configuration for comparison and test a move to the CUDA Driver path separately. [Package responsibilities](../architecture/module-map.md) · [Accelerator support](https://github.com/AIKernel-NET/AIKernel.Core/blob/dev/docs/inference-accelerators-0.1.4.md)

## Check your first Cosmos reply

Use sibling development checkouts of Core, Providers and Monolith and the .NET 10.0.404 SDK feature band. Follow the [Monolith startup commands](https://github.com/AIKernel-NET/AIKernel.Monolith/blob/dev/README.md#run-the-monolith) to create the four directories, import Edge into `models/edge` and install the [example registration](https://github.com/AIKernel-NET/AIKernel.Monolith/blob/dev/samples/cosmos-edge.json) as `models/cosmos-edge.json`. The installer verifies the known manifest content and pins its on-disk digest. Use the registration ID `cosmos-edge` below. [Checkpoint tools and disk requirements](https://github.com/AIKernel-NET/AIKernel.Core/blob/dev/docs/cosmos3-inference-en.md)

With the host listening on `127.0.0.1:8080`, set the client's `AIKERNEL_API_KEY` to the host's bearer token and check admission.

```bash
curl --fail-with-body -H "Authorization: Bearer $AIKERNEL_API_KEY" \
  'http://127.0.0.1:8080/v1/models/admission?model=cosmos-edge'
```

If `admissible` is `true`, send a question using the same registration ID. The first generation also verifies and loads the weights.

```bash
curl --fail-with-body -H "Authorization: Bearer $AIKERNEL_API_KEY" \
  -H 'Content-Type: application/json' \
  -d '{"model":"cosmos-edge","messages":[{"role":"system","content":"You are helpful."},{"role":"user","content":"What is 2 + 2? Answer briefly."}]}' \
  http://127.0.0.1:8080/v1/chat/completions
```

For this input, the reference answer in `choices[0].message.content` is `4` and `choices[0].finish_reason` is `stop`. For HTTP 401, check the host token. If admission fails, check the registration ID, model directory, manifest and tokenizer files first.

## Running within 7 GB

The Server comparison used four workers, `maximumResidentBytes=7000000000`, `weightCacheBytes=3221225472` (3 GiB) and `kvCacheBytes=128000000` (128 MB). Generated tokens matched the reference in six cases, with a peak RSS of 3.564 GB. Reducing KV to 8 MiB increased total SSD writes across those cases from 84 KiB to 18.09 GB. When reducing memory allowances, check both peak RSS and bytes written with representative inputs. [Inputs, conditions and results (Japanese)](https://github.com/AIKernel-NET/AIKernel.Core/blob/dev/docs/development/evidence/cosmos3-server-7gb-20261120/README.md)

For a slow first response, start with `model_load_ms` and `prefill_ms` in the private audit log. The former includes weight verification and the latter measures prompt processing. On Windows Native AOT, enabling `cosmos.profilePrefill` also records the executable's BF16 dot kernel and projection time. The full-model speed comparison between portable and AVX2 builds is pending. [Audit fields and measurement procedure](https://github.com/AIKernel-NET/AIKernel.Monolith/blob/dev/README.md)
