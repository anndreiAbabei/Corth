using Corth.Core;
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
        var value1 = _stack.Pop();
        var value2 = _stack.Pop();

        var val = value1.Add(value2);
        
        _stack.Push(val);
    }

    public void Subtract()
    {
        var value1 = _stack.Pop();
        var value2 = _stack.Pop();

        var val = value1.Subtract(value2);
        
        _stack.Push(val);
    }

    public void Multiply()
    {
        var value1 = _stack.Pop();
        var value2 = _stack.Pop();

        var val = value1.Multiply(value2);
        
        _stack.Push(val);
    }

    public void Divide()
    {
        var value1 = _stack.Pop();
        var value2 = _stack.Pop();

        var val = value1.Divide(value2);
        
        _stack.Push(val);
    }

    public void Equals()
    {
        var value1 = _stack.Pop();
        var value2 = _stack.Pop();

        var val = value1.IsEquals(value2);
        
        _stack.Push(val);
    }

    public void GreaterThan()
    {
        var value1 = _stack.Pop();
        var value2 = _stack.Pop();

        var val = value1.GreaterThan(value2);
        
        _stack.Push(val);
    }

    public void LessThan()
    {
        var value1 = _stack.Pop();
        var value2 = _stack.Pop();

        var val = value1.LessThan(value2);
        
        _stack.Push(val);
    }
}