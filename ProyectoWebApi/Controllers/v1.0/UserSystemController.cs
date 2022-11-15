using ApplicationServices.Filters;
using ApplicationsServices.Features.Commands.CreateCommands;
using ApplicationsServices.Features.Commands.DeleteCommands;
using ApplicationsServices.Features.Commands.UpdateCommands;
using ApplicationsServices.Features.Queries.SelectAllQueries;
using ApplicationsServices.Features.Queries.SelectByQueries;
using Microsoft.AspNetCore.Mvc;

namespace InstituteWebApi.Controllers.v1._0
{
    [ApiVersion("1.0")]
    public class UserSystemController : BaseApiController
    {
        [HttpGet]
        public async Task<IActionResult> GetAllUsers([FromQuery] UserResponseFilter filter)
        {
            return Ok(await Mediator.Send(new SelectUserQuery
            {
                PageNumber = filter.PageNumber,
                PageSize = filter.PageSize,
                Name = filter.Name,
                LastName = filter.LastName,
                IsDeleted = filter.IsDeleted
            }));
        }

        [HttpGet("{id:long}")]
        public async Task<IActionResult> GetById(long id)
        {
            return Ok(await Mediator.Send(new SelectUserByIdQuery { Id = id }));
        }

        [HttpPost]
        public async Task<IActionResult> Post(CreateUserCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        [HttpPut("{id:long}")]
        public async Task<IActionResult> Put(long id, UpdateUserCommand command)
        {
            if (id != command.Id)
                return BadRequest("Error en el Id suministrado no corresponde al registro a actualizar");
            return Ok(await Mediator.Send(command));
        }

        [HttpDelete("{id:long}")]
        public async Task<IActionResult> Delete(long id)
        {
            return Ok(await Mediator.Send(new DeleteUserCommand { Id = id }));
        }
    }
}
