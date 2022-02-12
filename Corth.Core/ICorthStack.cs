namespace Corth.Core;

public interface ICorthStack
{
    void Nop();
    void Dump();
    void Duplicate();
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
    void If(out bool result);
    void Else();
    void EndIf();
    void Loop(out bool result);
    void EndLoop();
}