using ApplicationsServices.Interfaces;
using Ardalis.Specification.EntityFrameworkCore;
using Persistence.Contexts;

namespace Persistence.Repository
{
    internal class RepositoryCustom<T> : RepositoryBase<T>, IRepository<T> where T : class
    {
        private readonly PhotographyAppContext _context;

        public RepositoryCustom(PhotographyAppContext context) : base(context)
        {
            _context = context;
        }
    }
}
