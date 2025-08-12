using Microsoft.EntityFrameworkCore;
using ProjectA.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

// Add connection string
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ??
                       "Host=localhost;Port=5432;Database=desk;User ID=postgres;Password=postgres;";

var customSchemaName = builder.Configuration["CustomSchemaName"];
builder.Services.AddDbContext<ProjectA.Data.ProjectADbContext>(options =>
{
    if (!string.IsNullOrEmpty(customSchemaName))
    {
        options.UseNpgsql(connectionString,
            sqlOptions => sqlOptions.MigrationsHistoryTable("__EFMigrationsHistoryProjectA",customSchemaName));
    }
    else
    {
        options.UseNpgsql(connectionString,
            sqlOptions => sqlOptions.MigrationsHistoryTable("__EFMigrationsHistoryProjectA"));
    }
});

// Add controllers
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

var app = builder.Build();

// 初始化資料庫資���
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var context = services.GetRequiredService<ProjectADbContext>();
    //await SeedData.Initialize(context);
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

var summaries = new[]
{
    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
};

app.MapGet("/weatherforecast", () =>
    {
        var forecast = Enumerable.Range(1, 5).Select(index =>
                new WeatherForecast
                (
                    DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                    Random.Shared.Next(-20, 55),
                    summaries[Random.Shared.Next(summaries.Length)]
                ))
            .ToArray();
        return forecast;
    })
    .WithName("GetWeatherForecast");

app.Run();

internal record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}