using Corth.Core.Models;

namespace Corth.Core.Tokens;

public abstract class CorthToken
{
    protected static string None => string.Empty;
    
    public int Index { get; set; }
    
    public FilePosition? Position { get; set; }

    public abstract string Operation { get; }

    public virtual CorthToken? Next { get; set; }

    public virtual bool IsMultiLine => false;

    /// <summary>Returns a string that represents the current object.</summary>
    /// <returns>A string that represents the current object.</returns>
    public override string ToString() => Operation;
    
    public abstract void Execute(ICorthStack stack, ref int index);
}