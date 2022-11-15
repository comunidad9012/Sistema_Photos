using MediatR;
using ApplicationsServices.Wrappers;
using ApplicationsServices.Interfaces;
using DomainClass.Entity;
using AutoMapper;
using DomainClass.Common;
using Ardalis.Specification;

namespace ApplicationsServices.Features.Commands.CreateCommands
{
    public class CreatePhotoCommand : IRequest<Response<long>>
    {
        public string? Name { get; set; }

        public string? Type { get; set; }

        public string? Size { get; set; }

        public long Idclient { get; set; }

       

    }
    public class CreatePhotoCommandHandler : IRequestHandler<CreatePhotoCommand, Response<long>>
    {
        private readonly IRepository<Photo> _repository;
        private readonly IMapper _mapper;

        public CreatePhotoCommandHandler(IRepository<Photo> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Response<long>> Handle(CreatePhotoCommand request, CancellationToken cancellationToken)
        {
           
            var newRegister = _mapper.Map<Photo>(request);
            var data = await _repository.AddAsync(newRegister);

            return new Response<long>(data.Id);
        }
    }
}
