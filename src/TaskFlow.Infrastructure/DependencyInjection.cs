using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TaskFlow.Infrastructure.Data;

namespace TaskFlow.Infrastructure;

public static class DependencyInjection
{
    public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        AddDbContext(services, configuration);
    }

    private static void AddDbContext(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("Connection");
        var version = new Version(8, 0, 40 );
        var serverVersion = new MySqlServerVersion(version);
        
        services.AddDbContext<AppDbContext>(config => config.UseMySql(connectionString, serverVersion));
    }
}