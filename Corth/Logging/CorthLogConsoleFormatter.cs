using System;
using System.IO;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;
using Microsoft.Extensions.Logging.Console;

namespace Corth.Logging;

internal class CorthLogConsoleFormatter : ConsoleFormatter
{
    internal const string UseName = "Corth";

    public CorthLogConsoleFormatter()
        : base(UseName)
    {
    }


    public override void Write<TState>(in LogEntry<TState> logEntry,
                                       IExternalScopeProvider scopeProvider,
                                       TextWriter textWriter)
    {
        if (logEntry.Formatter == null)
            return;

        var message = logEntry.Formatter(logEntry.State, logEntry.Exception);

        Console.WriteLine(message);
    }
}