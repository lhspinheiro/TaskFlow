using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ActionConstraints;
using TaskFlow.Application.UseCases.Tasks.DeleteTask;
using TaskFlow.Application.UseCases.Tasks.GetAllTasks;
using TaskFlow.Application.UseCases.Tasks.RegisterTask;
using TaskFlow.Application.UseCases.Tasks.UpdateTask;
using TaskFlow.Communication.Requests;
using TaskFlow.Communication.Response;

namespace TaskFlow.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        [HttpPost]
        [ProducesResponseType(typeof(ResponseRegisterTaskJson), StatusCodes.Status201Created)]
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

          if(response.Tasks.Count != 0)
            return Ok(response);
          
          return NoContent();
        }
        
        [HttpPut]
        [Route("{id}")]
        [ProducesResponseType(typeof(ResponseRegisterTaskJson), StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> UpdateTask([FromServices] IUpdateTask useCase, [FromRoute] int id,[FromBody] RequestTask request)
        {
            var response = await useCase.Execute(id, request);
            
            return NoContent();
        }

        [HttpDelete]
        [Route("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteTask([FromServices] IDeleteTask useCase, [FromRoute] int id)
        {
            var response = await useCase.Execute(id);
            
            return NoContent();
           
        }
        
    }
}
