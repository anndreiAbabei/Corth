namespace Corth.Core.Values;

public class StringValue : CorthValue
{
    private string Value { get; }

    public override string Type => "string";

    public StringValue(string value)
    {
        Value = value;
    }

    public override CorthValue Add(CorthValue value)
    {
        return new StringValue(Value + value.ConvertValue<StringValue>(Type).Value);
    }

    public override CorthValue Subtract(CorthValue value) => InvalidOperation();

    public override CorthValue Multiply(CorthValue value) => InvalidOperation();

    public override CorthValue Divide(CorthValue value) => InvalidOperation();

    public override CorthValue IsEquals(CorthValue value)
    {
        return Value == value.ConvertValue<StringValue>(Type).Value
                   ? BoolValue.True
                   : BoolValue.False;
    }

    public override CorthValue GreaterThan(CorthValue value) => InvalidOperation();

    public override CorthValue LessThan(CorthValue value) => InvalidOperation();

    public override string ToString() => Value;

    public override int GetHashCode() => Value.GetHashCode();

    public override bool Equals(object? obj) => obj is StringValue sv && sv.Value == Value;
}