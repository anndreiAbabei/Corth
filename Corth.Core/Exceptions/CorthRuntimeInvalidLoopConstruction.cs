namespace Corth.Core.Exceptions;

public class CorthRuntimeInvalidLoopConstruction : CorthRuntimeInvalidIfConstruction
{
    public CorthRuntimeInvalidLoopConstruction(string message)
        : this(message, ErrorCodes.RuntimeInvalidLoopConstruction)
    {
    }

    protected CorthRuntimeInvalidLoopConstruction(string message, int errorCode)
        : base(message, errorCode)
    {
    }
}
