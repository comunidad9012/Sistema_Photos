using ApplicationServices.Filters;
using ApplicationsServices.Features.Commands.CreateCommands;
using ApplicationsServices.Features.Commands.DeleteCommands;
using ApplicationsServices.Features.Commands.UpdateCommands;
using ApplicationsServices.Features.Queries.SelectAllQueries;
using InstituteWebApi.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace Photography.ProyectoWebApi.Controllers.v1._0
{
    [ApiVersion("1.0")]
    public class PhotographerController : BaseApiController
    {
        [HttpGet]
        public async Task<IActionResult> GetAllUsers([FromQuery] PhotographerResponseFilter filter)
        {
            return Ok(await Mediator.Send(new SelectPhotographerQuery
            {
                PageNumber = filter.PageNumber,
                PageSize = filter.PageSize,
                Name = filter.Name,
                LastName = filter.LastName,
                IsDeleted = filter.IsDeleted
            }));
        }


        [HttpPost]
        public async Task<IActionResult> Post(CreatePhotographerCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        [HttpPut("{id:long}")]
        public async Task<IActionResult> Put(string id, UpdatePhotographerCommand command)
        {
            if (id != command.Name)
                return BadRequest("Error en el Id suministrado no corresponde al registro a actualizar");
            return Ok(await Mediator.Send(command));
        }

        [HttpDelete("{id:long}")]
        public async Task<IActionResult> Delete(long id)
        {
            return Ok(await Mediator.Send(new DeletePhotographerCommand { Id = id }));
        }
    }
}