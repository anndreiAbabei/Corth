using System;
using System.IO;
using System.Threading.Tasks;

namespace Corth.Core.Models;

public class CorthFile : IDisposable, IAsyncDisposable
{

    public string Path { get; set; }

    public Stream Content { get; set; }
    

    public CorthFile(string path, Stream content)
    {
        Path = path;
        Content = content;
    }

    ~CorthFile()
    {
        Dispose(true);
    }

    protected virtual void Dispose(bool disposing)
    {
        if (disposing)
        {
            Content.Dispose();
        }
    }
    
    protected virtual async ValueTask DisposeAsync(bool disposing)
    {
        if (disposing)
        {
            await Content.DisposeAsync().ConfigureAwait(false);
        }
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