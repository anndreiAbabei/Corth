using Corth.Core.Exceptions;
using Corth.Core.Extensions;
using Corth.Core.Models;
using Corth.Core.Tokens;

namespace Corth.Core;

public class CorthTokenParser : ICorthTokenParser
{
    public CorthToken Parse(string operation, FilePosition? position = null)
    {
        if (string.IsNullOrWhiteSpace(operation))
            return CorthTokens.None;



        if (int.TryParse(operation, out var num))
            return CorthTokens.Numeral(num);

        return operation switch
        {
            CorthTokens.Symbols.Add => CorthTokens.Add(),
            CorthTokens.Symbols.Subtract => CorthTokens.Subtract(),
            CorthTokens.Symbols.Multiply => CorthTokens.Multiply(),
            CorthTokens.Symbols.Divide => CorthTokens.Divide(),
            CorthTokens.Symbols.Eq => CorthTokens.Equals(),
            CorthTokens.Symbols.Lt => CorthTokens.LessThan(),
            CorthTokens.Symbols.Gt => CorthTokens.GreaterThan(),

            CorthTokens.Symbols.True => CorthTokens.True(),
            CorthTokens.Symbols.False => CorthTokens.False(),

            CorthTokens.Symbols.If => CorthTokens.If(),
            CorthTokens.Symbols.Else => CorthTokens.Else(),
            CorthTokens.Symbols.EndIf => CorthTokens.EndIf(),

            CorthTokens.Symbols.Loop => CorthTokens.Loop(),
            CorthTokens.Symbols.EndLoop => CorthTokens.EndLoop(),
            // CorthTokens.Symbols.While => CorthToken.While(),
            // CorthTokens.Symbols.Do => CorthToken.Do(),
            //     
            CorthTokens.Symbols.Duplicate => CorthTokens.Duplicate(),
            CorthTokens.Symbols.Dump => CorthTokens.Dump(),

            // CorthTokens.Symbols.Ret => CorthToken.Ret(),
            _ => throw new InvalidCorthTokenException(operation).WithPosition(position)
        };
    }

    public bool TryParse(string operation, out CorthToken token, FilePosition? position = null)
    {
        try
        {
            token = Parse(operation, position);
            return true;
        }
        catch (InvalidCorthTokenException)
        {
            token = CorthTokens.None;
            return false;
        }
    }

    public CorthToken ParseFullLine(string line, FilePosition? position = null)
    {

        if (string.IsNullOrWhiteSpace(line))
            return CorthTokens.None;

        // if (line.StartsWith(CorthTokens.Metadata))
        // {
        //     (string first, string remaining) = line[CorthTokens.Metadata.Length..].Trim().SplitFirst(' ');
        //
        //     return CorthToken.Metadata(first, remaining);
        // }

        if (line.StartsWith(CorthTokens.Symbols.Comment))
            return CorthTokens.Comment(line[CorthTokens.Symbols.Comment.Length..].Trim());

        throw new InvalidCorthTokenException(line).WithPosition(position);
    }

    public bool TryParseFullLine(string line, out CorthToken token, FilePosition? position = null)
    {
        try
        {
            token = ParseFullLine(line, position);
            return true;
        }
        catch (InvalidCorthTokenException)
        {
            token = CorthTokens.None;
            return false;
        }
    }
}