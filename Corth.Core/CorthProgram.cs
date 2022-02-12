using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace Corth.Core;
    
public class CorthProgram : ICorthProgram
{
    public IEnumerable<Stream>? Files { get; set; }

    ~CorthProgram()
    {
        Dispose(false);
    }

    protected virtual async ValueTask DisposeAsync(bool disposing)
    {
        if (!disposing || Files == null)
            return;
        
        foreach (var stream in Files)
            await stream.DisposeAsync().ConfigureAwait(false);
    }
    
    protected virtual void Dispose(bool disposing)
    {
        if (!disposing || Files == null)
            return;

        foreach (var stream in Files) 
            stream.Dispose();
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