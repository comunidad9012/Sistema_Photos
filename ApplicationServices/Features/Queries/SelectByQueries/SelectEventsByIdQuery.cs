using ApplicationServices.DTOs.Users;
using ApplicationsServices.DTOs.Users;
using ApplicationsServices.Interfaces;
using ApplicationsServices.Wrappers;
using AutoMapper;
using DomainClass.Entity;
using MediatR;

namespace ApplicationsServices.Features.Queries.SelectByQueries
{
    public class SelectEventsByIdQuery : IRequest<Response<EventsDTO>>
    {
        public long Id { get; set; }
    }
    public class SelectEventsByIdQueryHandler : IRequestHandler<SelectEventsByIdQuery, Response<EventsDTO>>
    {
        private readonly IRepository<Events> _repository;
        private readonly IMapper _mapper;

        public SelectEventsByIdQueryHandler(IRepository<Events> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        async Task<Response<EventsDTO>> IRequestHandler<SelectEventsByIdQuery, Response<EventsDTO>>.Handle(SelectEventsByIdQuery request, CancellationToken cancellationToken)
        {
            var user = await _repository.GetByIdAsync(request.Id);
            if (user == null)
            {
                throw new KeyNotFoundException($"El registro solicitado con Id {request.Id} no existe en la base de datos");
            }
            else
            {
                var dto = _mapper.Map<EventsDTO>(user);
                return new Response<EventsDTO>(dto);

            }
        }
    }

}
