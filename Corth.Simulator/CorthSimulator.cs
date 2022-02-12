using Corth.Core;
using Microsoft.Extensions.Logging;

namespace Corth.Simulator;

public class CorthSimulator : ICorthSimulator
{
    private readonly ICorthSimulatedRuntime _corthSimulatedRuntime;
    private readonly ILogger<CorthSimulator> _logger;

    // ReSharper disable once ContextualLoggerProblem
    public CorthSimulator(ICorthSimulatedRuntime corthSimulatedRuntime, ILogger<CorthSimulator> logger)
    {
        _corthSimulatedRuntime = corthSimulatedRuntime;
        _logger = logger;
    }

    public async ValueTask<ICorthRuntime> Compile(ICorthProgramSource source, CancellationToken cancellationToken = default)
    {
        _logger.LogInformation("Start building");
        
        await using var program = await source.CreateProgram(cancellationToken)
            .ConfigureAwait(false);

        await _corthSimulatedRuntime.Load(program, cancellationToken)
            .ConfigureAwait(false);

        _logger.LogInformation("Build success!");
        
        return _corthSimulatedRuntime;
    }
}