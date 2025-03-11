
using BenchmarkWriteLog.Api.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Serilog;

namespace BenchmarkWriteLog.Api;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        builder.Services.AddAuthorization();

        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();
        builder.Services.AddControllers();

        builder.Services.AddScoped<IWriteLogService, WriteLogService>();

        Log.Logger = new LoggerConfiguration()
            .WriteTo.Console()
            .CreateLogger();
        
        builder.Services.AddSingleton(Log.Logger);

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();

        app.UseAuthorization();
        app.MapControllers();

        app.Run();
    }
}
