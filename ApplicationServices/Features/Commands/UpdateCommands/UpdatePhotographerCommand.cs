using ApplicationsServices.Interfaces;
using ApplicationsServices.Wrappers;
using AutoMapper;
using DomainClass.Entity;
using MediatR;

namespace ApplicationsServices.Features.Commands.UpdateCommands
{
    public class UpdatePhotographerCommand : IRequest<Response<long>>
    {
        public long Id { get; set; }
        public string? Name { get; set; }

        public string? LastName { get; set; }

        public string? QualityPhoto { get; set; }

        public string? SizePhoto { get; set; }

        public long UserRol { get; set; }
    }
    public class UpdatePhotographerCommandHandler : IRequestHandler<UpdatePhotographerCommand, Response<long>>
    {
        private readonly IRepository<Photographer> _repository;


        public UpdatePhotographerCommandHandler(IRepository<Photographer> repository, IMapper mapper)
        {
            _repository = repository;

        }

        public async Task<Response<long>> Handle(UpdatePhotographerCommand request, CancellationToken cancellationToken)
        {
            //Obtiene el registro en base al Id enviado.
            var register = await _repository.GetByIdAsync(request.Name);
            //Consulta si se regreso algún registro desde la base de datos.
            if (register == null)
            {
                throw new KeyNotFoundException($"No se encontro el registro con el Id: {request.Name}");
            }
            else
            {
                register.Name = request.Name;
                register.LastName = request.LastName;
                register.QualityPhoto = request.QualityPhoto;
                
                register.SizePhoto = request.SizePhoto;
                
                

                await _repository.UpdateAsync(register);
            }


            return new Response<long>(register.Id);
        }
    }
}
