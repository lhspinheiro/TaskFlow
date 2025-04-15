using Microsoft.Extensions.DependencyInjection;
using TaskFlow.Application.AutoMapper;
using TaskFlow.Application.UseCases.Tasks.RegisterTask;

namespace TaskFlow.Application;

public static class DependencyInjection
{
    public static void AddApplication(this IServiceCollection services)
    {
        AddAutoMapper(services);
        AddUSeCase(services);
    }

    private static void AddAutoMapper(IServiceCollection services)
    {
        services.AddAutoMapper(typeof(AutoMapping));
    }

    private static void AddUSeCase(IServiceCollection services)
    {
        services.AddScoped<IRegisterTask, RegisterTask>();
    }
}