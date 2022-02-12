using Corth.Core.Models;
using Corth.Core.Tokens;

namespace Corth.Core;

public interface ICorthTokenParser
{
    CorthToken Parse(string operation, FilePosition? position = null);
    bool TryParse(string operation, out CorthToken token, FilePosition? position = null);
    
    CorthToken ParseFullLine(string line, FilePosition? position = null);
    bool TryParseFullLine(string line, out CorthToken token, FilePosition? position = null);
}