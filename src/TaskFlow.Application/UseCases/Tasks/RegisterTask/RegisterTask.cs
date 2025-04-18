using AutoMapper;
using TaskFlow.Communication.Requests;
using TaskFlow.Communication.Response;
using TaskFlow.Exception;
using TaskFlow.Infrastructure.Data;

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
    
    public async Task <ResponseRegisterTaskJson> Register(RequestTask request)
    {
        await  Validate(request);
        
        var entity =  _mapper.Map<Domain.Entities.Task>(request);
        
        await _dbContext.task.AddAsync(entity);
        await _dbContext.SaveChangesAsync();
        
        return _mapper.Map<ResponseRegisterTaskJson>(entity);
    }

    private async Task Validate(RequestTask request)
    {
        var validate = new TaskValidator();
        
        var result = await validate.ValidateAsync(request);

        if (result.IsValid == false)
        {
            var errorMessages = result.Errors.Select(e => e.ErrorMessage).ToList();

            throw new ErrorOnValidationException(errorMessages);
        }
        
    }
}