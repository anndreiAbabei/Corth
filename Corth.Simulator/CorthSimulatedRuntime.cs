using Corth.Core;
using Corth.Core.Exceptions;
using Corth.Core.Tokens;
using Microsoft.Extensions.Logging;

namespace Corth.Simulator;

public class CorthSimulatedRuntime : ICorthSimulatedRuntime
{
    private readonly ILogger<CorthSimulatedRuntime> _logger;
    private readonly ICorthParser _parser;
    private IList<CorthToken>? _tokens;

    public const int Success = 0;

    public bool Loaded => _tokens != null;

    public CorthSimulatedRuntime(ICorthParser parser, ILogger<CorthSimulatedRuntime> logger)
    {
        _parser = parser;
        _logger = logger;
    }

    public async ValueTask Load(ICorthProgram program, CancellationToken cancellationToken = default)
    {
        _tokens = null;
        
        var tokens = await _parser.Parse(program, cancellationToken)
            .ConfigureAwait(false);
        
        _tokens = tokens.ToList();
    }
    
    public int Run()
    {
        try
        {
            _logger.LogInformation("Started simulated runtime");

            if (!Loaded)
                throw new CorthProgramNotLoadedException();

            var index = 0;
            var stack = new CorthSimulatorStack();
            
            foreach (var token in _tokens!)
            {
                token.Execute(stack, ref index);
                index++;
            }

            return Success;
        }
        catch (CorthException ex)
        {
            _logger.LogError(ex, "\n\nError occurred: {Message}", ex.Message);

            return ex.Code;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "\n\nUnknown error occurred: {Message}", ex.Message);

            return ErrorCodes.UnknownError;
        }
        finally
        {
            _logger.LogInformation("\n\nEnded simulated runtime");
        }
    }
}