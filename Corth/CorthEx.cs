using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Corth.Compiler;
using Corth.Core;
using Corth.Simulator;

namespace Corth;

internal static class CorthEx
{
    internal static async ValueTask<int> Run(this ICorthSimulator sim, string file, CancellationToken cancellationToken = default)
    {
        if (sim == null)
            throw new ArgumentNullException(nameof(sim));
        
        if (string.IsNullOrEmpty(file)) 
            throw new ArgumentNullException(nameof(file));

        if (!File.Exists(file))
            throw new FileLoadException("File does not exist");

        var program = new CorthProgramSource(file);
        var runtime = await sim.Build(program, cancellationToken)
            .ConfigureAwait(false);
        
        return runtime.Run();
    }
    internal static void Compile(this ICorthCompiler sim, string file)
    {
        if (sim == null)
            throw new ArgumentNullException(nameof(sim));
    
        if (string.IsNullOrEmpty(file)) 
            throw new ArgumentNullException(nameof(file));

        if (!File.Exists(file))
            throw new FileLoadException("File does not exist");
    }
}