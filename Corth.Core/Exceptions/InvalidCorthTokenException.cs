using System.Diagnostics.CodeAnalysis;

namespace Corth.Core.Exceptions;

public class InvalidCorthTokenException : CorthException
{
    [SuppressMessage("ReSharper", "MemberCanBeProtected.Global")]
    public string Operation { get; }
        
    public override string Message => $"Invalid token `{Operation}`";

    public InvalidCorthTokenException(string operation, int errorCode = ErrorCodes.InvalidToken)
        : base(errorCode)
    {
        Operation = operation;
    }
}



public class InvalidCorthLineTokenException : InvalidCorthTokenException
{
    public override string Message => $"Invalid line token `{Operation}`";

    public InvalidCorthLineTokenException(string operation, int errorCode = ErrorCodes.InvalidLineToken)
        : base(operation, errorCode)
    {
    }
}