namespace Corth.Core.Exceptions;

public class CorthRuntimeStackInvalidSizeException : CorthException
{
    public virtual int ExpectedSize { get; }
    public virtual int ActualSize { get; }
        
    public override string Message => $"Stack expected size was {ExpectedSize}, but it's {ActualSize}";

    public CorthRuntimeStackInvalidSizeException(int expectedSize, int actualSize)
        : this(expectedSize, actualSize, ErrorCodes.RuntimeStackInvalidSize)
    {
        
    }

    protected CorthRuntimeStackInvalidSizeException(int expectedSize, int actualSize, int errorCode)
        : base(errorCode)
    {
        ExpectedSize = expectedSize;
        ActualSize = actualSize;
    }
}