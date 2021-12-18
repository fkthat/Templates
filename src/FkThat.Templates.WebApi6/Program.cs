using Serilog;

var builder = WebApplication.CreateBuilder(args);

builder.Host.UseSerilog((context, configuration) =>
    configuration.ReadFrom.Configuration(context.Configuration));

// Configure services.

builder.Services.AddControllers();

builder.Services.AddCors(options => {
    // configure CORS here
});

builder.Services.AddOpenApiDocument(configure => {
    configure.Title = "FkThat.Templates.WebApi6";
});

// Build application.

var app = builder.Build();

// Configure application.

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.UseHttpsRedirection();
app.UseCors();
app.UseAuthorization();
app.MapControllers();
app.UseOpenApi();

app.UseSwaggerUi3(configure => {
    configure.DocumentTitle = "FkThat.Templates.WebApi6";
});

app.Run();
