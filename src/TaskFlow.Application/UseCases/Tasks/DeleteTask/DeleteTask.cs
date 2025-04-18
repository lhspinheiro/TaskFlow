using Microsoft.EntityFrameworkCore;
using TaskFlow.Infrastructure.Data;

namespace TaskFlow.Application.UseCases.Tasks.DeleteTask;

public class DeleteTask : IDeleteTask
{
    private readonly AppDbContext  _context;

    public DeleteTask(AppDbContext  context)
    {
        _context = context;
    }
    
    
    public async Task<bool> Execute(int id)
    {
        var deleteTask = await _context.task.FirstOrDefaultAsync(task => task.Id == id);

        if (deleteTask is null)
        {
            return false;
        }
        _context.task.Remove(deleteTask);
        await _context.SaveChangesAsync();
        
        return true;
        
    }
}