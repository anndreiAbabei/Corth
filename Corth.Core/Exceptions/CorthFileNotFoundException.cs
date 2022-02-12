namespace Corth.Core.Exceptions;

public class CorthFileNotFoundException : CorthException
{
    private readonly string _file;

    public override string Message => $"File {_file} not found";

    public CorthFileNotFoundException(string file) 
        : base(ErrorCodes.FileNotFound)
    {
        _file = file;
    }
}