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
    public class DeletePhotoCommand : IRequest<Response<long>>

    {
        public long Id { get; set; }
        public long Name { get; set; }
        public long Isdelete { get; set; }
    }
    public class DeletePhotoCommandHandler : IRequestHandler<DeletePhotoCommand, Response<long>>

    {
        private readonly IRepository<Photo> _repository;
        public DeletePhotoCommandHandler(IRepository<Photo> repository)
        {
            _repository = repository;
        }

        public async Task<Response<long>> Handle(DeletePhotoCommand request, CancellationToken cancellationToken)
        {
            var DPhoto = await _repository.GetByIdAsync(request.Id);

            if (DPhoto == null)
            {
                throw new KeyNotFoundException($"Registro no encontrado con el Id {request.Id}");
            }
            else
            {
                DPhoto.IsDeleted = true;
                await _repository.UpdateAsync(DPhoto);

            }
            return new Response<long>(DPhoto.Id);


        }
    }
}
