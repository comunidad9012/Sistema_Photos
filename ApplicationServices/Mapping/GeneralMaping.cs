using ApplicationServices.DTOs.Users;
using ApplicationsServices.DTOs.Users;
using ApplicationsServices.Features.Commands.CreateCommands;
using AutoMapper;
using DomainClass.Entity;

namespace ApplicationsServices.Mapping
{
    public class GeneralMaping : Profile
    {
        public GeneralMaping()
        {
            CreateMap<UserSystem, AddUserDto>();
            CreateMap<CreateUserCommand, UserSystem>();

            CreateMap<Client, ClientDTO>();
            CreateMap<CreateClientCommand, Client>();

            CreateMap<Photographer, PhotographerDTO>();
            CreateMap<CreatePhotographerCommand, Photographer>();

            CreateMap<Events, EventsDTO>();
            CreateMap<CreateEventsCommand, Events>();

            CreateMap<Photo, PhotoDTO>();
            CreateMap<CreatePhotoCommand, Photo>();


        }
    }
}
