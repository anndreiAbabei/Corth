using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Corth.Core.Exceptions;
using Corth.Core.Tokens;
using Corth.Core.Tokens.Blocks;

namespace Corth.Core;

public class CorthBuilder : ICorthBuilder
{
    private readonly ICorthParser _parser;

    public CorthBuilder(ICorthParser parser)
    {
        _parser = parser;
    }
    
    public async ValueTask<IEnumerable<CorthToken>> Build(ICorthProgram program, CancellationToken cancellationToken = default)
    {
        var tokens = await _parser.Parse(program, cancellationToken)
            .ConfigureAwait(false);
        var tokensLst = tokens as CorthToken[] ?? tokens.ToArray();
        
        LinkBlockTokens(tokensLst);

        return tokensLst;
    }

    private static void LinkBlockTokens(IReadOnlyList<CorthToken> tokens)
    {
        var stack = new Stack<ICorthBlockToken>();
        CorthToken? prevToken = null;

        for (var index = 0; index < tokens.Count; index++)
        {
            var token = tokens[index];

            token.Index = index;

            if (token is ICorthEndToken endToken)
            {
                if (stack.Count <= 0)
                    throw new CorthInvalidEndBlockToken(token);
                
                var blkToken = stack.Peek();

                if (blkToken.Accept(endToken, ref index))
                    stack.Pop();
            }

            if(token is ICorthBlockToken blockToken)
                stack.Push(blockToken);

            if (prevToken is { Next: null })
                prevToken.Next = token;

            prevToken = token;
        }

        if (stack.Count > 0)
            throw new CorthMissingEndTokenException((CorthToken)stack.Peek());
    }
}