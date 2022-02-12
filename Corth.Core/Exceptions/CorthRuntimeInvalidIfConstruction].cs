namespace Corth.Core.Exceptions;

public class CorthRuntimeInvalidIfConstruction : CorthException
{
    public CorthRuntimeInvalidIfConstruction(string message, int errorCode = ErrorCodes.RuntimeInvalidIfConstruction)
        : base(message, errorCode)
    {
    }
}