using System.Runtime.CompilerServices;
using Corth.Core.Exceptions;

namespace Corth.Core.Values;

public class BoolValue : CorthValue
{
    public override string Type => "bool";
    
    protected bool Value { get; }

    public static BoolValue True { get; } = new BoolValue(true);
    
    public static BoolValue False { get; } = new BoolValue(false);
    
    private BoolValue(bool value) => Value = value;

    public override CorthValue Add(CorthValue value) => InvalidOperation();

    public override CorthValue Subtract(CorthValue value) => InvalidOperation();

    public override CorthValue Multiply(CorthValue value) => InvalidOperation();

    public override CorthValue Divide(CorthValue value) => InvalidOperation();

    public override CorthValue IsEquals(CorthValue value)
    {
        return Value == value.ConvertValue<BoolValue>(Type).Value
            ? True
            : False;
    }

    public override CorthValue GreaterThan(CorthValue value) => InvalidOperation();

    public override CorthValue LessThan(CorthValue value) => InvalidOperation();
    
    public override string ToString() => Value.ToString();

    public override int GetHashCode() => Value.GetHashCode();

    public override bool Equals(object? obj) => obj is BoolValue bv && bv.Value == Value;
    
}