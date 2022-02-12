using System;
using System.Collections.Generic;
using System.IO;

namespace Corth.Core;

public interface ICorthProgram : IDisposable, IAsyncDisposable
{
    IEnumerable<Stream>? Files { get; }
}