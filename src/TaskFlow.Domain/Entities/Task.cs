using TaskFlow.Domain.Enum;

namespace TaskFlow.Domain.Entities;

public class Task
{
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public DateTime DueDate { get; set; } 
    public string IsCompleted { get; set; } = string.Empty;
    
    public Priority Priority { get; set; } 
}