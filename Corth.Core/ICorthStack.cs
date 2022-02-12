namespace Corth.Core;

public interface ICorthStack
{
    void Dump();
    void Push(int value);
    void Push(string value);
    void Push(bool value);
    void Add();
    void Subtract();
    void Multiply();
    void Divide();
    void Equals();
    void GreaterThan();
    void LessThan();
}