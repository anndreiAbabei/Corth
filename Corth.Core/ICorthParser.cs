using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Corth.Core.Tokens;

namespace Corth.Core;

public interface ICorthParser
{
    ValueTask<IEnumerable<CorthToken>> Parse(ICorthProgram program, CancellationToken cancellationToken = default);
}