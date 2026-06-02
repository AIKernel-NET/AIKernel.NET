namespace AIKernel.Abstractions.Kernel;

using AIKernel.Dtos.Kernel;

public interface IKernelRequestHasher
{
    string ComputeHash(KernelRequest request);
}