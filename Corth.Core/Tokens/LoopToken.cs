using Corth.Core.Exceptions;
using Corth.Core.Extensions;
using Corth.Core.Tokens.Blocks;

namespace Corth.Core.Tokens;

public class LoopToken : CorthToken, ICorthBlockToken
{
    public override string Operation => CorthTokens.Symbols.Loop;

    private EndLoopToken? EndToken { get; set; }

    public override void Execute(ICorthStack stack, ref int index)
    {
        if (EndToken == null)
            throw new CorthRuntimeInvalidLoopConstruction("Missing End token").WithPosition(Position);

        stack.Loop(out var result);

        if (result)
            return;

        EndToken.Stop = true;
        index = EndToken.Index;
    }

    public bool Accept(ICorthEndToken endToken, ref int index)
    {
        if (endToken is not EndLoopToken elt)
            return false;

        EndToken = elt;
        EndToken.StartToken = this;

        return true;

    }
}

public class EndLoopToken : CorthToken, ICorthEndToken
{
    public override string Operation => CorthTokens.Symbols.EndLoop;
    public LoopToken? StartToken { get; set; }

    public bool Stop { get; set; }

    public override void Execute(ICorthStack stack, ref int index)
    {
        if (StartToken == null)
            throw new CorthRuntimeInvalidLoopConstruction("Invalid start loop").WithPosition(Position);

        if (!Stop)
            index = StartToken.Index - 1;
    }
}
