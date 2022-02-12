using System.Diagnostics.CodeAnalysis;

namespace Corth.Core.Tokens;

public class BoolToken : CorthToken
{
    [SuppressMessage("ReSharper", "MemberCanBePrivate.Global")]
    public bool Value { get; }

    public override string Operation => None;

    public BoolToken(bool value)
    {
        Value = value;
    }

    public override void Execute(ICorthStack stack, ref int index) => stack.Push(Value);

    public override string ToString() => Value.ToString();
}