using MediatR;
using ApplicationsServices.Wrappers;
using ApplicationsServices.Interfaces;
using DomainClass.Entity;
using AutoMapper;
using DomainClass.Common;
using Ardalis.Specification;

namespace ApplicationsServices.Features.Commands.CreateCommands
{
    public class CreateUserCommand : IRequest<Response<long>>
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string? Mobile { get; set; }
        public long UserRol { get; set; }

    }
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, Response<long>>
    {
        private readonly IRepository<UserSystem> _repository;
        private readonly IMapper _mapper;

        public CreateUserCommandHandler(IRepository<UserSystem> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Response<long>> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
           
            var newRegister = _mapper.Map<UserSystem>(request);
            var data = await _repository.AddAsync(newRegister);

            return new Response<long>(data.Id);
        }
    }
}
