using System.Net;

namespace TaskFlow.Exception;

public class ErrorOnValidationException : TaskException
{
    private readonly List<string> _errors;

    public ErrorOnValidationException(List<string> errorsMessages)
    {
        _errors = errorsMessages;
    }
    
    public override List<string> GetErrorMessages() => _errors;

    public override HttpStatusCode GetStatusCode() => HttpStatusCode.BadRequest;
}