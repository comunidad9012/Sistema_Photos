using ApplicationsServices.Interfaces;
using ApplicationsServices.Wrappers;
using DomainClass.Entity;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ardalis.Specification;

namespace ApplicationsServices.Features.Commands.DeleteCommands
{
    public class DeletePhotographerCommand : IRequest<Response<long>>
    {
        public long Id { get; set; }
        public long Name { get; set; }
    }
    public class DeletPhotographerCommandHandler : IRequestHandler<DeletePhotographerCommand, Response<long>>

    {
        private readonly IRepository<Photographer> _repository;
        public DeletPhotographerCommandHandler(IRepository<Photographer> repository)
        {
            _repository = repository;
        }

        public async Task<Response<long>> Handle(DeletePhotographerCommand request, CancellationToken cancellationToken)
        {
            var DPhotographer = await _repository.GetByIdAsync(request.Id);

            if (DPhotographer == null)
            {
                throw new KeyNotFoundException($"Registro no encontrado con el Id {request.Id}");
            }
            else
            {
                DPhotographer.IsDeleted = true;
                await _repository.UpdateAsync(DPhotographer);

            }
            return new Response<long>(DPhotographer.Id);
        }
    }


}