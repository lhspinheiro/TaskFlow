using AutoMapper;
using TaskFlow.Communication.Requests;
using TaskFlow.Communication.Response;
using TaskFlow.Infrastructure.Data;
using Task = TaskFlow.Domain.Entities.Task;

namespace TaskFlow.Application.UseCases.Tasks.RegisterTask;

public class RegisterTask : IRegisterTask
{
    private readonly IMapper _mapper;
    private readonly AppDbContext _dbContext;


    public RegisterTask(IMapper mapper, AppDbContext dbContext)
    {
        _mapper = mapper;
        _dbContext = dbContext;
  
    }
    
    public async Task <ResponseTaskJson> Register(RequestTask request)
    {
        Validate(request);
        
        var entity = _mapper.Map<Task>(request);
        
        await _dbContext.task.AddAsync(entity);
        await _dbContext.SaveChangesAsync();
        
        return _mapper.Map<ResponseTaskJson>(entity);
    }

    private void Validate(RequestTask request)
    {
        var validator = new TaskValidator();
        var result = validator.Validate(request);

        if (!result.IsValid)
        {
            
        }
    }
}