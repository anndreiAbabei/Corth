namespace Corth.Core.Tokens;

public class StringToken : CorthToken
{
    public string Text { get; }
    public override string Operation => CorthTokens.Symbols.Str;

    public StringToken(string text)
    {
        Text = text;
    }

    public override void Execute(ICorthStack stack, ref int index) => stack.Push(Text);
}