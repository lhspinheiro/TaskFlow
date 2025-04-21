using AutoMapper;
using Microsoft.EntityFrameworkCore;
using TaskFlow.Communication.Response;
using TaskFlow.Infrastructure.Data;

namespace TaskFlow.Application.UseCases.Tasks.GetTaskById;

public class GetTaskById : IGetTaskById
{
    private readonly AppDbContext _context;
    private readonly IMapper _mapper;

    public GetTaskById(AppDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    
    public async Task<ResponseRegisterTaskJson> GetById(int id)
    {
        var taskById = _context.task.AsNoTracking().FirstOrDefault(task => task.Id == id);

        if (taskById == null)
        {
            return null;
        }

        return _mapper.Map<ResponseRegisterTaskJson>(taskById);
    }
}