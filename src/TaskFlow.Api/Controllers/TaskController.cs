using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ActionConstraints;
using TaskFlow.Application.UseCases.Tasks.GetAllTasks;
using TaskFlow.Application.UseCases.Tasks.RegisterTask;
using TaskFlow.Communication.Requests;
using TaskFlow.Communication.Response;

namespace TaskFlow.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        [HttpPost]
        [ProducesResponseType(typeof(ResponseTaskJson), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<IActionResult> RegisterTask([FromServices] IRegisterTask useCase, [FromBody]RequestTask request)
        {
            var response = await useCase.Register(request);
            
            return Created(string.Empty, response);
        }


        [HttpGet]
        [ProducesResponseType(typeof(ResponseTaskJson), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> GellALl([FromServices] IGetAllTasks useCase)
        {
            var response = await useCase.GetALl();

            if (response == null)
            {
                return NoContent();
            }
            
            return Ok(response);
        }
    }
}
