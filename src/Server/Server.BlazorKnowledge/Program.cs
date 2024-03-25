using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Server.Shared.DataModelSource;
using Server.Shared.Swagger;


namespace Server.Shared;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddControllers();

        builder.Services.AddSwaggerNuget();

        builder.Services.AddDBContextConfiguration(builder.Configuration.GetConnectionString("SQLite"));

        var app = builder.Build();

        app.AddSwaggerStartPage();

        app.MapControllers();

        app.Run();
    }
}