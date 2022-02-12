using System.Diagnostics.CodeAnalysis;

namespace Corth.Core.Exceptions;

public class CorthRuntimeOperationInvalidTypeException : CorthException
{
    [SuppressMessage("ReSharper", "MemberCanBeProtected.Global")]
    public virtual string Type { get; }
    
    [SuppressMessage("ReSharper", "MemberCanBeProtected.Global")]
    public virtual string Operation { get; }

    public override string Message => $"Type `{Type}` does not support `{Operation}`";

    public CorthRuntimeOperationInvalidTypeException(string type, string operation, int errorCode = ErrorCodes.RuntimeOperationInvalidType)
        : base(errorCode)
    {
        Type = type;
        Operation = operation;
    }
}