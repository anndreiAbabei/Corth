namespace Corth.Core.Tokens;

public class SubtractToken : CorthToken
{
    public override string Operation => CorthTokens.Symbols.Subtract;
    
    public override void Execute(ICorthStack stack, ref int index) => stack.Subtract();
}