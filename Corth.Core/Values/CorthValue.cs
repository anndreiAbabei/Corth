using System.Runtime.CompilerServices;
using Corth.Core.Exceptions;
using Corth.Core.Tokens;

namespace Corth.Core.Values;

public abstract class CorthValue
{
    public abstract string Type { get; }
    
    public abstract CorthValue Add(CorthValue value);
    public abstract CorthValue Subtract(CorthValue value);
    public abstract CorthValue Multiply(CorthValue value);
    public abstract CorthValue Divide(CorthValue value);

    internal TValue ConvertValue<TValue>(string expectedType) where
        TValue : CorthValue
    {
        return this is not TValue tv 
            ? throw new CorthRuntimeOperationValueIncompatibleTypesException(Type, expectedType) 
            : tv;
    }

    public abstract CorthValue IsEquals(CorthValue value);
    public abstract CorthValue GreaterThan(CorthValue value);
    public abstract CorthValue LessThan(CorthValue value);
    
    protected virtual CorthValue InvalidOperation([CallerMemberName] string operation = "") => throw new CorthRuntimeOperationInvalidTypeException(Type, operation);

}