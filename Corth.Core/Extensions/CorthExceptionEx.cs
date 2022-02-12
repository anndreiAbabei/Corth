using Corth.Core.Exceptions;
using Corth.Core.Models;

namespace Corth.Core.Extensions;

public static class CorthExceptionEx
{
    public static TException WithPosition<TException>(this TException exception, FilePosition? filePosition)
        where TException : CorthException
    {
        exception.Location = filePosition;

        return exception;
    }
}