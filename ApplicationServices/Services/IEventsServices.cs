using DomainClass.Entity;

namespace ApplicationServices.Services
{
    public interface IEventsServices
    {
        // esto se encarga de instertar un usuario en la base de datos
        Task<int> Register(Events events);

    }
}
