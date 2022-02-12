using Corth.Core;

namespace Corth.Compiler;

public interface ICorthCompiler
{
    ValueTask<ICorthRuntime> Compile(ICorthProgramSource source, CancellationToken cancellationToken = default);
}