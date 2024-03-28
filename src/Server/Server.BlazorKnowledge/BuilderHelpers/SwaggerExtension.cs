using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace Server.BlazorKnowledge.BuilderHelpers;

internal static class SwaggerExtension
{
    //Swagger - dodanie do serviców
    internal static void AddSwaggerNuget(this IServiceCollection services)
    {
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();
    }

    //Swagger - użycie i ustwienie go jako domyślną przeglądarkę
    internal static void AddSwaggerStartPage(this WebApplication app)
    {
        app.UseSwagger();
        app.UseSwaggerUI(c =>
        {
            c.SwaggerEndpoint("/swagger/v1/swagger.json", typeof(SwaggerExtension).Assembly.GetName().Name);
            c.RoutePrefix = string.Empty;
        });
    }
}
