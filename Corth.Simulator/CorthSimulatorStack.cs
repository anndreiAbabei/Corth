using Corth.Core;
using Corth.Core.Exceptions;
using Corth.Core.Values;
using Microsoft.Extensions.Logging;

namespace Corth.Simulator;

public class CorthSimulatorStack : ICorthStack
{
    private readonly Stack<CorthValue> _stack;

    public CorthSimulatorStack()
    {
        _stack = new Stack<CorthValue>();
    }
    
    public void Dump()
    {
        EnsureStackSize(1);
        
        var value = _stack.Pop();
        
        Console.Write(value.ToString());
    }

    public void Push(int value)
    {
        _stack.Push(new IntValue(value));
    }

    public void Push(string value)
    {
        _stack.Push(new StringValue(value));
    }

    public void Push(bool value)
    {
        _stack.Push(value ? BoolValue.True : BoolValue.False);
    }

    public void Add()
    {
        EnsureStackSize(2);
        
        var value1 = _stack.Pop();
        var value2 = _stack.Pop();

        var val = value1.Add(value2);
        
        _stack.Push(val);
    }

    public void Subtract()
    {
        EnsureStackSize(2);
        
        var value1 = _stack.Pop();
        var value2 = _stack.Pop();

        var val = value1.Subtract(value2);
        
        _stack.Push(val);
    }

    public void Multiply()
    {
        EnsureStackSize(2);
        
        var value1 = _stack.Pop();
        var value2 = _stack.Pop();

        var val = value1.Multiply(value2);
        
        _stack.Push(val);
    }

    public void Divide()
    {
        EnsureStackSize(2);

        var value1 = _stack.Pop();
        var value2 = _stack.Pop();

        var val = value1.Divide(value2);
        
        _stack.Push(val);
    }

    public void Equals()
    {
        EnsureStackSize(2);

        var value1 = _stack.Pop();
        var value2 = _stack.Pop();

        var val = value1.IsEquals(value2);
        
        _stack.Push(val);
    }

    public void GreaterThan()
    {
        EnsureStackSize(2);

        var value1 = _stack.Pop();
        var value2 = _stack.Pop();

        var val = value1.GreaterThan(value2);
        
        _stack.Push(val);
    }

    public void LessThan()
    {
        EnsureStackSize(2);

        var value1 = _stack.Pop();
        var value2 = _stack.Pop();

        var val = value1.LessThan(value2);
        
        _stack.Push(val);
    }

    public void If(out bool result)
    {
        EnsureStackSize(1);

        var val = _stack.Pop();

        result = ConvertValue<BoolValue>(val, "bool").Equals(BoolValue.True);
    }

    public void Else()
    {
    }

    public void EndIf()
    {
    }

    private void EnsureStackSize(int minSize)
    {
        if (_stack.Count < minSize)
            throw new CorthRuntimeStackInvalidSizeException(minSize, _stack.Count);
    }

    private static TValue ConvertValue<TValue>(CorthValue value, string expectedType)
        where TValue : CorthValue
    {
        return value as TValue ?? throw new CorthRuntimeOperationValueIncompatibleTypesException(value.Type, expectedType);
    }
}