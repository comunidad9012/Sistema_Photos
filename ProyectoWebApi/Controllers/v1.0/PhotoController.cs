using ApplicationServices.Filters;
using ApplicationsServices.Features.Commands.CreateCommands;
using ApplicationsServices.Features.Commands.DeleteCommands;
using ApplicationsServices.Features.Commands.UpdateCommands;
using ApplicationsServices.Features.Queries.SelectAllQueries;
using InstituteWebApi.Controllers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Photo.ProyectoWebApi.Controllers.v1._0
{
    [ApiVersion("1.0")]
    public class PhotoController : BaseApiController
    {
        [HttpGet]
        public async Task<IActionResult> GetAllUsers([FromQuery] PhotoResponseFilter filter)
        {
            return Ok(await Mediator.Send(new SelectPhotoQuery
            {
                PageNumber = filter.PageNumber,
                PageSize = filter.PageSize,
                Name = filter.Name,
                Type = filter.Type,
                IsDeleted = filter.IsDeleted
            }));
        }


        [HttpPost]
        public async Task<IActionResult> Post(CreatePhotoCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        [HttpPut("{id:long}")]
        public async Task<IActionResult> Put(long id, UpdatePhotoCommand command)
        {
            if (id != command.Id)
                return BadRequest("Error en el Id suministrado no corresponde al registro a actualizar");
            return Ok(await Mediator.Send(command));
        }

        [HttpDelete("{id:long}")]
        public async Task<IActionResult> Delete(long id)
        {
            return Ok(await Mediator.Send(new DeletePhotoCommand { Id = id }));
        }
    }
}