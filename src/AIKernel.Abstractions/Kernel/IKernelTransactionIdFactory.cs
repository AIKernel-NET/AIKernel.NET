namespace AIKernel.Abstractions.Kernel;

using AIKernel.Dtos.Kernel;

public interface IKernelTransactionIdFactory
{
    string CreateTransactionId(KernelRequest request);
}