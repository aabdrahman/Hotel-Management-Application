using Serilog;

var builder = WebApplication.CreateBuilder(args);


//Configure Serilog
Log.Logger = new LoggerConfiguration()
    .MinimumLevel.Debug()
    .Enrich.FromLogContext()
    .WriteTo.Console()
    .WriteTo.File(path: "Logs/log-.txt", 
                    fileSizeLimitBytes: 10_000_000, rollingInterval: RollingInterval.Day, rollOnFileSizeLimit: true, buffered: true, 
                    outputTemplate: "[{Timestamp:yyyy-MM-dd HH:mm:ss}||{Level:u3}] || [{ClassName}].[{MethodName}] - {Message:lj}{NewLine}{Exception}")
    .CreateLogger();

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo { Title = "Hotel Management Api", Description = "Hotel Management Api", Version = "v1" });
});

var app = builder.Build();

app.UseSwagger(options =>
{
    options.RouteTemplate = "HotelManagement/swagger/{documentname}/swagger.json";
});

app.UseSwaggerUI(options =>
{
    options.RoutePrefix = "HotelManagement/swagger";
    options.SwaggerEndpoint("/HotelManagement/swagger/v1/swagger.json", "Hotel Mangement Api");
});

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
