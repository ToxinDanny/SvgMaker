using System.Text.Json;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var svgSettingsPath = Path.Combine(Environment.CurrentDirectory, "svgsettings.json");
builder.Configuration.AddJsonFile(svgSettingsPath);

var app = builder.Build();

app.UseHttpsRedirection();

app.MapGet("/svg", () =>
{
    var svgSettings = new
    {
        Height = app.Configuration["SvgSettings:Height"],
        Width = app.Configuration["SvgSettings:Width"]
    };

    return Results.Ok(svgSettings);
});

app.MapPut("/svg/{height}/{width}", async (int height, int width) =>
{
    Thread.Sleep(10000);

    if (width > height)
    {
        return Results.ValidationProblem(
            new Dictionary<string, string[]>() { { "Messages", ["Invalid parameters"] } },
            "Width is greater than Height");
    }

    var svgSettings = new { Height = height, Width = width };

    using var fileStream = File.OpenWrite(svgSettingsPath);
    await fileStream.WriteAsync(JsonSerializer.SerializeToUtf8Bytes(svgSettings));

    return Results.Ok(svgSettings);
});

app.Run();
