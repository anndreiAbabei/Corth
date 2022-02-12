namespace Corth.Core.Exceptions;

public class InvalidCorthTokenException : CorthException
{
    public virtual string Operation { get; }
        
    public override string Message => $"Invalid token `{Operation}`";

    public InvalidCorthTokenException(string operation)
        : this(operation, ErrorCodes.InvalidToken)
    {
        Operation = operation;
    }

    protected InvalidCorthTokenException(string operation, int errorCode)
        : base(errorCode)
    {
        Operation = operation;
    }
}



public class InvalidCorthLineTokenException : InvalidCorthTokenException
{
    public override string Message => $"Invalid line token `{Operation}`";

    public InvalidCorthLineTokenException(string operation)
        : this(operation, ErrorCodes.InvalidLineToken)
    {
    }

    protected InvalidCorthLineTokenException(string operation, int errorCode)
        : base(operation, errorCode)
    {
    }
}