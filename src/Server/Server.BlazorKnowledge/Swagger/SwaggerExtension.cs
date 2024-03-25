using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace Server.Shared.Swagger;

public static class SwaggerExtension
{        
    //Swagger - dodanie do serviców
    public static void AddSwaggerNuget(this IServiceCollection services)
    {
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();
    }

    //Swagger - użycie i ustwienie go jako domyślną przeglądarkę
    public static void AddSwaggerStartPage(this WebApplication app)
    {
        app.UseSwagger();
        app.UseSwaggerUI(c =>
        {
            c.SwaggerEndpoint("/swagger/v1/swagger.json", "Blazor Knowledge");
            c.RoutePrefix = string.Empty;
        });
    }
}
