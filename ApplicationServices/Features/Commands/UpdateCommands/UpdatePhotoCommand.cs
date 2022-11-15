using ApplicationsServices.Interfaces;
using ApplicationsServices.Wrappers;
using AutoMapper;
using DomainClass.Entity;
using MediatR;

namespace ApplicationsServices.Features.Commands.UpdateCommands
{
    public class UpdatePhotoCommand : IRequest<Response<long>>
    {
        public long Id { get; set; }
        public string? Name { get; set; }

        public string? Type { get; set; }

        public string? Size { get; set; }

        public long Idclient { get; set; }

        public long IdPhotographer { get; set; }
    }
    public class UpdatePhotoCommandHandler : IRequestHandler<UpdatePhotoCommand, Response<long>>
    {
        private readonly IRepository<Photo> _repository;


        public UpdatePhotoCommandHandler(IRepository<Photo> repository, IMapper mapper)
        {
            _repository = repository;

        }

        public async Task<Response<long>> Handle(UpdatePhotoCommand request, CancellationToken cancellationToken)
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
                register.Id=request.Id;
                register.Name = request.Name;
                register.Type = request.Type;
               
              
                register.Size = request.Size;
                register.Idclient = request.Idclient;
                register.IdPhotographer = request.IdPhotographer;

                await _repository.UpdateAsync(register);
            }


            return new Response<long>(register.Id);
        }
    }
}
