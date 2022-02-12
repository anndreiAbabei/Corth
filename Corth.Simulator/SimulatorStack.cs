using System.Runtime.CompilerServices;

namespace Corth.Simulator;

public class SimulatorStack<T>
{
    private readonly bool _log;
    private readonly Stack<T> _stack;

    public int Count => _stack.Count;

    public SimulatorStack(bool log = false)
    {
        _log = log;
        _stack = new Stack<T>();
    }

    public void Push(T item, [CallerMemberName] string caller = "")
    {
        _stack.Push(item);

        if (_log)
            Console.WriteLine($"[{caller}] Pushed: {item} \t\t\t [Stack: {{{PrintStack()}}}]");
    }

    public T Pop([CallerMemberName] string caller = "")
    {
        var item = _stack.Pop();

        if (_log)
            Console.WriteLine($"[{caller}] Popped: {item} \t\t\t [Stack: {{{PrintStack()}}}]");

        return item;
    }

    private string PrintStack() => string.Join(", ", _stack.Reverse());
}
