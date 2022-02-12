using Corth.Core.Exceptions;
using Corth.Core.Extensions;
using Corth.Core.Tokens.Blocks;

namespace Corth.Core.Tokens;

public class IfToken : CorthToken, ICorthBlockToken
{
    private ElseToken? ElseToken { get; set; }

    private EndIfToken? EndToken { get; set; }

    public override string Operation => CorthTokens.Symbols.If;

    public override void Execute(ICorthStack stack, ref int index)
    {
        if (ElseToken == null && EndToken == null)
            throw new CorthRuntimeInvalidIfConstruction("Missing End token").WithPosition(Position);

        stack.If(out var result);

        if (result)
        {
            if (ElseToken != null)
                ElseToken.Skip = true;
        }
        else
            index = ElseToken?.Index ?? EndToken!.Index;
    }

    public bool Accept(ICorthEndToken endToken, ref int index)
    {
        switch (endToken)
        {
            case ElseToken elt:
                ElseToken = elt;
                return true;
            case EndIfToken eit:
                EndToken = eit;
                return true;
            default:
                return false;
        }
    }
}

public class ElseToken : CorthToken, ICorthBlockToken, ICorthEndToken
{
    public bool Skip { get; set; }

    private EndIfToken? EndToken { get; set; }

    public override string Operation => CorthTokens.Symbols.Else;

    public override void Execute(ICorthStack stack, ref int index)
    {
        if (EndToken == null)
            throw new CorthRuntimeInvalidIfConstruction("Missing End token").WithPosition(Position);

        if (Skip)
        {
            index = EndToken.Index;
        }

        stack.Else();
    }

    public bool Accept(ICorthEndToken endToken, ref int index)
    {
        if (endToken is not EndIfToken eit)
            return false;

        EndToken = eit;

        return true;
    }
}

public class EndIfToken : CorthToken, ICorthEndToken
{
    public override string Operation => CorthTokens.Symbols.EndIf;
    public override void Execute(ICorthStack stack, ref int index) => stack.EndIf();
}