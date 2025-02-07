using System.Text.Json;

var builder = WebApplication.CreateBuilder(args);

var svgSettingsPath = Path.Combine(Environment.CurrentDirectory, "svgsettings.json");
builder.Configuration.AddJsonFile(svgSettingsPath);

var app = builder.Build();

app.UseDefaultFiles();
app.UseStaticFiles();
app.UseHttpsRedirection();

app.MapGet("/svg", () =>
{
    var svgSettings = new
    {
        Height = app.Configuration["Height"],
        Width = app.Configuration["Width"]
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

    app.MapFallbackToFile("/index.html");

    return Results.Ok(svgSettings);
});

app.MapFallbackToFile("/index.html");

app.Run();
