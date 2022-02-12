namespace Corth.Core.Tokens;

public class CommentToken : CorthToken
{
    public string Comment { get; }

    public override string Operation => CorthTokens.Symbols.Comment;

    public CommentToken(string comment) => Comment = comment;
    
    public override void Execute(ICorthStack stack, ref int index) {}
}