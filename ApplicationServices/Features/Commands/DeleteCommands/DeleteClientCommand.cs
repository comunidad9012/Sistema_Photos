using ApplicationsServices.Interfaces;
using ApplicationsServices.Wrappers;
using DomainClass.Entity;
using MediatR;

namespace ApplicationsServices.Features.Commands.DeleteCommands
{
    public class DeleteClientCommand : IRequest<Response<long>>
    {
        public long Id { get; set; }

        public long Isdelete { get; set; }
    }
    //public class DeleteClientCommandHandle : IRequestHandler<DeleteClientCommand, Response<long>>
    //{
    //    private readonly IRepository<Client> _repository;

    //    public DeleteClientCommandHandle(IRepository<Client> repository)
    //    {
    //        _repository = repository;
    //    }

    //    public async Task<Response<long>> Handle(DeleteClientCommand request, CancellationToken cancellationToken)
    //    {

    //        var register = await _repository.GetByIdAsync(request.Id);

    //        if (register == null)
    //        {
    //            throw new KeyNotFoundException($"No se encontro el registro con el Id: {request.Id}");
    //        }
    //        else
    //        {
    //            await _repository.DeleteAsync(register);
    //            return new Response<long>(register.NameClient);
    //        }

    public class DeletClientCommandHandler : IRequestHandler<DeleteClientCommand, Response<long>>

    {
        private readonly IRepository<Client> _repository;
        public DeletClientCommandHandler(IRepository<Client> repository)
        {
            _repository = repository;
        }

        public async Task<Response<long>> Handle(DeleteClientCommand request, CancellationToken cancellationToken)
        {
            var DClient = await _repository.GetByIdAsync(request.Id);

            if (DClient == null)
            {
                throw new KeyNotFoundException($"Registro no encontrado con el Id {request.Id}");
            }
            else
            {
                DClient.IsDeleted = true;
                await _repository.UpdateAsync(DClient);

            }
            return new Response<long>(DClient.Id);
        }
    }


}
    

