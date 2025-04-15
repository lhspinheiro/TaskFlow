using TaskFlow.Communication.Requests;
using TaskFlow.Communication.Response;

namespace TaskFlow.Application.UseCases.Tasks.RegisterTask;

public interface IRegisterTask
{
    public Task  <ResponseTaskJson>  Register(RequestTask request);
}