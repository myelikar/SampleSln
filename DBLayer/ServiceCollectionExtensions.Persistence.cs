namespace Microsoft.Extensions.DependencyInjection;

using Application.Interfaces.Repositories;
using DbLayer.DBContext;
using DBLayer.Common;
using DBLayer.Repositories;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Data;

public static partial class ServiceCollectionExtensions
{
    public static IServiceCollection AddPersistance(
        this IServiceCollection services, IConfiguration configuration, EDbTypes DbTyp, string ConnStr)
    {
        //EDbTypes DbTyp = (EDbTypes)configuration.GetValue<int>("DbTyp");
        //string ConnStr = configuration.GetConnectionString("DefaultConnection");
        if (DbTyp == EDbTypes.SQLITE)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlite(ConnStr,
                b => b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName))
                .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking)
            , ServiceLifetime.Singleton);
        }

        if (DbTyp == EDbTypes.SQLSERVER)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(ConnStr,
                b => b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName))
                .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking)
                , ServiceLifetime.Singleton);
        }
        services.AddRepos();
        return services;
    }

    static void AddRepos(this IServiceCollection services)
    {
        services.AddTransient<IUserRepository, UserRepository>();
    }

    public static void PrepDb(this IServiceProvider serviceProvider)
    {
        serviceProvider.GetRequiredService<ApplicationDbContext>().Database.EnsureCreated();
    }
}
