using System;
using System.Collections.Generic;
using Corth.Core.Models;

namespace Corth.Core;

public interface ICorthProgram : IDisposable, IAsyncDisposable
{
    IEnumerable<CorthFile>? Files { get; }
}