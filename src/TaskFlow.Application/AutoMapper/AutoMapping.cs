using AutoMapper;
using TaskFlow.Communication.Requests;
using TaskFlow.Communication.Response;
using Task = TaskFlow.Domain.Entities.Task;

namespace TaskFlow.Application.AutoMapper;

public class AutoMapping : Profile
{
    public AutoMapping()
    {
        RequestToEntityMapping();
        EntityToResponseMapping();
    }

    private void RequestToEntityMapping()
    {
        CreateMap<RequestTask, Task>();
    }

    private void EntityToResponseMapping()
    {
        CreateMap<Task, ResponseRegisterTaskJson>();
    }
}