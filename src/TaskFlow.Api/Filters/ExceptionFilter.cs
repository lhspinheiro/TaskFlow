using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using TaskFlow.Communication.Response;
using TaskFlow.Exception;

namespace TaskFlow.Api.Filters;

public class ExceptionFilter : IExceptionFilter
{
    public void OnException(ExceptionContext context)
    {
        if (context.Exception is TaskException taskException)
        {
            context.HttpContext.Response.StatusCode = (int)taskException.GetStatusCode();
            context.Result = new ObjectResult(new ResponseErrorMessagesJson
            {
                Errors = taskException.GetErrorMessages()
            });
        }
        else
        {
            context.HttpContext.Response.StatusCode = StatusCodes.Status500InternalServerError;
            context.Result = new ObjectResult(new ResponseErrorMessagesJson
            {
                Errors = ["Unknown error"]
            });
        }
    }
}
