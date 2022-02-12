using Corth.Core;

namespace Corth.Compiler;

public class CorthCompiler : ICorthCompiler
{
    public ValueTask<ICorthRuntime> Build(ICorthProgramSource source, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }
}