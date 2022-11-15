using ApplicationsServices.Interfaces;
using ApplicationsServices.Wrappers;
using AutoMapper;
using DomainClass.Entity;
using MediatR;

namespace ApplicationsServices.Features.Commands.UpdateCommands
{
    public class UpdateClientCommand : IRequest<Response<long>>
    {
        public long? Id { get; set; }
        public string? NameClient { get; set; }

        public string? NameLastClient { get; set; }

        public string? Mobile { get; set; }

        public string? Email { get; set; }

        public string? Address { get; set; }
    }
    public class UpdateClientCommandHandler : IRequestHandler<UpdateClientCommand, Response<long>>
    {
        private readonly IRepository<Client> _repository;


        public UpdateClientCommandHandler(IRepository<Client> repository, IMapper mapper)
        {
            _repository = repository;

        }

        public async Task<Response<long>> Handle(UpdateClientCommand request, CancellationToken cancellationToken)
        {
            //Obtiene el registro en base al Id enviado.
            var register = await _repository.GetByIdAsync(request.Id);
            //Consulta si se regreso algún registro desde la base de datos.
            if (register == null)
            {
                throw new KeyNotFoundException($"No se encontro el registro con el Id: {request.NameClient}");
            }
            else
            {
                register.NameClient = request.NameClient;
                register.NameLastClient = request.NameLastClient;
                register.Address = request.Address;
                
                register.Email = request.Email;
                register.Mobile = request.Mobile;
               

                await _repository.UpdateAsync(register);
            }


            return new Response<long>(register.Id);
        }
    }
}
