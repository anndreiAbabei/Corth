namespace Corth.Core.Exceptions;

public class CorthRuntimeInvalidIfConstruction : CorthException
{
    public CorthRuntimeInvalidIfConstruction(string message)
        : this(message, ErrorCodes.RuntimeInvalidIfConstruction)
    {
    }

    protected CorthRuntimeInvalidIfConstruction(string message, int errorCode)
        : base(message, errorCode)
    {
    }
}