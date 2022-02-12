namespace Corth.Core.Exceptions;

public class CorthRuntimeOperationInvalidTypeException : CorthException
{
    public virtual string Type { get; }
    public virtual string Operation { get; }
        
    public override string Message => $"Type `{Type}` does not support `{Operation}`";

    public CorthRuntimeOperationInvalidTypeException(string type, string operation)
        : this(type, operation, ErrorCodes.RuntimeOperationInvalidType)
    {
        
    }

    protected CorthRuntimeOperationInvalidTypeException(string type, string operation, int errorCode)
        : base(errorCode)
    {
        Type = type;
        Operation = operation;
    }
}