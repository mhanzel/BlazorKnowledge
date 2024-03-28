using Microsoft.Extensions.DependencyInjection;
using Server.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Server.BlazorKnowledge.BuilderHelpers;

internal static class ServicesExtension
{
    internal static void AddServiceRegistration(this IServiceCollection services)
    {
        foreach (var assembly in AppDomain.CurrentDomain.GetAssemblies())
        {
            foreach (var type in assembly.GetTypes().Where(t => !t.IsInterface && !t.IsAbstract && typeof(IServiceRegistration).IsAssignableFrom(t)))
            {
                var implementedInterfaces = type.GetInterfaces().Where(i => i != typeof(IServiceRegistration));
                foreach (var implementedInterface in implementedInterfaces)
                {
                    services.AddScoped(implementedInterface, type);
                }
            }
        }
    }
}

