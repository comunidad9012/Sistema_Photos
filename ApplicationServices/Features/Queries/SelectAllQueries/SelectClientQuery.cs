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
    public class SelectClientQuery : IRequest<PaginatedResponse<IEnumerable<ClientDTO>>>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public string? NameClient { get; set; }
        public string? NameLastClient { get; set; }
        public bool IsDeleted { get; set; }

        public class SelectClientQueryHandler : IRequestHandler<SelectClientQuery, PaginatedResponse<IEnumerable<ClientDTO>>>
        {
            private readonly IRepository<Client> _repository;
            private readonly IMapper _mapper;

            public SelectClientQueryHandler(IRepository<Client> repository, IMapper mapper)
            {
                _repository = repository;
                _mapper = mapper;
            }
            public async Task<PaginatedResponse<IEnumerable<ClientDTO>>> Handle(SelectClientQuery request, CancellationToken cancellationToken)
            {
                ClientResponseFilter responseFilter = new ClientResponseFilter()
                {
                    PageSize = request.PageSize,
                    PageNumber = request.PageNumber,
                    NameClient = request.NameClient,
                    NameLastClient = request.NameLastClient,
                    IsDeleted= request.IsDeleted,
                };

                var Clients = await _repository.ListAsync(new PaginatedClientSpecification(responseFilter));
                var ClientsDto = _mapper.Map<IEnumerable<ClientDTO>>(Clients);
                return new PaginatedResponse<IEnumerable<ClientDTO>>(ClientsDto, request.PageNumber, request.PageSize);
            }
        }
    }
}
