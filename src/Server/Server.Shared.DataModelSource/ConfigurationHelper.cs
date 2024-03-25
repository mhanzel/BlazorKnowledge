using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Server.Shared.DataModelSource;

public static class ConfigurationHelper
{
    static string DefaultPath = "Data Source = TempDataBase.db";
    public static void AddDBContextConfiguration(this IServiceCollection services, string? path)
    {
        services.AddDbContext<DBContext>(options =>
            options.UseSqlite(
                path ?? DefaultPath,
                x => x.MigrationsAssembly(typeof(DBContext).Assembly.GetName().Name)
                ));
    }
}
