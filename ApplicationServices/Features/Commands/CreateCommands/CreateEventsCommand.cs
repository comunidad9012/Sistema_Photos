using MediatR;
using ApplicationsServices.Wrappers;
using ApplicationsServices.Interfaces;
using DomainClass.Entity;
using AutoMapper;
using DomainClass.Common;
using Ardalis.Specification;

namespace ApplicationsServices.Features.Commands.CreateCommands
{
    public class CreateEventsCommand : IRequest<Response<long>>
    {

        public string? Type { get; set; }

        public string? Service { get; set; }

        public DateTime? date { get; set; }

    }
    public class CreateEventsCommandHandler : IRequestHandler<CreateEventsCommand, Response<long>>
    {
        private readonly IRepository<Events> _repository;
        private readonly IMapper _mapper;

        public CreateEventsCommandHandler(IRepository<Events> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Response<long>> Handle(CreateEventsCommand request, CancellationToken cancellationToken)
        {
           
            var newRegister = _mapper.Map<Events>(request);
            var data = await _repository.AddAsync(newRegister);

            return new Response<long>(data.Id);
        }
    }
}
