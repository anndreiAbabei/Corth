namespace Corth.Core.Tokens;

public class NoneToken : CorthToken
{
    public override string Operation => None;
    
    public override void Execute(ICorthStack stack, ref int index) {}
}