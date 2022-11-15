using ApplicationServices.DTOs.Users;
using ApplicationsServices.DTOs.Users;
using ApplicationsServices.Interfaces;
using ApplicationsServices.Wrappers;
using AutoMapper;
using DomainClass.Entity;
using MediatR;
namespace ApplicationsServices.Features.Queries.SelectByQueries
{
    public class SelectClientByIdQuery : IRequest<Response<ClientDTO>>
    {
        public long Id { get; set; }
    }
    public class SelectClientByIdQueryHandler : IRequestHandler<SelectClientByIdQuery, Response<ClientDTO>>
    {
        private readonly IRepository<Client> _repository;
        private readonly IMapper _mapper;

        public SelectClientByIdQueryHandler(IRepository<Client> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        async Task<Response<ClientDTO>> IRequestHandler<SelectClientByIdQuery, Response<ClientDTO>>.Handle(SelectClientByIdQuery request, CancellationToken cancellationToken)
        {
            var user = await _repository.GetByIdAsync(request.Id);
            if (user == null)
            {
                throw new KeyNotFoundException($"El registro solicitado con Id {request.Id} no existe en la base de datos");
            }
            else
            {
                var dto = _mapper.Map<ClientDTO>(user);
                return new Response<ClientDTO>(dto);

            }
        }
    }

}
