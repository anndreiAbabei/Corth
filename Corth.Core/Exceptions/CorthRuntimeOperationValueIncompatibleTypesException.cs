using System.Diagnostics.CodeAnalysis;

namespace Corth.Core.Exceptions;

public class CorthRuntimeOperationValueIncompatibleTypesException : CorthException
{
    [SuppressMessage("ReSharper", "MemberCanBeProtected.Global")]
    public virtual string Type1 { get; }
    
    [SuppressMessage("ReSharper", "MemberCanBeProtected.Global")]
    public virtual string Type2 { get; }
        
    public override string Message => $"Type `{Type1}` is not compatible to be added with `{Type2}`";

    public CorthRuntimeOperationValueIncompatibleTypesException(string type1, string type2, int errorCode = ErrorCodes.RuntimeOperationValueIncompatibleTypes)
        : base(errorCode)
    {
        Type1 = type1;
        Type2 = type2;
    }
}