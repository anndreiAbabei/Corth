using Cocona;
using Corth;
using Corth.Compiler;
using Corth.Core;
using Corth.Logging;
using Corth.Simulator;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

var builder = CoconaApp.CreateBuilder();

builder.Services.AddSingleton<ICorthParser, CorthParser>();
builder.Services.AddSingleton<ICorthTokenParser, CorthTokenParser>();
builder.Services.AddSingleton<ICorthBuilder, CorthBuilder>();

builder.Services.AddSingleton<ICorthSimulator, CorthSimulator>();
builder.Services.AddSingleton<ICorthSimulatedRuntime, CorthSimulatedRuntime>();

builder.Services.AddSingleton<ICorthCompiler, CorthCompiler>();

builder.Logging.AddConsoleFormatter<CorthLogConsoleFormatter, CorthLogConsoleFormaterOptions>()
    .AddConsole(options => options.FormatterName = CorthLogConsoleFormatter.UseName);

var app = builder.Build();

app.AddCommand("run", async (ICorthSimulator sim, string file) => await sim.Run(file));
app.AddCommand("compile", (ICorthCompiler comp, string file) => comp.Compile(file));

app.Run();