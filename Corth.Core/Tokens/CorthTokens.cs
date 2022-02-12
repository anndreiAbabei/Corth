using System.Diagnostics.CodeAnalysis;

namespace Corth.Core.Tokens;

public static class CorthTokens
{
    [SuppressMessage("ReSharper", "MemberHidesStaticFromOuterClass")]
    public static class Symbols
    {
        public const string Dump = ".";
        public const string Comment = ";;";
        public const string Add = "+";
        public const string Subtract = "-";
        public const string Multiply = "*";
        public const string Divide = "/";
        
        public const string Eq = "=";
        public const string Gt = ">";
        public const string Lt = "<";

        public const string Str = "'";
        public const string True = "True";
        public const string False = "False";
    }

    public static CorthToken None { get; } = new NoneToken();

    public static CorthToken Numeral(int result) => new NumeralToken(result);

    public static CorthToken Dump() => new DumpToken();

    public static CorthToken Comment(string comment) => new CommentToken(comment);

    public static CorthToken Add() => new AddToken();
    
    public static CorthToken Subtract() => new SubtractToken();
    
    public static CorthToken Multiply() => new MultiplyToken();
    
    public static CorthToken Divide() => new DivideToken();

    public static CorthToken Equals() => new EqualsToken();
    public static CorthToken LessThan() => new LessThanToken();
    public static CorthToken GreaterThan() => new GreaterThanToken();

    public static CorthToken String(string str) => new StringToken(str);
    public static CorthToken True() => Bool(true);
    public static CorthToken False() => Bool(false);
    public static CorthToken Bool(bool value) => new BoolToken(value);
}