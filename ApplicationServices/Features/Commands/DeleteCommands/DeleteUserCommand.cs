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
    public class DeleteUserCommand : IRequest<Response<long>>
    {
        public long Id { get; set; }
    }
    public class DeletUserCommandHandler : IRequestHandler<DeleteUserCommand, Response<long>>

    {
        private readonly IRepository<UserSystem> _repository;
        public DeletUserCommandHandler(IRepository<UserSystem> repository)
        {
            _repository = repository;
        }

        public async Task<Response<long>> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            var DUser = await _repository.GetByIdAsync(request.Id);

            if (DUser == null)
            {
                throw new KeyNotFoundException($"Registro no encontrado con el Id {request.Id}");
            }
            else
            {
                DUser.IsDeleted = true;
                await _repository.UpdateAsync(DUser);

            }
            return new Response<long>(DUser.Id);
        }
    }



}
  
