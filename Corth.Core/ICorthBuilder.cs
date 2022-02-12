using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Corth.Core.Tokens;

namespace Corth.Core;

public interface ICorthBuilder
{
    ValueTask<IEnumerable<CorthToken>> Build(ICorthProgram program, CancellationToken cancellationToken = default);
}