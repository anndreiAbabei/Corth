namespace Corth.Core.Exceptions;

public class CorthInvalidEndProgram : CorthException
{
    public string State { get; }
    
    public override string Message => "Unexpected token closed with `{State}`";

    public CorthInvalidEndProgram(string state)
        : base(ErrorCodes.InvalidEndProgram)
    {
        State = state;
    }
}