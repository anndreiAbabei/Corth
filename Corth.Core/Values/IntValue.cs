using System;

namespace Corth.Core.Values;

public class IntValue : CorthValue
{
    private int Value { get; }

    public override string Type => "int";

    public IntValue(int value)
    {
        Value = value;
    }

    public override CorthValue Add(CorthValue value)
    {
        return Perform(value, (a, b) => a + b);
    }

    public override CorthValue Subtract(CorthValue value)
    {
        return Perform(value, (a, b) => a - b);
    }

    public override CorthValue Multiply(CorthValue value)
    {
        return Perform(value, (a, b) => a * b);
    }

    public override CorthValue Divide(CorthValue value)
    {
        return Perform(value, (a, b) => a / b);
    }

    public override CorthValue IsEquals(CorthValue value)
    {
        return Perform(value, (a, b) => a == b);
    }

    public override CorthValue GreaterThan(CorthValue value)
    {
        return Perform(value, (a, b) => a > b);
    }

    public override CorthValue LessThan(CorthValue value)
    {
        return Perform(value, (a, b) => a < b);
    }

    private CorthValue Perform(CorthValue value, Func<int, int, int> operation)
    {
        return new IntValue(operation(Value, value.ConvertValue<IntValue>(Type).Value));
    }

    private CorthValue Perform(CorthValue value, Func<int, int, bool> operation)
    {
        return operation(Value, value.ConvertValue<IntValue>(Type).Value)
                   ? BoolValue.True
                   : BoolValue.False;
    }

    public override string ToString() => Value.ToString();

    public override int GetHashCode() => Value.GetHashCode();

    public override bool Equals(object? obj) => obj is IntValue iv && iv.Value == Value;
}