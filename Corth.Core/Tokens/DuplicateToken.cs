namespace Corth.Core.Tokens;

public class DuplicateToken : CorthToken
{
    public override string Operation => CorthTokens.Symbols.Duplicate;

    public override void Execute(ICorthStack stack, ref int index) => stack.Duplicate();
}
