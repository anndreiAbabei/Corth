namespace Corth.Core.Tokens;

public class DumpToken : CorthToken
{
    public override string Operation => CorthTokens.Symbols.Dump;

    public override void Execute(ICorthStack stack, ref int index) => stack.Dump();
}