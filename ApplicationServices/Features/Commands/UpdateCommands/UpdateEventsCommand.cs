using ApplicationsServices.Interfaces;
using ApplicationsServices.Wrappers;
using AutoMapper;
using DomainClass.Entity;
using MediatR;

namespace ApplicationsServices.Features.Commands.UpdateCommands
{
    public class UpdateEventsCommand : IRequest<Response<long>>
    {
        public long Id { get; set; }
        public string IdType { get; set; }

        public string Service { get; set; }

        public DateTime Date { get; set; }
    }
    public class UpdateEventsCommandHandler : IRequestHandler<UpdateEventsCommand, Response<long>>
    {
        private readonly IRepository<Events> _repository;


        public UpdateEventsCommandHandler(IRepository<Events> repository, IMapper mapper)
        {
            _repository = repository;

        }

        public async Task<Response<long>> Handle(UpdateEventsCommand request, CancellationToken cancellationToken)
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
                register.Id = request.Id;
                register.Service = request.Service;
                register.Date = request.Date;


                await _repository.UpdateAsync(register);
            }


            return new Response<long>(register.Id);
        }
    }
}
