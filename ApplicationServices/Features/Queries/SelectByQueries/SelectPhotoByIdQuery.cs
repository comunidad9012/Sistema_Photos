using ApplicationServices.DTOs.Users;
using ApplicationsServices.DTOs.Users;
using ApplicationsServices.Interfaces;
using ApplicationsServices.Wrappers;
using AutoMapper;
using DomainClass.Entity;
using MediatR;

namespace ApplicationsServices.Features.Queries.SelectByQueries
{
    public class SelectPhotoByIdQuery : IRequest<Response<PhotoDTO>>
    {
        public long Id { get; set; }
    }
    public class SelectPhotoByIdQueryHandler : IRequestHandler<SelectPhotoByIdQuery, Response<PhotoDTO>>
    {
        private readonly IRepository<Photo> _repository;
        private readonly IMapper _mapper;

        public SelectPhotoByIdQueryHandler(IRepository<Photo> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public Task<Response<PhotoDTO>> Handle(SelectPhotoByIdQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        async Task<Response<PhotoDTO>> IRequestHandler<SelectPhotoByIdQuery, Response<PhotoDTO>>.Handle(SelectPhotoByIdQuery request, CancellationToken cancellationToken)
        {
            var user = await _repository.GetByIdAsync(request.Id);
            if (user == null)
            {
                throw new KeyNotFoundException($"El registro solicitado con Id {request.Id} no existe en la base de datos");
            }
            else
            {
                var dto = _mapper.Map<PhotoDTO>(user);
                return new Response<PhotoDTO>(dto);

            }
        }
    }

}
