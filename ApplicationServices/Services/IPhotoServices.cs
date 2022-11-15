using DomainClass.Entity;

namespace ApplicationServices.Services
{
    public interface IPhotoServices
    {
        // esto se encarga de instertar un usuario en la base de datos
        Task<int> Register(Photo photo);

    }
}
