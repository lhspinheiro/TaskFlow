namespace TaskFlow.Communication.Response;

public class ResponseTaskJson
{
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public DateTime DueDate { get; set; } 
    public string Priority { get; set; } = string.Empty;
}