namespace Corth.Core.Tokens;

public class MultiplyToken : CorthToken
{
    public override string Operation => CorthTokens.Symbols.Multiply;
    
    public override void Execute(ICorthStack stack, ref int index) => stack.Multiply();
}

public class DivideToken : CorthToken
{
    public override string Operation => CorthTokens.Symbols.Divide;
    
    public override void Execute(ICorthStack stack, ref int index) => stack.Divide();
}