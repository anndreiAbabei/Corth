using System.Diagnostics.CodeAnalysis;

namespace Corth.Core.Exceptions;

[SuppressMessage("ReSharper", "ClassWithVirtualMembersNeverInherited.Global")]
public class CorthRuntimeStackInvalidSizeException : CorthException
{
    [SuppressMessage("ReSharper", "MemberCanBeProtected.Global")]
    public virtual int ExpectedSize { get; }
    
    [SuppressMessage("ReSharper", "MemberCanBeProtected.Global")]
    public virtual int ActualSize { get; }

    public override string Message => $"Stack expected size was {ExpectedSize}, but it's {ActualSize}";

    public CorthRuntimeStackInvalidSizeException(int expectedSize, int actualSize, int errorCode = ErrorCodes.RuntimeStackInvalidSize)
        : base(errorCode)
    {
        ExpectedSize = expectedSize;
        ActualSize = actualSize;
    }
}