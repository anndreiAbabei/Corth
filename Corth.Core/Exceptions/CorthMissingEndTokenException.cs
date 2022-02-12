using System.Diagnostics.CodeAnalysis;
using Corth.Core.Models;
using Corth.Core.Tokens;

namespace Corth.Core.Exceptions;

public class CorthMissingEndTokenException : CorthException
{
    [SuppressMessage("ReSharper", "MemberCanBePrivate.Global")]
    public CorthToken Token { get; }

    public override string Message => $"Missing end token for `{Token.Operation}`";

    public override FilePosition? Location => Token.Position;

    public CorthMissingEndTokenException(CorthToken token)
        : base(ErrorCodes.MissingEndToken)
    {
        Token = token;
    }
}