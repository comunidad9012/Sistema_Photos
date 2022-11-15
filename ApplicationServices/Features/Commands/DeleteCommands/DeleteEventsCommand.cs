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
    public class DeleteEventsCommand : IRequest<Response<long>>
    {
        public long Id { get; set; }
        public long IdType { get; set; }
        public long Isdelete { get; set; }
    }
    //public class DeleteEventsCommandHandle : IRequestHandler<DeleteEventsCommand, Response<long>>
    //{
    //    private readonly IRepository<Events> _repository;

    //    public DeleteEventsCommandHandle(IRepository<Events> repository)
    //    {
    //        _repository = repository;
    //    }

    //    public async Task<Response<long>> Handle(DeleteEventsCommand request, CancellationToken cancellationToken)
    //    {

    //        var register = await _repository.GetByIdAsync(request.IdType);

    //        if (register == null)
    //        {
    //            throw new KeyNotFoundException($"No se encontro el registro con el Id: {request.IdType}");
    //        }
    //        else
    //        {
    //            await _repository.DeleteAsync(register);
    //            return new Response<long>(register.Type);
    //        }

    public class DeleteEventsCommandHandler : IRequestHandler<DeleteEventsCommand, Response<long>>

    {
        private readonly IRepository<Events> _repository;
        public DeleteEventsCommandHandler(IRepository<Events> repository)
        {
            _repository = repository;
        }

        public async Task<Response<long>> Handle(DeleteEventsCommand request, CancellationToken cancellationToken)
        {
            var DEvents = await _repository.GetByIdAsync(request.Id);

            if (DEvents == null)
            {
                throw new KeyNotFoundException($"Registro no encontrado con el Id {request.Id}");
            }
            else
            {
                DEvents.IsDeleted = true;
                await _repository.UpdateAsync(DEvents);

            }
            return new Response<long>(DEvents.Id);


        }
    }
}
