using Corth.Core;

namespace Corth.Compiler;

public interface ICorthCompiler
{
    ValueTask<ICorthRuntime> Build(ICorthProgramSource source, CancellationToken cancellationToken = default);
}