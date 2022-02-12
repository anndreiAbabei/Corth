using System.Threading;
using System.Threading.Tasks;

namespace Corth.Core;

public interface ICorthRuntime
{
    bool Loaded { get; }
    ValueTask Load(ICorthProgram program, CancellationToken cancellationToken = default);
    int Run();
}