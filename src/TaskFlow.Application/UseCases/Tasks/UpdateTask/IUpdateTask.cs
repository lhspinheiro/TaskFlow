using TaskFlow.Communication.Requests;
using TaskFlow.Communication.Response;

namespace TaskFlow.Application.UseCases.Tasks.UpdateTask;

public interface IUpdateTask
{
    public Task<ResponseRegisterTaskJson> Execute(int id, RequestTask request);
}