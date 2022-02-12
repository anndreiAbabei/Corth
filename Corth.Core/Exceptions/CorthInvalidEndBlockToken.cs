using System.Diagnostics.CodeAnalysis;
using Corth.Core.Models;
using Corth.Core.Tokens;

namespace Corth.Core.Exceptions;

public class CorthInvalidEndBlockToken : CorthException
{
    [SuppressMessage("ReSharper", "MemberCanBePrivate.Global")]
    public CorthToken Token { get; }

    public override string Message => $"Unexpected end token `{Token.Operation}`";

    public override FilePosition? Location => Token.Position;

    public CorthInvalidEndBlockToken(CorthToken token)
        : base(ErrorCodes.InvalidEndBlockToken)
    {
        Token = token;
    }
}