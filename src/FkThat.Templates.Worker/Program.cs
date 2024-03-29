using FkThat.Templates.Worker;

using Serilog;

var builder = Host.CreateDefaultBuilder(args);

builder.UseSerilog((context, configuration) =>
    configuration.ReadFrom.Configuration(context.Configuration));

builder.ConfigureServices(services => services.AddHostedService<HelloWorker>());

await builder.Build().RunAsync().ConfigureAwait(false);

// https://github.com/dotnet/roslyn-analyzers/issues/6141
sealed partial class Program {}
