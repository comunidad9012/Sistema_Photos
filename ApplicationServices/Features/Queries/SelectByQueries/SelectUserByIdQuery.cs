using ApplicationsServices.DTOs.Users;
using ApplicationsServices.Interfaces;
using ApplicationsServices.Wrappers;
using AutoMapper;
using DomainClass.Entity;
using MediatR;

namespace ApplicationsServices.Features.Queries.SelectByQueries
{
    public class SelectUserByIdQuery : IRequest<Response<AddUserDto>>
    {
        public long Id { get; set; }
    }
    public class SelectUserByIdQueryHandler : IRequestHandler<SelectUserByIdQuery, Response<AddUserDto>>
    {
        private readonly IRepository<UserSystem> _repository;
        private readonly IMapper _mapper;

        public SelectUserByIdQueryHandler(IRepository<UserSystem> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        async Task<Response<AddUserDto>> IRequestHandler<SelectUserByIdQuery, Response<AddUserDto>>.Handle(SelectUserByIdQuery request, CancellationToken cancellationToken)
        {
            var user = await _repository.GetByIdAsync(request.Id);
            if (user == null)
            {
                throw new KeyNotFoundException($"El registro solicitado con Id {request.Id} no existe en la base de datos");
            }
            else
            {
                var dto = _mapper.Map<AddUserDto>(user);
                return new Response<AddUserDto>(dto);

            }
        }
    }

}
