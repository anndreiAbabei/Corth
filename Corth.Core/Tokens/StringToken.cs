using System.Diagnostics.CodeAnalysis;
using Corth.Core.Extensions;

namespace Corth.Core.Tokens;

public class StringToken : CorthToken
{
    [SuppressMessage("ReSharper", "MemberCanBePrivate.Global")]
    public string Text { get; }
    
    public override string Operation => CorthTokens.Symbols.Str;

    public override bool IsMultiLine => Text.CountLines() > 1;

    public StringToken(string text)
    {
        Text = text;
    }

    public override void Execute(ICorthStack stack, ref int index) => stack.Push(Text);

    public override string ToString() => Text;
}