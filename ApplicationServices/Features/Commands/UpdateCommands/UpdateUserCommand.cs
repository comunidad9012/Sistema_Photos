using ApplicationsServices.Interfaces;
using ApplicationsServices.Wrappers;
using AutoMapper;
using DomainClass.Entity;
using MediatR;

namespace ApplicationsServices.Features.Commands.UpdateCommands
{
    public class UpdateUserCommand : IRequest<Response<long>>
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string? Mobile { get; set; }
        public long UserRol { get; set; }
    }
    public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, Response<long>>
    {
        private readonly IRepository<UserSystem> _repository;


        public UpdateUserCommandHandler(IRepository<UserSystem> repository, IMapper mapper)
        {
            _repository = repository;

        }

        public async Task<Response<long>> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            //Obtiene el registro en base al Id enviado.
            var register = await _repository.GetByIdAsync(request.Id);
            //Consulta si se regreso algún registro desde la base de datos.
            if (register == null)
            {
                throw new KeyNotFoundException($"No se encontro el registro con el Id: {request.Id}");
            }
            else
            {
                register.Name = request.Name;
                register.LastName = request.LastName;
                register.UserName = request.UserName;
                register.Password = request.Password;
                register.Email = request.Email;
                register.Mobile = request.Mobile;
                register.UserRol = request.UserRol;

                await _repository.UpdateAsync(register);
            }


            return new Response<long>(register.Id);
        }
    }
}
