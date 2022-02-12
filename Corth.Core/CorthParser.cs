using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using Corth.Core.Exceptions;
using Corth.Core.Extensions;
using Corth.Core.Models;
using Corth.Core.Tokens;

namespace Corth.Core;

public class CorthParser : ICorthParser
{
    private readonly ICorthTokenParser _tokenParser;

    public CorthParser(ICorthTokenParser tokenParser)
    {
        _tokenParser = tokenParser;
    }
    
    public async ValueTask<IEnumerable<CorthToken>> Parse(ICorthProgram program, CancellationToken cancellationToken = default)
    {
        if (program.Files == null)
            return Enumerable.Empty<CorthToken>();
        
        var tokens = new List<CorthToken>();

        foreach (var file in program.Files)
        {
            cancellationToken.ThrowIfCancellationRequested();

            await ParseFile(file, tokens, cancellationToken)
                .ConfigureAwait(false);
        }

        return tokens;
    }

    private async ValueTask ParseFile(CorthFile file, 
        ICollection<CorthToken> tokens,
        CancellationToken cancellationToken = default)
    {
        using var sr = new StreamReader(file.Content);
        var lineNo = 0;
        
        while (!sr.EndOfStream)
        {
            cancellationToken.ThrowIfCancellationRequested();

            var line = await sr.ReadLineAsync().ConfigureAwait(false);

            ParseLine(line, lineNo, file.Path, tokens);
            lineNo++;
        }
    }

    private void ParseLine(string? line, int lineNo, string file, ICollection<CorthToken> tokens)
    {
        if(string.IsNullOrWhiteSpace(line))
            return;

        var sb = new StringBuilder();
        var colPos = 0;
        var inString = false;

        line += ' ';
        
        if (IsFullLineToken(line, lineNo, tokens, file))
            return;
    
        for (var i = 0; i < line.Length; i++)
        {
            var chr = line[i];
            if (char.IsWhiteSpace(chr) && !inString)
            {
                if (sb.Length == 0)
                    continue;

                var token = CreateToken(sb.ToString(), lineNo, colPos, file);
                tokens.Add(token);

                sb.Clear();
                colPos = -1;
            }
            else if (chr == '\'' && (sb.Length == 0 || sb[^1] != '\\'))
            {
                inString = !inString;

                if (!inString)
                {
                    var token = CreateStringToken(sb.ToString(), lineNo, colPos, file);
                    tokens.Add(token);

                    sb.Clear();
                    colPos = -1;
                }
            }
            else
            {
                if (colPos < 0)
                    colPos = i;
                
                sb.Append(chr);
            }
        }

        if (sb.Length != 0)
        {
            var lastPosition = tokens.LastOrDefault()?.Position?.End ?? new TextPosition(lineNo, 0);
            var str = sb.ToString();
            var pos = new FilePosition(file, lastPosition, str.GetEndPosition(lastPosition));
            
            throw new CorthInvalidEndProgram(str).WithPosition(pos);
        }
    }

    private bool IsFullLineToken(string line, int lineNo, ICollection<CorthToken> tokens, string file)
    {
        var position = CreateFilePosition(line, lineNo, 0, file);
        if (!_tokenParser.TryParseFullLine(line, out var token, position))
            return false;

        token.Position = position;

        tokens.Add(token);

        return true;
    }

    private CorthToken CreateToken(string tokenStr, int line, int col, string file)
    {
        var position = CreateFilePosition(tokenStr, line, col, file);
        var token = _tokenParser.Parse(tokenStr, position);

        token.Position = position;

        return token;
    }

    private static CorthToken CreateStringToken(string text, int line, int col, string file)
    {
        var token = CorthTokens.String(Regex.Unescape(text));

        SetPosToToken(token, line, col, file);
        
        return token;
    }

    private static void SetPosToToken(CorthToken token, int line, int col, string file)
    {
        token.Position = CreateFilePosition(token.ToString(), line, col, file, token.IsMultiLine);
    }

    private static FilePosition CreateFilePosition(string text, int line, int col, string file, bool? isMultiline = null)
    {
        int? linesCount = null;
        var iml = isMultiline ?? (linesCount = text.CountLines()) > 1;
        
        return new FilePosition
        {
            File = file,
            Start = new TextPosition(line, col),
            End = new TextPosition
            {
                Line = iml
                    ? line + (linesCount ?? text.CountLines())
                    : line,
                Column = iml
                    ? text.LastLine().Length
                    : line + text.Length
            }
        };
    }
}