using TaskFlow.Communication.Response;

namespace TaskFlow.Application.UseCases.Tasks.GetTaskById;

public interface IGetTaskById
{
    public Task<ResponseRegisterTaskJson> GetById(int id);
}