using ApplicationServices.DTOs.Users;
using ApplicationServices.Filters;
using ApplicationServices.Specifications;

using ApplicationsServices.Interfaces;

using ApplicationsServices.Wrappers;
using AutoMapper;
using DomainClass.Entity;
using MediatR;

namespace ApplicationsServices.Features.Queries.SelectAllQueries
{
    public class SelectEventsQuery : IRequest<PaginatedResponse<IEnumerable<EventsDTO>>>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public string? Type { get; set; }
        public string? Service { get; set; }
        public bool IsDeleted { get; set; }


        public class SelectEventsQueryHandler : IRequestHandler<SelectEventsQuery, PaginatedResponse<IEnumerable<EventsDTO>>>
        {
            private readonly IRepository<Events> _repository;
            private readonly IMapper _mapper;

            public SelectEventsQueryHandler(IRepository<Events> repository, IMapper mapper)
            {
                _repository = repository;
                _mapper = mapper;
            }
            public async Task<PaginatedResponse<IEnumerable<EventsDTO>>> Handle(SelectEventsQuery request, CancellationToken cancellationToken)
            {
                EventsResponseFilter responseFilter = new EventsResponseFilter()
                {
                    PageSize = request.PageSize,
                    PageNumber = request.PageNumber,
                    Type = request.Type,
                    Service = request.Service,
                    IsDeleted=request.IsDeleted,
                };

                var Events = await _repository.ListAsync(new PaginatedEventsSpecification(responseFilter));
                var EventsDto = _mapper.Map<IEnumerable<EventsDTO>>(Events);
                return new PaginatedResponse<IEnumerable<EventsDTO>>(EventsDto, request.PageNumber, request.PageSize);
            }
        }
    }
}
