using AutoMapper;
using Microsoft.EntityFrameworkCore;
using TaskFlow.Communication.Requests;
using TaskFlow.Communication.Response;
using TaskFlow.Infrastructure.Data;

namespace TaskFlow.Application.UseCases.Tasks.UpdateTask;

public class UpdateTask : IUpdateTask
{
    private readonly AppDbContext _dbContext;
    private readonly IMapper _mapper;

    public UpdateTask(AppDbContext dbContext, IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }

    public async Task<ResponseRegisterTaskJson> Execute(int id, RequestTask request)
    {
        var updateTask = await _dbContext.task.FirstOrDefaultAsync(task => task.Id == id);

        if (updateTask is null)
        {
            return null;
        }

        _mapper.Map(request, updateTask);

        _dbContext.Update(updateTask);
        await _dbContext.SaveChangesAsync();

        return _mapper.Map<ResponseRegisterTaskJson>(updateTask);
    }
}