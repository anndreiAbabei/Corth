namespace Corth.Core.Tokens.Blocks;

internal interface ICorthBlockToken
{
    bool Accept(ICorthEndToken endToken, ref int index);
}