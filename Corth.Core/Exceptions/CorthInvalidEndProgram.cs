using System.Diagnostics.CodeAnalysis;

namespace Corth.Core.Exceptions;

public class CorthInvalidEndProgram : CorthException
{
    [SuppressMessage("ReSharper", "MemberCanBePrivate.Global")]
    public string State { get; }

    public override string Message => $"Unexpected token closed with `{State}`";

    public CorthInvalidEndProgram(string state)
        : base(ErrorCodes.InvalidEndProgram)
    {
        State = state;
    }
}