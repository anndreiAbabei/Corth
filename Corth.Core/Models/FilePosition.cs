namespace Corth.Core.Models;

public class FilePosition
{
    public string? File { get; init; }
    
    public TextPosition? Start { get; init; }
    
    public TextPosition? End { get; init; }
    
    public FilePosition(string? file = null, TextPosition? start = null, TextPosition? end = null)
    {
        File = file;
        Start = start;
        End = end;
    }

    public override string ToString() => $"{File} [{Start}]-[{End}]";
}

public class TextPosition
{
    public int Line { get; init; }

    public int Column { get; init; }

    public TextPosition()
    {

    }

    public TextPosition(int line, int column)
    {
        Line = line;
        Column = column;
    }

    public override string ToString() => $"{Line}, {Column}";
}