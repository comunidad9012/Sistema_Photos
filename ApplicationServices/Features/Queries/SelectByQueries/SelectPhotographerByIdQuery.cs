using ApplicationServices.DTOs.Users;
using ApplicationsServices.DTOs.Users;
using ApplicationsServices.Interfaces;
using ApplicationsServices.Wrappers;
using AutoMapper;
using DomainClass.Entity;
using MediatR;

namespace ApplicationsServices.Features.Queries.SelectByQueries
{
    public class SelectPhotographerByIdQuery : IRequest<Response<PhotographerDTO>>
    {
        public long Id { get; set; }
    }
    public class SelectPhotographerByIdQueryHandler : IRequestHandler<SelectPhotographerByIdQuery, Response<PhotographerDTO>>
    {
        private readonly IRepository<Photographer> _repository;
        private readonly IMapper _mapper;

        public SelectPhotographerByIdQueryHandler(IRepository<Photographer> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        async Task<Response<PhotographerDTO>> IRequestHandler<SelectPhotographerByIdQuery, Response<PhotographerDTO>>.Handle(SelectPhotographerByIdQuery request, CancellationToken cancellationToken)
        {
            var user = await _repository.GetByIdAsync(request.Id);
            if (user == null)
            {
                throw new KeyNotFoundException($"El registro solicitado con Id {request.Id} no existe en la base de datos");
            }
            else
            {
                var dto = _mapper.Map<PhotographerDTO>(user);
                return new Response<PhotographerDTO>(dto);

            }
        }
    }

}
