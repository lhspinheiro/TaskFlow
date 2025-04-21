using TaskFlow.Communication.Enum;

namespace TaskFlow.Communication.Requests;

public class RequestTask
{
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public DateTime DueDate { get; set; } 
    public string IsCompleted { get; set; } = string.Empty;
    public Priority Priority { get; set; } 
}