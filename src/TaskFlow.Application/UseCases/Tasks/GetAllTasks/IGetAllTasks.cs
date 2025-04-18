using TaskFlow.Communication.Response;

namespace TaskFlow.Application.UseCases.Tasks.GetAllTasks;

public interface IGetAllTasks
{
    public Task<ResponseTaskJson> GetALl(); 
}