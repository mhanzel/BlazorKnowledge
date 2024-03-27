using Microsoft.Extensions.DependencyInjection;
using Server.Shared;
using System.Linq;
using System.Reflection;

namespace Server.BlazorKnowledge.BuilderHelpers;

internal static class ServicesExtension
{
    internal static void AddServiceRegistration(this IServiceCollection services)
    {
        var interfaceType = typeof(IServiceRegistration);
        var assembly = Assembly.GetExecutingAssembly(); // Tutaj możesz użyć dowolnej innej metody do pobrania całej solucji

        var types = assembly.GetTypes().Where(t => !t.IsAbstract && !t.IsInterface && interfaceType.IsAssignableFrom(t));

        foreach (var type in types)
        {
            services.AddScoped(interfaceType, type);
        }
    }
}

