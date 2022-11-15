using DomainClass.Entity;

namespace ApplicationServices.Services
{
    public interface IUserServices
    {
        // esto se encarga de instertar un usuario en la base de datos
        Task<int> Register(UserSystem user);

    }
}
