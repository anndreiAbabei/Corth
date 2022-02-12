using System;
using System.Linq;
using Corth.Core.Models;

namespace Corth.Core.Extensions;

internal static class StringEx
{
    internal static int CountLines(this string source)
    {
        if (string.IsNullOrEmpty(source))
            return 1;

        int index = -1,
            count = 1;

        while ((index = source.IndexOf(Environment.NewLine, index + 1, StringComparison.Ordinal)) != -1)
            count++;

        return count + 1;
    }

    internal static string LastLine(this string source)
    {
        return string.IsNullOrEmpty(source)
                   ? source
                   : source.Split(Environment.NewLine).Last();
    }

    internal static TextPosition GetEndPosition(this string source, TextPosition? start = null)
    {
        start ??= new TextPosition(0, 0);
        var lines = source.CountLines();

        return new TextPosition
        {
            Line = start.Line + lines - 1,
            Column = lines > 1
                         ? source.LastLine().Length
                         : start.Column + source.Length
        };
    }
}