using Corth.Core;

namespace Corth.Compiler;

public class CorthCompiler : ICorthCompiler
{
    public ValueTask<ICorthRuntime> Compile(ICorthProgramSource source, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }
}