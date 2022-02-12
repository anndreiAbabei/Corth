using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Corth.Core.Models;

namespace Corth.Core;

public class CorthProgram : ICorthProgram
{
    public IEnumerable<CorthFile>? Files { get; set; }

    ~CorthProgram()
    {
        Dispose(false);
    }

    protected virtual async ValueTask DisposeAsync(bool disposing)
    {
        if (!disposing || Files == null)
            return;

        foreach (var file in Files)
            await file.DisposeAsync().ConfigureAwait(false);
    }

    protected virtual void Dispose(bool disposing)
    {
        if (!disposing || Files == null)
            return;

        foreach (var file in Files)
            file.Dispose();
    }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    public async ValueTask DisposeAsync()
    {
        await DisposeAsync(true).ConfigureAwait(false);
        GC.SuppressFinalize(this);
    }
}