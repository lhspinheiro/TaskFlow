using AutoMapper;
using Microsoft.EntityFrameworkCore;
using TaskFlow.Communication.Response;
using TaskFlow.Infrastructure.Data;

namespace TaskFlow.Application.UseCases.Tasks.GetAllTasks;

public class GetAllTasks : IGetAllTasks
{
    private readonly AppDbContext _dbContext;
    private readonly IMapper _mapper;


    public GetAllTasks(AppDbContext dbContext, IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }
    
    
    public async Task<List<ResponseTaskJson>> GetALl()
    {
        var response = await _dbContext.task.AsNoTracking().OrderByDescending(order => order.IsCompleted == "completa")
            .ToListAsync();
        
        return _mapper.Map<List<ResponseTaskJson>>(response);
    }
}