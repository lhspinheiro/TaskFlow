using Microsoft.Extensions.DependencyInjection;
using TaskFlow.Application.AutoMapper;
using TaskFlow.Application.UseCases.Tasks.DeleteTask;
using TaskFlow.Application.UseCases.Tasks.GetAllTasks;
using TaskFlow.Application.UseCases.Tasks.GetTaskById;
using TaskFlow.Application.UseCases.Tasks.RegisterTask;
using TaskFlow.Application.UseCases.Tasks.UpdateTask;

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
        services.AddScoped<IGetAllTasks, GetAllTasks>();
        services.AddScoped<IUpdateTask, UpdateTask>();
        services.AddScoped<IDeleteTask, DeleteTask>();
        services.AddScoped<IGetTaskById, GetTaskById>();
    }
}