namespace Corth.Core.Tokens;

public class AddToken : CorthToken
{
    public override string Operation => CorthTokens.Symbols.Add;
    public override void Execute(ICorthStack stack, ref int index) => stack.Add();
}