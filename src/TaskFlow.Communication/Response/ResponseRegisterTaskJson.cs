namespace TaskFlow.Communication.Response;

public class ResponseRegisterTaskJson
{
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public DateTime DueDate { get; set; } 
    public string Priority { get; set; } = string.Empty;
}