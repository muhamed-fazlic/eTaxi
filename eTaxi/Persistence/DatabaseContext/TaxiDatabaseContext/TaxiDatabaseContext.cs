using eTaxi.Domain;
using eTaxi.Domain.Common;
using Microsoft.EntityFrameworkCore;

namespace Persistence.DatabaseContext.TaxiDatabaseContext
{
    public class TaxiDatabaseContext : DbContext
    {
        public TaxiDatabaseContext(DbContextOptions<TaxiDatabaseContext> options) : base(options)
        {

        }

        public DbSet<User> User { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
     
            Seed.OnModelCreating(modelBuilder);
        }
        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            //Added automatically time updater (DateCreated, DateModified)
            foreach (var item in base.ChangeTracker.Entries<BaseEntity>()
                .Where(x => x.State == EntityState.Added || x.State == EntityState.Modified))
            {
                item.Entity.DateModified = DateTime.Now;

                if (item.State == EntityState.Added)
                    item.Entity.DateCreated = DateTime.Now;
            }

            return base.SaveChangesAsync(cancellationToken);
        }
    }
}
