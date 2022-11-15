using ApplicationsServices.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Persistence.Contexts;
using Persistence.Repository;

namespace Persistence
{
    public static class ServiceExtensions
    {
        public static void AddPersistenceInfraestructure(this IServiceCollection services, IConfiguration configuration)
        {
          
            services.AddDbContext<PhotographyAppContext>(options => options.UseSqlServer(configuration.GetConnectionString("MsSqlServer"), c => c.MigrationsAssembly(typeof(PhotographyAppContext).Assembly.FullName)));

            #region Repositories
            services.AddTransient(typeof(IRepository<>), typeof(RepositoryCustom<>));
            #endregion
        }
    }
}