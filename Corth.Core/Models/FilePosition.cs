namespace Corth.Core.Models;

public class FilePosition
{
    public string? File { get; set; }
    
    public TextPosition? Start { get; set; }
    
    public TextPosition? End { get; set; }
    
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
    public int Line { get; set; }
    
    public int Column { get; set; }
    
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