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
    public class SelectPhotoQuery : IRequest<PaginatedResponse<IEnumerable<PhotoDTO>>>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public string? Name { get; set; }
        public string? Type { get; set; }
        public bool IsDeleted { get; set; }

        public class SelectPhotoQueryHandler : IRequestHandler<SelectPhotoQuery, PaginatedResponse<IEnumerable<PhotoDTO>>>
        {
            private readonly IRepository<Photo> _repository;
            private readonly IMapper _mapper;

            public SelectPhotoQueryHandler(IRepository<Photo> repository, IMapper mapper)
            {
                _repository = repository;
                _mapper = mapper;
            }
            public async Task<PaginatedResponse<IEnumerable<PhotoDTO>>> Handle(SelectPhotoQuery request, CancellationToken cancellationToken)
            {
                PhotoResponseFilter responseFilter = new PhotoResponseFilter()
                {
                    PageSize = request.PageSize,
                    PageNumber = request.PageNumber,
                    Name = request.Name,
                    Type = request.Type,
                    IsDeleted = request.IsDeleted,
                };

                var Photo = await _repository.ListAsync(new PaginatedPhotoSpecification(responseFilter));
                var PhotoDto = _mapper.Map<IEnumerable<PhotoDTO>>(Photo);
                return new PaginatedResponse<IEnumerable<PhotoDTO>>(PhotoDto, request.PageNumber, request.PageSize);
            }
        }
    }
}
