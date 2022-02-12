namespace Corth.Core.Tokens;

public abstract class CorthToken
{
    protected static string None => string.Empty;
    
    public int Line { get; set; }

    public int Column { get; set; }

    public abstract string Operation { get; }

    public virtual CorthToken? Next { get; set; }

    /// <summary>Returns a string that represents the current object.</summary>
    /// <returns>A string that represents the current object.</returns>
    public override string ToString() => Operation;
    
    public abstract void Execute(ICorthStack stack, ref int index);
}