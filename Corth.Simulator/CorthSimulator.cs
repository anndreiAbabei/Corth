using Corth.Core;
using Microsoft.Extensions.Logging;

namespace Corth.Simulator;

public class CorthSimulator : ICorthSimulator
{
    private readonly ILogger<CorthSimulator> _logger;
    private readonly ICorthSimulatedRuntime _corthSimulatedRuntime;

    // ReSharper disable once ContextualLoggerProblem
    public CorthSimulator(ILogger<CorthSimulator> logger, ICorthSimulatedRuntime corthSimulatedRuntime)
    {
        _logger = logger;
        _corthSimulatedRuntime = corthSimulatedRuntime;
    }

    public async ValueTask<ICorthRuntime> Build(ICorthProgramSource source, CancellationToken cancellationToken = default)
    {
        await using var program = await source.CreateProgram(cancellationToken)
            .ConfigureAwait(false);

        await _corthSimulatedRuntime.Load(program, cancellationToken)
            .ConfigureAwait(false);

        return _corthSimulatedRuntime;
    }
}