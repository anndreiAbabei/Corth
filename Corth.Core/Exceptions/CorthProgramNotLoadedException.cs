namespace Corth.Core.Exceptions;

public class CorthProgramNotLoadedException : CorthException
{
    public override string Message => "Program not loaded";

    public CorthProgramNotLoadedException()
        : base(ErrorCodes.CorthProgramNotLoaded)
    {
        
    }
}