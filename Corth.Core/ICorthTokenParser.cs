using Corth.Core.Tokens;

namespace Corth.Core;

public interface ICorthTokenParser
{
    CorthToken Parse(string operation);
    bool TryParse(string operation, out CorthToken token);
    
    CorthToken ParseFullLine(string line);
    bool TryParseFullLine(string line, out CorthToken token);
}