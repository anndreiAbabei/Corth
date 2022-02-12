namespace Corth.Core.Tokens;

public class NumeralToken : CorthToken
{
    private int Value { get; }

    public override string Operation => None;

    public NumeralToken(int value)
    {
        Value = value;
    }

    public override void Execute(ICorthStack stack, ref int index) => stack.Push(Value);
}