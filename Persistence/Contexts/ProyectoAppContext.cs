using DomainClass.Common;
using DomainClass.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;

namespace Persistence.Contexts
{
    public class PhotographyAppContext : DbContext
    {
        public PhotographyAppContext(DbContextOptions<PhotographyAppContext> options) : base(options)
        {
        }
        DbSet<UserSystem> UsersSystem { set; get; }
        DbSet<Client> Clients { set; get; }
        DbSet<Photo> Photos { set; get; }

        DbSet<Photographer> Photographers { set; get; }
        DbSet<Events> Events { set; get; }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            foreach (var entry in ChangeTracker.Entries<BaseEntityClass>())
            {
                switch (entry.State)
                {
                    case EntityState.Modified:
                        //entry.Entity.LastModifiedBy = 0;
                        entry.Entity.LastModifiedDate = DateTime.UtcNow;
                        break;
                    case EntityState.Added:
                        //entry.Entity.CreateBy = 0;
                        entry.Entity.CreationDate = DateTime.UtcNow;
                        entry.Entity.LastModifiedDate = DateTime.UtcNow;
                        entry.Entity.IsDeleted = false;
                        break;
                }
            }
            return base.SaveChangesAsync(cancellationToken);
        }
    }
}
    