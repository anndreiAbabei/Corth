namespace Corth.Core.Exceptions;

public class CorthRuntimeInvalidLoopConstruction : CorthRuntimeInvalidIfConstruction
{
    public CorthRuntimeInvalidLoopConstruction(string message, int errorCode = ErrorCodes.RuntimeInvalidLoopConstruction)
        : base(message, errorCode)
    {
    }
}
