using MediatR;
using ApplicationsServices.Wrappers;
using ApplicationsServices.Interfaces;
using DomainClass.Entity;
using AutoMapper;
using DomainClass.Common;
using Ardalis.Specification;

namespace ApplicationsServices.Features.Commands.CreateCommands
{
    public class CreateClientCommand : IRequest<Response<long>>
    {
        public string? NameClient { get; set; }

        public string? NameLastClient { get; set; }

        public string? Mobile { get; set; }

        public string? Email { get; set; }

        public string? Address { get; set; }


    }
    public class CreateclientCommandHandler : IRequestHandler<CreateClientCommand, Response<long>>
    {
        private readonly IRepository<Client> _repository;
        private readonly IMapper _mapper;

        public CreateclientCommandHandler(IRepository<Client> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Response<long>> Handle(CreateClientCommand request, CancellationToken cancellationToken)
        {
           
            var newRegister = _mapper.Map<Client>(request);
            var data = await _repository.AddAsync(newRegister);

            return new Response<long>(data.Id);
        }
    }
}
