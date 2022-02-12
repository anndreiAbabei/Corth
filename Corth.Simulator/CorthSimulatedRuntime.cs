using Corth.Core;
using Corth.Core.Exceptions;
using Corth.Core.Tokens;
using Microsoft.Extensions.Logging;

namespace Corth.Simulator;

public class CorthSimulatedRuntime : ICorthSimulatedRuntime
{
    private readonly ICorthBuilder _builder;
    private readonly ILogger<CorthSimulatedRuntime> _logger;
    private IList<CorthToken>? _tokens;

    public const int Success = 0;

    public bool Loaded => _tokens != null;

    public CorthSimulatedRuntime(ICorthBuilder builder, ILogger<CorthSimulatedRuntime> logger)
    {
        _builder = builder;
        _logger = logger;
    }

    public async ValueTask Load(ICorthProgram program, CancellationToken cancellationToken = default)
    {
        _tokens = null;

        var tokens = await _builder.Build(program, cancellationToken)
                                   .ConfigureAwait(false);

        _tokens = tokens.ToList();
    }

    public int Run()
    {
        try
        {
            _logger.LogInformation("---Started simulated runtime---\n\n");

            if (!Loaded)
                throw new CorthProgramNotLoadedException();

            var stack = new CorthSimulatorStack();

            for (var index = 0; index < _tokens!.Count; index++)
            {
                var token = _tokens![index];

                token.Execute(stack, ref index);
            }

            return Success;
        }
        catch (CorthException ex)
        {
            _logger.LogError(ex, "\n\nError (0x{Code}) occurred: {Message}\t\t{Location}",
                             ex.Code.ToString("X"),
                             ex.Message,
                             ex.Location);

            return ex.Code;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "\n\nUnknown error occurred: {Message}", ex.Message);

            return ErrorCodes.UnknownError;
        }
        finally
        {
            _logger.LogInformation("\n\n---Ended simulated runtime---");
        }
    }
}