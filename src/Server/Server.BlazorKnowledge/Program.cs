using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Server.Shared.DataModelSource;
using Server.BlazorKnowledge.BuilderHelpers;
using Server.Modules.Job.Interfaces;
using Server.Modules.Job.Services;


namespace Server.Shared;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddControllers();

        builder.Services.AddServiceRegistration();

        builder.Services.AddSwaggerNuget();
        //builder.Services.AddScoped<IJobService, JobService>();

        builder.Services.AddDBContextConfiguration(builder.Configuration.GetConnectionString("SQLite"));

        var app = builder.Build();

        app.AddSwaggerStartPage();

        app.MapControllers();

        app.Run();
    }
}