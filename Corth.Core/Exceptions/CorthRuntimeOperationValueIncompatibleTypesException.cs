namespace Corth.Core.Exceptions;

public class CorthRuntimeOperationValueIncompatibleTypesException : CorthException
{
    public virtual string Type1 { get; }
    public virtual string Type2 { get; }
        
    public override string Message => $"Type `{Type1}` is not compatible to be added with `{Type2}`";

    public CorthRuntimeOperationValueIncompatibleTypesException(string type1, string type2)
        : this(type1, type2, ErrorCodes.RuntimeOperationValueIncompatibleTypes)
    {
        
    }

    protected CorthRuntimeOperationValueIncompatibleTypesException(string type1, string type2, int errorCode)
        : base(errorCode)
    {
        Type1 = type1;
        Type2 = type2;
    }
}