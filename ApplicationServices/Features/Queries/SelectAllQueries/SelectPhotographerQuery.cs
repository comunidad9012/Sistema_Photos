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
    public class SelectPhotographerQuery : IRequest<PaginatedResponse<IEnumerable<PhotographerDTO>>>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public string? Name { get; set; }
        public string? LastName { get; set; }
        public bool IsDeleted { get; set; }

        public class SelectPhotographerQueryHandler : IRequestHandler<SelectPhotographerQuery, PaginatedResponse<IEnumerable<PhotographerDTO>>>
        {
            private readonly IRepository<Photographer> _repository;
            private readonly IMapper _mapper;

            public SelectPhotographerQueryHandler(IRepository<Photographer> repository, IMapper mapper)
            {
                _repository = repository;
                _mapper = mapper;
            }
            public async Task<PaginatedResponse<IEnumerable<PhotographerDTO>>> Handle(SelectPhotographerQuery request, CancellationToken cancellationToken)
            {
                PhotographerResponseFilter responseFilter = new PhotographerResponseFilter()
                {
                    PageSize = request.PageSize,
                    PageNumber = request.PageNumber,
                    Name = request.Name,
                    LastName = request.LastName,
                    IsDeleted=request.IsDeleted,
                };

                var Photographer = await _repository.ListAsync(new PaginatedPhotographerSpecification (responseFilter));
                var PhotographerDto = _mapper.Map<IEnumerable<PhotographerDTO>>(Photographer);
                return new PaginatedResponse<IEnumerable<PhotographerDTO>>(PhotographerDto, request.PageNumber, request.PageSize);
            }
        }
    }
}
