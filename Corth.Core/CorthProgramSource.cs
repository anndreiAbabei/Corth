using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Corth.Core.Exceptions;
using Corth.Core.Models;

namespace Corth.Core;

public interface ICorthProgramSource
{
    string MainFile { get; }
    
    ValueTask<ICorthProgram> CreateProgram(CancellationToken cancellationToken = default);
}

public class CorthProgramSource : ICorthProgramSource
{
    public string MainFile { get; }

    public CorthProgramSource(string mainFile)
    {
        MainFile = mainFile;
    }
    
    public ValueTask<ICorthProgram> CreateProgram(CancellationToken cancellationToken = default)
    {
        if (string.IsNullOrEmpty(MainFile) || !File.Exists(MainFile))
            throw new CorthFileNotFoundException(MainFile);
        
        //todo: read imports and get all files

        var program = new CorthProgram();

        program.Files = new[]
        {
            new CorthFile(MainFile, File.OpenRead(MainFile))
        };

        return new ValueTask<ICorthProgram>(program);
    }
}