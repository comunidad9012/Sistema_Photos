using ApplicationServices.Filters;
using ApplicationsServices.Features.Commands.CreateCommands;
using ApplicationsServices.Features.Commands.DeleteCommands;
using ApplicationsServices.Features.Commands.UpdateCommands;
using ApplicationsServices.Features.Queries.SelectAllQueries;
using ApplicationsServices.Features.Queries.SelectByQueries;
using InstituteWebApi.Controllers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Photography.ProyectoWebApi.Controllers.v1._0
{
    [ApiVersion("1.0")]
    public class EventsController : BaseApiController
    {
        [HttpGet]
        public async Task<IActionResult> GetAllUsers([FromQuery] EventsResponseFilter filter)
        {
            return Ok(await Mediator.Send(new SelectEventsQuery
            {
                PageNumber = filter.PageNumber,
                PageSize = filter.PageSize,
                Type = filter.Type,
                Service = filter.Service,
                IsDeleted = filter.IsDeleted
            }));
        }

        [HttpGet("{id:long}")]
        public async Task<IActionResult> GetById(long id)
        {
            return Ok(await Mediator.Send(new SelectEventsByIdQuery { Id = id }));
        }

        [HttpPost]
        public async Task<IActionResult> Post(CreateEventsCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        [HttpPut("{id:long}")]
        public async Task<IActionResult> Put(long id, UpdateEventsCommand command)
        {
            if (id != command.Id)
                return BadRequest("Error en el Id suministrado no corresponde al registro a actualizar");
            return Ok(await Mediator.Send(command));
        }

        [HttpDelete("{id:long}")]
        public async Task<IActionResult> Delete(long id)
        {
            return Ok(await Mediator.Send(new DeleteEventsCommand { Id = id }));
        }
    }
}