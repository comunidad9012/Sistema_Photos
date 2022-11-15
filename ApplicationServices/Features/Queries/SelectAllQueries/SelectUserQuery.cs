using ApplicationServices.Filters;
using ApplicationServices.Specifications;
using ApplicationsServices.DTOs.Users;

using ApplicationsServices.Interfaces;

using ApplicationsServices.Wrappers;
using AutoMapper;
using DomainClass.Entity;
using MediatR;
using System.Runtime.InteropServices;

namespace ApplicationsServices.Features.Queries.SelectAllQueries
{
    public class SelectUserQuery : IRequest<PaginatedResponse<IEnumerable<AddUserDto>>>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public string? Name { get; set; }
        public string? LastName { get; set; }
        public bool IsDeleted { get; set; }

        public class SelectUserQueryHandler : IRequestHandler<SelectUserQuery, PaginatedResponse<IEnumerable<AddUserDto>>>
        {
            private readonly IRepository<UserSystem> _repository;
            private readonly IMapper _mapper;

            public SelectUserQueryHandler(IRepository<UserSystem> repository, IMapper mapper)
            {
                _repository = repository;
                _mapper = mapper;
            }
            public async Task<PaginatedResponse<IEnumerable<AddUserDto>>> Handle(SelectUserQuery request, CancellationToken cancellationToken)
            {
                UserResponseFilter responseFilter = new UserResponseFilter()
                {
                    PageSize = request.PageSize,
                    PageNumber = request.PageNumber,
                    Name = request.Name,
                    LastName = request.LastName,
                    IsDeleted=request.IsDeleted,
                };

                var users = await _repository.ListAsync(new PaginatedUserSpecification(responseFilter));
                var usersDto = _mapper.Map<IEnumerable<AddUserDto>>(users);
                return new PaginatedResponse<IEnumerable<AddUserDto>>(usersDto, request.PageNumber, request.PageSize);
            }
        }
    }
}
