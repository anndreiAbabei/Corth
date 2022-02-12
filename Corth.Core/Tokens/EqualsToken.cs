namespace Corth.Core.Tokens;

public class EqualsToken : CorthToken
{
    public override string Operation => CorthTokens.Symbols.Eq;
    public override void Execute(ICorthStack stack, ref int index) => stack.Equals();
}

public class GreaterThanToken : CorthToken
{
    public override string Operation => CorthTokens.Symbols.Eq;

    public override void Execute(ICorthStack stack, ref int index) => stack.GreaterThan();
}

public class LessThanToken : CorthToken
{
    public override string Operation => CorthTokens.Symbols.Lt;

    public override void Execute(ICorthStack stack, ref int index) => stack.LessThan();
}