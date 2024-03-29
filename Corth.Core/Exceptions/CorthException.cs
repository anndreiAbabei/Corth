using System;
using System.Runtime.Serialization;
using Corth.Core.Models;

namespace Corth.Core.Exceptions;

[Serializable]
public class CorthException : Exception
{
    public virtual int Code { get; }

    public virtual FilePosition? Location { get; set; }



    public CorthException(int code = ErrorCodes.UnknownError)
    {
        Code = code;
    }



    public CorthException(string message, int code = ErrorCodes.UnknownError)
        : base(message)
    {
        Code = code;
    }



    public CorthException(string message, int code = ErrorCodes.UnknownError, Exception? inner = null)
        : base(message, inner)
    {
        Code = code;
    }



    protected CorthException(SerializationInfo info, StreamingContext context)
        : base(info, context)
    {
    }
}