using System.Net;

namespace TaskFlow.Exception;

public abstract class TaskException : System.Exception
{
    public abstract List<string> GetErrorMessages();
    public abstract HttpStatusCode  GetStatusCode();
}