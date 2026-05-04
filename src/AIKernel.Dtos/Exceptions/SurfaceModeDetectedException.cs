namespace AIKernel.Abstractions.Exceptions;

public class SurfaceModeDetectedException : Exception
{
    public SurfaceModeDetectedException(string message) : base(message) { }

    public SurfaceModeDetectedException(string message, Exception innerException)
        : base(message, innerException) { }
}
